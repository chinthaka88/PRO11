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
    public class ChoiceMapper
    {
        public static Choice Map(ChoiceDTO dto)
        {

            Mapper.CreateMap<ChoiceDTO, Choice>();
            return Mapper.Map<Choice>(dto);
        }

        public static ChoiceDTO Map(Choice obj)
        {

            Mapper.CreateMap<Choice, ChoiceDTO>();
            return Mapper.Map<ChoiceDTO>(obj);
        }

        public static IEnumerable<ChoiceDTO> Map(IEnumerable<Choice> entity)
        {
            List<ChoiceDTO> dtos = new List<ChoiceDTO>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Choice, ChoiceDTO>();
                ChoiceDTO dto = Mapper.Map<ChoiceDTO>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
