using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySchool.Models.Entities
{
    public class Class 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Class")]
        public string Name { get; set; }


        //public virtual ICollection<TeacherClass> ClassTeachers { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
