using DAL_EF1;
using DALInterfaces;
using ServiceInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using ExamWeb.Models.TraineeViewModels;
using ExamWeb.Helpers;
using ExamWeb.Helpers.ExamSession;
using ExamWeb.Models.ExamViewModels;
using ExamWeb.Models.ChoiceViewModels;

namespace ExamWeb.Controllers
{
    [Authorize(Roles = "User")]
    public class CourseEnrollmentController : Controller
    {

        IAppErrors error_trainee;
        IAppErrors error_exam;
        IAppErrors error_course;
        IAppErrors error_ques;
        ITraineeService service_trainee;
        IExamService service_exam;
        ICourseService service_course;
        IQuestionService service_ques;
        string KEY_EXAM_SESSION = "tempexam";

        public CourseEnrollmentController()
        {
            error_trainee = new AppErrors();
            ITraineeDataAccess repo = new TraineeRepository();
            service_trainee = new TraineeService(error_trainee, repo);

            error_exam = new AppErrors();
            IExamDataAccess repo_exam = new ExamRepository();
            service_exam = new ExamService(error_exam, repo_exam);

            error_course = new AppErrors();
            ICourseDataAccess repo_course = new CourseRepository();
            service_course = new CourseService(error_course, repo_course);

            error_ques = new AppErrors();
            IQuestionDataAccess repo_ques = new QuestionRepository();
            service_ques = new QuestionService(error_ques, repo_ques);
            
        }

        
        // GET: /CourseEnrollment/
        public ActionResult Index()
        {
           
                string userid = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
                TraineeCoursesManagerVM vm = new TraineeCoursesManagerVM();
                IEnumerable<CourseDTO> enrolleddto = service_trainee.GetEnrolledCourses(userid);
                IEnumerable<CourseDTO> unenrolleddto = service_trainee.GetUnEnrolledCourses(userid);
                vm.EnrolledCourses = CourseMapper.Map(enrolleddto);
                vm.UnEnrolledCourses = CourseMapper.Map(unenrolleddto);
                return View(vm);
           
           
        }


        // GET: /CourseEnrollment/Enroll/<courseid>
        public ActionResult Enroll(int? id)
        {
            string userid = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
            service_trainee.EnrollToCourse(id ?? 0,userid);
            return RedirectToAction("Index","CourseEnrollment");
        }

        // GET: /CourseEnrollment/UnEnroll/<courseid>
        public ActionResult UnEnroll(int? id)
        {
            string userid = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
            service_trainee.UnEnrollCourse(id ?? 0, userid);
            return RedirectToAction("Index", "CourseEnrollment");
        }

        // GET: /CourseEnrollment/Exams/<courseid>
        public ActionResult Exams(int? id)
        {
            IEnumerable<ExamVM> exams = new List<ExamVM>();
            exams = ExamMapper.Map(service_course.GetExams(id ?? 0));  
            return View(exams);
        }

        // GET: /CourseEnrollment/SetAnswer/<questionid>/correctChoiceId=<choiceid>
        public JsonResult SetAnswer(int? id, int? correctChoiceId)
        {
            ExamHandler handler = (ExamHandler)Session[KEY_EXAM_SESSION];
            handler.AddAnswer(id ?? 0, correctChoiceId ?? 0);
            var result = new { Success = "True" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: /CourseEnrollment/SubmitExam/<examid>
        public ActionResult SubmitExam()
        {
            ExamHandler handler = (ExamHandler)Session[KEY_EXAM_SESSION];
            string userid = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
            TraineeExamEnrollmentDTO dto = new TraineeExamEnrollmentDTO();
            dto.StartTime = handler.StratTime;
            dto.Marks = handler.GetMarks();
            ViewBag.Marks = handler.GetMarks();
            dto.ExaminationID = handler.ExamID;
            dto.EndTime = DateTime.Now;
            dto.TraineeID = userid;
            service_trainee.FinishExam(dto);
            Session[KEY_EXAM_SESSION] = null;
            return View();
        }


        public ActionResult Results()
        {
            string userid = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
            IEnumerable<ExamResultsDTO> results = service_trainee.GetResults(userid);
            List<TraineeResultVM> resultsvms=new List<TraineeResultVM>();
            foreach(ExamResultsDTO dto in results)
            {
                resultsvms.Add(new TraineeResultVM()
                    {
                        CourseID=dto.CourseID,
                        CourseName=dto.CourseName,
                        EndTime=dto.EndTime,
                        ExaminationID=dto.ExaminationID,
                        ExamName=dto.ExamName,
                        ID=dto.ID,
                        Marks=dto.Marks,
                        StartTime=dto.StartTime
                    });
            }
            return View(resultsvms);
        }
        // GET: /CourseEnrollment/GetChoicesByQuestion/<questionid>
        public ActionResult GetChoicesByQuestion(int? id)
        {
            IEnumerable<ChoiceVM> cdto = ChoiceMapper.Map(service_ques.GetChoices(id ?? 0));
            ExamHandler handler = (ExamHandler)Session[KEY_EXAM_SESSION];
            int correctAnswer = handler.GetSelected(id ??0).AnsweredID ?? 0;
            foreach (ChoiceVM vm in cdto)
            {
                if (vm.ID == correctAnswer)
                {
                    vm.AnswerColor = "#E1EDCE";
                }
                else
                {
                    vm.AnswerColor = "";
                }
            }
            return PartialView("_ChoiceView", cdto);
        }


        // GET: /CourseEnrollment/StratExam/<examid>
        public ActionResult StratExam(int? id)
        {
            List<ExamQuestion> questions = new List<ExamQuestion>();
            ViewBag.ExamID = id ?? 0;
            if(Session[KEY_EXAM_SESSION]!=null)
            {
                ExamHandler handler =(ExamHandler)Session[KEY_EXAM_SESSION];
                questions = handler.Questions;
            }
            else
            {
                
                IEnumerable<QuestionDTO> questionsdto= service_exam.GetQuestions(id ?? 0);
                foreach(QuestionDTO dto in questionsdto)
                {
                    questions.Add(new ExamQuestion() 
                    {
                        CorrectAnsID=dto.CorrectAnsID,
                        ExaminationID=dto.ExaminationID,
                        ID=dto.ID,
                        IsPinned=false,
                        QuestionDescription=dto.QuestionDescription
                       
                    });
                }
                ExamHandler handler = new ExamHandler();
                handler.Questions = questions;
                handler.StratTime = DateTime.Now;
                handler.ExamID = id ?? 0;
                Session[KEY_EXAM_SESSION] = handler;
            }
            return View(questions);
        }

	}
}