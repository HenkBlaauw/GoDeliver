using GoDeliverWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int DriverId { get; set; }

        public int RestaurantId { get; set; }

        public ICollection<Food> Foods { get; set; }

        public string State { get; set; }

        public DateTime TimeAtRestaurant { get; set; }

        public string RestaurantAddress { get; set; }

        public string CustomerAddress { get; set; }

        public float TotalCost { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
