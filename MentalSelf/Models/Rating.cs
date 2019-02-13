using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        
        [Required]
        public string RatingDescription { get; set; }
    }
}
