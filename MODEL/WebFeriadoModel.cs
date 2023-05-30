using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebFeriadoModel
    {
        private int _Id;
        private string _Feriado;
        private DateTime _DataFeriado;
        private int _IdUsuarioWeb;
        private DateTime _Data;

        public int Id
        {
            get{return _Id;}
            set{_Id = value;}
        }

        public string Feriado
        {
            get{return _Feriado;}
            set{_Feriado = value;}
        }

        public DateTime DataFeriado
        {
            get{return _DataFeriado;}
            set{_DataFeriado = value;}
        }

        public int IdUsuarioWeb
        {
            get{return _IdUsuarioWeb;}
            set{_IdUsuarioWeb = value;}
        }

        public DateTime Data
        {
            get{return _Data;}
            set{_Data = value;}
        }
    }
}
