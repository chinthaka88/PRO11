using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.ExamViewModels
{
    public class ExamVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Enter Cut Off Mark")]
        [Display(Name = "Cut Off Mark")]
        public int CutOffMark { get; set; }
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please Enter Duration")]
        [Display(Name = "Duration (Munites)")]
        public Nullable<int> Duration { get; set; }
    }
}