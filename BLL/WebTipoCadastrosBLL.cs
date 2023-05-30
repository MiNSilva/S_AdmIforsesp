using DIAPOIO.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class WebTipoCadastrosBLL
    {
        public DataSet GetTipoCadastro()
        {
            WebTipoCadastroDAL obj = new WebTipoCadastroDAL();
            return obj.GetTipoCadastro();
        }

    }
}
