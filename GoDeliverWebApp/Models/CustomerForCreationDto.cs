using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliverWebApp.Models
{
    public class CustomerForCreationDto
    {
        //[JsonProperty("customerId")]
        public int CustomerId { get; set; }

        //[JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("adress")]
        public string Adress { get; set; }

       // [JsonProperty("mobileNr")]
        public string MobileNr { get; set; }

        //[JsonProperty("createdAtDate")]
        public DateTime CreatedAtDate { get; set; }

       // [JsonProperty("updatedAtDate")]
        public DateTime UpdatedAtDate  { get; set; }

    }
}
