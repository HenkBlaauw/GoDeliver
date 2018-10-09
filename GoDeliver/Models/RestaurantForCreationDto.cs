using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class RestaurantForCreationDto
    {

        
            public int RestaurantId { get; set; }

            public string Name { get; set; }

            public string Adress { get; set; }

            public string TelephoneNr { get; set; }

            public ICollection<Entities.Food> foods { get; set; }

            public DateTime CreatedAtDate { get; set; }

            public DateTime UpdatedAtDate { get; set; }


        }
}
