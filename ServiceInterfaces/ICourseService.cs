using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALInterfaces
{
    public interface ICourseService
    {
        bool AddNew(CourseDTO dto);
        bool Update(CourseDTO dto);
        bool Delete(int courceid);
        IEnumerable<CourseDTO> GetCourses();

        CourseDTO GetSelected(int courseid);
        IEnumerable<ExaminationDTO> GetExams(int courseid);

        bool Validate(CourseDTO course);
    }
}
