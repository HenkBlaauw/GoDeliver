﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class CustomerForCreationDto
    {
        //[JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [MaxLength(50)]
        //[JsonProperty("name")]
        public string Name { get; set; }

        [MaxLength(100)]
        //[JsonProperty("adress")]
        public string Adress { get; set; }

        [MaxLength(10)]
       // [JsonProperty("mobileNr")]
        public string MobileNr { get; set; }

        //[JsonProperty("createdAtDate")]
        public DateTime CreatedAtDate { get; set; }

       // [JsonProperty("updatedAtDate")]
        public DateTime UpdatedAtDate  { get; set; }

    }
}
