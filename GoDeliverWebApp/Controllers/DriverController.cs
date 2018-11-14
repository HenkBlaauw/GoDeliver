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
                return StatusCode(System.Net.HttpStatusCode.BadRequest);
            }


            IQueryable<Order> whereQuery = context.Orders.Where(x => x.DriverId == driverId);


            return Ok(whereQuery);
            //return whereQuery.ToList();

            //for(int i = 0; i < orders.Rows.Count; i++)
            //{
            //    if (driverId == orders.DriverId[i])
            //    {

            //    }
            //}
        }

        //Driver accepted order
        [Route("api/orders/accept/{orderId}")]
        [HttpPatch()]
        public IHttpActionResult AcceptOrder([FromUri]int orderId)
        {
            Order order = _orderRepository.GetOrder(orderId);
             
            if (order == null)
            {
                return BadRequest();
            }

            order.State = "Out for delivery";

            _orderRepository.Save();

            return Ok("Be at "+ order.RestaurantAddress + " at " + order.TimeAtRestaurant+ ", and deliver the food to " + order.CustomerAddress);
        }
        
        //Change state to delivered
        [Route("api/order/delivered/{orderid}")]
        [HttpPatch()]
        public IHttpActionResult DeliveredOrder([FromUri] int orderId)
        {
            Order order = _orderRepository.GetOrder(orderId);

            if (order == null)
            {
                return BadRequest();
            }

            order.State = "Delivered";

            _orderRepository.Save();

            return Ok("Order delivered");

        }
    }
}
