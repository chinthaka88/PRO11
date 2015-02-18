using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExaminationViewDTO
    {
       
        public int ID { get; set; }        
        public string Description { get; set; }        
        public int CutOffMark { get; set; }
        public int CourseID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<double> Marks { get; set; }
        public Nullable<bool> IsApproved { get; set; }

    }
}
