using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloSorteioPremioModel
    {
        private int _IdSorteioPremio;
        private int _IdSorteio;
        private string _Item;
        private string _Descricao;
        private int _Ordem;

        public int IdSorteioPremio
        {
            get{return _IdSorteioPremio;}
            set{_IdSorteioPremio = value;}
        }

        public int IdSorteio
        {
            get{return _IdSorteio;}
            set{_IdSorteio = value;}
        }

        public string Item
        {
            get{return _Item;}
            set{_Item = value;}
        }

        public string Descricao
        {
            get{return _Descricao;}
            set{_Descricao = value;}
        }

        public int Ordem
        {
            get{return _Ordem;}
            set{_Ordem = value;}
        }
    }
}
