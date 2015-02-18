using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces;
using DALInterfaces;
using DTO;

namespace Services
{
    public class QuestionService : IQuestionService
    {
        private IAppErrors modelerrors;
        private IQuestionDataAccess repository;

        public QuestionService(IAppErrors modelstate, IQuestionDataAccess repository)
        {
            this.modelerrors = modelstate;
            this.repository = repository;
        }

        public IEnumerable<ChoiceDTO> GetChoices(int questionid)
        {
            return repository.GetChoices(questionid);
        }

        public int AddNew(QuestionDTO dto)
        {
            if (Validate(dto))
            {
                return repository.AddNew(dto);
               
            }
            return 0;
        }

        public bool Update(QuestionDTO dto)
        {
            if (Validate(dto))
            {
                repository.Update(dto);
                return true;
            }
            return false;
        }

        public bool Delete(int questionid)
        {
            repository.Delete(questionid);
            return true;
        }

        public bool Validate(QuestionDTO ques)
        {
            if (ques.QuestionDescription == null || ques.QuestionDescription == "")
                modelerrors.AddError("QuestionDescription", "Please Enter Question Description");
            return modelerrors.IsValid;
        }

        public QuestionDTO GetSelected(int questionid)
        {
            return repository.GetSelected(questionid);
        }


        public void SetCorrectChoice(int questionid, int choiceid)
        {
            repository.UpdateCorrectChoice(questionid, choiceid);
        }


        public int GetCorrectAnswer(int questionid)
        {
            QuestionDTO dto=this.GetSelected(questionid);
            return dto.CorrectAnsID ?? 0;
        }
    }
}
