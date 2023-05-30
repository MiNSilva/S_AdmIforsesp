using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL.DB;
using System.Data;

namespace DIAPOIO.DAL
{
    public class WebTarefasDAL
    {
        public List<UsuarioWebModel> TarefaMembros()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafMembros", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<UsuarioWebModel> list = new List<UsuarioWebModel>();
                while (dr.Read())
                {
                    UsuarioWebModel item = new UsuarioWebModel();

                    item.UsuarioWebId = (int)dr["UsuarioWebId"];

                    if (dr["nome"] != DBNull.Value)
                        item.Nome = (string)dr["nome"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }

        public List<WebTarefasModel> TarefasCarrega(int nOperacao, int nId, string usuariowebid)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafTarefasCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", nId);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                var dr = cmd.ExecuteReader();

                List<WebTarefasModel> list = new List<WebTarefasModel>();

                while (dr.Read())
                {
                    WebTarefasModel item = new WebTarefasModel();

                    item.Id = (int)dr["id"];

                    if (dr["Titulo"] != DBNull.Value)
                        item.Titulo = (string)dr["Titulo"];

                    item.IdCategoria = (int)dr["IdCategoria"];
                    if (dr["Categoria"] != DBNull.Value)
                        item.Categoria = (string)dr["Categoria"];

                    item.IdPrioridade = (int)dr["IdPrioridade"];
                    if (dr["Prioridade"] != DBNull.Value)
                        item.Prioridade = (string)dr["Prioridade"];

                    item.IdSituacao = (int)dr["IdSituacao"];
                    if (dr["Situacao"] != DBNull.Value)
                        item.Situacao = (string)dr["Situacao"];

                    item.DataEntrega = (DateTime)dr["DataEntrega"];

                    if (dr["Descricao"] != DBNull.Value)
                        item.Descricao = (string)dr["Descricao"];

                    if (dr["Anexo"] != DBNull.Value)
                        item.Anexo = (string)dr["Anexo"];

                    if (dr["Membros"] != DBNull.Value)
                        item.Membros = (string)dr["Membros"];

                    if (dr["Status"] != DBNull.Value)
                        item.Status = (string)dr["Status"];

                    if (dr["Class"] != DBNull.Value)
                        item.Class = (string)dr["Class"];

                    item.Data = (DateTime)dr["Data"];
                    item.IdUsuario = (int)dr["IdUsuario"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }


        public List<WebTarefasModel> TarefasCarregaFiltros(string Prioridade, string Categoria, string Situacao, string Membro)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebtaftarefascarregaFiltros", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Prioridade", Prioridade);
                cmd.Parameters.AddWithValue("@Categoria", Categoria);
                cmd.Parameters.AddWithValue("@Situacao", Situacao);
                cmd.Parameters.AddWithValue("@Membro", Membro);
                var dr = cmd.ExecuteReader();

                List<WebTarefasModel> list = new List<WebTarefasModel>();

                while (dr.Read())
                {
                    WebTarefasModel item = new WebTarefasModel();

                    item.Id = (int)dr["id"];

                    if (dr["Titulo"] != DBNull.Value)
                        item.Titulo = (string)dr["Titulo"];

                    item.IdCategoria = (int)dr["IdCategoria"];
                    if (dr["Categoria"] != DBNull.Value)
                        item.Categoria = (string)dr["Categoria"];

                    item.IdPrioridade = (int)dr["IdPrioridade"];
                    if (dr["Prioridade"] != DBNull.Value)
                        item.Prioridade = (string)dr["Prioridade"];

                    item.IdSituacao = (int)dr["IdSituacao"];
                    if (dr["Situacao"] != DBNull.Value)
                        item.Situacao = (string)dr["Situacao"];

                    item.DataEntrega = (DateTime)dr["DataEntrega"];

                    if (dr["Descricao"] != DBNull.Value)
                        item.Descricao = (string)dr["Descricao"];

                    if (dr["Anexo"] != DBNull.Value)
                        item.Anexo = (string)dr["Anexo"];

                    if (dr["Membros"] != DBNull.Value)
                        item.Membros = (string)dr["Membros"];

                    if (dr["Status"] != DBNull.Value)
                        item.Status = (string)dr["Status"];

                    if (dr["Class"] != DBNull.Value)
                        item.Class = (string)dr["Class"];

                    item.Data = (DateTime)dr["Data"];
                    item.IdUsuario = (int)dr["IdUsuario"];

                    list.Add(item);
                }
                dr.Close();
                return list;
            }
        }

