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
    public class ModuloLegislacaoItemDAL
    {
        
        public void AtualizaLegislacaoItem(ModuloLegislacaoItemModel legis, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloLegislacaoItemAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@WebLegislacaoItemId", legis.WebLegislacaoItemId);
                cmd.Parameters.AddWithValue("@WebLegislacaoId", legis.WebLegislacaoId);
                cmd.Parameters.AddWithValue("@Nome", legis.Nome);
                cmd.Parameters.AddWithValue("@Arquivo", legis.Arquivo);
                cmd.Parameters.AddWithValue("@Ordem", legis.Ordem);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaLegislacaoItem(string pesq, int Id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloLegislacaoItem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@pesq", pesq);
                cmd.Parameters.AddWithValue("@WebLegislacaoId", Id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public ModuloLegislacaoItemModel GetLegislacaoItemById(int id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloLegislacaoItemById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id", id);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    ModuloLegislacaoItemModel leg = new ModuloLegislacaoItemModel();
                    leg.WebLegislacaoItemId = (int)result["WebLegislacaoItemId"];
                    leg.WebLegislacaoId = (int)result["WebLegislacaoId"];
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

        public int GetLegislacaoItemOrdem(int id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloLegislacaoItemOrdem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@weblegislacaoid", id);
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

        public void OrdernaLegislacaoItem(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloLegislacaoItemOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebLegislacaoItemId", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetLegislacaoItemShow(int id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloLegislacaoItemShow", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebLegislacaoId", id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int GetLegisalcaoItemShowLoad()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloLegislacaoItemLoad", CommandType.StoredProcedure);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["WebLegislacaoId"] != DBNull.Value)
                    {
                        return (int)result["WebLegislacaoId"];
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
