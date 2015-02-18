using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.ExamViewModels
{
    public class ExamListVM
    {
        public IEnumerable<ExamVM> Exams { get;set; }
    }
}