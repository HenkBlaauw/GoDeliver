using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class FoodForCreationDto
    {

        

        public int FoodId { get; set; }
       
        [MaxLength(50)]
        public string Name { get; set; }

        
        [MaxLength(100)]
        public string Description { get; set; }

        public float Cost { get; set; }

        
        public int RestaurantId { get; set; }

        
        public DateTime CreatedAtDate { get; set; }

        
        public DateTime UpdatedAtDate { get; set; }




    }
}
