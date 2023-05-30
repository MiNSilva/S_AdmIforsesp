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
    public class WebSituacaoContatoDAL
    {
        public DataSet GetSituacaoContato()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSituacaoContato", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetSituacaoContatoNovo()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSituacaoContatoNovo", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public void AtualizaSituacaoContato(WebSituacaoContatoModel sitcontato, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebSituacaoContatoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@SituacaoContatoId", sitcontato.SituacaoContatoId);
                cmd.Parameters.AddWithValue("@SituacaoContato", sitcontato.SituacaoContato);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet ValidaSituacaoContato(WebSituacaoContatoModel sitcontato, int operacao)
        {
            
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSituacaoContatoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@SituacaoContatoId", sitcontato.SituacaoContatoId);
                cmd.Parameters.AddWithValue("@SituacaoContato", sitcontato.SituacaoContato);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
     
    }
}
