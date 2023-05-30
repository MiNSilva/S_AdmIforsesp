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
    public class WebEmailRespostaBLL
    {
        public int AtualizaEmailResposta(WebEmailRespostaModel emailr, int operacao)
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            return obj.AtualizaEmailResposta(emailr, operacao);
        }
        public DataSet CarregaEmailResposta(int EmailId)
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            return obj.CarregaEmailResposta(EmailId);
        }
        public DataSet CarregaEmailRespostaId(int EmailRespostaId)
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            return obj.CarregaEmailRespostaId(EmailRespostaId);
        }

        public String EmailBuscaResponsavelEscritorio(WebEmailRespostaModel emailr)
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            return obj.EmailBuscaResponsavelEscritorio(emailr);
        }
        public void FinalizarEmail(int EmailId)
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            obj.FinalizarEmail(EmailId);
        }
        public DataSet GetSituacaoEmail()
        {
            WebEmailRespostaDAL obj = new WebEmailRespostaDAL();
            return obj.GetSituacaoEmail();
        }
    }
}
