using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface IQuestionDataAccess
    {
        IEnumerable<ChoiceDTO> GetChoices(int questionid);
        int AddNew(QuestionDTO q);
        void Update(QuestionDTO q);
        void Delete(int questionid);

        QuestionDTO GetSelected(int questionid);
        void UpdateCorrectChoice(int questionid,int choiceid);


    }
}
