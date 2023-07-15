using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface IClassRepository : IRepository<Class>
    {
        void Update(Class Newclass);
    }
}
