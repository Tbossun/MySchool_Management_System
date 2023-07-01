using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class User  : IdentityUser  
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }

    }
}
