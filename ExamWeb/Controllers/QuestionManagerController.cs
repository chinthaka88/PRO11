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
using ExamWeb.Models.ExamViewModels;
using ExamWeb.Helpers;
using ExamWeb.Models.QuestionViewModels;
using ExamWeb.Models.ChoiceViewModels;

namespace ExamWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuestionManagerController : Controller
    {
        IAppErrors error_ques;
        IAppErrors error_choice;
        IAppErrors error_exam;
        IQuestionService service_ques;
        IChoiceService service_choice;
        IExamService service_exam;


        public QuestionManagerController()
        {
            error_ques = new AppErrors();
            error_choice = new AppErrors();
            error_exam = new AppErrors();
            IQuestionDataAccess ques_da = new QuestionRepository();
            IChoiceDataAccess choice_da = new ChoiceRepository();
            IExamDataAccess exam_da = new ExamRepository();
            service_ques = new QuestionService(error_ques, ques_da);
            service_choice = new ChoiceService(error_choice, choice_da);
            service_exam = new ExamService(error_exam, exam_da);
        }


        // GET: /QuestionManager/Index/<examinationid>
        public ActionResult Index(int? id)
        {
            IEnumerable<QuestionDisplayVM> vm=new List<QuestionDisplayVM>(); 
            ViewBag.ExaminationID = id ?? 0;
            try
            {   
                IEnumerable<QuestionDTO> qdto = service_exam.GetQuestions(id ?? 0);
                vm = QuestionMapper.MapToDisplay(qdto); 
                   
                return View(vm);
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: /QuestionManager/GetChoicesByQuestion/<questionid>
        public ActionResult GetChoicesByQuestion(int? id)
        {
            IEnumerable<ChoiceVM> cdto = ChoiceMapper.Map(service_ques.GetChoices(id ?? 0));
            int correctAnswer=service_ques.GetCorrectAnswer(id ?? 0);
            foreach(ChoiceVM vm in cdto)
            {
                if(vm.ID==correctAnswer)
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


        //Action method to render question creation partial view. Call action using JQuery Ajax
        //Calling From : ~/Views/QuestionManager/Index.cshtml
        // GET: /QuestionManager/Create/<examinationid>
        public ActionResult Create(int? id)
        {
            QuestionVM q = new QuestionVM();
            q.ExaminationID = id ?? 0;
            return PartialView("_AddQuestion",q);
        }

        //Action method to render choice creation partial view. Call action using JQuery Ajax
        //Calling From : ~/Views/QuestionManager/Index.cshtml
        // GET: /QuestionManager/CreateChoice/<examinationid>
        public ActionResult CreateChoice(int? id,string returnurl)
        {
            ChoiceVM c = new ChoiceVM();
            c.QuestionID = id ?? 0;
            return PartialView("_AddChoice", c);
        }


        // POST: /QuestionManager/Create
        [HttpPost]
        public ActionResult Create(QuestionVM ques)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    QuestionDTO dto = QuestionMapper.Map(ques);
                    int newid=service_ques.AddNew(dto);
                    if (newid!=0)
                    {
                        return RedirectToAction("Index", new { id=ques.ExaminationID});
                    }
                }
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View();
            }
        }


        // POST: /QuestionManager/CreateChoice
        [HttpPost]
        public ActionResult CreateChoice(ChoiceVM choice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ChoiceDTO dto = ChoiceMapper.Map(choice);    
                    if (service_choice.AddNew(dto))
                    {
                        string returl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
                        return Redirect(returl);
                    }
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // POST: /QuestionManager/SetAsCorrectChoice/<questionid>/correctChoiceId=<choiceid>
        public JsonResult SetAsCorrectChoice(int? id,int? correctChoiceId)
        {

             service_ques.SetCorrectChoice(id ?? 0,correctChoiceId ?? 0);
             var result = new { Success = "True"};
             return Json(result, JsonRequestBehavior.AllowGet);   

        }

       
    }
}
