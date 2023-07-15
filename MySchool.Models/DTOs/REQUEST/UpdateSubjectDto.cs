using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MySchool.Models.DTOs.REQUEST
{
    public class UpdateSubjectDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }
    }
}
