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
    public class WebFeriadoDAL
    {
        public DataSet CarregarFeriado()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCarregarFeriado", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int AtualizaFeriado(WebFeriadoModel feriado, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAtualizaFeriado", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", feriado.Id);
                cmd.Parameters.AddWithValue("@Feriado", feriado.Feriado);
                cmd.Parameters.AddWithValue("@DataFeriado", feriado.DataFeriado);
                cmd.Parameters.AddWithValue("@IdUsuarioWeb", feriado.IdUsuarioWeb);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

    }
}
