using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;

namespace DIAPOIO.BLL
{
    public class WebGrupoBLL
    {
        public DataSet CarregaGrupo()
        {
            WebGrupoDAL obj = new WebGrupoDAL();
            return obj.CarregaGrupo();
        }
        public void AtualizaGrupo(WebGrupoMODEL grup , int operacao)
        {
            WebGrupoDAL obj = new WebGrupoDAL();
            obj.AtualizaGrupo(grup, operacao);
        }
        public int ValidaGrupo(WebGrupoMODEL grup, int operacao)
        {
            WebGrupoDAL obj = new WebGrupoDAL();
            return obj.ValidaGrupo(grup, operacao);
        }
    }
}
