using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface ITopicRepository : IRepository<Topic>
    {
        void Update(Topic topic);
    }
}
