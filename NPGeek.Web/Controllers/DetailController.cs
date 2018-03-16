using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPGeek.Web.DAL;
using NPGeek.Web.Models;

namespace NPGeek.Web.Controllers
{
    public class DetailController : Controller
    {
        private IParkDAL dal;
        private IWeatherDAL dal2;

        public DetailController(IParkDAL dal, IWeatherDAL dal2)
        {
            this.dal = dal;
            this.dal2 = dal2;
        }

        // GET: Detail
        public ActionResult ParkDetail(string id, string tempChoice)
        {
            
            TempChoiceModel tcm = new TempChoiceModel();
            tcm.ParkTempModel = dal.GetParkDetail(id.ToUpper());
            tcm.TempChoice = tempChoice;

            return View("ParkDetail", tcm);
        }

        //[HttpPost]
        //public ActionResult ParkDetail(string id, string tempChoice)
        //{
        //    ParkModel park;
        //    Session["tempChoice"] = tempChoice;

        //    return RedirectToAction("ParkDetail", park = dal.GetParkDetail(id.ToUpper()));
        //}

        public ActionResult PartialWeatherF(string id)
        {

            List<WeatherModel> f = dal2.ParkWeather(id);
            return PartialView("PartialWeather", f);
        }

        public ActionResult PartialWeather(string id)
        {
            List<WeatherModel> f = dal2.ParkWeather(id);
            return PartialView("PartialWeatherF", f);
        }

        
    }
}