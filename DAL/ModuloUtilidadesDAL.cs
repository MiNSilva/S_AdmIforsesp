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
    public class ModuloUtilidadesDAL
    {
        
        public void Atualiza(ModuloUtilidadesModel util, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloUtilidadeAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@WebUtilidadeId", util.WebUtilidadeId);
                cmd.Parameters.AddWithValue("@Nome", util.Nome);
                cmd.Parameters.AddWithValue("@Imagem", util.Imagem);
                cmd.Parameters.AddWithValue("@Link", util.Link);
                cmd.Parameters.AddWithValue("@Externo", util.Externo);
                cmd.Parameters.AddWithValue("@Ordem", util.Ordem);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloUtilidade", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int GetOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloUtilidadeOrdem", CommandType.StoredProcedure);
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

        public void Orderna(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloUtilidadeOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebUtilidadeId", Id);
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
                var cmd = db.CriarComando("WebGetModuloUtilidade", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaUtilidadeId(ModuloUtilidadesModel util, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloUtilidadeCarregaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", util.WebUtilidadeId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
