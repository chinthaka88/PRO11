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
using ExamWeb.Models.ExamViewModels;
using ExamWeb.Helpers;

namespace ExamWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExamManagerController : Controller
    {
        IAppErrors error;
        IAppErrors error_exam;
        ICourseService service;
        IExamService service_exam;


        public ExamManagerController()
        {
            
            error = new AppErrors();
            error_exam = new AppErrors();
            ICourseDataAccess repo = new CourseRepository();
            IExamDataAccess repo_exam = new ExamRepository();
            service = new CourseService(error, repo);
            service_exam = new ExamService(error_exam, repo_exam);

        }

        //
        // GET: /Exam/
        public ActionResult Index(int id=1)
        {
            ExamManagerVM vm = new ExamManagerVM();
            IEnumerable<CourseDTO> dto = service.GetCourses();
            vm.Courses = CourseMapper.Map(dto);
            vm.Exams = ExamMapper.Map(service.GetExams(id));
            vm.CourseID = id;
            return View(vm);
         
            
        }

        // GET: /Exam/GetCreateView
        public ActionResult GetCreateView()
        {
            return PartialView("_CourseForm");
        }


        // GET: /Exam/CreatePartial/<courseid>
        public ActionResult CreatePartial(int? id)
        {
            ExamVM vm = new ExamVM();
            vm.CourseID = id ?? 0;
            return PartialView("_AddExamination", vm);
        }

        //
        // POST: /Exam/Create
        [HttpPost]
        public ActionResult Create(ExamVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ExaminationDTO dto = ExamMapper.Map(vm);
                    int newid=service_exam.AddNewExam(dto);
                    if (newid!=0)
                    {
                        return RedirectToAction("Index", new {id=dto.CourseID });
                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

       
    }
}
