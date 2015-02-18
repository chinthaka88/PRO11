using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DALInterfaces
{
    public interface IChoiceDataAccess
    {
        void AddNew(ChoiceDTO c);
        void Update(ChoiceDTO c);

        void Delete(int choiceid);
        


    }
}
