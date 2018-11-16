using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDeliverWebApp.Models
{
    public class OrderCreationDto
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int[] FoodId { get; set; }

        public float TotalCost { get; set; }


    }
}