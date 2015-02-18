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
using ExamWeb.Helpers;

namespace ExamWeb.Controllers
{
    public class TraineeController : Controller
    {
        //
        // GET: /Trainee/

        IAppErrors error_trainee;
        ITraineeService service_trainee;

        public TraineeController()
        {
            error_trainee = new AppErrors();
            ITraineeDataAccess repo = new TraineeRepository();
            service_trainee = new TraineeService(error_trainee, repo);
        }
        public ActionResult Index()
        {
            IEnumerable<TraineeDTO> trainees = service_trainee.GetAll();
            return View(TraineeMapping.Map(trainees));
        }
	}
}