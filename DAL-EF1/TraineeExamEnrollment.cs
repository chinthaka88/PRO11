//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_EF1
{
    using System;
    using System.Collections.Generic;
    
    public partial class TraineeExamEnrollment
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Marks { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string TraineeID { get; set; }
        public int ExaminationID { get; set; }
    
        public virtual Examination Examination { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
