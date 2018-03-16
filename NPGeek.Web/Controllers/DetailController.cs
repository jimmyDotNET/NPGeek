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

        //public ActionResult PartialWeatherF(string id)
        //{
        //    List<WeatherModel> f = dal2.ParkWeather(id);
        //    return PartialView("PartialWeatherF", f);
        //}

        public ActionResult PartialWeather(string id)
        {
            List<WeatherModel> c = dal2.ParkWeather(id);
            return PartialView("PartialWeather", c);
        }
    }
}