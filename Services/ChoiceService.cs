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
    public class ChoiceService : IChoiceService
    {

        private IAppErrors modelerrors;
        private IChoiceDataAccess repository;

        public ChoiceService(IAppErrors modelstate, IChoiceDataAccess repository)
        {
            this.modelerrors = modelstate;
            this.repository = repository;
        }

        public bool AddNew(ChoiceDTO c)
        {
            if (Validate(c))
            {
                repository.AddNew(c);
                return true;
            }
            return false;
        }

        public bool Update(ChoiceDTO c)
        {
            if (Validate(c))
            {
                repository.Update(c);
                return true;
            }
            return false;
        }

        public bool Delete(int choiceid)
        {
            repository.Delete(choiceid);
            return true;
        }


        public bool Validate(ChoiceDTO choice)
        {
            if (choice.ChoiceDescription == null || choice.ChoiceDescription == "")
                modelerrors.AddError("ChoiceDescription", "Please Enter Choice Description");
            if (choice.QuestionID == null || choice.QuestionID == 0)
                modelerrors.AddError("QuestionID", "Please Select Question");
            return modelerrors.IsValid;
        }
    }
}
