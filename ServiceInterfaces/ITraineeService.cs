using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{

    public interface ITraineeService
    {
        IEnumerable<TraineeCourseEnrollmentDTO> GetEnroledCourses(string traineeid);
        IEnumerable<TraineeExamEnrollmentDTO> GetEnroledExaminations(string traineeid);
        string AddNew(TraineeDTO dto);
        IEnumerable<TraineeDTO> GetAll();
        IEnumerable<CourseDTO> GetEnrolledCourses(string traineeid);
        IEnumerable<CourseDTO> GetUnEnrolledCourses(string traineeid);
        int EnrollToCourse(int courseid, string traineeid);
        int FinishExam(TraineeExamEnrollmentDTO dto);
        void UnEnrollCourse(int courseid,string traineeid);
        IEnumerable<ExamResultsDTO> GetResults(string traineeid);
    }
}
