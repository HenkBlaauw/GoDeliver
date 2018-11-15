﻿using GoDeliverWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoDeliverWebApp.Models
{
    public class RestaurantInfoDto
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string TelephoneNr { get; set; }

        public ICollection<Food> Foods { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public DateTime UpdatedAtDate { get; set; }
    }
}