using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces;
using DTO;
using DAL_EF1.Mapping;

namespace DAL_EF1
{
    public class TraineeRepository : ITraineeDataAccess
    {
        ExaminationDBEntities1 db = new ExaminationDBEntities1();
        public IEnumerable<TraineeCourseEnrollmentDTO> GetEnroledCourses(string traineeid)
        {
           IEnumerable<TraineeCourseEnrollment> cenroll= db.TraineeCourseEnrollments.Where(c => c.TraineeID == traineeid && c.IsEnrolled==true);
           return TraineeCourseEnrollmentMapping.Map(cenroll);
        }

        public IEnumerable<TraineeExamEnrollmentDTO> GetEnroledExaminations(string traineeid)
        {
            IEnumerable<TraineeExamEnrollment> examall = db.TraineeExamEnrollments.Where(c => c.TraineeID == traineeid && c.IsApproved == true);
            return TraineeExamEnrollmentMapping.Map(examall);
        }

        public string AddNew(TraineeDTO dto)
        {
            string id = db.Trainees.Add(TraineeMapper.Map(dto)).ID;
            db.SaveChanges();
            return id;
        }

        public IEnumerable<TraineeDTO> GetAll()
        {
            List<Trainee> trainees = db.Trainees.ToList<Trainee>();
            return TraineeMapper.Map(trainees);
        }






        public IEnumerable<CourseDTO> GetCourse(string traineeid, bool isenrolled)
        {

            List<CourseDTO> course_dtos = new List<CourseDTO>();
            if (isenrolled)
            {
                    var enrolled_courses = db.TraineeCourseEnrollments.Where(e => e.TraineeID == traineeid);
                    foreach (TraineeCourseEnrollment enroll in enrolled_courses)
                    {
                        course_dtos.Add(new CourseDTO() { CourseName = enroll.Course.CourseName, ID = enroll.Course.ID });
                    }
                    return course_dtos;
            }
            else
            {
                var excludeIDs = db.TraineeCourseEnrollments.Where(w => w.TraineeID == traineeid).Select(s => s.CourseID);
                var unenrolled = db.Courses.Where(w => !excludeIDs.Contains(w.ID)).ToList();
                foreach (Course unenroll in unenrolled)
                {
                    course_dtos.Add(new CourseDTO() { CourseName = unenroll.CourseName, ID = unenroll.ID });
                }
                return course_dtos;
            }

           
            

        }


        public int AddCourseEnrollment(TraineeCourseEnrollmentDTO dto)
        {
            int id = db.TraineeCourseEnrollments.Add(TraineeCourseEnrollmentMapping.Map(dto)).ID;
            db.SaveChanges();
            return id;
        }


        public void RemoveCourseEnrollment(int courseid,string traineeid)
        {
            TraineeCourseEnrollment tr = db.TraineeCourseEnrollments.Where(c=>c.CourseID == courseid && c.TraineeID==traineeid).FirstOrDefault();
            db.TraineeCourseEnrollments.Remove(tr);
            db.SaveChanges();
        }





        public int AddExamEnrollment(TraineeExamEnrollmentDTO dto)
        {
            int id = db.TraineeExamEnrollments.Add(TraineeExamEnrollmentMapping.Map(dto)).ID;
            db.SaveChanges();
            return id;
        }


        public IEnumerable<ExamResultsDTO> GetResults(string traineeid)
        {
            IEnumerable<TraineeExamEnrollment> enrollments = db.TraineeExamEnrollments.Where(t => t.TraineeID == traineeid);
            List<ExamResultsDTO> dtos = new List<ExamResultsDTO>();
            foreach(TraineeExamEnrollment data in enrollments)
            {
                dtos.Add(new ExamResultsDTO()
                    {
                        CourseID=data.Examination.CourseID,
                        CourseName=data.Examination.Course.CourseName,
                        EndTime=data.EndTime,
                        ExaminationID=data.ExaminationID,
                        ExamName=data.Examination.Description,
                        ID=data.ID,
                        Marks=data.Marks,
                        StartTime=data.StartTime
                    });
            }
            return dtos;
        }
    }
}
