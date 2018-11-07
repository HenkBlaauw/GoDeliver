//using GoDeliver.Entities;
//using GoDeliver.Models;
//using GoDeliver.Services;
//using GoDeliverWebApp.Entities;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Web.Http;
//using System.Web.Mvc;

using GoDeliverWebApp.Entities;
using GoDeliverWebApp.Models;
using GoDeliverWebApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using System.Web.Mvc;
namespace GoDeliverWebApp.Controllers
{

    public class CustomersController : ApiController
    {
        private InfoRepository _customerInfoRepository;

        public CustomersController(InfoRepository customerInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
        }

        //Gets all customers

        private GoDeliveryContext _context;

        //public CustomersController(GoDeliveryContext context)
        //{
        //    _context = context;
        //}


        public CustomersController()
        {
            GoDeliveryContext context = new GoDeliveryContext();
            _context = context;

            _customerInfoRepository = new DataInfoRepository(context);
        }


        // GET api/customers
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        // [ResponseType(typeof(JsonResult))]

        [Route("customers")]
        [HttpGet()]
        public string GetCustomers()
        {
            GoDeliveryContext context = new GoDeliveryContext();
            IQueryable<CustomerDto> customers = from b in context.Customers
                                                select new CustomerDto()
                                                {
                                                    CustomerId = b.CustomerId,
                                                    Name = b.Name
                                                };
            string result = JsonConvert.SerializeObject(customers);
            return result;
        }
       
        [Route("customers")]
        [HttpPost()]
        public IHttpActionResult CreateCustomer([FromBody]CustomerForCreationDto CustomerInfo)
        {

            Customer customer = new Customer();
            if (CustomerInfo == null)
            {
                return BadRequest();
            }

            if (CustomerInfo.Name == null || CustomerInfo.Adress == null)
            {
                throw new Exception("Sorry, the data you entered is null");
            }

            customer.Name = CustomerInfo.Name;
            if (CustomerInfo.Name.Length > 255)
            {
                return BadRequest("The name is too long!");
            }
            customer.Adress = CustomerInfo.Adress;
            if (CustomerInfo.Adress.Length > 255)
            {
                return BadRequest("The address is too long!");
            }

            customer.CreatedAtDate = DateTime.Now;
            customer.UpdatedAtDate = customer.CreatedAtDate;

            _customerInfoRepository.AddCustomer(customer);



            if (!_customerInfoRepository.Save())
            {
                return null;
            }


            return Ok(customer);


        }




        //    [ResponseType(typeof(CustomerDto))]
        //        public async Task<IHttpActionResult> GetCustomer(int id)
        //    {
        //        var customer = await _context.Customers.Include(b => b.Customers).Select(b =>
        //        new CustomerDto()
        //        {
        //            CustomerId = b.CustomerId,
        //            Name = b.Name


        //        }).SingleOrDefaultAsync(b => b.CustomerId == id);

        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }

        //        return customer;
        //    }
        //}














        //Get a single customer
        //[HttpGet("{customerId}")]
        //public IActionResult GetCustomer(int customerId)
        //{
        //    var customer = _customerInfoRepository.GetCustomer(customerId);
        //    if (customer == null)
        //    {
        //        return StatusCode(500, "The customer is null and void, so i'm sorry, but we don't have this customer in the database");
        //    }

        //    //  var customerResult = Mapper.Map<CustomerDto>(customer);
        //    return Ok(customer);
        //}



    }
}

//        //Creating a customer
//        [HttpPost()]
//        public IActionResult CreateCustomer([FromBody]CustomerForCreationDto customerInfo)
//        {

//            var customerError = "Please look at your data and make sure it's not empty, incorrect, or has values that are the same!";
//            Customer customer = new Customer();

//            if (customerInfo == null)
//            {
//                return BadRequest(customerError);
//            }

//            if (customerInfo.Name == customerInfo.Adress || customerInfo.Name == customerInfo.MobileNr || customerInfo.MobileNr == customerInfo.Adress)
//            {
//                return BadRequest(customerError);
//            }

