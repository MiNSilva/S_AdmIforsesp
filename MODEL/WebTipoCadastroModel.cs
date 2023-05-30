using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebTipoCadastroModel
    {
        private int _TipoCadastroId;
        private string _TipoCadastro;

        public int TipoCadastroId
        {
            get { return _TipoCadastroId; }
            set { _TipoCadastroId = value; }
        }
        public string TipoCadastro
        {
            get { return _TipoCadastro; }
            set { _TipoCadastro = value; }
        }
    }
}
