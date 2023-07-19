using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Topic   
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Topic")]
        public string TopicName { get; set; }
        public string Notes { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public double AssignmentScore { get; set; }
    }   
}
