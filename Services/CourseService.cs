using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces;
using DALInterfaces;
using DTO;

namespace Services
{
    public class CourseService : ICourseService
    {
        private IAppErrors modelerrors;
        private ICourseDataAccess repository;

        public CourseService(IAppErrors modelstate, ICourseDataAccess repository)
        {
            this.modelerrors = modelstate;
            this.repository = repository;
        }

        public bool AddNew(CourseDTO dto)
        {
            if(Validate(dto))
            {
                repository.AddNew(dto);
                return true;
            }
            return false;
        }

        public bool Update(CourseDTO dto)
        {
            if (Validate(dto))
            {
                repository.Update(dto);
                return true;
            }
            return false;
        }

        public bool Delete(int courceid)
        {
            repository.Delete(courceid);
            return true;
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            return repository.GetCourses();
        }

        public CourseDTO GetSelected(int courseid)
        {
            return repository.GetSelected(courseid);
        }

        public IEnumerable<ExaminationDTO> GetExams(int courseid)
        {
            return repository.GetExams(courseid);
        }

        public bool Validate(CourseDTO course)
        {
            if (course.CourseName == null || course.CourseName == "")
                modelerrors.AddError("CourseName", "Please Enter Course Name");
            
            return modelerrors.IsValid;
        }
    }
}
