using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class UserTest
    {
        [Key]
        public int UserTestID { get; set; }

        [Required]
        public int TestID { get; set; }

        public Test Test { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateTaken { get; set; }
    }
}
