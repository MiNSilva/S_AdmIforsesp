using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebTipoStatusModel
    {
        private int _TipoStatusId;
        private string _TipoStatus;

        public int TipoStatusId
        {
            get { return _TipoStatusId; }
            set { _TipoStatusId = value; }
        }

        public string TipoStatus
        {
            get { return _TipoStatus; }
            set { _TipoStatus = value; }
        }
    }
}
