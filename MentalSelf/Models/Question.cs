using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public string QuestionDesc { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        public QuestionType QuestionType { get; set; }

        [Required]
        public int TestId { get; set; }

        public Test Test { get; set; }
    }
}
