using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ExamWeb.Models.ChoiceViewModels;

namespace ExamWeb.Models.QuestionViewModels
{
    public class QuestionDisplayVM
    {
        public int ID { get; set; }
        public string QuestionDescription { get; set; }
        public int? CorrectAnsID { get; set; }
        public int ExaminationID { get; set; }
        public int Duration { get; set; }
        public IEnumerable<ChoiceVM> Choices { get; set; }
    }
}