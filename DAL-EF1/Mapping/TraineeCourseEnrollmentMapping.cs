using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF1.Mapping
{
    public class TraineeCourseEnrollmentMapping
    {
        public static IEnumerable<TraineeCourseEnrollmentDTO> Map(IEnumerable<TraineeCourseEnrollment> entity)
        {
            List<TraineeCourseEnrollmentDTO> dtos = new List<TraineeCourseEnrollmentDTO>();
            foreach (TraineeCourseEnrollment x in entity)
            {
                TraineeCourseEnrollmentDTO dto = new TraineeCourseEnrollmentDTO()
                    {
                        CourseID=x.CourseID,
                        CourseName=x.Course.CourseName,
                        EnrolledDate =x.EnrolledDate,
                        ID=x.ID,
                        IsEnrolled=x.IsEnrolled,
                        TraineeID=x.TraineeID
                    };
                dtos.Add(dto);

            }
            return dtos;
        }

        public static TraineeCourseEnrollment Map(TraineeCourseEnrollmentDTO dto)
        {

            Mapper.CreateMap<TraineeCourseEnrollmentDTO, TraineeCourseEnrollment>();
            return Mapper.Map<TraineeCourseEnrollment>(dto);
        }
    }
}
