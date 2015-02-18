using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.ChoiceViewModels
{
    public class ChoiceListVM
    {
        public IEnumerable<ChoiceVM> Choices { get; set; }
    }
}