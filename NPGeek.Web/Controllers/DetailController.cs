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
        public DetailController(IParkDAL dal)
        {
            this.dal = dal;
        }

        // GET: Detail
        public ActionResult ParkDetail(string id)
        {
            ParkModel park; 

            return View("ParkDetail", park = dal.GetParkDetail(id.ToUpper()));
        }
    }
}