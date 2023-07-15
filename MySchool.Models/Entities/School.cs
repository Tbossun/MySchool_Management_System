using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MySchool.Models.Entities
{
    public class School 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "School Name")]
        public string Name { get; set; }

        [StringLength(150)]
        [Display(Name = "School Location")]
        public string Address { get; set; }

        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Student> Students { get; set; }


    }
}
