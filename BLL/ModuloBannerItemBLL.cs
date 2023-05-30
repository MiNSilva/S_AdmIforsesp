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
    public class ModuloBannerItemBLL
    {
        public DataSet CarregaBannerItem(string pesq)
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            return obj.CarregaBannerItem(pesq);
        }

        public void AtualizaBannerItem(ModuloBannerItemModel ban, int operacao)
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            obj.AtualizaBannerItem(ban, operacao);
        }

        public ModuloBannerItemModel GetBannerItemById(int id)
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            return obj.GetBannerItemById(id);
        }

        public int GetBannerItemOrdem()
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            return obj.GetBannerItemOrdem();
        }

        public void OrdernaBannerItem(int Id, int Ordem, int Operacao)
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            obj.OrdernaBannerItem(Id, Ordem, Operacao);
        }

        public DataSet GetBannerItemShow()
        {
            ModuloBannerItemDAL obj = new ModuloBannerItemDAL();
            return obj.GetBannerItemShow();
        }
    }
}
