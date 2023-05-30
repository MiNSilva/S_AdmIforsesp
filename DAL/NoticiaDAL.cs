using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class NoticiaDAL
    {
        public void AtualizaNoticia(NoticiaModel noticia, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebnoticiasatualizaNova", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@NoticiaDepartamentoID", noticia.NoticiaDepartamentoID);
                cmd.Parameters.AddWithValue("@NoticiaCategoriaID", noticia.NoticiaCategoriaID);
                cmd.Parameters.AddWithValue("@titulo", noticia.Titulo);
                cmd.Parameters.AddWithValue("@resumo", noticia.Resumo);
                cmd.Parameters.AddWithValue("@noticia", noticia.Noticia);
                cmd.Parameters.AddWithValue("@imagem1", noticia.Imagem1);
                cmd.Parameters.AddWithValue("@autor", noticia.Autor);
                cmd.Parameters.AddWithValue("@situacao", noticia.Situacao);
                cmd.Parameters.AddWithValue("@DataNoticia", noticia.DataNoticia);
                cmd.Parameters.AddWithValue("@noticiaid", noticia.NoticiaID);
                cmd.Parameters.AddWithValue("@IdRegional", noticia.IdRegional);
                cmd.Parameters.AddWithValue("@usuariowebid", noticia.Usuariowebid);
                cmd.Parameters.AddWithValue("@DestaqueId", noticia.DestaqueId);
                cmd.Parameters.AddWithValue("@TipoDep", noticia.DestaqueId);


                cmd.ExecuteNonQuery();
            }
        }

        public List<NoticiaModel> CarregaNoticiaAprovacao(int IdUsuario)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasAprovacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@UsuarioWebId", IdUsuario);

                var dr = cmd.ExecuteReader();
                List<NoticiaModel> list = new List<NoticiaModel>();
                while (dr.Read())
                {
                    NoticiaModel noticia = new NoticiaModel();
                    noticia.NoticiaID = (int)dr["NoticiaID"];
                    noticia.Autor = (string)dr["Autor"];
                    noticia.Titulo = (string)dr["Titulo"];
                    noticia.Resumo = (string)dr["Resumo"];
                    noticia.Noticia = (string)dr["Noticia"];
                    noticia.DataNoticia = (DateTime)dr["DataNoticia"];
                    noticia.Data = (DateTime)dr["Data"];
                    noticia.Situacao = (string)dr["Situacao"];
                    list.Add(noticia);
                }
                dr.Close();
                return list;
            }
        }

        public void AlteraSituacaoNoticia(NoticiaModel noticia)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasSituacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@NoticiaID", noticia.NoticiaID);
                cmd.Parameters.AddWithValue("@Situacao", noticia.Situacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaTodasNoticias(string pesquisa)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasAll", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Busca", pesquisa);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaNoticiasTop(int Qtde, int DeptoId, int NoticiaID)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasTop", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Qtde", Qtde);
                cmd.Parameters.AddWithValue("@DeptoId", DeptoId);
                cmd.Parameters.AddWithValue("@NoticiaId", NoticiaID);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaNoticiasHome(int Qtde)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasDefault", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Qtde", Qtde);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet CarregaNoticiaById(int Id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasByID", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@NoticiaID", Id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public NoticiaModel CarregaNoticiaById(NoticiaModel noticia)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasByID", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@NoticiaID", noticia.NoticiaID);

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    noticia.NoticiaDepartamentoID = (int)result["NoticiaDepartamentoID"];
                    noticia.NoticiaCategoriaID = (int)result["NoticiaCategoriaID"];
                    noticia.Titulo = (string)result["Titulo"];
                    noticia.Resumo = (string)result["Resumo"];
                    noticia.Noticia = (string)result["Noticia"];
                    noticia.Imagem1 = (string)result["imagem1"];
                    noticia.Imagem2 = (string)result["imagem2"];
                    noticia.Imagem3 = (string)result["imagem3"];
                    noticia.Imagem4 = (string)result["imagem4"];
                    noticia.Arquivo1 = (string)result["Arquivo1"];
                    noticia.Arquivo2 = (string)result["Arquivo2"];
                    noticia.Autor = (string)result["Autor"];
                    noticia.Situacao = (string)result["Situacao"];
                    noticia.Contador = (int)result["Contador"];
                    noticia.Data = (DateTime)result["Data"];
                    noticia.DataNoticia = (DateTime)result["DataNoticia"];
                    noticia.DestaqueId = (int)result["DestaqueHome"];
                    return noticia;
                }
                else
                {
                    return null;
                }

            }
        }

        public DataSet CarregaMesAnoPublicado(int DeptoId, int Operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetMesAnoPublic", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@DeptoId", DeptoId);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaMesAnoPublicadoTodos(int DeptoId ,int Operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetMesAnoPublicAll", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@DeptoId", DeptoId);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
 
        public DataSet CarregaCategPublicado(int DeptoId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetCategPublic", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@DeptoID", DeptoId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaCategPublicadoTodos(int DeptoId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetCategPublicAll", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@DeptoID", DeptoId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaNoticiaByCateg(int IdCateg)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasByCateg", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdCateg", IdCateg);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaNoticiaByData(string Mes, string Ano, int DeptoId, int Operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasByData", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Mes", Mes);
                cmd.Parameters.AddWithValue("@Ano", Ano);
                cmd.Parameters.AddWithValue("@DeptoID", DeptoId);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int VerificaUpld(string pesq, int num)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasVerificaUpld", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@pesq", pesq);
                cmd.Parameters.AddWithValue("@num", num);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string DeptosUsuario(int Id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasDeptosUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@UsuarioWebId", Id);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return (string)result["deptosId"];
                }
                else
                {
                    return null;
                }
            }
        }

        public void EmailAprovador(int Depto)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("EnviarEmail", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Depto", Depto);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet BuscaNoticia(string Busca, int Depto, int Todas)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasBusca", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Busca", Busca);
                cmd.Parameters.AddWithValue("@DeptoId", Depto);
                cmd.Parameters.AddWithValue("@Todas", Todas);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
       
    }
}
