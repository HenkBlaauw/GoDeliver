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
            if (foodEntities == null)
            {
                return StatusCode(500, "The food database is empty, sorry");
            }
            return Ok(foodEntities);

        }



        [HttpGet("{foodId}")]
        public IActionResult GetFood(int foodId)
        {
            var foodEntities = _foodInfoRepository.GetFood(foodId);
            if (foodEntities == null)
            {
                return StatusCode(500, "The food you requested is not available");
            }

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
            if (food.Name == null || food.Name.Length > 10)
            {
                return StatusCode(500, "Sorry, the name is too long, or you forgot to enter it");
            }


            food.Description = foodInfo.Description;
            if (food.Description == null || food.Name.Length > 100)
            {
                return StatusCode(500, "Sorry, the description is too long, or you forgot to enter it");
            }
            
            food.RestaurantId = foodInfo.RestaurantId;
           

            food.Cost = foodInfo.Cost;
            if (food.Cost == null || food.Cost.Equals(0))
            {
                return StatusCode(500, "Sorry, the cost cannot be 0");
            }


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


        [HttpPatch("{foodId}")]
        public IActionResult PartiallyUpdateFood([FromRoute]int foodId, 
            [FromBody]FoodForCreationDto patchFood)
        {
            if (patchFood == null)
            {
                return BadRequest();
            }

            var FoodEntity = _foodInfoRepository.GetFood(foodId);

            if (FoodEntity == null)
            {
                return StatusCode(500, "The food you requested is not available");
            }

            if (patchFood.Name != null)
            {
                if (patchFood.Name.Length > 50)
                {
                    return StatusCode(500, "The name is too long");
                }
                FoodEntity.Name = patchFood.Name;
            }

            if (patchFood.Description != null)
            {
                FoodEntity.Description = patchFood.Description;
            }

            if (patchFood.Cost != null)
            {
                FoodEntity.Cost = patchFood.Cost;
            }

            if (patchFood.CreatedAtDate != null)
            {
                FoodEntity.CreatedAtDate = patchFood.CreatedAtDate;
            }

            if (patchFood.RestaurantId != null)
            {
                FoodEntity.RestaurantId = patchFood.RestaurantId;
            }

            patchFood.UpdatedAtDate = DateTime.Now;

            if (!_foodInfoRepository.Save())
            {
                return StatusCode(500, "Something happened while handling your request");
            }

            return Ok(FoodEntity);



        }



    }
}
