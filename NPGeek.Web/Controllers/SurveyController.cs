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
        private ISurveyDAL dal;

        public SurveyController(ISurveyDAL dal)
        {
            this.dal = dal;
        }

        public ActionResult SurveyView()
        {
            return View("SurveyView");
        }

        public ActionResult SurveyResult()
        {
            return SurveyResult();
        }
    }
}