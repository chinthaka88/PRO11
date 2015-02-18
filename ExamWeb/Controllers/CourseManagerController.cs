using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_EF1;
using DALInterfaces;
using Services;
using ServiceInterfaces;
using DTO;
using ExamWeb.Models.CourseViewModels;
using ExamWeb.Models.ExamViewModels;
using ExamWeb.Helpers;

namespace ExamWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseManagerController : Controller
    {
        ICourseService service_course;
        IAppErrors error_course; 

        public CourseManagerController()
        {
            error_course=new AppErrors();
            ICourseDataAccess repo = new CourseRepository();
            service_course = new CourseService(error_course, repo);
        }

        // GET: /CourseMnager/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /CourseMnager/GetExamsByCourse/<courseid>
        public ActionResult GetExamsByCourse(int? id)
        {
            IEnumerable<ExamVM> exams = new List<ExamVM>();
            exams=ExamMapper.Map(service_course.GetExams(id ?? 0));          
            return PartialView("_ExamsTable",exams);
        }

        // GET: /CourseMnager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CourseMnager/Create
        public ActionResult Create()
        {
            return PartialView("_AddCourse");
        }

        //
        // POST: /CourseMnager/Create
        [HttpPost]
        public ActionResult Create(CourseVM vm)
        {
            
                if (ModelState.IsValid)
                {
                    CourseDTO dto = CourseMapper.Map(vm);
                    if (service_course.AddNew(dto))
                    {
                        return RedirectToAction("Index", "ExamManager");
                    }
                }
                return RedirectToAction("Index", "ExamManager");

                
            
        }

 
       
    }
}
