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
    public class WebFeriadoBLL
    {
        public DataSet CarregarFeriado()
        {
            WebFeriadoDAL obj = new WebFeriadoDAL();
            return obj.CarregarFeriado();
        }
        public int AtualizaFeriado(WebFeriadoModel feriado, int operacao)
        {
            WebFeriadoDAL obj = new WebFeriadoDAL();
            return obj.AtualizaFeriado(feriado, operacao);
        }
    }
}
