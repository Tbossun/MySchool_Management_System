using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Core.Interface
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ISchoolRepository SchoolRepository { get; }
        IClassRepository ClassRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITopicRepository TopicRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuestionOptionRepository QuestionOptionRepository { get; }
        IExaminationRepository ExaminationRepository { get; }

        void Save();
    }
}
