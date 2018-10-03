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



    }
}
