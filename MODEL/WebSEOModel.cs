using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebSEOModel
    {
        private int _SEOId;
        private string _Nome;
        private string _Paginas;
        private string _Titulo;
        private string _Descricao;
        private string _PalavrasChave;
        private string _Empresa;
        private string _Rating;
        private string _Robots;
        private string _RevisitAfter;
        private string _Language;
        private string _Enconding;
        private string _URL;
   

        #region propriedades

        public int SEOId
        {
            get { return _SEOId; }
            set { _SEOId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Paginas
        {
            get { return _Paginas; }
            set { _Paginas = value; }
        }

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }
        public string PalavrasChave
        {
            get { return _PalavrasChave; }
            set { _PalavrasChave = value; }
        }

        public string Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
        }
        public string Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public string Robots
        {
            get { return _Robots; }
            set { _Robots = value; }
        }
        public string RevisitAfter
        {
            get { return _RevisitAfter; }
            set { _RevisitAfter = value; }
        }
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public string Enconding
        {
            get { return _Enconding; }
            set { _Enconding = value; }
        }
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        #endregion
    }

}
