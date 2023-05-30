using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloDuvidaModel
    {
        private int _WebDuvidaId;
        private string _Pergunta;
        private string _Resposta;
        private int _Ordem;

        public int WebDuvidaId
        {
            get { return _WebDuvidaId; }
            set { _WebDuvidaId = value; }
        }
        public string Pergunta
        {
            get { return _Pergunta; }
            set { _Pergunta = value; }
        }
        public string Resposta
        {
            get { return _Resposta; }
            set { _Resposta = value; }
        }
        public int Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }

    }
}
