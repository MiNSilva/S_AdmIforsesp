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
    public class WebEstatutoBLL
    {
        public DataSet CarregaEstatuto()
        {
            WebEstatutoDAL obj = new WebEstatutoDAL();
            return obj.CarregaEstatuto();
        }
        public DataSet CarregaEstatutoID(int EstatutoId)
        {
            WebEstatutoDAL obj = new WebEstatutoDAL();
            return obj.CarregaEstatutoID(EstatutoId);
        }
        public void AtualizaEstatuto(WebEstatutoModel est, int operacao)
        {
            WebEstatutoDAL obj = new WebEstatutoDAL();
            obj.AtualizaEstatuto(est, operacao);
        }
        //public DataSet CarregaEscritoriosPag()
        //{
        //    WebEstatutoDAL obj = new WebEstatutoDAL();
        //    return obj.CarregaEscritoriosPag();
        //}
    }
}
