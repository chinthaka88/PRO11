using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWeb.Models.TraineeViewModels;
using DTO;
using AutoMapper;

namespace ExamWeb.Helpers
{
    public class TraineeMapping
    {
        public static TraineeVM Map(TraineeDTO dto)
        {

            Mapper.CreateMap<TraineeDTO, TraineeVM>();
            return Mapper.Map<TraineeVM>(dto);
        }

        public static TraineeDTO Map(TraineeVM obj)
        {

            Mapper.CreateMap<TraineeVM, TraineeDTO>();
            return Mapper.Map<TraineeDTO>(obj);
        }
        public static IEnumerable<TraineeVM> Map(IEnumerable<TraineeDTO> entity)
        {
            List<TraineeVM> vms = new List<TraineeVM>();
            foreach (var x in entity)
            {
                Mapper.CreateMap<TraineeDTO, TraineeVM>();
                TraineeVM vm = Mapper.Map<TraineeVM>(x);
                vms.Add(vm);

            }
            return vms;
        }
    }
}