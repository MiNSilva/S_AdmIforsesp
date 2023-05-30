using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class WebSEOBLL
    {

        public DataSet CarregaSEO()
        {
            WebSEODAL obj = new WebSEODAL();
            return obj.CarregaSEO();
        }

        public void AtualizaSEO(WebSEOModel seo, int operacao)
        {
            WebSEODAL obj = new WebSEODAL();
            obj.AtualizaSEO(seo, operacao);
        }

        public DataSet ValidaSEO(string page)
        {
            WebSEODAL obj = new WebSEODAL();
            return obj.ValidaSEO(page);
        }
  
    }
}
