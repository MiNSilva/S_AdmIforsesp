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
    public class ModuloBannerBLL
    {
        public DataSet CarregaBanner()
        {
            ModuloBannerDAL obj = new ModuloBannerDAL();
            return obj.CarregaBanner();
        }

        public void AtualizaBanner(ModuloBannerModel ban, int operacao)
        {
            ModuloBannerDAL obj = new ModuloBannerDAL();
            obj.AtualizaBanner(ban, operacao);
        }

        public DataSet ValidaBanner(ModuloBannerModel ban, int operacao)
        {
            ModuloBannerDAL obj = new ModuloBannerDAL();
            return obj.ValidaBanner(ban, operacao);
        }

        public DataSet CarregaBannerItens(ModuloBannerModel ban)
        {
            ModuloBannerDAL obj = new ModuloBannerDAL();
            return obj.CarregaBannerItens(ban);
        }

    }
}
