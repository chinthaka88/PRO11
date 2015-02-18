using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using ExamWeb.Models.ExamViewModels;
using ExamWeb.Models.CourseViewModels;
using AutoMapper;
using ExamWeb.Models.ChoiceViewModels;

namespace ExamWeb.Helpers
{
    public class ChoiceMapper
    {

        public static IEnumerable<ChoiceVM> Map(IEnumerable<ChoiceDTO> entity)
        {
            List<ChoiceVM> dtos = new List<ChoiceVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<ChoiceDTO, ChoiceVM>();
                ChoiceVM dto = Mapper.Map<ChoiceVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }

        public static ChoiceDTO Map(ChoiceVM vm)
        {

            Mapper.CreateMap<ChoiceVM, ChoiceDTO>();
            return Mapper.Map<ChoiceDTO>(vm);
        }
    }
}