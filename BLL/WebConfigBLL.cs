using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class WebConfigBLL
    {
        public int AtualizaConfiguracao(WebConfigModel config, int operacao)
        {
            WebConfigDAL obj = new WebConfigDAL();
            return obj.AtualizaConfiguracao(config, operacao);
        }
        public DataSet CarregaConfig()
        {
            WebConfigDAL obj = new WebConfigDAL();
            return obj.CarregaConfig();
        }
    }
}
