﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExaminationDBEntities1 : DbContext
    {
        public ExaminationDBEntities1()
            : base("name=ExaminationDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<TraineeCourseEnrollment> TraineeCourseEnrollments { get; set; }
        public virtual DbSet<TraineeExamEnrollment> TraineeExamEnrollments { get; set; }
    }
}
