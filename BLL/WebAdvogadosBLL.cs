using DIAPOIO.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class WebAdvogadosBLL
    {
        public DataSet CarregaAdvogados()
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.CarregaAdvogados();
        }
        public void AtualizaAdvogados(WebAdvogadoModel adv, int operacao)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            obj.AtualizaAdvogados(adv, operacao);
        }
        public int ValidaaAdvogados(WebAdvogadoModel adv, int operacao)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.ValidaaAdvogados(adv, operacao);
        }

        public DataSet CarregaDepartamentoAdvogados(int usuariowebid, int operacao)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.CarregaDepartamentoAdvogados(usuariowebid, operacao);
        }
        public DataSet SalvarMenuDepartamento(int operacao, int usuariowebid, int SituacaoContatoId, int Responsavel)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.SalvarMenuDepartamento(operacao, usuariowebid, SituacaoContatoId, Responsavel);
        }
        public DataSet CarregaAdvogadosPorDepartamento(string depto)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.CarregaAdvogadosPorDepartamento(depto);
        }

        public DataSet CarregaPorUsuarioWebId(int usuariowebid)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            return obj.CarregaPorUsuarioWebId(usuariowebid);
        }
        public void ExcluirDepartamentos(int idUsuario)
        {
            WebAdvogadosDAL obj = new WebAdvogadosDAL();
            obj.ExcluirDepartamentos(idUsuario);
        }
    }
}
