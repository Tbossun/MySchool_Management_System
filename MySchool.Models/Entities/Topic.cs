using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Quiz Quiz { get;set; }
        
}    }
