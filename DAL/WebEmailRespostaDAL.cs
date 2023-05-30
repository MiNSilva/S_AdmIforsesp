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
    public class WebEmailRespostaDAL
    {
        public int AtualizaEmailResposta(WebEmailRespostaModel emailr, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEmailRespostaAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Emailid", emailr.Emailid);
                cmd.Parameters.AddWithValue("@Resposta", emailr.Resposta);
                cmd.Parameters.AddWithValue("@usuariowebid", emailr.Usuariowebid);
                
                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    int EmailRespostaId = (int)result["EmailRespostaId"];
                    return EmailRespostaId;
                }
                else
                {
                    return 0;
                }
            }
        }

        public DataSet CarregaEmailResposta(int EmailId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailRespostaCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEmailRespostaId(int EmailRespostaId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailRespostaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailRespostaId", EmailRespostaId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public String EmailBuscaResponsavelEscritorio(WebEmailRespostaModel emailr)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailBuscaResponsavelEscritorio", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", emailr.Emailid);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return (string)result["login"];
                }
                else
                {
                    return null;
                }
            }
        }
        public void FinalizarEmail(int EmailId)
        { 
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEmailFinalizar", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Emailid", EmailId);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet GetSituacaoEmail()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSituacao", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

    }
}
