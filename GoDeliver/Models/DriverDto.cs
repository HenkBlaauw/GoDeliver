using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Models
{
    public class DriverDto
    {
        public int DriverId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
