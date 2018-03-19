using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPGeek.Web.DAL
{
    public interface IContext
    {
        string ConnectionString { get; }

    }
}
