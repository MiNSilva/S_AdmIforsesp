using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class ModuloUtilidadesModel
    {
        private int _WebUtilidadeId;
        private string _Nome;
        private string _Link;
        private string _Imagem;
        private int _Ordem;
        private int _Externo;


        public int WebUtilidadeId
        {
            get { return _WebUtilidadeId; }
            set { _WebUtilidadeId = value; }
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

    }
}
