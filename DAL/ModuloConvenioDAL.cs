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
    public class ModuloConvenioDAL
    {
        
        public void Atualiza(ModuloConvenioModel util, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("[WebmoduloConveniosatualiza]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@ConvenioId", util.ConvenioId);
                cmd.Parameters.AddWithValue("@Nome", util.Nome);
                cmd.Parameters.AddWithValue("@Imagem", util.Imagem);
                cmd.Parameters.AddWithValue("@Link", util.Link);
                cmd.Parameters.AddWithValue("@Externo", util.Externo);
                cmd.Parameters.AddWithValue("@Ordem", util.Ordem);
                cmd.Parameters.AddWithValue("@Descricao", util.Descricao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("Webgetmoduloconvenios", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int GetOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloConveniosOrdem", CommandType.StoredProcedure);
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
                var cmd = db.CriarComando("[WebmoduloConveniosordenaid]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@ConvenioId", Id);
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
                var cmd = db.CriarComando("Webgetmoduloconvenios", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaConveniosId(ModuloConvenioModel util, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("[WebmoduloConvenioscarregaid]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", util.ConvenioId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
