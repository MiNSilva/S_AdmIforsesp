using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebEmailRespostaModel
    {
        private int _EmailRespostaId;
        private int _Emailid;
        private string _Resposta;
        private int _usuariowebid;
        private DateTime _DataResposta;

        #region
        public int EmailRespostaId
        {
            get
            {
                return _EmailRespostaId;
            }

            set
            {
                _EmailRespostaId = value;
            }
        }

        public int Emailid
        {
            get
            {
                return _Emailid;
            }

            set
            {
                _Emailid = value;
            }
        }

        public string Resposta
        {
            get
            {
                return _Resposta;
            }

            set
            {
                _Resposta = value;
            }
        }

        public int Usuariowebid
        {
            get
            {
                return _usuariowebid;
            }

            set
            {
                _usuariowebid = value;
            }
        }

        public DateTime DataResposta
        {
            get
            {
                return _DataResposta;
            }

            set
            {
                _DataResposta = value;
            }
        }
        #endregion
    }
}
