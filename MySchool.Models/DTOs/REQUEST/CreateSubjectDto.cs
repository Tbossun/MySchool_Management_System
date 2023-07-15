using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace MySchool.Models.DTOs.REQUEST
{
    public class CreateSubjectDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }
    }
}
