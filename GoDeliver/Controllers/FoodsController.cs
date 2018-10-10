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

    [Route("api/foods")]
    public class FoodsController : Controller
    {

        private InfoRepository _foodInfoRepository;
        public FoodsController(InfoRepository foodInfoRepository)
        {
            _foodInfoRepository = foodInfoRepository;
        }




        [HttpGet()]
        public IActionResult GetFoods()
        {
            var foodEntities = _foodInfoRepository.GetFoods();
            return Ok(foodEntities);

        }



        [HttpGet("{foodId}")]
        public IActionResult GetFood(int foodId)
        {
            var foodEntities = _foodInfoRepository.GetFood(foodId);
            return Ok(foodEntities);
        }


        [HttpPost()]
        public IActionResult CreateFood([FromBody] FoodForCreationDto foodInfo)
        {
            var foodError = "Please look at your data and make sure it's not empty, incorrect, or has values that are the same!";

            Food food = new Food();


            if(foodInfo == null)
            {
                return BadRequest(foodError);
            }

            food.Name = foodInfo.Name;
            food.Description = foodInfo.Description;
            food.RestaurantId = foodInfo.RestaurantId;
            food.Cost = foodInfo.Cost;
            food.CreatedAtDate = DateTime.Now;
            food.UpdatedAtDate = food.CreatedAtDate;


            _foodInfoRepository.AddFood(food);

            if (!_foodInfoRepository.Save())
            {
                return StatusCode(500, "Something went wrong during the request...");
            }


            return Ok(food);


        }

        [HttpDelete("{foodId}")]
        public IActionResult DeleteFood([FromRoute] int foodId)
        {
            var foodEntity = _foodInfoRepository.GetFood(foodId);

            if(foodEntity == null)
            {
                return NotFound();
            }

            _foodInfoRepository.DeleteFood(_foodInfoRepository.GetFood(foodId));

            if (!_foodInfoRepository.Save())
            {
                return StatusCode(500, "Something went wrong saving to the database");
            }

            return NoContent();

        }

        [HttpPut("{foodId}")]
        public IActionResult UpdateFood([FromRoute]int foodId, [FromBody] FoodForCreationDto foodEdit)
        {
            var foodToEdit = _foodInfoRepository.GetFood(foodId);

            Food food = new Food();


            if (foodToEdit.Name != foodEdit.Name)
            {
                foodToEdit.Name = foodEdit.Name;
            }

            if (foodToEdit.Description != foodEdit.Description)
            {
                foodToEdit.Description = foodToEdit.Description;
            }

            if (foodToEdit.Cost != foodEdit.Cost)
            {
                foodToEdit.Cost = foodEdit.Cost;
            }

            if (foodToEdit.RestaurantId != foodEdit.RestaurantId)
            {
                foodToEdit.RestaurantId = foodEdit.RestaurantId;
            }

            if (foodToEdit.CreatedAtDate != foodEdit.CreatedAtDate)
            {
                foodToEdit.CreatedAtDate = foodEdit.CreatedAtDate;
            }

            foodToEdit.UpdatedAtDate = DateTime.Now;

            if (!_foodInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(foodToEdit);
        }






    }
}
