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
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private MySchoolDbContext _context;

        public QuestionRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Question NewQuestion)
        {
            _context.Entry(NewQuestion).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
