using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private MySchoolDbContext _context;

        public TeacherRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