//            // Convert CustomerForCreationDto to Customer entity
//            customer.Adress = customerInfo.Adress;
//            if (customer.Adress.Length > 50)
//            {
//                return StatusCode(500, "Your adress is too long. Please make sure it's less than 50 characters!");
//            }

//            customer.Name = customerInfo.Name;
//            if (customer.Name.Length > 50)
//            {
//                return StatusCode(500, "Your name is too long. Please ensure it's less than 50 characters long!");
//            }



//            customer.CreatedAtDate = DateTime.Now;
//            customer.UpdatedAtDate = customer.CreatedAtDate;



//            _customerInfoRepository.AddCustomer(customer);

//            if (!_customerInfoRepository.Save())
//            {
//                return StatusCode(500, "A problem happened while handling your request.");
//            }

//            return Ok(customer);
//        }





//        //Delete a customer             
//        [HttpDelete("{customerId}")]
//        public IActionResult DeleteCustomer([FromRoute]int customerId)
//        {

//            var customerEntity = _customerInfoRepository.GetCustomer(customerId);

//            if (customerEntity == null)
//            {
//                return NotFound();
//            }

//            _customerInfoRepository.DeleteCustomer(_customerInfoRepository.GetCustomer(customerId));

//            if (!_customerInfoRepository.Save())
//            {
//                return StatusCode(500, "A thing happened which caused the program to stop responding");
//            }

//            return NoContent();

//        }

//        //Editing a customer
//        [HttpPut("{customerId}")]
//        public IActionResult UpdateCustomer([FromRoute]int customerId, [FromBody] CustomerForCreationDto customer)
//        {

//            if (customer == null)
//            {
//                return BadRequest();
//            }

//            var customerEntity = _customerInfoRepository.GetCustomer(customerId);

//            if (customerEntity == null)
//            {
//                return NotFound();
//            }


//            if (customer.Name != null)
//            {
//                customerEntity.Name = customer.Name;
//            }
//            if (customer.Name.Length > 50)
//            {
//                return StatusCode(500, "The name you entered is a tad bit too long....");
//            }
//            if (customer.MobileNr.Length > 10)
//            {
//                return StatusCode(418, "Teapot error, go away. Actually your mobile number is just too long");
//            }
//            if (customer.Adress != null)
//            {
//                customerEntity.Adress = customer.Adress;
//            }
//            if (customer.Adress.Length > 50)
//            {
//                return StatusCode(500, "The adress is too long...............");
//            }


//            if (customer.CreatedAtDate != null)
//            {
//                customerEntity.CreatedAtDate = customer.CreatedAtDate;
//            }

//            customer.UpdatedAtDate = DateTime.Now;


//            if (!_customerInfoRepository.Save())
//            {
//                return StatusCode(418, "Something happened maatjie. Ek is jammer, kyk na die tee pot, want jou data wil nie save nie");
//            }


//            return Ok(customerEntity);



//        }


//        [HttpPatch("{customerId}")]
//        public IActionResult PartiallyUpdateCustomer([FromRoute]int customerId,
//            [FromBody]CustomerForCreationDto patchCustomer)
//        {

//            if (patchCustomer == null)
//            {
//                return BadRequest();
//            }

//            var CustomerEntity = _customerInfoRepository.GetCustomer(customerId);

//            if (CustomerEntity == null)
//            {
//                return StatusCode(500, "The customer you requested is not in the database");
//            }

//            if (patchCustomer.Name != null)
//            {
//                if (patchCustomer.Name.Length > 50)
//                {
//                    return StatusCode(500, "THe name is too long");
//                }
//                CustomerEntity.Name = patchCustomer.Name;
//            }

//            if (patchCustomer.Adress != null)
//            {
//                CustomerEntity.Adress = patchCustomer.Adress;
//            }

//            if (patchCustomer.CreatedAtDate != null)
//            {
//                CustomerEntity.CreatedAtDate = patchCustomer.CreatedAtDate;
//            }




//            CustomerEntity.UpdatedAtDate = DateTime.Now;


//            if (!_customerInfoRepository.Save())
//            {
//                return StatusCode(500, "SOmething happened while handling your request");
//            }


//            return Ok(CustomerEntity);


//        }




//    }
//}
