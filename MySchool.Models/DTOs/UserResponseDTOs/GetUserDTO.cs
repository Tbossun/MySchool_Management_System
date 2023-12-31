﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Models.DTOs.UserResponseDTOs
{
    public class GetUserDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }

        public string DateOfBirth { get; set; }
    }
}
