using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedAtDate { get; set; }
        
        public DateTime UpdatedAtDate { get; set; }
    }
}
