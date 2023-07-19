using System.ComponentModel.DataAnnotations;

namespace MySchool.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Content { get; set; }
        [Required]
        public virtual ICollection<QuestionOption> Options { get; set; }

        public int ExaminationId { get; set; }

        public Examination Examination { get; set; }
    }

}