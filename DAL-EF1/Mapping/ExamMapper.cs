using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using AutoMapper;

namespace DAL_EF1.Mapping
{
    public class ExamMapper
    {

        public static Examination Map(ExaminationDTO dto)
        {

            Mapper.CreateMap<ExaminationDTO, Examination>();
            return Mapper.Map<Examination>(dto);
        }

        public static IEnumerable<ExaminationDTO> Map(IEnumerable<Examination> entity)
        {
            List<ExaminationDTO> dtos = new List<ExaminationDTO>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Examination, ExaminationDTO>();
                ExaminationDTO dto = Mapper.Map<ExaminationDTO>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
