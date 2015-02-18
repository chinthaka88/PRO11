using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuestionDTO
    {
        public int ID { get; set; }
        public string QuestionDescription { get; set; }
        public int? CorrectAnsID { get; set; }
        public int ExaminationID { get; set; }
    }
}
