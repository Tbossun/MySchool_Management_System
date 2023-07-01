using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public List<Class> Classes { get; set; } = new List<Class>();
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
