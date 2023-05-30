using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    public class NoticiaCategoriaModel
    {
        private int _NoticiaCategoriaID;
        private int _NoticiaDepartamentoID;
        private string _Categoria;

        public int NoticiaCategoriaID
        {
            get { return _NoticiaCategoriaID; }
            set { _NoticiaCategoriaID = value; }
        }
        public int NoticiaDepartamentoID
        {
            get { return _NoticiaDepartamentoID; }
            set { _NoticiaDepartamentoID = value; }
        }
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
    }
}
