using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebSituacaoContatoModel
    {
        private int _SituacaoContatoId;
        private string _SituacaoContato;

        public int SituacaoContatoId
        {
            get{return _SituacaoContatoId;}
            set{_SituacaoContatoId = value;}
        }

        public string SituacaoContato
        {
            get{return _SituacaoContato;}
            set{_SituacaoContato = value;}
        }
    }
}
