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
        public ActionResult ParkDetail(string id)
        {
            ParkModel park; 

            return View("ParkDetail", park = dal.GetParkDetail(id.ToUpper()));
        }

        [HttpPost]
        public ActionResult ParkDetail(string id, string sessionC)
        {
            ParkModel park;
            Session["Partial_Weather"] = sessionC;
            return View("ParkDetail", park = dal.GetParkDetail(id.ToUpper()));
        }

      
        //[HttpPost]
        //public ActionResult ParkDetail(string id, string sessionF, string sessionC)
        //{
        //    ParkModel park;
        //    if (Session["Partial_Weather"] == null)
        //    {
        //        Session["Partial_Weather"] = sessionF;
        //    }
        //    else
        //    {
        //        Session["Partial_Weather"] = sessionC;
        //    }
        //    return View("ParkDetail", park = dal.GetParkDetail(id.ToUpper()));
        //}

        public ActionResult PartialWeatherF(string id)
        {

            List<WeatherModel> f = dal2.ParkWeather(id);
            return View("PartialWeatherF", f);
        }

        public ActionResult PartialWeather(string id)
        {
            List<WeatherModel> f = dal2.ParkWeather(id);
            return View("PartialWeather", f);
        }

        ////THIS IS WHERE THE SESSION CODE STARTS
        //public WeatherModel GetCorrectTemp()
        //{
        //    WeatherModel weather = null;

        //    if (Session["Partial_Weather"] == null)
        //    {
        //        weather = new WeatherModel();
        //        Session["Partial_Weather"] = weather;
        //    }

        //    else
        //    {
        //        weather = Session["Partial_Weather"] as WeatherModel;
        //    }

        //    return weather;
        //}
    }
}