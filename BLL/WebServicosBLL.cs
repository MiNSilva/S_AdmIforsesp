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
    public class WebServicosBLL
    {
        public DataSet CarregaServicos(int ServicoId)
        {
            WebServicosDAL obj = new WebServicosDAL();
            return obj.CarregaServicos(ServicoId);
        }
        public void AtualizaServicos(WebServicosModel serv, int operacao)
        {
            WebServicosDAL obj = new WebServicosDAL();
            obj.AtualizaServicos(serv, operacao);
        }
        public DataSet ValidaServicos(WebServicosModel serv, int operacao)
        {
            WebServicosDAL obj = new WebServicosDAL();
            return obj.ValidaServicos(serv, operacao);
        }
    }
}
