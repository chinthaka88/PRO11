using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.TraineeViewModels
{
    public class TraineeVM
    {
        [Display(Name = "User Name")]
        public string ID { get; set; }
        [Display(Name = "Trainee Name")]
        public string TraineeName { get; set; }
    }
}