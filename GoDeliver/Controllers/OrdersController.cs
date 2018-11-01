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
            if (orderEntities == null)
            {
                return StatusCode(500, "The order table is empty");
            }


            return Ok(orderEntities);
        }


        [HttpGet("{orderId}")]
        public IActionResult GetOrder(int orderId)
        {
            var order = _orderInfoRepository.GetOrder(orderId);
            if (order == null)
            {
                return StatusCode(500, "The order is empty!");
            }


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
            

           




            order.TotalCost = orderInfo.Cost;

            if (order.TotalCost < 0)
            {
                return StatusCode(500, "Cost can't be less than 0!");
            }
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

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder([FromRoute] int orderId, [FromBody] OrderForCreationDto orderEdit)
        {

            var orderToEdit = _orderInfoRepository.GetOrder(orderId);

            
            

            if (orderToEdit.CustomerId != orderEdit.CustomerId)
            {
                orderToEdit.CustomerId = orderEdit.CustomerId;
            }

            if (orderToEdit.DriverId != orderEdit.DriverId)
            {
                orderToEdit.DriverId = orderEdit.DriverId;
            }

            if (orderToEdit.RestaurantId != orderEdit.RestaurantId)
            {
                orderToEdit.RestaurantId = orderEdit.RestaurantId;
            }


            if (orderToEdit.TotalCost != orderEdit.Cost)
            {
                if(orderEdit.Cost < 0 )
                {
                    return StatusCode(500, "The cost can't be less than 0");
                }
                orderToEdit.TotalCost = orderEdit.Cost;
            }

            if (orderToEdit.TimeAtRestaurant != orderEdit.TimeAtRestaurant)
            {
                if (orderEdit.TimeAtRestaurant == null)
                {
                    return StatusCode(500, "The time is invalid");
                }
                orderToEdit.TimeAtRestaurant = orderEdit.TimeAtRestaurant;
            }
            


            


            if (orderToEdit.CreatedAtDate != orderEdit.CreatedAtDate)
            {
                if (orderEdit.CreatedAtDate == null)
                {
                    return StatusCode(500, "The date is null");
                }
                orderToEdit.CreatedAtDate = orderEdit.CreatedAtDate;
            }



            orderToEdit.UpdatedAtDate = DateTime.Now;



            if (!_orderInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }


            return Ok(orderToEdit);

        }

        [HttpPatch("{orderId}")]
        public IActionResult PartiallyUpdateOrder([FromRoute]int orderId,
            [FromBody]OrderForCreationDto patchOrder)
        {
            if (patchOrder == null)
            {
                return BadRequest();
            }

            var OrderEntity = _orderInfoRepository.GetOrder(orderId);

            if (OrderEntity == null)
            {
                return StatusCode(500, "The order you requested is not in the database");
            }

            

            if (patchOrder.CustomerId != null)
            {
                OrderEntity.CustomerId = patchOrder.CustomerId;
            }

            if (patchOrder.DriverId != null)
            {
                OrderEntity.DriverId = patchOrder.DriverId;
            }

            if (patchOrder.RestaurantId != null)
            {
                OrderEntity.RestaurantId = patchOrder.RestaurantId;
            }

            


            if (patchOrder.TimeAtRestaurant != null)
            {
                OrderEntity.TimeAtRestaurant = patchOrder.TimeAtRestaurant;
            }

            

            if (patchOrder.CreatedAtDate != null)
            {
                OrderEntity.CreatedAtDate = patchOrder.CreatedAtDate;
            }

            if (patchOrder.Cost != null)
            {
                OrderEntity.TotalCost = patchOrder.Cost;
            }


           


            OrderEntity.UpdatedAtDate = DateTime.Now;

            if (!_orderInfoRepository.Save())
            {
                return StatusCode(500, "Something happened while handling your request");
            }

            return Ok(OrderEntity);



        }



    }
}
