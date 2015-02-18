using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using ExamWeb.Models.ExamViewModels;
using AutoMapper;

namespace ExamWeb.Helpers
{
    public class ExamMapper
    {
        public static IEnumerable<ExamVM> Map(IEnumerable<ExaminationDTO> entity)
        {
            List<ExamVM> dtos = new List<ExamVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<ExaminationDTO, ExamVM>();
                ExamVM dto = Mapper.Map<ExamVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }

        public static ExaminationDTO Map(ExamVM vm)
        {

            Mapper.CreateMap<ExamVM, ExaminationDTO>();
            return Mapper.Map<ExaminationDTO>(vm);
        }

    }
}