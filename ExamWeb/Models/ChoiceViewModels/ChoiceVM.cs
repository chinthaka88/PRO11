using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.ChoiceViewModels
{
    public class ChoiceVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Choice Description")]
        [Display(Name = "Choice Description")]
        public string ChoiceDescription { get; set; }

        public string AnswerColor { get; set; }
        public int QuestionID { get; set; }
    }
}