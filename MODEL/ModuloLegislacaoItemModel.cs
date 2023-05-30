using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloLegislacaoItemModel
    {
        private int _WebLegislacaoItemId;
        private int _WebLegislacaoId;
        private string _Nome;
        private string _Arquivo;
        private int _Ordem;

        public int WebLegislacaoItemId
        {
            get { return _WebLegislacaoItemId; }
            set { _WebLegislacaoItemId = value; }
        }
        public int WebLegislacaoId
        {
            get { return _WebLegislacaoId; }
            set { _WebLegislacaoId = value; }
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
