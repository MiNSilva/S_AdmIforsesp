using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class ModuloPublicacaoItemBLL
    {
        public DataSet CarregaPublicacaoItem(string pesq, int id)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            return obj.CarregaPublicacaoItem(pesq, id);
        }

        public void AtualizaPublicacaoItem(ModuloPublicacaoItemModel pub, int operacao, int IdUsuario)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            obj.AtualizaPublicacaoItem(pub, operacao, IdUsuario);
        }

        public ModuloPublicacaoItemModel GetPublicacaoItemById(int id)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            return obj.GetPublicacaoItemById(id);
        }

        public int GetPublicacaoItemOrdem(int id)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            return obj.GetPublicacaoItemOrdem(id);
        }

        public void OrdernaPublicacaoItem(int Id, int Ordem, int Operacao)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            obj.OrdernaPublicacaoItem(Id, Ordem, Operacao);
        }

        public DataSet GetPublicacaoItemShow(int Id)
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            return obj.GetPublicacaoItemShow(Id);
        }

        public int GetPublicacaoItemShowLoad()
        {
            ModuloPublicacaoItemDAL obj = new ModuloPublicacaoItemDAL();
            return obj.GetPublicacaoItemShowLoad();
        }
    }
}
