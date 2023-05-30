using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class NoticiaModel
    {
        private int _NoticiaID;
        private int _NoticiaDepartamentoID;
        private int _NoticiaCategoriaID;
        private string _Titulo;
        private string _Resumo;
        private string _Noticia;
        private string _Imagem1;
        private string _Imagem2;
        private string _Imagem3;
        private string _Imagem4;
        private string _Arquivo1;
        private string _Arquivo2;
        private string _Autor;
        private string _Situacao;
        private int _Contador;
        private DateTime _Data;
        private DateTime _DataNoticia;
        private int _IdRegional;
        private int _usuariowebid;
        private int _DestaqueId;
        private int _TipoDep;



        #region Propriedades
        public int NoticiaID
            {
                get { return _NoticiaID; }
                set { _NoticiaID = value; }
            }
            public int NoticiaDepartamentoID
            {
                get { return _NoticiaDepartamentoID; }
                set { _NoticiaDepartamentoID = value; }
            }
            public int NoticiaCategoriaID
            {
                get { return _NoticiaCategoriaID; }
                set { _NoticiaCategoriaID = value; }
            }
            public string Titulo
            {
                get { return _Titulo; }
                set { _Titulo = value; }
            }
            public string Resumo
            {
                get { return _Resumo; }
                set { _Resumo = value; }
            }
            public string Noticia
            {
                get { return _Noticia; }
                set { _Noticia = value; }
            }
            public string Imagem1
            {
                get { return _Imagem1; }
                set { _Imagem1 = value; }
            }
            public string Imagem2
            {
                get { return _Imagem2; }
                set { _Imagem2 = value; }
            }
            public string Imagem3
            {
                get { return _Imagem3; }
                set { _Imagem3 = value; }
            }
            public string Imagem4
            {
                get { return _Imagem4; }
                set { _Imagem4 = value; }
            }
            public string Arquivo1
            {
                get { return _Arquivo1; }
                set { _Arquivo1 = value; }
            }
            public string Arquivo2
            {
                get { return _Arquivo2; }
                set { _Arquivo2 = value; }
            }
            public string Autor
            {
                get { return _Autor; }
                set { _Autor = value; }
            }
            public string Situacao
            {
                get { return _Situacao; }
                set { _Situacao = value; }
            }
            public int Contador
            {
                get { return _Contador; }
                set { _Contador = value; }
            }
            public DateTime Data
            {
                get { return _Data; }
                set { _Data = value; }
            }
            public DateTime DataNoticia
            {
                get { return _DataNoticia; }
                set { _DataNoticia = value; }
            }
          

            public int IdRegional
            {
                get{return _IdRegional;}
                set{_IdRegional = value;}
            }

            public int Usuariowebid
            {
                get{return _usuariowebid;}
                set{_usuariowebid = value;}
            }

            public int DestaqueId
            {
                get{return _DestaqueId;}
                set{_DestaqueId = value;}
            }

            public int TipoDep
            {
                get{return _TipoDep;}
                set{_TipoDep = value;}
            }

        #endregion
    }
}

