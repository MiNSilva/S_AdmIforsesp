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
    public class WebEmailDAL
    {
        public int AtualizaEmail(WebEmailModel email, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEmailAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@nome", email.Nome);
                cmd.Parameters.AddWithValue("@EmailId", email.EmailId);
                cmd.Parameters.AddWithValue("@email", email.Email);
                cmd.Parameters.AddWithValue("@ddi", email.Ddi);
                cmd.Parameters.AddWithValue("@ddd", email.Ddd);
                cmd.Parameters.AddWithValue("@telefone", email.Telefone);
                cmd.Parameters.AddWithValue("@cliente", email.Cliente);
                cmd.Parameters.AddWithValue("@servidor", email.Servidor);
                cmd.Parameters.AddWithValue("@status", email.Status);
                cmd.Parameters.AddWithValue("@assunto", email.Assunto);
                cmd.Parameters.AddWithValue("@mensagem", email.Mensagem);
                cmd.Parameters.AddWithValue("@formulario", email.Formulario);
                cmd.Parameters.AddWithValue("@SituacaoId", email.SituacaoId);
                cmd.Parameters.AddWithValue("@Visualizado", email.Visualizado);
                cmd.Parameters.AddWithValue("@CPF", email.CPF);
                cmd.Parameters.AddWithValue("@prioridade", email.Prioridade);
                //cmd.Parameters.AddWithValue("@EmailCopia", email.EmailCopia);

                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    int EmailId = (int)result["num"];
                    return EmailId;


                }
                else
                {
                    return 0;
                }


            }
        }

        public int ValidaContato(WebEmailModel email)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebContatoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nome", email.Nome);
                cmd.Parameters.AddWithValue("@email", email.Email);
                cmd.Parameters.AddWithValue("@assunto", email.Assunto);
                cmd.Parameters.AddWithValue("@mensagem", email.Mensagem);
                cmd.Parameters.AddWithValue("@CPF", email.CPF);

                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    int num = (int)result["num"];
                    return num;


                }
                else
                {
                    return 0;
                }


            }
        }

        public DataSet CarregaEmailNovo(string CPF, string Nome, string Assunto, int SituacaoId, int Resp, int usuariowebid, int Operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarregaNovo", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Assunto", Assunto);
                cmd.Parameters.AddWithValue("@SituacaoId", SituacaoId);
                cmd.Parameters.AddWithValue("@RespId", Resp);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEmail(string busca, int operacao, int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Busca", busca);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEmailId(int EmailId, int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailIdcarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet CarregaEmailEstatistica(int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailEstatisticas", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaNotificacoesEmail(int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailNotificacoes", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet EnviaNotificacoesEmail()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailEnvianotificacoes", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEmailPorUsuario(string  CPF)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarregaPorUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@cpf", CPF);
                da.SelectCommand = cmd;

                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaPorSituacaoId(int SituacaoId, int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarregapPorSituacaoId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@SituacaoId", SituacaoId);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet AtualizaFormularioEmail(int EmailId, int Formulario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailAtualizaFormulario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@Formulario", Formulario);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet AtualizaResponsavelEmail(int EmailId, int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailAtualizaResponsavel", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataTable RelatorioEmail(int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataTable ds = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioEmail", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataTable RelatorioEmailTotal(int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataTable ds = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioEmailTotal", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void TravaEmail(int EmailId, int operacao)
        {
            using (var db = new Conexao())
            {
               
                var cmd = db.CriarComando("WebTravaEmail", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.ExecuteReader();
            }
        }

        public int ValidaTravaEmail(int EmailId)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebValidaTravaEmail", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);

                var result = cmd.ExecuteReader();

                if (result.Read())
                {
                    int num = (int)result["Visualizado"];
                    return num;


                }
                else
                {
                    return 0;
                }
            }
        }

        public DataSet BuscaEmail(int EmailId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebBuscaEmail", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public void AlteraStatusEmail(int EmailId, int SituacaoId)
        {
            using (var db = new Conexao())
            {

                var cmd = db.CriarComando("[WebAlteraStatusEmail]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);
                cmd.Parameters.AddWithValue("@SituacaoId", SituacaoId);
                cmd.ExecuteReader();
            }
        }


        //NOVA PESQUISA
        public DataSet CarregaEmailGrid(string busca, int operacao, int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarregaGrid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Busca", busca);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaResponsavel()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebResponsavelEmail", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
