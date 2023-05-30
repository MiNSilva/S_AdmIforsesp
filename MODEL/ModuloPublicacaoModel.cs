using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloPublicacaoModel
    {
        private int _WebPublicacaoId;
        private string _Nome;

        public int WebPublicacaoId
        {
            get { return _WebPublicacaoId; }
            set { _WebPublicacaoId = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

    }
}
