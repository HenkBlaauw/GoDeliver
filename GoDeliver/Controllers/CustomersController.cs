using GoDeliver.Entities;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
       public IActionResult CreateCustomer([FromBody]CustomerForCreationDto customerInfo)
       {
           
            var customerError = "Please look at your data and make sure it's not empty, incorrect, or has values that are the same!";
            Customer customer = new Customer();

            if (customerInfo == null)
            {
                return BadRequest(customerError);
            }

            if (customerInfo.Name == customerInfo.Adress || customerInfo.Name == customerInfo.MobileNr || customerInfo.MobileNr == customerInfo.Adress)
            {
                return BadRequest(customerError);
            }

            // Convert CustomerForCreationDto to Customer entity
            customer.Adress = customerInfo.Adress;
            customer.Name = customerInfo.Name;
            customer.MobileNr = customerInfo.MobileNr;
            customer.CustomerId = customerInfo.CustomerId;
            customer.CreatedAtDate = DateTime.Now;
            customer.UpdatedAtDate = customer.CreatedAtDate;

            if (customer.MobileNr.Length > 10)
            {
                return BadRequest(customerError);
            }

            _customerInfoRepository.AddCustomer(customer);

            if (!_customerInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
  
            return Ok(customer);
        }


       


       //Delete a customer             
       [HttpDelete("{customerId}")]
       public IActionResult DeleteCustomer([FromRoute]int customerId)
       {

            var customerEntity = _customerInfoRepository.GetCustomer(customerId);

            if (customerEntity == null)
            {
                return NotFound();
            }

            _customerInfoRepository.DeleteCustomer(_customerInfoRepository.GetCustomer(customerId));
            
            if (!_customerInfoRepository.Save())
            {
                return StatusCode(500, "A thing happened which caused the program to stop responding");
            }

            return NoContent();
            
       }





        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer([FromRoute]int customerId)
        {

        }
    }
}
