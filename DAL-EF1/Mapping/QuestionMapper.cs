using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL_EF1;
using AutoMapper;

namespace DAL_EF1.Mapping
{
    public class QuestionMapper
    {
        public static Question Map(QuestionDTO dto)
        {

            Mapper.CreateMap<QuestionDTO, Question>();
            return Mapper.Map<Question>(dto);
        }

        public static QuestionDTO Map(Question obj)
        {

            Mapper.CreateMap<Question, QuestionDTO>();
            return Mapper.Map<QuestionDTO>(obj);
        }
        public static IEnumerable<QuestionDTO> Map(IEnumerable<Question> entity)
        {
            List<QuestionDTO> dtos = new List<QuestionDTO>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Question, QuestionDTO>();
                QuestionDTO dto = Mapper.Map<QuestionDTO>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
