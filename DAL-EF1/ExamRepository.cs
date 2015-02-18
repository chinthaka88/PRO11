using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces;
using System.Data.Entity;
using DTO;
using AutoMapper;
using DAL_EF1.Mapping;

namespace DAL_EF1
{
    public class ExamRepository : IExamDataAccess
    {
        ExaminationDBEntities1 context = new ExaminationDBEntities1();
        public int AddNew(ExaminationDTO ex)
        {
            int id=context.Examinations.Add(ExamMapper.Map(ex)).ID;
            context.SaveChanges();
            return id;
        }

        public void Update(ExaminationDTO ex)
        {
            context.Entry(ExamMapper.Map(ex)).State = EntityState.Modified;
            context.SaveChanges();
            
        }

        public void Delete(int examid)
        {
            Examination sub = context.Examinations.Find(examid);
            context.Examinations.Remove(sub);
            context.SaveChanges();
        }

        public IEnumerable<ExaminationDTO> GetExams()
        {
            
            List<Examination> exams= context.Examinations.ToList<Examination>();
            return ExamMapper.Map(exams);
        }

        public IEnumerable<QuestionDTO> GetQuestions(int examid)
        {
            List<Question> exams = new List<Question>();
            exams = context.Examinations.Find(examid).Questions.ToList();
            return QuestionMapper.Map(exams);
        }

        

      
    }
}
