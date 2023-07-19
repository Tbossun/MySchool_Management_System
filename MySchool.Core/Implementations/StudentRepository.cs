using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;

namespace MySchool.Core
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private MySchoolDbContext _context;

        public StudentRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
