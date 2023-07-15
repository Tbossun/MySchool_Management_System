using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        void Update(Subject subject);
    }
}
