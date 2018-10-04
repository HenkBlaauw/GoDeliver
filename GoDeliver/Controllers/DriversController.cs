using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Controllers
{

    [Route("api/drivers")]
    public class DriversController : Controller
    {

        private InfoRepository _driverInfoRepository;
        public DriversController(InfoRepository driverInfoRepository)
        {
            _driverInfoRepository = driverInfoRepository;
        }

        
        [HttpGet()]
        public IActionResult GetDrivers()
        {
            var driverEntities = _driverInfoRepository.GetDrivers();

            return Ok(driverEntities);
        }
        
        [HttpGet("{driverid}")]
        public IActionResult GetDriver(int driverId)
        {
            var driver = _driverInfoRepository.GetDriver(driverId);

            return Ok(driver);
        }


    }
}
