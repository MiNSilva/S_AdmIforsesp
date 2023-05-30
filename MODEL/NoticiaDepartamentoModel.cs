using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class NoticiaDepartamentoModel
    {
        private int _NoticiaDepartamentoID;
        private string _Departamento;

        public string Departamento
        {
            get { return _Departamento; }
            set { _Departamento = value; }
        }
        public int NoticiaDepartamentoID
        {
            get { return _NoticiaDepartamentoID; }
            set { _NoticiaDepartamentoID = value; }
        }
    }
}
