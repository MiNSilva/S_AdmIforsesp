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
    public class WebSituacaoContatoBLL
    {
        public DataSet GetSituacaoContato()
        {
            WebSituacaoContatoDAL obj = new WebSituacaoContatoDAL();
            return obj.GetSituacaoContato();
        }
        public DataSet GetSituacaoContatoNovo()
        {
            WebSituacaoContatoDAL obj = new WebSituacaoContatoDAL();
            return obj.GetSituacaoContatoNovo();
        }
        public void AtualizaSituacaoContato(WebSituacaoContatoModel sitcontato, int operacao)
        {
            WebSituacaoContatoDAL obj = new WebSituacaoContatoDAL();
            obj.AtualizaSituacaoContato(sitcontato, operacao);
        }
        public DataSet ValidaSituacaoContato(WebSituacaoContatoModel sitcontato, int operacao)
        {
            WebSituacaoContatoDAL obj = new WebSituacaoContatoDAL();
            return obj.ValidaSituacaoContato(sitcontato, operacao);
        }
      
        
    }
}
