using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        private MySchoolDbContext _context;

        public SchoolRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
