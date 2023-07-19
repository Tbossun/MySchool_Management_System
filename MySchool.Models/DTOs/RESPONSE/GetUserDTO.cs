using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Models.DTOs.RESPONSE
{
    public class GetUserDTO
    {
        public string Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }

    }
}
