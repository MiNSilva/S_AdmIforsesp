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
    public class WebConfigDAL
    {
        public int AtualizaConfiguracao(WebConfigModel config, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebConfigAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", config.Id);
                cmd.Parameters.AddWithValue("@EmailDiasResposta", config.EmailDiasResposta);
                cmd.Parameters.AddWithValue("@ServidorAdm", config.ServidorAdm);
                cmd.Parameters.AddWithValue("@ServidorSite", config.ServidorSite);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
        public DataSet CarregaConfig()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebConfigCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }

    
}
