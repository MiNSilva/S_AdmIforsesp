using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebMensagemModel
    {
        private int _WebMensagemId;
        private string _Mensagem;
        private int _Exibe;
        private DateTime _Inicio;
        private DateTime _Final;
        private string _Titulo;

        public int WebMensagemId
        {
            get { return _WebMensagemId; }
            set { _WebMensagemId = value; }
        }

        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; }
        }

        public int Exibe
        {
            get { return _Exibe; }
            set { _Exibe = value; }
        }

        public DateTime Inicio
        {
            get { return _Inicio; }
            set { _Inicio = value; }
        }

        public DateTime Final
        {
            get { return _Final; }
            set { _Final = value; }
        }

        public string Titulo
        {
            get{return _Titulo;}
            set{_Titulo = value;}
        }
    }
}
