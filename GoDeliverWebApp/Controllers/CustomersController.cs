using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Models;
using GoDeliverWebApp.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Http;
namespace GoDeliverWebApp.Controllers
{
    

    public class CustomersController : ApiController
    {
        private InfoRepository _customerInfoRepository;
        GoDeliveryContext context = new GoDeliveryContext();
        private InfoRepository _orderRepository;
        private InfoRepository _restaurantInfoRepository;
        
        public CustomersController(InfoRepository customerInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
        }
        private GoDeliveryContext _context;
        public CustomersController()
        {
            _context = context;
            _orderRepository = new DataInfoRepository(context);
            _customerInfoRepository = new DataInfoRepository(context);
            _restaurantInfoRepository = new DataInfoRepository(context);
        }

        [Route("customers")]
        [HttpPost()]
        public IHttpActionResult CreateCustomer([FromBody]CustomerForCreationDto CustomerInfo)
        {
            Customer customer = new Customer();
            if (CustomerInfo == null)
            {
                return BadRequest();
            }

            if (CustomerInfo.Name == null || CustomerInfo.Adress == null)
            {
                throw new Exception("Sorry, the data you entered is null");
            }

            customer.Name = CustomerInfo.Name;
            if (CustomerInfo.Name.Length > 255)
            {
                return BadRequest("The name is too long!");
            }
            customer.Adress = CustomerInfo.Adress;
            if (CustomerInfo.Adress.Length > 255)
            {
                return BadRequest("The address is too long!");
            }

            customer.CreatedAtDate = DateTime.Now;
            customer.UpdatedAtDate = customer.CreatedAtDate;

            _customerInfoRepository.AddCustomer(customer);
            if (!_customerInfoRepository.Save())
            {
                return null;
            }

            return Ok(customer);
        }

        //Gets a list of restaurants
        [Route("api/restaurants")]
        [HttpGet()]
        public IHttpActionResult GetRestaurants()
        {
            GoDeliveryContext context = new GoDeliveryContext();
            IQueryable<RestaurantDto> restaurants = from b in context.Restaurants
                                                select new RestaurantDto()
                                                {
                                                    Name = b.Name,
                                                    Adress = b.Adress                                                    
                                                };

            return Ok(restaurants.OrderBy( t=> t.Name));
        }

        [Route("api/restaurants/{restaurantId}/foods")]
        [HttpGet()]
        public IHttpActionResult GetFoodForRestaurant([FromUri] int restaurantId)
        {
            Restaurant restaurant = _restaurantInfoRepository.GetRestaurant(restaurantId);
            GoDeliveryContext context = new GoDeliveryContext();
            List<Food> foods = _restaurantInfoRepository.GetForRestaurant(restaurantId);
            
            return Json(foods);
        }
       
        //Call when a customer orders food
        [Route("api/customers/createorder/{customerId}")]
        [HttpPost()]
        public IHttpActionResult CreateOrder([FromUri] int CustomerId, [FromBody]OrderCreationDto orderInfo)
        {
            Order order = new Order();
            order.TotalCost = 0;
            ICollection<Food> food4Order = new List<Food>();
            if (orderInfo == null)
            {
                return BadRequest("Sorry, but the customer's info you entered is empty");
            }

            var foodTest = orderInfo.FoodId;
           foodTest =  foodTest.ToArray();
            
            foreach(int i in foodTest)
            {
                food4Order.Add(_restaurantInfoRepository.GetFood(i));
            }

            order.CustomerId = CustomerId;
            order.Foods = food4Order;
            
            foreach( Food food in  food4Order)
            {
                order.TotalCost = order.TotalCost+  food4Order.Select(a => a.Cost).First();
            }
            
            var value = order.Foods.First();
            var resId = Convert.ToInt32(value.RestaurantId);
            order.State = "Sent";
            var restAddress = _restaurantInfoRepository.GetRestaurant(resId).Adress;
            order.RestaurantAddress = restAddress;
            order.CustomerAddress = _restaurantInfoRepository.GetCustomer(CustomerId).Adress;
            order.UpdatedAtDate = DateTime.UtcNow;
            order.CreatedAtDate = DateTime.UtcNow;
            order.TimeAtRestaurant = order.CreatedAtDate.AddMinutes(21);
            _orderRepository.AddOrder(order);

            if (!_orderRepository.Save())
            {
                return BadRequest();
            }
          
            return Json("The order has been sent to the restaurant. You will be notified about the order's progression");
        }
    }
}