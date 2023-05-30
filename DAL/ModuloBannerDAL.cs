using DIAPOIO.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;

namespace DIAPOIO.DAL
{
    public class ModuloBannerDAL
    {
        public void AtualizaBanner(ModuloBannerModel ban, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloBannerAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Nome", ban.Nome);
                cmd.Parameters.AddWithValue("@Altura", ban.Altura);
                cmd.Parameters.AddWithValue("@Largura", ban.Largura);
                cmd.Parameters.AddWithValue("@WebBannerId", ban.WebBannerId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaBanner()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloBanner", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ValidaBanner(ModuloBannerModel ban, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebmodulobannervalidacaoNova", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", ban.WebBannerId);
                cmd.Parameters.AddWithValue("@NomeBanner", ban.Nome);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaBannerItens(ModuloBannerModel ban)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebBannerCarregaItens", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@BannerId", ban.WebBannerId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
