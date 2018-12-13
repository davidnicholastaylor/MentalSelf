﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class Test
    {
        [Key]
        public int TestID { get; set; }

        [Required]
        public string Title { get; set; }

    }
}
