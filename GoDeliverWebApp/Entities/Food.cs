using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public float Cost { get; set;}
        
        public long RestaurantId { get; set; }
        
        public DateTime CreatedAtDate { get; set; }
        
        public DateTime UpdatedAtDate { get; set; }

        public Food(string name, string description, float cost, DateTime createdAtDate, DateTime updatedAtDate)
        {
            Name = name;
            Description = description;
            Cost = cost;
            CreatedAtDate = createdAtDate;
            UpdatedAtDate = updatedAtDate;
        }
    }
}
