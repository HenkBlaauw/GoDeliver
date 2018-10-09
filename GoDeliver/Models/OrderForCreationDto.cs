using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class OrderForCreationDto
    {

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int DriverId { get; set; }

        public int RestaurantId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime TimeAtRestaurant { get; set; }

        public DateTime TimePickedUp { get; set; }

        public DateTime DeliveryTime { get; set; }

        public string State { get; set; }

        public float Cost { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
