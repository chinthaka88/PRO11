using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Helpers.ExamSession
{
    public class ExamQuestion
    {
        public int ID { get; set; }
        public string QuestionDescription { get; set; }
        public Nullable<int> CorrectAnsID { get; set; }
        public int ExaminationID { get; set; }
        public Nullable<int> AnsweredID { get; set; }
        public Nullable<bool> IsPinned { get; set; }
        public bool IsCorrect
        { 
            get
            {
                if (AnsweredID.HasValue)
                {
                    if (CorrectAnsID == AnsweredID)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}