﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalSelf.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() 
        {

        }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Response> Responses { get; set; }
    }
}
