using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace MySchool.Models.DTOs.REQUEST
{
    public class StudentCreateDto
    {
        public string FirstMidName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /*[DataType(DataType.EmailAddress)]
        public string Email { get; set; }*/

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int SchoolId { get; set; }

        public string UserId { get; set; }
    }
}
