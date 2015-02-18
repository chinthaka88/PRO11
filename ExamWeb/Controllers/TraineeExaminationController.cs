using DAL_EF1;
using DALInterfaces;
using ServiceInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWeb.Helpers;

namespace ExamWeb.Controllers
{
    [Authorize(Roles = "User")]
    public class TraineeExaminationController : Controller
    {
        
        IAppErrors error_trainee;
        ITraineeService service_trainee;

        public TraineeExaminationController()
        {
            error_trainee = new AppErrors();
            ITraineeDataAccess repo = new TraineeRepository();
            service_trainee = new TraineeService(error_trainee, repo);
        }

        
        public ActionResult Index()
        {
            string str = Session[ExamWeb.Controllers.AccountController.LOGGIN_SESSION_KEY].ToString();
            return View(TraineeExamMapping.Map(service_trainee.GetEnroledExaminations(str)));
        }
	}
}