using GoDeliver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver
{
    public class CustomerDataStore
    {

        public static CustomerDataStore Current { get; } = new CustomerDataStore();

        public List<CustomerDto> Customers { get; set; }

        public CustomerDataStore()
        {
            Customers = new List<CustomerDto>()
            {
                new CustomerDto()
                {
                    CustomerId = 1,
                    Name = "Jacques",
                    Adress = "14 plakkers straat",
                    MobileNr = "0821345782"
                },

                new CustomerDto()
                {
                    CustomerId = 2,
                    Name = "Sarah",
                    Adress = "12 Highway street",
                    MobileNr = "0825035301"
                }

            };
        }



    }
}
