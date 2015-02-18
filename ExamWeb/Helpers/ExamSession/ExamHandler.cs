using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Helpers.ExamSession
{
    public class ExamHandler
    {
        List<ExamQuestion> questions = new List<ExamQuestion>();
        public DateTime StratTime { get; set; }
        public int ExamID { get; set; }

        public List<ExamQuestion> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public double GetMarks()
        {
            return questions.Where(x => x.IsCorrect == true).Count();
        }

        public ExamQuestion GetSelected(int quesid)
        {
            return questions.Single(x => x.ID == quesid);
        }
        public void AddAnswer(int quesid,int choiceid)
        {
            var question = questions.Single(x => x.ID==quesid);
            question.AnsweredID = choiceid;
        }

        public void SetPin(int quesid)
        {
            var question = questions.Single(x => x.ID == quesid);
            question.IsPinned = true;
        }

        public void RemovePin(int quesid)
        {
            var question = questions.Single(x => x.ID == quesid);
            question.IsPinned = false;
        }

        public IEnumerable<ExamQuestion> GetAnswered()
        {
            return questions.Where(x => x.AnsweredID.HasValue);
        }

        public IEnumerable<ExamQuestion> GetUnAnswered()
        {
            return questions.Where(x => !x.AnsweredID.HasValue);
        }

        public IEnumerable<ExamQuestion> GetPinned()
        {
            return questions.Where(x => x.IsPinned==true);
        }

        
        public IEnumerable<ExamQuestion> GetAll()
        {
            return questions;
        }
    }
}