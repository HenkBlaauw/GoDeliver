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


        // GET api/customers
        //[Route("customers")]
        //[HttpGet()]
        //public IHttpActionResult GetCustomers()
        //{
        //    GoDeliveryContext context = new GoDeliveryContext();
        //    IQueryable<CustomerDto> customers = from b in context.Customers
        //                                        select new CustomerDto()
        //                                        {
        //                                            CustomerId = b.CustomerId,
        //                                            Name = b.Name
        //                                        };
        //    return Ok(customers);
        //}
       
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

            


      
          //  var food2Return = JsonConvert.SerializeObject(foods).ToString();
            
            return Json(foods);


        }










        //Call when a customer orders food
        [Route("customers/createorder")]
        [HttpPost()]
        public IHttpActionResult CreateOrder([FromBody]Order orderInfo)
        {

            Order order = new Order();

            if (orderInfo == null)
            {
                return BadRequest("Sorry, but the customer's info you entered is empty");
            }

            order.Foods = orderInfo.Foods;
            order.CustomerAddress = orderInfo.CustomerAddress;
            order.RestaurantId = orderInfo.RestaurantId;
            order.TimeAtRestaurant = orderInfo.TimeAtRestaurant;
            order.TotalCost = orderInfo.TotalCost;
            order.State = "Sent";
            order.RestaurantAddress = orderInfo.RestaurantAddress;
            order.TimeAtRestaurant = orderInfo.CreatedAtDate;
            order.UpdatedAtDate = DateTime.UtcNow;
            order.CreatedAtDate = orderInfo.CreatedAtDate;

            _orderRepository.AddOrder(order);

            if (!_orderRepository.Save())
            {
                return BadRequest();
            }

            return Ok("The order has been sent to the restaurant. You will be notified about the order's progression");
        }
    }
}