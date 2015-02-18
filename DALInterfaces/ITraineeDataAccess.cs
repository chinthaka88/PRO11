using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface ITraineeDataAccess
    {
        IEnumerable<TraineeCourseEnrollmentDTO> GetEnroledCourses(string traineeid);
        IEnumerable<TraineeExamEnrollmentDTO> GetEnroledExaminations(string traineeid);
        string AddNew(TraineeDTO dto);
        IEnumerable<TraineeDTO> GetAll();
        IEnumerable<CourseDTO> GetCourse(string traineeid,bool isenrolled);
        int AddCourseEnrollment(TraineeCourseEnrollmentDTO dto);
        int AddExamEnrollment(TraineeExamEnrollmentDTO dto);
        IEnumerable<ExamResultsDTO> GetResults(string traineeid);
        void RemoveCourseEnrollment(int courseid,string traineeid);

    }
}
