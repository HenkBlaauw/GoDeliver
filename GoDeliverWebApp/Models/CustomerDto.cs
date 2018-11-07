using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Models
{
    public class CustomerDto 
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string MobileNr { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
