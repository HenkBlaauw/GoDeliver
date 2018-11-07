using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Entities
{
    public class Restaurant
    {
        
        public int RestaurantId { get; set; }

        public string Name { get; set; }
        
        public string Adress { get; set; }
      
        public ICollection<Entities.Food> foods {get; set;}
        
        public DateTime CreatedAtDate { get; set; }
        
        public DateTime UpdatedAtDate { get; set; }

    }
}
