﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExamResultsDTO
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Marks { get; set; }
        public int ExaminationID { get; set; }
        public string ExamName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
    }
}
