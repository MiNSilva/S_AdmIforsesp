using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloLegislacaoModel
    {
        private int _WebLesgislacaoId;
        private string _Nome;

        public int WebLesgislacaoId
        {
            get { return _WebLesgislacaoId; }
            set { _WebLesgislacaoId = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

    }
}
