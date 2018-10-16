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
        public IActionResult CreateDriver([FromBody]DriverForCreationDto driverInfo)
        {
            var driverError = "Please look at your data and make sure it's not empty, incorrect, or has values that are the same!";
            Driver driver = new Driver();

            if (driverInfo == null)
            {
                return BadRequest(driverError);
            }

            driver.Name = driverInfo.Name;
            if (driverInfo.Name == null )
            {
                return StatusCode(500, "The name is invalid or too long!");
            }
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
                if (driverEdit.Name.Length > 50 || driverToEdit.Name == null)
                {
                    return StatusCode(500, "The name is too long, also make sure it's entered");
                }
                driverToEdit.Name = driverEdit.Name;
            }

            if (driverToEdit.CreatedAtDate != driverEdit.CreatedAtDate)
            {
                if (driverEdit.CreatedAtDate == null)
                {
                    return StatusCode(500, "Please check the date you entered");
                }
                driverToEdit.CreatedAtDate = driverEdit.CreatedAtDate;
            }

            driverToEdit.UpdatedAtDate = DateTime.Now;

            if (!_driverInfoRepository.Save())
            {
                return StatusCode(500, "Internal Server Error, I am sorry to inform you!");
            }
            return Ok(driverToEdit);
        }

        [HttpPatch("{driverId}")]
        public IActionResult PartiallyUpdateDriver([FromRoute] int driverId,[FromBody] DriverForCreationDto patchDriver)
        {
            if (patchDriver == null)
            {
                return BadRequest();
            }

            var DriverEntity = _driverInfoRepository.GetDriver(driverId);

            if(DriverEntity == null)
            {
                return StatusCode(500, "The driver you requested is not in the database");
            }

            if (patchDriver.Name != null)
            {
                if (patchDriver.Name.Length > 50)
                {
                    return StatusCode(500, "The name is too long");
                }
                DriverEntity.Name = patchDriver.Name;
            }

            if (patchDriver.CreatedAtDate != null)
            {
                DriverEntity.CreatedAtDate = patchDriver.CreatedAtDate;
            }

            DriverEntity.UpdatedAtDate = DateTime.Now;

            if (!_driverInfoRepository.Save())
            {
                return StatusCode(500, "Something happened while handling the request");
            }

            return Ok(DriverEntity);
        }
    }
}
