using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using AutoMapper;
using ExamWeb.Models.TraineeViewModels;

namespace ExamWeb.Helpers
{
    public class TraineeExamMapping
    {
        public static IEnumerable<TraineeExamEnrollmentVM> Map(IEnumerable<TraineeExamEnrollmentDTO> entity)
        {
            List<TraineeExamEnrollmentVM> dtos = new List<TraineeExamEnrollmentVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<TraineeExamEnrollmentDTO, TraineeExamEnrollmentVM>();
                TraineeExamEnrollmentVM dto = Mapper.Map<TraineeExamEnrollmentVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}