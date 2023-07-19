using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Models.Entities
{
    public class Subject  
    {
        public int SubjectID { get; set; }

        [Display(Name = "Subject Title")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Subject Description")]
        public string Description { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public  Examination Examination { get; set; }

    }
}
