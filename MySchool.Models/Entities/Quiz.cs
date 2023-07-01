using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int SubjectId { get; set; }
        public int TopicId { get; set; }
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
        public Topic Topic { get; set; }
        public Teacher Teacher { get; set; }
    }
}
