using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DALInterfaces
{
    public interface IChoiceService
    {
        bool AddNew(ChoiceDTO c);
        bool Update(ChoiceDTO c);

        bool Delete(int choiceid);
        bool Validate(ChoiceDTO choice);


    }
}
