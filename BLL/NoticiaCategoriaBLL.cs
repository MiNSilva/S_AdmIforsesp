using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System.Data;

namespace DIAPOIO.BLL
{
    public class NoticiaCategoriaBLL
    {
        public void AtualizaCategoria(NoticiaCategoriaModel categoria, int operacao)
        {
            NoticiaCategoriaDAL obj = new NoticiaCategoriaDAL();
            obj.AtualizaCategoria(categoria, operacao);
        }

        public DataSet CarregaCategoria(int categoria)
        {
            NoticiaCategoriaDAL obj = new NoticiaCategoriaDAL();
            return obj.CarregaCategoria(categoria);
        }

        public DataSet GetCategoria(NoticiaCategoriaModel categoria)
        {
            NoticiaCategoriaDAL obj = new NoticiaCategoriaDAL();
            return obj.GetCategoria(categoria);
        }

        public DataSet ValidaCategoria(NoticiaCategoriaModel categoria, int operacao)
        {
            NoticiaCategoriaDAL obj = new NoticiaCategoriaDAL();
            return obj.ValidaCategoria(categoria, operacao);
        }
    }
}
