using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System.Data;

namespace DIAPOIO.BLL
{
    public class NoticiaDepartamentoBLL
    {
        public void AtualizaDepartamento(NoticiaDepartamentoModel depto, int operacao)
        {
            NoticiaDepartamentoDAL obj = new NoticiaDepartamentoDAL();
            obj.AtualizaDepartamento(depto, operacao);
        }

        public DataSet CarregaDepartamento()
        {            
            NoticiaDepartamentoDAL obj = new NoticiaDepartamentoDAL();
            return obj.CarregaDepartamento();
        }

        public DataSet GetDepartamento()
        {
            NoticiaDepartamentoDAL obj = new NoticiaDepartamentoDAL();
            return obj.GetDepartamento();
        }

        public DataSet ValidaDepto(NoticiaDepartamentoModel depto, int operacao)
        {
            NoticiaDepartamentoDAL obj = new NoticiaDepartamentoDAL();
            return obj.ValidaDepto(depto, operacao);
        }
    }
}
