using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebConfigModel
    {
        private int _Id;
        private int _EmailDiasResposta;
        private string _ServidorAdm;
        private string _ServidorSite;

        public int Id
        {
            get{return _Id;}
            set{_Id = value;}
        }

        public int EmailDiasResposta
        {
            get{return _EmailDiasResposta;}
            set { _EmailDiasResposta = value; }
        }

        public string ServidorAdm
        {
            get{ return _ServidorAdm; }
            set{ _ServidorAdm = value;}
        }

        public string ServidorSite
        {
            get{return _ServidorSite;}
            set{_ServidorSite = value;}
        }
    }
}
