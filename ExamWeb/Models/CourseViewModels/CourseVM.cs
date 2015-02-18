using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.CourseViewModels
{
    public class CourseVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Please Enter Course Name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
    }
}