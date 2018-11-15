using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDeliverWebApp.Models
{
    public class FoodForRestaurantDto
    {
        public int FoodId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Cost { get; set; }



    }
}