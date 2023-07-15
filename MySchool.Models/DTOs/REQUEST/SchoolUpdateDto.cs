using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Models.DTOs.REQUEST
{
    public class SchoolUpdateDto
    {
        public string Name { get; set; }

        // [StringLength(150)]
        // [Display(Name = "School Location")]
        public string Address { get; set; }

        // [StringLength(25)]
        // [DataType(DataType.PhoneNumber)]
        // [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        // [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
