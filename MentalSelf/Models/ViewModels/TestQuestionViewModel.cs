using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models.ViewModels
{
    public class TestQuestionViewModel
    {
        public Test Test { get; set; }

        public IEnumerable<Question> Question { get; set; }
        
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTaken { get; set; }
    }
}