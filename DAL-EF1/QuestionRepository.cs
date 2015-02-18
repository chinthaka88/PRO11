using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
using AutoMapper;
using DAL_EF1.Mapping;
using DALInterfaces;


namespace DAL_EF1
{
    public class QuestionRepository : IQuestionDataAccess
    {
        ExaminationDBEntities1 context = new ExaminationDBEntities1();
        public IEnumerable<ChoiceDTO> GetChoices(int questionid)
        {
            IEnumerable<Choice> choices = context.Questions.Find(questionid).Choices;
            return ChoiceMapper.Map(choices);
        }

        public int AddNew(QuestionDTO q)
        {
            int id=context.Questions.Add(QuestionMapper.Map(q)).ID;
            context.SaveChanges();
            return id;
        }

        public void Update(QuestionDTO q)
        {
            context.Entry(QuestionMapper.Map(q)).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int questionid)
        {
            Question q = context.Questions.Find(questionid);
            context.Questions.Remove(q);
            context.SaveChanges();
        }

        public QuestionDTO GetSelected(int questionid)
        {
            Question q = context.Questions.Find(questionid);
            return QuestionMapper.Map(q);
        }


        public void UpdateCorrectChoice(int questionid,int choiceid)
        {
            Question q = context.Questions.Find(questionid);
            q.CorrectAnsID = choiceid;
            context.Entry(q).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
