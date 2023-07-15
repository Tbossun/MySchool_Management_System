using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface ISchoolRepository : IRepository<School>
    {
        void Update(School school);
    }
}
