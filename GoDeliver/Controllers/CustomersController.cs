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

       



    }
}
