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

        [HttpPost()]
        public IActionResult CreateDriver([FromRoute]DriverForCreationDto driverInfo)
        {

            var driverError = "Please look at your data and make sure it's not empty, incorrect, or has values that are the same!";
            Driver driver = new Driver();

            if (driverInfo == null)
            {
                return BadRequest(driverError);
            }


            driver.Name = driverInfo.Name;
            driver.CreatedAtDate = DateTime.Now;
            driver.UpdatedAtDate = driver.CreatedAtDate;
            if (!_driverInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Ok(driver);
        }


        [HttpDelete("{driverId}")]
        public IActionResult DeleteDriver([FromRoute]int driverId)
        {

            var driverEntity = _driverInfoRepository.GetDriver(driverId);
            if (driverEntity == null)
            {
                return NotFound();
            }

            _driverInfoRepository.DeleteDriver(_driverInfoRepository.GetDriver(driverId));

            if (!_driverInfoRepository.Save())
            {
                return StatusCode(500, "Something went wrong");
            }

            return NoContent();
        }




        [HttpPut("{driverId}")]
        public IActionResult UpdateDriver([FromRoute]int driverId, [FromBody]DriverForCreationDto driverEdit)
        {
            var driverToEdit = _driverInfoRepository.GetDriver(driverId);
            Driver driver = new Driver();

            if (driverToEdit == null)
            {
                return NotFound();
            }

            if (driverToEdit.Name != driverEdit.Name)
            {
                driverToEdit.Name = driverEdit.Name;
            }

            if (driverToEdit.CreatedAtDate != driverEdit.CreatedAtDate)
            {
                driverToEdit.CreatedAtDate = driverEdit.CreatedAtDate;
            }

            driverToEdit.UpdatedAtDate = DateTime.Now;

            if (!_driverInfoRepository.Save())
            {
                return StatusCode(500, "Internal Server Error, I am sorry to inform you!");
            }

            return Ok(driverToEdit);
        }



    }
}
