using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private MySchoolDbContext _context;

        public SubjectRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
