using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebAtividadeModel
    {
        private int _Atividadeid;
        private string _DescAtividade;
        private int _Usuariowebid;
        private string _Url;
        private int _Menuid;
        private DateTime _Data;

        #region
        public int Atividadeid
        {
            get
            {
                return _Atividadeid;
            }

            set
            {
                _Atividadeid = value;
            }
        }

        public string DescAtividade
        {
            get
            {
                return _DescAtividade;
            }

            set
            {
                _DescAtividade = value;
            }
        }

        public int Usuariowebid
        {
            get
            {
                return _Usuariowebid;
            }

            set
            {
                _Usuariowebid = value;
            }
        }

        public string Url
        {
            get
            {
                return _Url;
            }

            set
            {
                _Url = value;
            }
        }

        public int Menuid
        {
            get
            {
                return _Menuid;
            }

            set
            {
                _Menuid = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }
        #endregion
    }
}
