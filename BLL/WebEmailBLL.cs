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
    public class WebEmailBLL
    {
        public int ValidaContato(WebEmailModel email)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.ValidaContato(email);
        }

        public int AtualizaEmail(WebEmailModel email, int operacao)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.AtualizaEmail(email, operacao);
        }


        public DataSet CarregaEmailNovo(string CPF, string Nome, string Assunto, int SituacaoId, int Resp, int usuariowebid, int Operacao)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmailNovo(CPF, Nome, Assunto, SituacaoId, Resp, usuariowebid, Operacao);
        }
        public DataSet CarregaEmail(string busca, int operacao, int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmail(busca, operacao, usuariowebid);
        }

        public DataSet CarregaEmailId(int EmailId, int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmailId(EmailId, usuariowebid);
        }

        public DataSet CarregaEmailEstatistica( int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmailEstatistica(usuariowebid);
        }

        public DataSet CarregaNotificacoesEmail(int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaNotificacoesEmail(usuariowebid);
        }

        public DataSet EnviaNotificacoesEmail()
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.EnviaNotificacoesEmail();
        }

        public DataSet CarregaEmailPorUsuario(string CPF)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmailPorUsuario(CPF);
        }
        public DataSet CarregaPorSituacaoId(int SituacaoId, int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaPorSituacaoId(SituacaoId, usuariowebid);
        }
        public void AtualizaFormularioEmail(int EmailId, int Formulario)
        {
            WebEmailDAL obj = new WebEmailDAL();
            obj.AtualizaFormularioEmail(EmailId, Formulario);
        }
        public void AtualizaResponsavelEmail(int EmailId, int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            obj.AtualizaResponsavelEmail(EmailId, usuariowebid);
        }
        public DataTable RelatorioEmail(int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.RelatorioEmail(usuariowebid);

        }
        public DataTable RelatorioEmailTotal(int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.RelatorioEmailTotal(usuariowebid);

        }
        public void TravaEmail(int EmailId, int operacao)
        {
            WebEmailDAL obj = new WebEmailDAL();
            obj.TravaEmail(EmailId, operacao);

        }
        public int ValidaTravaEmail(int EmailId)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.ValidaTravaEmail(EmailId);

        }
        public DataSet BuscaEmail(int EmailId)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.BuscaEmail(EmailId);

        }
        public void AlteraStatusEmail(int EmailId, int SituacaoId)
        {
            WebEmailDAL obj = new WebEmailDAL();
            obj.AlteraStatusEmail(EmailId, SituacaoId);

        }


        //NOVA PESQUISA
        public DataSet CarregaEmailGrid(string busca, int operacao, int usuariowebid)
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaEmailGrid(busca, operacao, usuariowebid);
        }

        public DataSet CarregaResponsavel()
        {
            WebEmailDAL obj = new WebEmailDAL();
            return obj.CarregaResponsavel();
        }
    }
}
