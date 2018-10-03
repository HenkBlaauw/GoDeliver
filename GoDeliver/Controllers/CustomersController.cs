using AutoMapper;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoDeliver.Controllers
{
 
    public class CustomersController : Controller
    {
        private InfoRepository _customerInfoRepository;
        public CustomersController(InfoRepository customerInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
        }





        //GET api customers
        [HttpGet("api/customers")]
        public IActionResult GetCustomers()
        {
            var customerEntities = _customerInfoRepository.GetCustomers();
            var results = Mapper.Map<IEnumerable<CustomerDto>>(customerEntities);

            return Ok(results);
  
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCity(int customerId)
        {
            var customer = _customerInfoRepository.GetCustomer(customerId);
            var customerResult = Mapper.Map<CustomerDto>(customer);
            return Ok(customerResult);
        }

        [HttpGet("api/foods")]
        public IActionResult GetFoods()
        {
            var foodEntities = _customerInfoRepository.GetFoods();
            //  var results = Mapper.Map<I>
            return Ok("Placeholder");

        }



    }
}
