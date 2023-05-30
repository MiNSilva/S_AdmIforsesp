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
    public class WebServicosDAL
    {

        public DataSet CarregaServicos(int ServicoId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebServicosCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Id", ServicoId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaServicos(WebServicosModel serv, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebServicosAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@ServicoId", serv.ServicoId);
                cmd.Parameters.AddWithValue("@Nome", serv.Nome);
                cmd.Parameters.AddWithValue("@Slug", serv.Slug);
                cmd.Parameters.AddWithValue("@Resumo", serv.Resumo);
                cmd.Parameters.AddWithValue("@Conteudo", serv.Conteudo);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet ValidaServicos(WebServicosModel serv, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebServicosValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@ServicoId", serv.ServicoId);
                cmd.Parameters.AddWithValue("@Nome", serv.Nome);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

    }
}
