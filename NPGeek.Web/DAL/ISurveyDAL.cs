using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPGeek.Web.Models;

namespace NPGeek.Web.DAL
{
    public interface ISurveyDAL
    {
        bool MakePost(SurveyModel survey);
    }
}
