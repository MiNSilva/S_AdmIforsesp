using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class NoticiaCategoriaDAL
    {
        public void AtualizaCategoria(NoticiaCategoriaModel categoria, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasAtualizaCat", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@categoria", categoria.Categoria);
                cmd.Parameters.AddWithValue("@NoticiaDepartamentoID", categoria.NoticiaDepartamentoID);
                cmd.Parameters.AddWithValue("@NoticiaCategoriaID", categoria.NoticiaCategoriaID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaCategoria(int categoria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasCarregaCat", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@NoticiaDepartamentoID", categoria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetCategoria(NoticiaCategoriaModel categoria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetCategoria", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@NoticiaDepartamentoID", categoria.NoticiaDepartamentoID);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ValidaCategoria(NoticiaCategoriaModel categoria, int operacao)
        {
            
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebnoticiasCatvalidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", categoria.NoticiaCategoriaID);
                cmd.Parameters.AddWithValue("@NomePesq", categoria.Categoria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

    }
}
