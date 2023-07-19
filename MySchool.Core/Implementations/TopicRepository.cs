using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        private MySchoolDbContext _context;

        public TopicRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Topic topic)
        {
            _context.Entry(topic).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
