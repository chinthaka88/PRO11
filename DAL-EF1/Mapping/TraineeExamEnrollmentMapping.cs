using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF1.Mapping
{
    public class TraineeExamEnrollmentMapping
    {
        public static IEnumerable<TraineeExamEnrollmentDTO> Map(IEnumerable<TraineeExamEnrollment> entity)
        {
            List<TraineeExamEnrollmentDTO> dtos = new List<TraineeExamEnrollmentDTO>();
            foreach (TraineeExamEnrollment x in entity)
            {
                TraineeExamEnrollmentDTO dto = new TraineeExamEnrollmentDTO()
                {
                   EndTime=x.EndTime,
                   ExaminationID=x.ExaminationID,
                   ExamName=x.Examination.Description,
                   ID=x.ID,
                   IsApproved=x.IsApproved,
                   Marks=x.Marks,
                   StartTime=x.StartTime,
                   TraineeID=x.TraineeID
                };
                dtos.Add(dto);

            }
            return dtos;
        }

        public static TraineeExamEnrollment Map(TraineeExamEnrollmentDTO dto)
        {

            Mapper.CreateMap<TraineeExamEnrollmentDTO, TraineeExamEnrollment>();
            return Mapper.Map<TraineeExamEnrollment>(dto);
        }
    }
}
