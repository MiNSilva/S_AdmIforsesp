using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloPublicacaoItemModel
    {
        private int _WebPublicacaoItemId;
        private int _WebPublicacaoId;
        private string _Nome;
        private string _Arquivo;
        private int _Ordem;

        public int WebPublicacaoItemId
        {
            get { return _WebPublicacaoItemId; }
            set { _WebPublicacaoItemId = value; }
        }
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
        public string Arquivo
        {
            get { return _Arquivo; }
            set { _Arquivo = value; }
        }
        public int Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }

    }
}
