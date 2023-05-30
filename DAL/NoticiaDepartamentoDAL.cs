using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIAPOIO.MODEL;
using DIAPOIO.DAL.DB;
using System.Data;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class NoticiaDepartamentoDAL
    {
        public void AtualizaDepartamento(NoticiaDepartamentoModel depto, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebnoticiasatualizadeptoNova", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@departamento", depto.Departamento);
                cmd.Parameters.AddWithValue("@noticiadepartamentoid", depto.NoticiaDepartamentoID);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet CarregaDepartamento()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasCarregaDepto", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet GetDepartamento()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebNoticiasGetDepartamentoNova", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet ValidaDepto(NoticiaDepartamentoModel depto, int operacao)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebNoticiasValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@Id", depto.NoticiaDepartamentoID);
                cmd.Parameters.AddWithValue("@NomePesq", depto.Departamento);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
        }
    }
}
