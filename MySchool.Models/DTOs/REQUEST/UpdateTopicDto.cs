using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Models.DTOs.REQUEST
{
    public class UpdateTopicDto
    {
        public string TopicName { get; set; }

        public string Notes { get; set; }

        public int SubjectId { get; set; }
    }
}
