using Microsoft.EntityFrameworkCore;
using MySchool.Core.Interface;
using MySchool.Data;
using MySchool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Core
{
    public class ExaminationRepository : Repository<Examination>, IExaminationRepository
    {
        private MySchoolDbContext _context;

        public ExaminationRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Examination NewExam)
        {
            _context.Entry(NewExam).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
