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
    public class OrderedFoodsController  : Controller
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
            return Ok(orderedEntities);
        }

        [HttpGet("{orderedfoodId}")]
        public IActionResult GetOrderedFood(int orderedFoodId)
        {
            var ordered = _orderedFoodRepository.GetOrderedFood(orderedFoodId);
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





    }
}
