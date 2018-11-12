using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoDeliverWebApp.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int DriverId { get; set; }

        public int RestaurantId { get; set; }

        public ICollection<Food> Foods { get; set; }

        public DateTime TimeAtRestaurant { get; set; }

        public string RestaurantAddress { get; set; }

        public string CustomerAddress { get; set; }

        public float TotalCost { get; set; }

        public string State { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
