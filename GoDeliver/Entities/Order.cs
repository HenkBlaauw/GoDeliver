using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDeliver.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [Required]
        public int DriverId { get; set; }

        [Required] 
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime TimeAtRestaurant { get; set; }

        [Required] 
        public DateTime TimePickedUp { get; set; } 

        [Required]
        public DateTime DeliveryTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        public float Cost { get; set; }

        [Required]
        public DateTime CreatedAtDate { get; set; }

        [Required]
        public DateTime UpdatedAtDate { get; set; }
    }
}
