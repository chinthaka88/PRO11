using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF1.Mapping
{
    public class CommonMapper
    {
        public static dynamic Map(dynamic dto)
        {

            Mapper.CreateMap<dynamic, dynamic>();
            return Mapper.Map<dynamic>(dto);
        }

        public static IEnumerable<dynamic> Map(IEnumerable<dynamic> entity)
        {
            List<dynamic> dtos = new List<dynamic>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Course, dynamic>();
                dynamic dto = Mapper.Map<dynamic>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
