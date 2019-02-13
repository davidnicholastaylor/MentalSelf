using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Threshold { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