        public void TarefasAtualiza(WebTarefasModel taf, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafTarefas", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", taf.Id);
                cmd.Parameters.AddWithValue("@cTitulo", taf.Titulo);
                cmd.Parameters.AddWithValue("@nIdCategoria", taf.IdCategoria);
                cmd.Parameters.AddWithValue("@nIdPrioridade", taf.IdPrioridade);
                cmd.Parameters.AddWithValue("@nIdSituacao", taf.IdSituacao);
                cmd.Parameters.AddWithValue("@dDataEntrega", taf.DataEntrega);
                cmd.Parameters.AddWithValue("@cDescricao", taf.Descricao);
                cmd.Parameters.AddWithValue("@cAnexo", taf.Anexo);
                cmd.Parameters.AddWithValue("@cMembros", taf.Membros);
                cmd.Parameters.AddWithValue("@nIdUsuario", taf.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class WebTarefasPrioridadeDAL
    {
        public void PrioridadeAtualiza(WebTarefasPrioridadeModel prio, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafPrioridade", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", prio.Id);
                cmd.Parameters.AddWithValue("@cPrioridade", prio.Prioridade);
                cmd.Parameters.AddWithValue("@nIdUsuario", prio.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebTarefasPrioridadeModel> PrioridadeCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafPrioridadeCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebTarefasPrioridadeModel> list = new List<WebTarefasPrioridadeModel>();
                while (dr.Read())
                {
                    WebTarefasPrioridadeModel item = new WebTarefasPrioridadeModel();

                    item.Id = (int)dr["id"];

                    if (dr["Prioridade"] != DBNull.Value)
                        item.Prioridade = (string)dr["Prioridade"];

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

    public class WebTarefasCategoriaDAL
    {
        public void CategoriaAtualiza(WebTarefasCategoriaModel cat, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafCategoria", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", cat.Id);
                cmd.Parameters.AddWithValue("@cCategoria", cat.Categoria);
                cmd.Parameters.AddWithValue("@nIdUsuario", cat.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebTarefasCategoriaModel> CategoriaCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafCategoriaCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebTarefasCategoriaModel> list = new List<WebTarefasCategoriaModel>();
                while (dr.Read())
                {
                    WebTarefasCategoriaModel item = new WebTarefasCategoriaModel();

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

    public class WebTarefasSituacaoDAL
    {
        public void SituacaoAtualiza(WebTarefasSituacaoModel sit, int nOperacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafSituacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", nOperacao);
                cmd.Parameters.AddWithValue("@nId", sit.Id);
                cmd.Parameters.AddWithValue("@cSituacao", sit.Situacao);
                cmd.Parameters.AddWithValue("@nIdUsuario", sit.IdUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        public List<WebTarefasSituacaoModel> SituacaoCarrega()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebTafSituacaoCarrega", CommandType.StoredProcedure);

                var dr = cmd.ExecuteReader();
                List<WebTarefasSituacaoModel> list = new List<WebTarefasSituacaoModel>();
                while (dr.Read())
                {
                    WebTarefasSituacaoModel item = new WebTarefasSituacaoModel();

                    item.Id = (int)dr["id"];

                    if (dr["Situacao"] != DBNull.Value)
                        item.Situacao = (string)dr["Situacao"];

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

}
