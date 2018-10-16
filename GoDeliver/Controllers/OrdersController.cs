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
            order.Name = orderInfo.Name;
            if (order.Name == null || order.Name.Length < 50)
            {
                return StatusCode(500, "Please ensure the name you entered is correct");
            }

            order.Description = orderInfo.Description;
            if (order.Description == null || order.Description.Length < 50)
            {
                return StatusCode(500, "The description is void or too long");
            }

            order.TimeAtRestaurant = orderInfo.TimeAtRestaurant;
            order.TimePickedUp = orderInfo.TimePickedUp;

            if (order.TimePickedUp < order.TimeAtRestaurant)
            {
                return StatusCode(418, "The time picked up can't be less than the time at restaurant");
            }


            order.DeliveryTime = orderInfo.DeliveryTime;


            order.State = orderInfo.State;





            order.Cost = orderInfo.Cost;

            if (order.Cost < 0)
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

            if (orderToEdit.Name != orderEdit.Name)
            {
                if ( orderEdit.Name.Length > 50 || orderEdit.Name == null)
                {
                    return StatusCode(500, "Name is too long or it has no value!");
                }
                orderToEdit.Name = orderEdit.Name;
            }

            if (orderToEdit.Description != orderEdit.Description)
            {
                if (orderEdit.Description.Length > 100 || orderEdit.Description == null)
                {
                    return StatusCode(500, "Description is too long, or it has no value");
                }
                orderToEdit.Description = orderEdit.Description;
            }

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

            if (orderToEdit.State != orderEdit.State)
            {
                if (orderEdit.State == null)
                {
                    return StatusCode(500, "The state you entered is null and void");
                }
                orderToEdit.State = orderEdit.State;
            }

            if (orderToEdit.Cost != orderEdit.Cost)
            {
                if(orderEdit.Cost < 0 )
                {
                    return StatusCode(500, "The cost can't be less than 0");
                }
                orderToEdit.Cost = orderEdit.Cost;
            }

            if (orderToEdit.TimeAtRestaurant != orderEdit.TimeAtRestaurant)
            {
                if (orderEdit.TimeAtRestaurant == null)
                {
                    return StatusCode(500, "The time is invalid");
                }
                orderToEdit.TimeAtRestaurant = orderEdit.TimeAtRestaurant;
            }

            if (orderToEdit.TimePickedUp != orderEdit.TimePickedUp)
            {
                if (orderEdit.TimePickedUp == null)
                {
                    return StatusCode(500, "The time you entered is invalid/null");
                }
                orderToEdit.TimePickedUp = orderEdit.TimePickedUp;
            }

            if (orderToEdit.DeliveryTime != orderEdit.DeliveryTime)
            {
                if (orderEdit.DeliveryTime == null)
                {
                    return StatusCode(500, "The time you entered is null");
                }
                orderToEdit.DeliveryTime = orderEdit.DeliveryTime;
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
        public IActionResult PartiallyUpdateOrder([FromRoute]int orderId, [FromBody]OrderForCreationDto patchOrder)
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

            if (patchOrder.Name != null)
            {
                OrderEntity.Name = patchOrder.Name;
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

            if (patchOrder.Description != null)
            {
                OrderEntity.Description = patchOrder.Description;
            }

            if (patchOrder.TimeAtRestaurant != null)
            {
                OrderEntity.TimeAtRestaurant = patchOrder.TimeAtRestaurant;
            }

            if (patchOrder.TimePickedUp != null)
            {
                OrderEntity.TimePickedUp = patchOrder.TimePickedUp;
            }

            if (patchOrder.CreatedAtDate != null)
            {
                OrderEntity.CreatedAtDate = patchOrder.CreatedAtDate;
            }

            if (patchOrder.Cost != null)
            {
                OrderEntity.Cost = patchOrder.Cost;
            }

            if (patchOrder.State != null)
            {
                OrderEntity.State = patchOrder.State;
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
