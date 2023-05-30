using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using DIAPOIO.DAL.DB;
using System.Data;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class ModuloDuvidaDAL
    {
    
        public void AtualizaDuvida(ModuloDuvidaModel duv, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloDuvidaAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Pergunta", duv.Pergunta);
                cmd.Parameters.AddWithValue("@Resposta", duv.Resposta);
                cmd.Parameters.AddWithValue("@WebDuvidaId", duv.WebDuvidaId);
                cmd.Parameters.AddWithValue("@Ordem", duv.Ordem);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloDuvida", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int ValidaDuvida(ModuloDuvidaModel duv, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloDuvidaValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", duv.WebDuvidaId);
                cmd.Parameters.AddWithValue("@NomePesq", duv.Pergunta);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }


        public DataSet CarregaDuvidaId(ModuloDuvidaModel duv, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloDuvidaCarregaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", duv.WebDuvidaId);
                cmd.Parameters.AddWithValue("@NomePesq", duv.Pergunta);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public int GetDuvidaOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloDuvidaOrdem", CommandType.StoredProcedure);
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

        public void OrdernaDuvida(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloDuvidaOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebDuvidaId", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetDuvidaShow()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloDuvida", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
