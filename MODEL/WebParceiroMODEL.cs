using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebParceiroMODEL
    {
        private int _ParceiroId;
        private string _Nome;
        private string _Link;
        private int _Ativo;
        private string _Arquivo;
        private int _Ordem;
        private int _Externo;

        public int ParceiroId
        {
            get { return _ParceiroId; }
            set { _ParceiroId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
        public string Arquivo
        {
            get { return _Arquivo; }
            set { _Arquivo = value; }
        }
        public int Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }
        public int Externo
        {
            get { return _Externo; }
            set { _Externo = value; }
        }


    }
}
