
using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Models;
using GoDeliverWebApp.Services;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace GoDeliverWebApp.Controllers
{
    
    public class RestaurantController : ApiController
    {

        private InfoRepository _restaurantInfoRepository;
        GoDeliveryContext context = new GoDeliveryContext();
        private InfoRepository _driverInfoRepository;
        private InfoRepository _orderRepository;

        private GoDeliveryContext _context;
        public RestaurantController()
        {

            _context = context;
            _orderRepository = new DataInfoRepository(context);
            _restaurantInfoRepository = new DataInfoRepository(context);

        }



        [Route("api/orders")]
        [HttpGet()]
        public IHttpActionResult GetOrders()
        {
            GoDeliveryContext context = new GoDeliveryContext();
            IQueryable<OrderDto> orders = from b in context.Orders
                                          select new OrderDto()
                                          {
                                              OrderId = b.OrderId,
                                              CustomerId = b.CustomerId,
                                              DriverId = b.DriverId,
                                              RestaurantId = b.RestaurantId,
                                              TimeAtRestaurant = b.TimeAtRestaurant,
                                              State = b.State,
                                              RestaurantAddress = b.RestaurantAddress,
                                              CustomerAddress = b.CustomerAddress,
                                              TotalCost = b.TotalCost,
                                              CreatedAtDate = b.CreatedAtDate,
                                              UpdatedAtDate = DateTime.UtcNow                                             

                                          };


            return Ok(orders);


        }


        [Route("api/orders/{orderid}")]
        [HttpPatch()]
        public IHttpActionResult ConfirmOrder([FromUri] int OrderId)
        {

            GoDeliveryContext context = new GoDeliveryContext();
            var currentOrder = _orderRepository.GetOrder(OrderId);

            if (currentOrder == null)
            {
                return StatusCode(HttpStatusCode.Gone);
            }

            currentOrder.State = "Order confirmed";
            currentOrder.UpdatedAtDate = DateTime.UtcNow;

            _orderRepository.Save();

            return Ok(currentOrder);
        }

        [Route("api/orders/assignDriver")]
        [HttpPatch()]
        public IHttpActionResult AssignDriver([FromUri] int driverId, [FromBody] int OrderId)
        {
            GoDeliveryContext context = new GoDeliveryContext();
            var currentOrder = _orderRepository.GetOrder(OrderId);

            if (currentOrder == null)
            {
                return BadRequest("The order you requested is empty");
            }


            currentOrder.DriverId = driverId;
            _orderRepository.Save();

            return Ok(currentOrder);
        }


        [Route("api/restaurants/makerestaurants")]
        [HttpPost()]
        public IHttpActionResult CreateRestaurant([FromBody]RestaurantInfoDto restaurantInfo)
        {

            var restaurantError = "Please look at the data and make sure it's not empty, incorrect, or has values that are the same!";
            Restaurant restaurant = new Restaurant();

            if (restaurantInfo == null)
            {
                return BadRequest(restaurantError);
            }


            restaurant.Name = restaurantInfo.Name;
            if (restaurantInfo.Name == null || restaurantInfo.Name.Length > 50)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }


            restaurant.Adress = restaurantInfo.Adress;
            if (restaurantInfo.Adress == null || restaurantInfo.Adress.Length > 50)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            restaurant.Foods = restaurantInfo.Foods;

            restaurant.CreatedAtDate = DateTime.Now;
            restaurant.UpdatedAtDate = DateTime.Now;
            
            _restaurantInfoRepository.AddRestaurant(restaurant);

            if (!_restaurantInfoRepository.Save())
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return Ok(restaurant);
        }
    }
}
