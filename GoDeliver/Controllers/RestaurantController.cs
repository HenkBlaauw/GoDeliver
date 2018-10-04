using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var restaurantEntities = _restaurantInfoRepository.GetFoods();
            return Ok(restaurantEntities);
        }


        [HttpGet("{restaurantId}")]
        public IActionResult GetRestaurant(int restaurantId)
        {
            var restaurantEntities = _restaurantInfoRepository.GetRestaurant(restaurantId);
            return Ok(restaurantEntities);
        }

        





    }
}
