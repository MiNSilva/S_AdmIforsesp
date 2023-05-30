using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloConvenioModel
    {
        private int _ConvenioId;
        private string _Nome;
        private string _Link;
        private string _Imagem;
        private int _Ordem;
        private int _Externo;
        private string _Descricao;


        public int ConvenioId
        {
            get { return _ConvenioId; }
            set { _ConvenioId = value; }
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
        public string Imagem
        {
            get { return _Imagem; }
            set { _Imagem = value; }
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

        public string Descricao
        {
            get{return _Descricao; }
            set{_Descricao = value;}
        }
    }
}
