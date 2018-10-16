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
    [Route("api/orderedfoods")]
    public class OrderedFoodsController : Controller
    {
        private InfoRepository _orderedFoodRepository;
        public OrderedFoodsController(InfoRepository orderedFoodRepository)
        {
            _orderedFoodRepository = orderedFoodRepository;
        }

        [HttpGet()]
        public IActionResult GetOrderedFoods()
        {
            var orderedEntities = _orderedFoodRepository.GetOrderedFoods();
            if (orderedEntities == null)
            {
                return StatusCode(500, "The data you requested does not exist");
            }
            return Ok(orderedEntities);
        }

        [HttpGet("{orderedfoodId}")]
        public IActionResult GetOrderedFood(int orderedFoodId)
        {
            var ordered = _orderedFoodRepository.GetOrderedFood(orderedFoodId);
            if (ordered == null)
            {
                return StatusCode(500, "The order you requested is not valid");
            }
            return Ok(ordered);
        }

        [HttpPost()]
        public IActionResult CreateOrderedFood([FromBody]OrderedFoodForCreationDto orderedFoodForCreationDto)
        {
            var orderError = "Please ensure your entered data is correct";

            OrderedFood orderedFood = new OrderedFood();

            if (orderedFoodForCreationDto == null)
            {
                return BadRequest(orderError);
            }

            orderedFood.FoodId = orderedFoodForCreationDto.FoodId;
            orderedFood.OrderId = orderedFoodForCreationDto.OrderId;
            orderedFood.CreatedAtDate = DateTime.Now;

            if (orderedFood.CreatedAtDate == null)
            {
                return StatusCode(500, "The date is invalid");
            }
            orderedFood.UpdatedAtDate = orderedFood.CreatedAtDate;

            _orderedFoodRepository.AddOrderedFood(orderedFood);

            if (!_orderedFoodRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(orderedFood);
        }


        [HttpDelete("{orderedfoodid}")]
        public IActionResult DeleteOrderedFood([FromRoute]int orderedFoodId)
        {
            var orderedFoodEntity = _orderedFoodRepository.GetOrderedFood(orderedFoodId);

            if (orderedFoodEntity == null)
            {
                return NoContent();
            }

            _orderedFoodRepository.DeleteOrderedFood(_orderedFoodRepository.GetOrderedFood(orderedFoodId));

            if (!_orderedFoodRepository.Save())
            {
                return StatusCode(500, "A thing that wasn't supposed to happen happened");
            }
            return NoContent();
        }

        [HttpPut("{orderedFoodId}")]
        public IActionResult UpdateOrderedFood([FromRoute]int orderedFoodId,
            [FromBody] OrderedFoodForCreationDto orderedFood)
        {
            if (orderedFood == null)
            {
                return BadRequest();
            }

            var OrderedFoodEntity = _orderedFoodRepository.GetOrderedFood(orderedFoodId);

            if (OrderedFoodEntity == null)
            {
                return StatusCode(500, "The ordered food you're trying to find is not in the database");
            }

            if (orderedFood.OrderId != null)
            {
                OrderedFoodEntity.OrderId = orderedFood.OrderId;
            }

            if (orderedFood.CreatedAtDate != null)
            {
                OrderedFoodEntity.CreatedAtDate = orderedFood.CreatedAtDate;
            }

            OrderedFoodEntity.UpdatedAtDate = DateTime.Now;

            if (!_orderedFoodRepository.Save())
            {
                return StatusCode(500, "Something happened while handling your request");
            }

            return Ok(OrderedFoodEntity);
        }

        [HttpPatch("{orderedFoodId}")]
        public IActionResult PartiallyUpdateOrderedFood([FromRoute] int orderedFoodId,[FromBody] OrderedFoodForCreationDto patchOrderedFood)
        {
            if (patchOrderedFood == null)
            {
                return BadRequest();
            }

            var OrderedFoodEntity = _orderedFoodRepository.GetOrderedFood(orderedFoodId);

            if (OrderedFoodEntity == null)
            {
                return StatusCode(500, "The ordered food you requested is not in the database");
            }

            if (patchOrderedFood.OrderId != null)
            {
                OrderedFoodEntity.OrderId = patchOrderedFood.OrderId;
            }

            if (patchOrderedFood.CreatedAtDate != null)
            {
                OrderedFoodEntity.CreatedAtDate = patchOrderedFood.CreatedAtDate;
            }

            OrderedFoodEntity.UpdatedAtDate = DateTime.Now;

            if (!_orderedFoodRepository.Save())
            {
                return StatusCode(500, "Something happened while handling your request");
            }

            return Ok(OrderedFoodEntity);
        }
    }
}
