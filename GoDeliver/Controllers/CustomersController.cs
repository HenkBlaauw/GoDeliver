using AutoMapper;
using GoDeliver.DatabaseData;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoDeliver.Controllers
{
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private InfoRepository _customerInfoRepository;
        public CustomersController(InfoRepository customerInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
        }

        //GET api customers
        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customerEntities = _customerInfoRepository.GetCustomers();
            //var results = Mapper.Map<IEnumerable<CustomerDto>>(customerEntities);

            return Ok(customerEntities);
  
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomer(int customerId)
        {
            var customer = _customerInfoRepository.GetCustomer(customerId);
          //  var customerResult = Mapper.Map<CustomerDto>(customer);
            return Ok(customer);
        }

       [HttpPost()]
       public IActionResult CreateCustomer(int customerId, [FromBody] CustomerForCreationDto customerInfo)
       {

            var customerError = "Please look at your data and make sure it's not incorrect, or has values that are the same!";

            if (customerInfo == null)
            {
                return BadRequest();
            }

            if(customerInfo.Name == customerInfo.Adress || customerInfo.Name == customerInfo.MobileNr || customerInfo.MobileNr == customerInfo.Adress)
            {
                return BadRequest(customerError);
            }

            var customerFinal = customerInfo;
            //   _customerInfoRepository.AddCustomer(customerId, );
            
            return CreatedAtRoute("GetCustomer",
                new { customerId = customerId, id = customerFinal.CustomerId }, customerFinal);
       }


        //Delete a customer              (Still buggy)
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {

            var customerEntity = _customerInfoRepository.GetCustomer(customerId);

            if (customerEntity == null)
            {
                return NotFound();
            }
            
            _customerInfoRepository.DeleteCustomer(customerEntity);
            return Ok(_customerInfoRepository.GetCustomers());
            
        }







    }
}
