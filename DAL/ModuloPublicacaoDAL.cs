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
    public class ModuloPublicacaoDAL
    {

        int conexao = 2;
        public DataSet CarregaPublicacao()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloPublicacao", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaPublicacao(ModuloPublicacaoModel pub, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloPublicacaoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Nome", pub.Nome);
                cmd.Parameters.AddWithValue("@WebPublicacaoId", pub.WebPublicacaoId);
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidaPublicacao(ModuloPublicacaoModel pub, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloPublicacaoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", pub.WebPublicacaoId);
                cmd.Parameters.AddWithValue("@NomePesq", pub.Nome);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
    }
}
