using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class ModuloLegislacaoBLL
    {
        public DataSet CarregaLegislacao()
        {
            ModuloLegislacaoDAL obj = new ModuloLegislacaoDAL();
            return obj.CarregaLegislacao();
        }

        public void AtualizaLegislacao(ModuloLegislacaoModel legis, int operacao)
        {
            ModuloLegislacaoDAL obj = new ModuloLegislacaoDAL();
            obj.AtualizaLegislacao(legis, operacao);
        }

        public int ValidaLegislacao(ModuloLegislacaoModel legis, int operacao)
        {
            ModuloLegislacaoDAL obj = new ModuloLegislacaoDAL();
            return obj.ValidaLegislacao(legis, operacao);
        }
    }
}
