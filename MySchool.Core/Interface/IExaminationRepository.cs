using MySchool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Core.Interface
{
    public interface IExaminationRepository : IRepository<Examination>
    {
        void Update(Examination NewExam);
    }
}
