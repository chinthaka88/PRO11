using ExamWeb.Models.QuestionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.ExamViewModels
{
    public class QuestionListVM
    {

        public IEnumerable<QuestionVM> Questions { get; set; }
    }
}