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
    public class WebGrupoDAL
    {

        public DataSet CarregaGrupo()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGrupoUsuariosCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaGrupo(WebGrupoMODEL grup, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGrupoUsuariosAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Descricao", grup.Descricao);
                cmd.Parameters.AddWithValue("@GrupoId", grup.GrupoId);
                cmd.ExecuteNonQuery();
            }
        }
        public int ValidaGrupo(WebGrupoMODEL grup, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGrupoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@GrupoId", grup.GrupoId);
                cmd.Parameters.AddWithValue("@Descricao", grup.Descricao);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

    }
}
