using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        [Required]
        public int UserTestId { get; set; }

        public UserTest UserTest { get; set; }

        [Required]
        public int RatingId { get; set; }

        public Rating Rating { get; set; }
    }
}
