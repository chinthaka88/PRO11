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
    public class CourseMapper
    {
        public static Course Map(CourseDTO dto)
        {

            Mapper.CreateMap<CourseDTO, Course>();
            return Mapper.Map<Course>(dto);
        }

        public static CourseDTO Map(Course obj)
        {

            Mapper.CreateMap<Course, CourseDTO>();
            return Mapper.Map<CourseDTO>(obj);
        }
        public static IEnumerable<CourseDTO> Map(IEnumerable<Course> entity)
        {
            List<CourseDTO> dtos = new List<CourseDTO>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Course, CourseDTO>();
                CourseDTO dto = Mapper.Map<CourseDTO>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
