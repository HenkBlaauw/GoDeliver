using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Models
{
    public class CustomerForCreationDto
    {
        public int CustomerId { get; set; }
        
        public string Name { get; set; }
        
        public string Adress { get; set; }
        
        public DateTime CreatedAtDate { get; set; }
        
        public DateTime UpdatedAtDate  { get; set; }

    }
}
