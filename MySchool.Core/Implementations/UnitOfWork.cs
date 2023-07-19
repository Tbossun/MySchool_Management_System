using MySchool.Core.Interface;
using MySchool.Data;

namespace MySchool.Core
{
    public class UnitOfWork : IUnitOfWork
    {

        private MySchoolDbContext _appDbContext;



        public IStudentRepository StudentRepository { get; private set; }

        public ITeacherRepository TeacherRepository { get; private set; }

        public ISchoolRepository SchoolRepository { get; private set; }

        public ISubjectRepository SubjectRepository { get; private set; }

        public IClassRepository ClassRepository { get; private set; }

        public ITopicRepository TopicRepository { get; private set; }

        public IQuestionOptionRepository QuestionOptionRepository { get; private set; }

        public IExaminationRepository ExaminationRepository { get; private set; }

        public IQuestionRepository QuestionRepository { get; private set ; }


        public UnitOfWork(MySchoolDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            StudentRepository = new StudentRepository(_appDbContext);
            TeacherRepository = new TeacherRepository(_appDbContext);
            SchoolRepository = new SchoolRepository(_appDbContext);
            TopicRepository = new TopicRepository(_appDbContext);
            SubjectRepository = new SubjectRepository(_appDbContext);
            ClassRepository = new ClassRepository(_appDbContext);
            ExaminationRepository = new ExaminationRepository(_appDbContext);
            QuestionRepository = new QuestionRepository(_appDbContext);
            QuestionOptionRepository = new QuestionOptionRepository(_appDbContext);

        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
