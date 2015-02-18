using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TraineeCourseEnrollmentDTO
    {
        public int ID { get; set; }
        public string TraineeID { get; set; }
        public int CourseID { get; set; }
        public System.DateTime EnrolledDate { get; set; }
        public Nullable<bool> IsEnrolled { get; set; }
        public string CourseName { get; set; }
    }
}
