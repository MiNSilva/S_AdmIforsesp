using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL;
using System.Data;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public  class WebCargoBLL
    {
        public DataSet CarregaCargo()
        {
            WebCargoDAL obj = new WebCargoDAL();
            return obj.CarregaCargo();
        }
        public void AtualizaCargo(WebCargoModel cargo, int operacao)
        {
            WebCargoDAL obj = new WebCargoDAL();
            obj.AtualizaCargo(cargo, operacao);
        }
        public int ValidaCargo(WebCargoModel cargo, int operacao)
        {
            WebCargoDAL obj = new WebCargoDAL();
            return obj.ValidaCargo(cargo, operacao);
        }
        public DataSet CarregaCargoEquipe()
        {
            WebCargoDAL obj = new WebCargoDAL();
            return obj.CarregaCargoEquipe();
        }
    }
}
