using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPGeek.Web.Models
{
    public class SurveyModel
    {
        public int SurveyID { get; set; }
        public string ParkCode{ get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }
        public List<ParkModel> Parks { get; set; }
        public string ParkName { get; set; }
    }
}