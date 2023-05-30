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
    public class ModuloPublicacaoItemDAL
    {
        
        public void AtualizaPublicacaoItem(ModuloPublicacaoItemModel legis, int operacao, int IdUsuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloPublicacaoItemAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@WebPublicacaoItemId", legis.WebPublicacaoItemId);
                cmd.Parameters.AddWithValue("@WebPublicacaoId", legis.WebPublicacaoId);
                cmd.Parameters.AddWithValue("@Nome", legis.Nome);
                cmd.Parameters.AddWithValue("@Arquivo", legis.Arquivo);
                cmd.Parameters.AddWithValue("@Ordem", legis.Ordem);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaPublicacaoItem(string pesq, int Id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloPublicacaoItem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@pesq", pesq);
                cmd.Parameters.AddWithValue("@WebPublicacaoId", Id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public ModuloPublicacaoItemModel GetPublicacaoItemById(int id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloPublicacaoItemById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id", id);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    ModuloPublicacaoItemModel leg = new ModuloPublicacaoItemModel();
                    leg.WebPublicacaoItemId = (int)result["WebPublicacaoItemId"];
                    leg.WebPublicacaoId = (int)result["WebPublicacaoId"];
                    leg.Nome = (string)result["Nome"];
                    leg.Arquivo = (string)result["Arquivo"];
                    leg.Ordem = (int)result["Ordem"];
                    return leg;
                }
                else
                {
                    return null;
                }
            }
        }

        public int GetPublicacaoItemOrdem(int id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloPublicacaoItemOrdem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@webPublicacaoid", id);
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

        public void OrdernaPublicacaoItem(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloPublicacaoItemOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebPublicacaoItemId", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetPublicacaoItemShow(int id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloPublicacaoItemShow", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebPublicacaoId", id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int GetPublicacaoItemShowLoad()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloPublicacaoItemLoad", CommandType.StoredProcedure);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["WebPublicacaoId"] != DBNull.Value)
                    {
                        return (int)result["WebPublicacaoId"];
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
    }
}
