using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces;
using ServiceInterfaces;
using DTO;
namespace Services
{
    public class TraineeService : ITraineeService
    {
        private IAppErrors modelerrors;
        private ITraineeDataAccess repository;

        public TraineeService(IAppErrors modelstate, ITraineeDataAccess repository)
        {
            this.modelerrors = modelstate;
            this.repository = repository;
        }
        public IEnumerable<TraineeCourseEnrollmentDTO> GetEnroledCourses(string traineeid)
        {
            return repository.GetEnroledCourses(traineeid);
        }

        public IEnumerable<TraineeExamEnrollmentDTO> GetEnroledExaminations(string traineeid)
        {
            return repository.GetEnroledExaminations(traineeid);
        }

        public string AddNew(TraineeDTO dto)
        {
            return repository.AddNew(dto);
        }

        public IEnumerable<TraineeDTO> GetAll()
        {
            return repository.GetAll();
        }




        public IEnumerable<CourseDTO> GetEnrolledCourses(string traineeid)
        {
            return repository.GetCourse(traineeid, true);
        }

        public IEnumerable<CourseDTO> GetUnEnrolledCourses(string traineeid)
        {
            return repository.GetCourse(traineeid, false);
        }

        




        public int EnrollToCourse(int courseid, string traineeid)
        {
            TraineeCourseEnrollmentDTO dto = new TraineeCourseEnrollmentDTO();
            dto.CourseID = courseid;
            dto.TraineeID = traineeid;
            dto.EnrolledDate = DateTime.Now;
            return repository.AddCourseEnrollment(dto);
        }


        public void UnEnrollCourse(int courseid,string traineeid)
        {
            repository.RemoveCourseEnrollment(courseid,traineeid);
        }


        public int FinishExam(TraineeExamEnrollmentDTO dto)
        {
            return repository.AddExamEnrollment(dto);
        }


        public IEnumerable<ExamResultsDTO> GetResults(string traineeid)
        {
            return repository.GetResults(traineeid);
        }
    }
}
