using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWeb.Models.CourseViewModels;

namespace ExamWeb.Models.ExamViewModels
{
    public class ExamManagerVM
    {
        public int CourseID { get; set; }
        public IEnumerable<ExamVM> Exams { get; set; }
        public IEnumerable<CourseVM> Courses { get; set; }
    }
}