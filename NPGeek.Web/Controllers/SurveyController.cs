using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;



namespace NPGeek.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDal;
        private IParkDAL parkDal;

        public SurveyController(ISurveyDAL surveyDal, IParkDAL parkDal)
        {
            this.surveyDal = surveyDal;
            this.parkDal = parkDal;
        }


        public ActionResult SurveyView()
        {
            SurveyModel survey = new SurveyModel();

            List<ParkModel> parks = parkDal.GetAllParks();

            survey.Parks = parks;

            surveyDal.MakePost(survey);

            return View("SurveyView", survey);
        }



        public ActionResult SurveyResult(SurveyModel survey)
        {

            List<ParkModel> favParks = survey.Parks;

            return View("SurveyResult", favParks);
        }
    }
}