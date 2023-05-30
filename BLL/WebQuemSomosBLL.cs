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
    public class WebQuemSomosBLL
    {
        public DataSet CarregaQuemSomos()
        {
            WebQuemSomosDAL obj = new WebQuemSomosDAL();
            return obj.CarregaQuemSomos();
        }
        public DataSet CarregaQuemSomosPaginas()
        {
            WebQuemSomosDAL obj = new WebQuemSomosDAL();
            return obj.CarregaQuemSomosPaginas();
        }
        public DataSet CarregaCentenario()
        {
            WebQuemSomosDAL obj = new WebQuemSomosDAL();
            return obj.CarregaCentenario();
        }
        public DataSet CarregaQuemSomosID(int Id)
        {
            WebQuemSomosDAL obj = new WebQuemSomosDAL();
            return obj.CarregaQuemSomosID(Id);
        }
        public void AtualizaQuemSomos(WebQuemSomosModel est, int operacao)
        {
            WebQuemSomosDAL obj = new WebQuemSomosDAL();
            obj.AtualizaQuemSomos(est, operacao);
        }
        
        //public DataSet CarregaEscritoriosPag()
        //{
        //    WebEstatutoDAL obj = new WebEstatutoDAL();
        //    return obj.CarregaEscritoriosPag();
        //}
    }
}
