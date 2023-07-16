using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class User  : IdentityUser  
    {
        [Required]
        public string Password { get; set; }

        public string AvatarUrl { get; set; } = string.Empty;

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
