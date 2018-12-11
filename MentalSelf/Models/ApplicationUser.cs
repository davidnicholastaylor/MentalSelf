using Microsoft.AspNetCore.Identity;
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

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Response> Responses { get; set; }
    }
}
