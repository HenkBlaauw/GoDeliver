using GoDeliver.Entities;
using GoDeliver.Models;
using GoDeliver.Services;
using Microsoft.AspNetCore.JsonPatch;
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

        //Gets all customers
        [HttpGet()]
        public IActionResult GetCustomers()
        {
            var customerEntities = _customerInfoRepository.GetCustomers();

            if (customerEntities == null)
            {
                return StatusCode(500, "Sorry, the database is empty!");
            }


            return Ok(customerEntities);

        }

        //Get a single customer
        [HttpGet("{customerId}")]
        public IActionResult GetCustomer(int customerId)
        {
            var customer = _customerInfoRepository.GetCustomer(customerId);
            if (customer == null)
            {
                return StatusCode(500, "The customer is null and void, so i'm sorry, but we don't have this customer in the database");
            }

            //  var customerResult = Mapper.Map<CustomerDto>(customer);
            return Ok(customer);
        }

        //Creating a customer
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
            if (customer.Adress.Length > 50)
            {
                return StatusCode(500, "Your adress is too long. Please make sure it's less than 50 characters!");
            }

            customer.Name = customerInfo.Name;
            if (customer.Name.Length > 50)
            {
                return StatusCode(500, "Your name is too long. Please ensure it's less than 50 characters long!");
            }

            customer.MobileNr = customerInfo.MobileNr;
            if (customer.MobileNr.Length > 10)
            {
                return StatusCode(500, "Your mobile number is too long. Please ensure it is shorter than 11 digits long!");
            }

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

        //Editing a customer
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer([FromRoute]int customerId, [FromBody] CustomerForCreationDto customer)
        {

                if (customer == null)
                {
                    return BadRequest();
                }

                var customerEntity = _customerInfoRepository.GetCustomer(customerId);

                if (customerEntity == null)
                {
                    return NotFound();
                }


                if (customer.Name != null)
                {
                    customerEntity.Name = customer.Name;
                }
                if ( customer.Name.Length > 50)
                {
                    return StatusCode(500, "The name you entered is a tad bit too long....");
                }
                if (customer.MobileNr.Length > 10)
                {
                    return StatusCode(418, "Teapot error, go away. Actually your mobile number is just too long");
                }
                if (customer.Adress != null)
                {
                    customerEntity.Adress = customer.Adress;
                }
                if (customer.Adress.Length > 50)
                {
                    return StatusCode(500, "The adress is too long...............");
                }

                if (customer.MobileNr != null)
                {
                    customerEntity.MobileNr = customer.MobileNr;
                }

                if (customer.CreatedAtDate != null)
                {
                    customerEntity.CreatedAtDate = customer.CreatedAtDate;
                }

                customer.UpdatedAtDate = DateTime.Now;


                if (!_customerInfoRepository.Save())
                {
                    return StatusCode(418, "Something happened maatjie. Ek is jammer, kyk na die tee pot, want jou data wil nie save nie");
                }


                return Ok(customerEntity);

            
            
        }


        [HttpPatch("{customerId}")]
        public IActionResult PartiallyUpdateCustomer([FromRoute]int customerId,
            [FromBody]CustomerForCreationDto patchCustomer)
        {

            if (patchCustomer == null)
            {
                return BadRequest();
            }

            var CustomerEntity = _customerInfoRepository.GetCustomer(customerId);

            if (CustomerEntity == null)
            {
                return StatusCode(500, "The customer you requested is not in the database");
            }

            if (patchCustomer.Name != null)
            {
                CustomerEntity.Name = patchCustomer.Name;
            }

            if (patchCustomer.Adress != null)
            {
                CustomerEntity.Adress = patchCustomer.Adress;
            }

            if (patchCustomer.CreatedAtDate != null)
            {
                CustomerEntity.CreatedAtDate = patchCustomer.CreatedAtDate;
            }

            if (patchCustomer.MobileNr != null)
            {
                CustomerEntity.MobileNr = patchCustomer.MobileNr;
            }


            CustomerEntity.UpdatedAtDate = DateTime.Now;


            if (!_customerInfoRepository.Save())
            {
                return StatusCode(500, "SOmething happened while handling your request");
            }


            return Ok(CustomerEntity);


        }




    }
}
