using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Models;
using GoDeliverWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;



namespace GoDeliverWebApp.Controllers
{
    public class DriverController : ApiController
    {
        GoDeliveryContext context = new GoDeliveryContext();
        private InfoRepository _orderRepository;
       
        
        //Get order from restaurant
        [Route("api/drivers/orders/{driverid}")]
        [HttpGet()]
        public IHttpActionResult GetOrder([FromUri] int driverId)
        {
           
            GoDeliveryContext context = new GoDeliveryContext();
            _orderRepository = new DataInfoRepository(context);
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
            if (orders == null)
            {
                return BadRequest("There are no orders to complete!");
            }

            List<OrderDto> driverOrder = orders.Where(x => x.DriverId == driverId).ToList();
            if(driverOrder == null)
            {
                return BadRequest("You have no orders to complete");
            }

            var assignedOrder = driverOrder.LastOrDefault();
            
            return Json("Be at " + assignedOrder.RestaurantAddress + "at " + assignedOrder.TimeAtRestaurant.ToString());
            
        }
        
        //Driver accepted order
        [Route("api/orders/accept/{orderId}")]
        [HttpPatch()]
        public IHttpActionResult AcceptOrder([FromUri]int orderId)
        {
            GoDeliveryContext context = new GoDeliveryContext();
            _orderRepository = new DataInfoRepository(context);
            var order = _orderRepository.GetOrder(orderId);
             
            if (order == null)
            {
                return BadRequest();
            }

            order.State = "Out for delivery";

            _orderRepository.Save();

            return Json("Be at "+ order.RestaurantAddress + " at " + order.TimeAtRestaurant+ ", and deliver the food to " + order.CustomerAddress);
        }

        //Driver denies order
        [Route("api/orders/deny/{orderId}")]
        [HttpPatch()]
        public IHttpActionResult DenyOrder([FromUri]int orderId)
        {
            GoDeliveryContext context = new GoDeliveryContext();
            _orderRepository = new DataInfoRepository(context);

            Order order = _orderRepository.GetOrder(orderId);

            if (order == null)
            {
                return BadRequest();
            }

            order.State = "Waiting on Driver";
            _orderRepository.Save();

            return Json("The restaurant will be notified of your choice..");
        }

        //Change state to delivered
        [Route("api/order/delivered/{orderid}")]
        [HttpPatch()]
        public IHttpActionResult DeliveredOrder([FromUri] int orderId)
        {
            GoDeliveryContext context = new GoDeliveryContext();
            _orderRepository = new DataInfoRepository(context);
            Order order = _orderRepository.GetOrder(orderId);

            if (order == null)
            {
                return BadRequest();
            }

            order.State = "Delivered";
            _orderRepository.Save();

            return Json("Order delivered");
        }
    }
}
