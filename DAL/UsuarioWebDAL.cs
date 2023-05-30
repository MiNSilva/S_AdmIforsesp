using DIAPOIO.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DIAPOIO.MODEL;


namespace DIAPOIO.DAL
{
    public class UsuarioWebDAL
    {
        public UsuarioWebModel Logar(UsuarioWebModel usuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebUsuaruioWebAutenticarLogin", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@login",usuario.Login);
                cmd.Parameters.AddWithValue("@senha",usuario.Senha);

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    UsuarioWebModel user = new UsuarioWebModel();

                    user.UsuarioWebId = (int)result["UsuarioWebID"];
                    user.Nome = (string)result["Nome"];
                    user.Login = (string)result["Login"];
                    user.Senha = (string)result["Senha"];
                    user.Deletado = (int)result["deletado"];
                    user.Grupo = (string)result["Grupo"];
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSet CarregaUsuario()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebUsuarioWebSelectUsuario", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaUsuarioEspecifico(int IdUsuario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCarregaUsuarioEspecifico", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@UsuariWebid", IdUsuario);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaData(UsuarioWebModel usuario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioAtividadeMesAno", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuario.UsuarioWebId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaUsuarioRelAtvidade(int usuariowebid, string dataIni, string dataFim)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebRelatorioAtividade", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                cmd.Parameters.AddWithValue("@dataIni", dataIni);
                cmd.Parameters.AddWithValue("@dataFim", dataFim);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public int AtualizaUsuario(UsuarioWebModel rev, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {

                var cmd = db.CriarComando("WebUsuarioWebAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Nome", rev.Nome);
                cmd.Parameters.AddWithValue("@Senha", rev.Senha);
                cmd.Parameters.AddWithValue("@UsuarioWebId", rev.UsuarioWebId);
                cmd.Parameters.AddWithValue("@Login", rev.Login);
                cmd.Parameters.AddWithValue("@Grupo", rev.Grupo);
                cmd.Parameters.AddWithValue("@Ativo", rev.Ativo);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public UsuarioWebModel VerificarSenha(UsuarioWebModel usuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebVerificarSenhaUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuario.UsuarioWebId);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    usuario.UsuarioWebId = (int)result["usuariowebid"];
                    usuario.Senha = (string)result["senha"];
                    if (result["senha"] != DBNull.Value)
                        usuario.Senha = (string)result["senha"];
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public void AtualizaSenha(UsuarioWebModel usuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebUsuarioWebAtualizaSenha", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuario.UsuarioWebId);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidaUsuario(UsuarioWebModel usu, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebUsuarioWebValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebId", usu.UsuarioWebId);
                cmd.Parameters.AddWithValue("@Nome", usu.Nome);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public string ProcuraNomeUsuario(int usuarioid)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebProcuraNomeUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuarioid", usuarioid);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return (string)result["Nomeusuario"];
                }
                else
                {
                    return null;
                }
            }
        }

        public DataSet ProcuraUsuario(int usuarioid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebProcuraUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@CadastroId", usuarioid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }


        }

        public UsuarioWebModel VerificarEmail(UsuarioWebModel usuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebRecuperarEmailUsuarioWeb", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@login", usuario.Login);

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    usuario.UsuarioWebId = (int)result["UsuarioWebId"];
                    usuario.Login = (string)result["login"];
                    if (result["senha"] != DBNull.Value)
                        usuario.Senha = (string)result["senha"];
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
