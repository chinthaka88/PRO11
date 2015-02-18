using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALInterfaces;
using System.Data.Entity;
using DTO;
using AutoMapper;
using DAL_EF1.Mapping;


namespace DAL_EF1
{
    public class CourseRepository : ICourseDataAccess 
    {
        ExaminationDBEntities1 context = new ExaminationDBEntities1();
        public void AddNew(CourseDTO dto)
        {
            context.Courses.Add(CourseMapper.Map(dto));
            context.SaveChanges();
        }

        public void Update(CourseDTO dto)
        {
            context.Entry(CourseMapper.Map(dto)).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int courceid)
        {
            Course sub = context.Courses.Find(courceid);
            context.Courses.Remove(sub);
            context.SaveChanges();
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            List<Course> courses = context.Courses.ToList<Course>();
            return CourseMapper.Map(courses);
        }

        public CourseDTO GetSelected(int courseid)
        {
            Course course = context.Courses.Find(courseid);
            return CourseMapper.Map(course);
        }

        public IEnumerable<ExaminationDTO> GetExams(int courseid)
        {
            IEnumerable<Examination> exams = context.Courses.Find(courseid).Examinations;
            return ExamMapper.Map(exams);

        }



        
    }
}
