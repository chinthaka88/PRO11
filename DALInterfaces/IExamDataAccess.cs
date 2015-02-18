using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface IExamDataAccess
    {
        int AddNew(ExaminationDTO ex);
        void Update(ExaminationDTO ex);
        void Delete(int examid);
        IEnumerable<ExaminationDTO> GetExams();
        IEnumerable<QuestionDTO> GetQuestions(int examid);
       


    }
}
