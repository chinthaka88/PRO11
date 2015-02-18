using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.QuestionViewModels
{
    public class QuestionVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Please Enter Question Description")]
        [Display(Name = "Question Description")]
        public string QuestionDescription { get; set; }
        public int? CorrectAnsID { get; set; }
        public int ExaminationID { get; set; }
    }
}