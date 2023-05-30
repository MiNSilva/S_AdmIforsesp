using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class WebTarefasBLL
    {
        public List<UsuarioWebModel> TarefaMembros()
        {
            return new WebTarefasDAL().TarefaMembros();
        }

        public void TarefasAtualiza(WebTarefasModel taf, int nOperacao)
        {
            WebTarefasDAL obj = new WebTarefasDAL();
            obj.TarefasAtualiza(taf, nOperacao);
        }

        public List<WebTarefasModel> TarefasCarrega(int nOperacao, int nId, string usuariowebid)
        {
            WebTarefasDAL obj = new WebTarefasDAL();
            return obj.TarefasCarrega(nOperacao, nId, usuariowebid);
        }
        public List<WebTarefasModel> TarefasCarregaFiltros(string Prioridade, string Categoria, string Situacao,string Membro)
        {
            WebTarefasDAL obj = new WebTarefasDAL();
            return obj.TarefasCarregaFiltros(Prioridade, Categoria, Situacao, Membro);
        }
    }

    public class WebTarefasPrioridadeBLL
    {

        public void PrioridadeAtualiza(WebTarefasPrioridadeModel prio, int nOperacao)
        {
            WebTarefasPrioridadeDAL obj = new WebTarefasPrioridadeDAL();
            obj.PrioridadeAtualiza(prio, nOperacao);
        }

        public List<WebTarefasPrioridadeModel> PrioridadeCarrega()
        {
            WebTarefasPrioridadeDAL obj = new WebTarefasPrioridadeDAL();
            return obj.PrioridadeCarrega();
        }

    }

    public class WebTarefasCategoriaBLL
    {
        public List<WebTarefasCategoriaModel> CategoriaCarrega()
        {

            WebTarefasCategoriaDAL obj = new WebTarefasCategoriaDAL();
            return obj.CategoriaCarrega();
        }

        public void CategoriaAtualiza(WebTarefasCategoriaModel cat, int nOperacao)
        {
            WebTarefasCategoriaDAL obj = new WebTarefasCategoriaDAL();
            obj.CategoriaAtualiza(cat, nOperacao);
        }
    }

    public class WebTarefasSituacaoBLL
    {
        public List<WebTarefasSituacaoModel> SituacaoCarrega()
        {
            WebTarefasSituacaoDAL obj = new WebTarefasSituacaoDAL();
            return obj.SituacaoCarrega();
        }

        public void SituacaoAtualiza(WebTarefasSituacaoModel sit, int nOperacao)
        {
            WebTarefasSituacaoDAL obj = new WebTarefasSituacaoDAL();
            obj.SituacaoAtualiza(sit, nOperacao);
        }
    }


}
