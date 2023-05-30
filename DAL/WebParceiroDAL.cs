using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DIAPOIO.DAL
{
    public class WebParceiroDAL
    {
        public void Atualiza(WebParceiroMODEL parc, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebParceiroAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@ParceiroId", parc.ParceiroId);
                cmd.Parameters.AddWithValue("@Nome", parc.Nome);
                cmd.Parameters.AddWithValue("@Link", parc.Link);
                cmd.Parameters.AddWithValue("@Ativo", parc.Ativo);
                cmd.Parameters.AddWithValue("@Ordem", parc.Ordem);
                cmd.Parameters.AddWithValue("@Arquivo", parc.Arquivo);
                cmd.Parameters.AddWithValue("@Externo", parc.Externo);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebParceiroCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int GetOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebParceiroGetOrdem", CommandType.StoredProcedure);
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

        public void Orderna(int ParceiroId, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebParceiroOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@ParceiroId", ParceiroId);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetShow()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebParceiroCarregaOrdena", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ValidaParceiros(WebParceiroMODEL parc, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebParceirosValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@ParceiroId", parc.ParceiroId);
                cmd.Parameters.AddWithValue("@Nome", parc.Nome);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

     }
}
