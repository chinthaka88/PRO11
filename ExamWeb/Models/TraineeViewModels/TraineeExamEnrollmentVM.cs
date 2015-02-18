using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamWeb.Models.TraineeViewModels
{
    public class TraineeExamEnrollmentVM
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Marks { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string TraineeID { get; set; }
        public int ExaminationID { get; set; }
        public string ExamName { get; set; }
    }
}