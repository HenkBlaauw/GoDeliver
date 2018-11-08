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
 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public float Cost { get; set;}

        [Required]
        public long RestaurantId { get; set; }

       // public ICollection<Order> OrderedFood { get; set; }



        [Required]
        public DateTime CreatedAtDate { get; set; }

        [Required]
        public DateTime UpdatedAtDate { get; set; }

        public Food() { }

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
