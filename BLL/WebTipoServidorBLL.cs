using DIAPOIO.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class WebTipoServidorBLL
    {
        public DataSet GetTipoServidor()
        {
            WebTipoServidorDAL obj = new WebTipoServidorDAL();
            return obj.GetTipoServidor();
        }

    }
}
