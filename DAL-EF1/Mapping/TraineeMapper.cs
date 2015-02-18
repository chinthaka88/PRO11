using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF1.Mapping
{
    public class TraineeMapper
    {
        public static Trainee Map(TraineeDTO dto)
        {

            Mapper.CreateMap<TraineeDTO, Trainee>();
            return Mapper.Map<Trainee>(dto);
        }

        public static TraineeDTO Map(Trainee obj)
        {

            Mapper.CreateMap<Trainee, TraineeDTO>();
            return Mapper.Map<TraineeDTO>(obj);
        }
        public static IEnumerable<TraineeDTO> Map(IEnumerable<Trainee> entity)
        {
            List<TraineeDTO> dtos = new List<TraineeDTO>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<Trainee, TraineeDTO>();
                TraineeDTO dto = Mapper.Map<TraineeDTO>(x);
                dtos.Add(dto);

            }
            return dtos;
        }
    }
}
