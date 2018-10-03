using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class FoodsDto
    {
        public int FoodId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Cost { get; set; }

        public int RestaurantId { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}
