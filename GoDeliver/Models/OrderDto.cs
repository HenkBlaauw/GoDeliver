using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int DriverId { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime TimeAtRestaurant { get; set;}

        public DateTime TimePickedUp { get; set; }

        public DateTime DeliveryTime { get; set; }

        public string State { get; set; }

        public float Cost { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
