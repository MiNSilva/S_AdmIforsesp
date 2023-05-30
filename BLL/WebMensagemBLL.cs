using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;

namespace DIAPOIO.BLL
{
    public class WebMensagemBLL
    {
        public void AtualizaMsg(WebMensagemModel msg)
        {
            WebMensagemDAL obj = new WebMensagemDAL();
            obj.AtualizaMsg(msg);
        }

        public void VerificaMsg(WebMensagemModel msg, int Operacao)
        {
            WebMensagemDAL obj = new WebMensagemDAL();
            obj.VerificaMsg(msg, Operacao); 
        }
    }
}
