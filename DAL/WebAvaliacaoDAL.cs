using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.DAL
{
    public class WebAvaliacaoDAL
    {
        public void AvaliacaoAtualiza(WebAvaliacaoModel avl)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlAvaliacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nIdQuestionario", avl.IdQuestionario);
                cmd.Parameters.AddWithValue("@cIdResposta", avl.IdResposta);
                cmd.ExecuteNonQuery();
            }
        }

    }

    public class WebAvaliacaoCategoriaDAL
    {
        public void CategoriaAtualiza(WebAvaliacaoCategoriaModel cat, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlCategoria", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", cat.Id);
                cmd.Parameters.AddWithValue("@cCategoria", cat.Categoria);
                cmd.Parameters.AddWithValue("@nIdUsuario", cat.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebAvaliacaoCategoriaModel> CategoriaCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlCategoriaCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebAvaliacaoCategoriaModel> list = new List<WebAvaliacaoCategoriaModel>();
                while (dr.Read())
                {
                    WebAvaliacaoCategoriaModel item = new WebAvaliacaoCategoriaModel();

                    item.Id = (int)dr["id"];

                    if (dr["Categoria"] != DBNull.Value)
                        item.Categoria = (string)dr["Categoria"];

                    item.Data = (DateTime)dr["Data"];
                    item.IdUsuario = (int)dr["IdUsuario"];
                    item.Flag = (int)dr["Flag"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }
    }

    public class WebAvaliacaoQuestionarioDAL
    {
        public void QuestionarioAtualiza(WebAvaliacaoQuestionarioModel qst, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlQuestionario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", qst.Id);
                cmd.Parameters.AddWithValue("@nIdCategoria", qst.IdCategoria);
                cmd.Parameters.AddWithValue("@cTitulo", qst.Titulo);
                cmd.Parameters.AddWithValue("@nIdUsuario", qst.IdUsuario);
                cmd.Parameters.AddWithValue("@Ativo", qst.Ativo);
                cmd.Parameters.AddWithValue("@DataExpira", qst.DataExpira);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebAvaliacaoQuestionarioModel> QuestionarioCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlQuestionarioCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebAvaliacaoQuestionarioModel> list = new List<WebAvaliacaoQuestionarioModel>();
                while (dr.Read())
                {
                    WebAvaliacaoQuestionarioModel item = new WebAvaliacaoQuestionarioModel();

                    item.Id = (int)dr["id"];
                    item.IdCategoria = (int)dr["IdCategoria"];

                    if (dr["Titulo"] != DBNull.Value)
                        item.Titulo = (string)dr["Titulo"];

                    item.Data = (DateTime)dr["Data"];
                    item.IdUsuario = (int)dr["IdUsuario"];
                    item.Flag = (int)dr["Flag"];


                    item.DataExpira = (DateTime)dr["DataExpira"];
                    item.Ativo = (int)dr["Ativo"];

                    if (dr["Status"] != DBNull.Value)
                        item.Status = (string)dr["Status"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }
    }

    public class WebAvaliacaoPerguntaDAL
    {
        public void PerguntaAtualiza(WebAvaliacaoPerguntaModel per, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlPergunta", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", per.Id);
                cmd.Parameters.AddWithValue("@nIdQuestionario", per.IdQuestionario);
                cmd.Parameters.AddWithValue("@nIdTipoResposta", per.IdTipoResposta);
                cmd.Parameters.AddWithValue("@cPergunta", per.Pergunta);
                cmd.Parameters.AddWithValue("@cResposta", per.Resposta);
                cmd.Parameters.AddWithValue("@nIdUsuario", per.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebAvaliacaoPerguntaModel> PerguntaCarrega(int nIdPerginta)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlPerguntaCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nIdPergunta", nIdPerginta);
                var dr = cmd.ExecuteReader();

                List<WebAvaliacaoPerguntaModel> list = new List<WebAvaliacaoPerguntaModel>();

                while (dr.Read())
                {
                    WebAvaliacaoPerguntaModel item = new WebAvaliacaoPerguntaModel();

                    item.Id = (int)dr["id"];
                    item.IdQuestionario = (int)dr["IdQuestionario"];
                    item.IdTipoResposta = (int)dr["IdTipoResposta"];

                    if (dr["Pergunta"] != DBNull.Value)
                        item.Pergunta = (string)dr["Pergunta"];

                    item.Data = (DateTime)dr["Data"];
                    item.IdUsuario = (int)dr["IdUsuario"];
                    item.Flag = (int)dr["Flag"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }
    }

    public class WebAvaliacaoRespostaDAL
    {
        public List<WebAvaliacaoRespostaModel> RespostaCarrega(int IdPergunta)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlRespostaCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nIdPergunta", IdPergunta);

                var dr = cmd.ExecuteReader();
                List<WebAvaliacaoRespostaModel> list = new List<WebAvaliacaoRespostaModel>();
                while (dr.Read())
                {
                    WebAvaliacaoRespostaModel item = new WebAvaliacaoRespostaModel();

                    item.Id = (int)dr["id"];

                    if (dr["Resposta"] != DBNull.Value)
                        item.Resposta = (string)dr["Resposta"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }
    }

    public class WebAvaliacaoModeloRespostaDAL
    {
        public List<WebAvaliacaoModeloRespostaModel> ModeloRespostaCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAvlModeloRepostaCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebAvaliacaoModeloRespostaModel> list = new List<WebAvaliacaoModeloRespostaModel>();
                while (dr.Read())
                {
                    WebAvaliacaoModeloRespostaModel item = new WebAvaliacaoModeloRespostaModel();

                    item.Id = (int)dr["id"];
                    if (dr["Modelo"] != DBNull.Value)
                        item.Modelo = (string)dr["Modelo"];
                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }
    }
}
