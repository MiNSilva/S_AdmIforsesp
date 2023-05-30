using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloSorteioResultadoModel
    {
        private int _IdSorteioResultado;
        private int _IdSorteio;
        private int _IdSorteioParticipantes;
        private int _IdSorteioPremio;
        private int _ordem;
        private DateTime _Data;
        private int _usuariowebid;

        public int IdSorteioResultado
        {
            get{return _IdSorteioResultado;}
            set{_IdSorteioResultado = value;}
        }

        public int IdSorteio
        {
            get{return _IdSorteio;}
            set{_IdSorteio = value;}
        }

        public int IdSorteioParticipantes
        {
            get{return _IdSorteioParticipantes;}
            set{_IdSorteioParticipantes = value;}
        }

        public int IdSorteioPremio
        {
            get{return _IdSorteioPremio;}
            set{_IdSorteioPremio = value;}
        }

        public int Ordem
        {
            get{return _ordem;}
            set{_ordem = value;}
        }

        public DateTime Data
        {
            get{return _Data;}
            set{_Data = value;}
        }

        public int Usuariowebid
        {
            get{return _usuariowebid;}
            set{_usuariowebid = value;}
        }
    }
}
