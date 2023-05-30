using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class ModuloLegislacaoItemBLL
    {
        public DataSet CarregaLegislacaoItem(string pesq, int id)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            return obj.CarregaLegislacaoItem(pesq, id);
        }

        public void AtualizaLegislacaoItem(ModuloLegislacaoItemModel ban, int operacao)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            obj.AtualizaLegislacaoItem(ban, operacao);
        }

        public ModuloLegislacaoItemModel GetLegislacaoItemById(int id)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            return obj.GetLegislacaoItemById(id);
        }

        public int GetLegislacaoItemOrdem(int id)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            return obj.GetLegislacaoItemOrdem(id);
        }

        public void OrdernaLegislacaoItem(int Id, int Ordem, int Operacao)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            obj.OrdernaLegislacaoItem(Id, Ordem, Operacao);
        }

        public DataSet GetLegisalcaoItemShow(int Id)
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            return obj.GetLegislacaoItemShow(Id);
        }

        public int GetLegisalcaoItemShowLoad()
        {
            ModuloLegislacaoItemDAL obj = new ModuloLegislacaoItemDAL();
            return obj.GetLegisalcaoItemShowLoad();
        }
    }
}
