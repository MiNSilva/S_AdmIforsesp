using DIAPOIO.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class ModuloLegislacaoDAL
    {

        int conexao = 2;
        public DataSet CarregaLegislacao()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloLegislacao", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaLegislacao(ModuloLegislacaoModel legis, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloLegislacaoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Nome", legis.Nome);
                cmd.Parameters.AddWithValue("@WebLegislacaoId", legis.WebLesgislacaoId);
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidaLegislacao(ModuloLegislacaoModel legis, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloLegislacaoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", legis.WebLesgislacaoId);
                cmd.Parameters.AddWithValue("@NomePesq", legis.Nome);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
    }
}
