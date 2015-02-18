using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using ExamWeb.Models.CourseViewModels;
using AutoMapper;

namespace ExamWeb.Helpers
{
    public class CourseMapper
    {
        public static CourseDTO Map(CourseVM vm)
        {

            Mapper.CreateMap<CourseVM, CourseDTO>();
            return Mapper.Map<CourseDTO>(vm);
        }

        public static CourseVM Map(CourseDTO obj)
        {

            Mapper.CreateMap<CourseDTO, CourseVM>();
            return Mapper.Map<CourseVM>(obj);
        }

        public static IEnumerable<CourseVM> Map(IEnumerable<CourseDTO> entity)
        {
            List<CourseVM> dtos = new List<CourseVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<CourseDTO, CourseVM>();
                CourseVM dto = Mapper.Map<CourseVM>(x);
                dtos.Add(dto);

            }
            return dtos;
        }

        
        
    }
}