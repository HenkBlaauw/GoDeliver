using GoDeliver.Entities;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GoDeliver.Controllers
{
    [Route("api/restaurants")]
    public class RestaurantController : Controller
    {

        private InfoRepository _restaurantInfoRepository;

        public RestaurantController(InfoRepository restaurantInfoRepository)
        {
            _restaurantInfoRepository = restaurantInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetRestaurants()
        {
            var restaurantEntities = _restaurantInfoRepository.GetRestaurants();
            if (restaurantEntities == null)
            {
                return StatusCode(500, "There are no restaurants in the array");
            }
            return Ok(restaurantEntities);
        }

        [HttpGet("{restaurantId}")]
        public IActionResult GetRestaurant(int restaurantId)
        {
            var restaurantEntities = _restaurantInfoRepository.GetRestaurant(restaurantId);
            if (restaurantEntities == null)
            {
                return StatusCode(500, "The restaurant you want is not in the database");
            }

            return Ok(restaurantEntities);
        }

        [HttpPost()]
        public IActionResult CreateRestaurant([FromBody]RestaurantForCreationDto restaurantInfo)
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
                return StatusCode(500, "The name is either null or too long");
            }


            restaurant.Adress = restaurantInfo.Adress;
            if (restaurantInfo.Adress == null || restaurantInfo.Adress.Length > 50)
            {
                return StatusCode(500, "The adress is null or too long");
            }

           
            

            restaurant.foods = restaurantInfo.foods;

            restaurant.CreatedAtDate = DateTime.Now;
            restaurant.UpdatedAtDate = DateTime.Now;

           

            _restaurantInfoRepository.AddRestaurant(restaurant);

            if (!_restaurantInfoRepository.Save())
            {
                return StatusCode(500, "SOmething wEnT WrOnG wHilE HanDlIng yOuR ReQUesT.");
            }

            return Ok(restaurant);
        }






        [HttpPut("{restaurantId}")]
        public IActionResult UpdateRestaurant([FromRoute]int restaurantId, [FromBody] RestaurantForCreationDto restaurantInfo)
        {
            if (restaurantInfo == null)
            {
                return BadRequest();
            }

            var restaurantEntity = _restaurantInfoRepository.GetRestaurant(restaurantId);

            if (restaurantEntity == null)
            {
                return NotFound();
            }

            if (restaurantInfo.Name != null)
            {
                restaurantEntity.Name = restaurantInfo.Name;
            }
            if (restaurantEntity.Name.Length > 50)
            {
                return StatusCode(500, "The name is too long!");
            }

            

            if (restaurantInfo.Adress != null)
            {
                restaurantEntity.Adress = restaurantInfo.Adress;
            }
            if (restaurantEntity.Adress == null || restaurantEntity.Adress.Length > 50)
            {
                return StatusCode(500, "The adress is too long or is null");
            }

            if(restaurantInfo.CreatedAtDate != null)
            {
                restaurantEntity.CreatedAtDate = restaurantInfo.CreatedAtDate;
            }

            restaurantEntity.UpdatedAtDate = DateTime.Now;

            return Ok(restaurantEntity);
        }
        [HttpDelete("{restaurantId}")]
        public IActionResult DeleteRestaurant([FromRoute]int restaurantId)
        {
            var restaurant = _restaurantInfoRepository.GetRestaurant(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantInfoRepository.DeleteRestaurant(_restaurantInfoRepository.GetRestaurant(restaurantId));

            if (!_restaurantInfoRepository.Save())
            {
                return StatusCode(500, "Something happened");
            }

            return NoContent();

        }

        //[HttpPut("{restaurantId}")]
        //public IActionResult UpdateRestaurant([FromRoute]int restaurantId, 
        //    [FromBody] RestaurantForCreationDto restaurant)
        //{
        //    if (restaurant == null)
        //    {
        //        return BadRequest();
        //    }

        //    var RestaurantEntity = _restaurantInfoRepository.GetRestaurant(restaurantId);

        //    if (RestaurantEntity == null)
        //    {
        //        return StatusCode(500, "The restuarant you requested is not available");
        //    }


        //    if (restaurant.Name != null)
        //    {
        //        RestaurantEntity.Name = restaurant.Name;
        //    }

        //    if (restaurant.TelephoneNr != null)
        //    {
        //        RestaurantEntity.TelephoneNr = restaurant.TelephoneNr;
        //    }

        //    if (restaurant.Adress != null)
        //    {
        //        RestaurantEntity.Adress = restaurant.Adress;
        //    }

        //    if (restaurant.CreatedAtDate != null)
        //    {
        //        RestaurantEntity.CreatedAtDate = restaurant.CreatedAtDate;
        //    }

        //    RestaurantEntity.UpdatedAtDate = DateTime.Now;


        //    if (!_restaurantInfoRepository.Save())
        //    {
        //        return StatusCode(500, "Something happened while handling your request");
        //    }


        //    return Ok(RestaurantEntity);

        //}





        [HttpPatch("{restaurantId}")]
        public IActionResult PartiallyUpdateRestaurant([FromRoute]int restaurantId, 
            [FromBody]RestaurantForCreationDto patchRestaurant)
        {
            if (patchRestaurant == null)
            {
                return BadRequest();
            }

            var RestaurantEntity = _restaurantInfoRepository.GetRestaurant(restaurantId);

            if (RestaurantEntity == null)
            {
                return StatusCode(500, "The restaurant you requested is not in the database");
            }


            if (patchRestaurant.Name != null)
            {
                if (patchRestaurant.Name.Length > 50)
                {
                    return StatusCode(500, "THe name is too long!");
                }
                RestaurantEntity.Name = patchRestaurant.Name;
            }

            if (patchRestaurant.Adress != null)
            {
                RestaurantEntity.Adress = patchRestaurant.Adress;
            }

            

            if (patchRestaurant.foods != null)
            {
                RestaurantEntity.foods = patchRestaurant.foods;
            }

            if (patchRestaurant.CreatedAtDate != null)
            {
                RestaurantEntity.CreatedAtDate = patchRestaurant.CreatedAtDate;
            }

            RestaurantEntity.UpdatedAtDate = DateTime.Now;


            if (!_restaurantInfoRepository.Save())
            {
                return StatusCode(500, "There was a problem handling your request");
            }


            return Ok(RestaurantEntity);

        }



    }
}
