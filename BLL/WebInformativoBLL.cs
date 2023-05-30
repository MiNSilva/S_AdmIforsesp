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
    public class WebInformativoBLL
    {
        public DataSet CarregaGrid()
        {
            WebInformativoDAL obj = new WebInformativoDAL();
            return obj.CarregaGrid();
        }
        public void Atualiza(WebInformativoModel info, int operacao)
        {
            WebInformativoDAL obj = new WebInformativoDAL();
            obj.Atualiza(info, operacao);
        }
        public DataSet CarregaSorteioId(WebInformativoModel info, int operacao)
        {
            WebInformativoDAL obj = new WebInformativoDAL();
            return obj.CarregaSorteioId(info, operacao);
        }
    }
}
