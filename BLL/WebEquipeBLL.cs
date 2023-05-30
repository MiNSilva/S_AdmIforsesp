using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class WebEquipeBLL
    {
        public DataSet CarregaEquipe(int operacao)
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            return obj.CarregaEquipe(operacao);
        }
        public DataSet CarregaEquipePorId(int EquipeId)
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            return obj.CarregaEquipePorId(EquipeId);
        }
        public void AtualizaEquipe(WebEquipeModel equipe, int operacao)
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            obj.AtualizaEquipe(equipe, operacao);
        }
        public int ValidaEquipe(WebEquipeModel equipe, int operacao)
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            return obj.ValidaEquipe(equipe, operacao);
        }
        public DataSet CarregaEquipeCargo()
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            return obj.CarregaEquipeCargo();
        }
        public DataSet CarregaEquipeByIdRegional(int Id)
        {
            WebEquipeDAL obj = new WebEquipeDAL();
            return obj.CarregaEquipeByIdRegional(Id);
        }


    }
}
