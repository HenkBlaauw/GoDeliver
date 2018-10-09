using GoDeliver.Entities;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Controllers
{

    [Route("api/orders")]
    public class OrdersController : Controller
    {
        private InfoRepository _orderInfoRepository;

        public OrdersController(InfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }


        [HttpGet()]
        public IActionResult GetOrders()
        {
            var orderEntities = _orderInfoRepository.GetOrders();

            return Ok(orderEntities);
        }


        [HttpGet("{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            var order = _orderInfoRepository.GetOrder(orderId);

            return Ok(order);
        }

        [HttpPost()]
        public IActionResult CreateOrder([FromBody]OrderForCreationDto orderInfo)
        {
            var orderError = "Please ensure your data is correct!";
            Order order = new Order();
            
            if (orderInfo == null)
            {
                return BadRequest(orderError);
            }


            order.CustomerId = orderInfo.CustomerId;
            order.DriverId = orderInfo.DriverId;
            order.RestaurantId = orderInfo.RestaurantId;
            order.Name = orderInfo.Name;
            order.Description = orderInfo.Description;
            order.TimeAtRestaurant = orderInfo.TimeAtRestaurant;
            order.TimePickedUp = orderInfo.TimePickedUp;
            order.DeliveryTime = orderInfo.DeliveryTime;
            order.State = orderInfo.State;
            order.Cost = orderInfo.Cost;
            order.CreatedAtDate = DateTime.Now;
            order.UpdatedAtDate = order.CreatedAtDate;


            _orderInfoRepository.AddOrder(order);

            if (!_orderInfoRepository.Save())
            {
                return StatusCode(500, "Something went wrong...");
            }


            return Ok(order);

        }




        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder([FromRoute]int orderId)
        {

            var orderEntity = _orderInfoRepository.GetOrder(orderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderInfoRepository.DeleteOrder(_orderInfoRepository.GetOrder(orderId));

            if (!_orderInfoRepository.Save())
            {
                return StatusCode(500, "Something went wrong, sorry!");
            }

            return NoContent();
        }



    }
}
