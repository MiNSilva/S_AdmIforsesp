using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class WebAtividadeBLL
    {
        public void AtualizaAtividade(WebAtividadeModel email, int operacao)
        {
            WebAtividadeDAL obj = new WebAtividadeDAL();
            obj.AtualizaAtividade(email, operacao);
        }
    }
}
