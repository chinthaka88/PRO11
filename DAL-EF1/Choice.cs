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
    
    public partial class Choice
    {
        public int ID { get; set; }
        public string ChoiceDescription { get; set; }
        public int QuestionID { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
