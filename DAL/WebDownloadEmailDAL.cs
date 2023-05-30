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
    public class WebDownloadEmailDAL
    {
        

        public void AtualizaDownloadEmail(WebDownloadEmailModel downemail, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebDownloadEmailAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@DownloadEmailid", downemail.DownloadEmailid);
                cmd.Parameters.AddWithValue("@NomeArquivo", downemail.NomeArquivo);
                cmd.Parameters.AddWithValue("@ativo", downemail.Ativo);
                cmd.Parameters.AddWithValue("@Arquivo", downemail.Arquivo);
                cmd.Parameters.AddWithValue("@EmailId", downemail.EmailId);
                cmd.Parameters.AddWithValue("@DataEmailId", downemail.DataEmailId);
                cmd.Parameters.AddWithValue("@EmailRespostaId", downemail.EmailRespostaId);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet CarregaDownloadEmailUrl(string url)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCarregaDownloadEmailUrl", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaDownloadAnexos(int EmailRespostaId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebDownloadEmailAnexosporEmailRespostaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailRespostaId", EmailRespostaId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaDownloadAnexosId(int downloadEmailId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("[WebdownloademailanexosDownId]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@downloadEmailId", downloadEmailId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
