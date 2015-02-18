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
    public class ChoiceRepository : IChoiceDataAccess
    {
        ExaminationDBEntities1 context = new ExaminationDBEntities1();
        public void AddNew(ChoiceDTO c)
        {
            context.Choices.Add(ChoiceMapper.Map(c));
            context.SaveChanges();


        }

        public void Update(ChoiceDTO c)
        {
            context.Entry(ChoiceMapper.Map(c)).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int choiceid)
        {
            Choice sub = context.Choices.Find(choiceid);
            context.Choices.Remove(sub);
            context.SaveChanges();
        }
    }
}
