using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class TestQuestion
    {
        [Key]
        public int TestQuestionID { get; set; }

        public Question Question { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public Test Test { get; set; }

        [Required]
        public int TestId { get; set; }
    }
}
