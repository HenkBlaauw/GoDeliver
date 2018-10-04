using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoDeliver.Models
{
    public class CustomerForCreationDto
    {
       
        [Required]
       public int CustomerId { get; set; }

        [Required(ErrorMessage = "You should enter a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter an address please")]
        [MaxLength(100)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "The number should be 10 characters long, and please make sure it's a number")]
        [MaxLength(10)]
        public string MobileNr { get; set; }

        [Required]
        DateTime CreatedAtDate { get; set; }

        //[Required]
        //public DateTime UpdatedAtDate { get; set; }

    }
}
