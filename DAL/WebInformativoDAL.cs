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
    public class WebInformativoDAL
    {
        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebmoduloInformativocarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public void Atualiza(WebInformativoModel info, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebmmoduloInformativoatualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@InformativoId", info.InformativoId);
                cmd.Parameters.AddWithValue("@Nome", info.Nome);
                cmd.Parameters.AddWithValue("@Descricao", info.Descricao);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet CarregaSorteioId(WebInformativoModel info, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebmoduloInformativocarregaid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@InformativoId", info.InformativoId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
