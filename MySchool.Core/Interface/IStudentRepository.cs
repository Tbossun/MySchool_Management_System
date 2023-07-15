using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
    }
}
