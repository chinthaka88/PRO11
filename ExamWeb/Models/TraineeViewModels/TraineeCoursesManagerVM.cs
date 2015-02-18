using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWeb.Models.CourseViewModels;
using System.ComponentModel.DataAnnotations;

namespace ExamWeb.Models.TraineeViewModels
{
    public class TraineeCoursesManagerVM
    {
        [Display(Name="Course ID")]
        public string CourseID { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public IEnumerable<CourseVM> EnrolledCourses { get; set; }
        public IEnumerable<CourseVM> UnEnrolledCourses { get; set; }
    }
}