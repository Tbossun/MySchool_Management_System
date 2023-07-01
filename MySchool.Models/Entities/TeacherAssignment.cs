using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class TeacherAssignment
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int TeacherId { get; set; }
        public School School { get; set; }
        public Teacher Teacher { get; set; }
    }
}
