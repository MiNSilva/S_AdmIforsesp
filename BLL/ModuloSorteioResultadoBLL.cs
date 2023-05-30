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
    public class ModuloSorteioResultadoBLL
    {
        public DataSet CarregaSorteioResultadoId(ModuloSorteioResultadoModel sort, int operacao)
        {
            ModuloSorteioResultadoDAL obj = new ModuloSorteioResultadoDAL();
            return obj.CarregaSorteioResultadoId(sort, operacao);
        }
    }

}
