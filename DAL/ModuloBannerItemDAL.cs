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
    public class ModuloBannerItemDAL
    {
        public void AtualizaBannerItem(ModuloBannerItemModel ban, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebBannerItemAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@WebBannerItemId", ban.WebBannerItemId);
                cmd.Parameters.AddWithValue("@WebBannerId", ban.WebBannerId);
                cmd.Parameters.AddWithValue("@Nome", ban.Nome);
                cmd.Parameters.AddWithValue("@Titulo", ban.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", ban.Descricao);
                cmd.Parameters.AddWithValue("@Tempo", ban.Tempo);
                cmd.Parameters.AddWithValue("@Ativo", ban.Ativo);
                cmd.Parameters.AddWithValue("@Ordem", ban.Ordem);
                cmd.Parameters.AddWithValue("@Inicio", ban.Inicio);
                cmd.Parameters.AddWithValue("@Final", ban.Final);
                cmd.Parameters.AddWithValue("@Arquivo", ban.Arquivo);
                cmd.Parameters.AddWithValue("@Link", ban.Link);
                cmd.Parameters.AddWithValue("@Externo", ban.Externo);
                cmd.Parameters.AddWithValue("@IdUsuario", ban.IdUsuario);
                cmd.Parameters.AddWithValue("@Palavra0", ban.Palavra0);
                cmd.Parameters.AddWithValue("@Palavra1", ban.Palavra1);
                cmd.Parameters.AddWithValue("@Palavra2", ban.Palavra2);
                cmd.Parameters.AddWithValue("@Palavra3", ban.Palavra3);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaBannerItem(string pesq)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloBannerItem", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@pesq", pesq);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public ModuloBannerItemModel GetBannerItemById(int id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloBannerItemById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id",id);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    ModuloBannerItemModel ban = new ModuloBannerItemModel();
                    ban.WebBannerItemId = (int)result["WebBannerItemId"];
                    ban.WebBannerId = (int)result["WebBannerId"];
                    ban.Nome = (string)result["Nome"];
                    if (result["Palavra0"] != DBNull.Value)
                        ban.Palavra0 = (string)result["Palavra0"];
                    if (result["Palavra1"] != DBNull.Value)
                        ban.Palavra1 = (string)result["Palavra1"];
                    if (result["Palavra2"] != DBNull.Value)
                        ban.Palavra2 = (string)result["Palavra2"];
                    if (result["Palavra3"] != DBNull.Value)
                        ban.Palavra3 = (string)result["Palavra3"];
                    ban.Titulo = (string)result["Titulo"];
                    ban.Descricao = (string)result["Descricao"];
                    if (result["Tempo"] != DBNull.Value)
                        ban.Tempo = (string)result["Tempo"];
                    ban.Ativo = (int)result["Ativo"];
                    ban.Ordem = (int)result["Ordem"];
                    ban.Inicio = (DateTime)result["Inicio"];
                    ban.Final = (DateTime)result["Final"];
                    ban.Arquivo = (string)result["Arquivo"];
                    ban.Link = (string)result["Link"];
                    ban.Externo = (int)result["Externo"];
                    ban.Data = (DateTime)result["Data"];
                    ban.IdUsuario = (int)result["Idusuario"];
                    return ban;
                }
                else
                {
                    return null;
                }
            }
        }

        public int GetBannerItemOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloBannerItemOrdem", CommandType.StoredProcedure);
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

        public void OrdernaBannerItem(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloBannerItemOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@WebBannerItemId", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet GetBannerItemShow()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloBannerItemShow", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
