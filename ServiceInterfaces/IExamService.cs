using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace ServiceInterfaces
{
    public interface IExamService
    {
        int AddNewExam(ExaminationDTO ex);
        bool UpdateExam(ExaminationDTO ex);
        bool DeleteExam(int examid);
        IEnumerable<ExaminationDTO> GetExams();
        IEnumerable<QuestionDTO> GetQuestions(int examid);
        bool Validate(ExaminationDTO exam);
    }
}
