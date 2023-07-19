namespace MySchool.Models.Entities
{
    public class QuestionOption
    {
        public int Id { get; set; }

        public string OptionText { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}