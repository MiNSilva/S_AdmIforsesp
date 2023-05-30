using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebTipoServidorModel
    {
        private int _TipoServidorId;
        private string _TipoServidor;

        
        public int TipoServidorId
        {
            get { return _TipoServidorId; }
            set { _TipoServidorId = value; }
        }
        public string TipoServidor
        {
            get { return _TipoServidor; }
            set { _TipoServidor = value; }
        }
    }
}
