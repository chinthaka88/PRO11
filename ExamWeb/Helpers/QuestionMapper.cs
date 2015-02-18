using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using AutoMapper;
using ExamWeb.Models.QuestionViewModels;

namespace ExamWeb.Helpers
{
    public class QuestionMapper
    {
        public static IEnumerable<QuestionVM> Map(IEnumerable<QuestionDTO> entity)
        {
            List<QuestionVM> dtos = new List<QuestionVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<QuestionDTO, QuestionVM>();
                QuestionVM dto = Mapper.Map<QuestionVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }


        public static IEnumerable<QuestionDisplayVM> MapToDisplay(IEnumerable<QuestionDTO> entity)
        {
            List<QuestionDisplayVM> dtos = new List<QuestionDisplayVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<QuestionDTO, QuestionDisplayVM>();
                QuestionDisplayVM dto = Mapper.Map<QuestionDisplayVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }

        public static QuestionDTO Map(QuestionVM vm)
        {

            Mapper.CreateMap<QuestionVM, QuestionDTO>();
            return Mapper.Map<QuestionDTO>(vm);
        }
    }
}