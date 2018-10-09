using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class DriverForCreationDto
    {
        public int DriverId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        public DateTime CreatedAtDate { get; set; }


        public DateTime UpdatedAtDate { get; set; }


    }
}
