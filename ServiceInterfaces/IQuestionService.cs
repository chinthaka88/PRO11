using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface IQuestionService
    {
        IEnumerable<ChoiceDTO> GetChoices(int questionid);
        int AddNew(QuestionDTO q);
        bool Update(QuestionDTO q);
        bool Delete(int questionid);

        bool Validate(QuestionDTO ques);

        QuestionDTO GetSelected(int questionid);
        void SetCorrectChoice(int questionid, int choiceid);

        int GetCorrectAnswer(int questionid);


    }
}
