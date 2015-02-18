using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface ICourseDataAccess
    {
        void AddNew(CourseDTO dto);
        void Update(CourseDTO dto);
        void Delete(int courceid);
        IEnumerable<CourseDTO> GetCourses();

        CourseDTO GetSelected(int courseid);
        IEnumerable<ExaminationDTO> GetExams(int courseid);
    }
}
