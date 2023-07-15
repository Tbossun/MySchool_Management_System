using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void Update(Teacher teacher);
    }
}
