namespace MySchool.Models.Entities
{
    public class Examination
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double ExamScore { get; set; }

        public int subjectId { get; set; }

        public Subject Subject { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public int studentId { get; set; }

        public Student Student { get; set; }

    }
}