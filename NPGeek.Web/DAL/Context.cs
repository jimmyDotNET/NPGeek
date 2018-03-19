using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NPGeek.Web.DAL
{
    public class Context : IContext
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
          
    }
}