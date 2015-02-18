using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.QuestionViewModels
{
    public class QuestionManagerVM
    {
        IEnumerable<QuestionVM> Questions { get; set; }

    }
}