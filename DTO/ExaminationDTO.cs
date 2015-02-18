using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class ExaminationDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]//
        public string Description { get; set; }
        [DataMember]
        public int CutOffMark { get; set; }
        [DataMember]
        public int CourseID { get; set; }
        [DataMember]
        public Nullable<int> Duration { get; set; }
    }
}
