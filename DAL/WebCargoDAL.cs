using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;

namespace DIAPOIO.DAL
{
    public class WebCargoDAL
    {
        public DataSet CarregaCargo()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCargoCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaCargoEquipe()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCargoEquipeCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaCargo(WebCargoModel grup, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebCargoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@CargoId", grup.CargoId);
                cmd.Parameters.AddWithValue("@Nome", grup.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public int ValidaCargo(WebCargoModel cargo, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebCargoValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@CargoId", cargo.CargoId);
                cmd.Parameters.AddWithValue("@Nome", cargo.Nome);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
    }
}
