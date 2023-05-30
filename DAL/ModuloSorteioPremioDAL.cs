using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.DAL
{
    public class ModuloSorteioPremioDAL
    {
        public DataSet CarregaGridPremio(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("Webmodulosorteiopremiocarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public void AtualizaPremio(ModuloSorteioPremioModel sortpre, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebmmodulosorteioPremioatualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@IdSorteioPremio", sortpre.IdSorteioPremio);
                cmd.Parameters.AddWithValue("@IdSorteio", sortpre.IdSorteio);
                cmd.Parameters.AddWithValue("@item", sortpre.Item);
                cmd.Parameters.AddWithValue("@Descricao", sortpre.Descricao);
                cmd.Parameters.AddWithValue("@ordem", sortpre.Ordem);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet CarregaSorteioPremioId(ModuloSorteioPremioModel sortpre, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloSorteioPremioCarregaid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@IdSorteioPremio", sortpre.IdSorteioPremio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void OrdernaPremio(int Id, int Ordem, int Operacao, int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebmoduloSorteioPremioordenaid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteioPremio", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                cmd.ExecuteNonQuery();
            }
        }

        //public DataSet GetShowPremio()
        //{
        //    using (var db = new Conexao())
        //    {
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        var cmd = db.CriarComando("WebmoduloSorteioPremioGet", CommandType.StoredProcedure);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //}

        public int GetShowPremio(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloSorteioPremioOrdem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["ordem"] != DBNull.Value)
                    {
                        return (int)result["ordem"];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public int ValidaQtdeSorteio(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloSorteioPremioValida", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["RETORNO"] != DBNull.Value)
                    {
                        return (int)result["RETORNO"];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public ModuloSorteioPremioModel CarregaSorteioPremioId(int IdSorteioPremio, int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloSorteioPremioById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteioPremio", IdSorteioPremio);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    ModuloSorteioPremioModel sortpre = new ModuloSorteioPremioModel();

                    sortpre.IdSorteioPremio = (int)result["IdSorteioPremio"];
                    sortpre.IdSorteio = (int)result["IdSorteio"];
                    if (result["Item"] != DBNull.Value)
                        sortpre.Item = (string)result["Item"];
                    if (result["Descricao"] != DBNull.Value)
                        sortpre.Descricao = (string)result["Descricao"];
                    sortpre.Ordem = (int)result["Ordem"];

                  
                    return sortpre;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
