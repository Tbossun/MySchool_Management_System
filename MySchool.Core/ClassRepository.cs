using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private MySchoolDbContext _context;

        public ClassRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Class Newclass)
        {
            _context.Entry(Newclass).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
