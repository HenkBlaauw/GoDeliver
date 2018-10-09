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
            return Ok(restaurantEntities);
        }


        [HttpGet("{restaurantId}")]
        public IActionResult GetRestaurant(int restaurantId)
        {
            var restaurantEntities = _restaurantInfoRepository.GetRestaurant(restaurantId);
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
            restaurant.Adress = restaurantInfo.Adress;
            restaurant.TelephoneNr = restaurantInfo.TelephoneNr;
            restaurant.foods = restaurantInfo.foods;
            restaurant.CreatedAtDate = DateTime.Now;
            restaurant.UpdatedAtDate = DateTime.Now;

            if (restaurant.TelephoneNr.Length > 10 || restaurant.Name.Length > 50)
            {
                return BadRequest(restaurantError);
            }

            _restaurantInfoRepository.AddRestaurant(restaurant);

            if (!_restaurantInfoRepository.Save())
            {
                return StatusCode(500, "SOmething wEnT WrOnG wHilE HanDlIng yOuR ReQUesT.");
            }

            return Ok(restaurant);


        }


    }
}
