using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace MySchool.Models.DTOs.REQUEST
{
    public class TeacherCreateDto
    {
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Display(Name = "Last Name"), StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Column("FirstName"), Display(Name = "First Name"), StringLength(50, MinimumLength = 1)]
        public string FirstMidName { get; set; }

        /*[Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }*/

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public int SchoolId { get; set; }

        public string UserId { get; set; }
    }
}
