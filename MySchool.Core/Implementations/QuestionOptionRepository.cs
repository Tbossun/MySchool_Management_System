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
    public class QuestionOptionRepository : Repository<QuestionOption>, IQuestionOptionRepository
    {
        private MySchoolDbContext _context;

        public QuestionOptionRepository(MySchoolDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(QuestionOption NewOption)
        {
            _context.Entry(NewOption).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
