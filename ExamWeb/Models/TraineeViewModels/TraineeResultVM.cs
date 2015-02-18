using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.TraineeViewModels
{
    public class TraineeResultVM
    {
        [Display(Name="EnrollmentID")]
        public int ID { get; set; }

        [Display(Name = "Strat Time")]
        public Nullable<System.DateTime> StartTime { get; set; }

        [Display(Name = "End Time")]
        public Nullable<System.DateTime> EndTime { get; set; }

        [Display(Name = "Marks")]
        public Nullable<double> Marks { get; set; }

        [Display(Name = "Examination ID")]
        public int ExaminationID { get; set; }

        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }

        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
    }
}