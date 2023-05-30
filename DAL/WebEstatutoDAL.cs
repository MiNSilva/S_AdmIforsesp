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
    public class WebEstatutoDAL
    {
        
        public DataSet CarregaEstatuto()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEstatutoCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaEstatutoID(int EstatutoId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("[WebEstatutoCarregaIdNOva]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EstatutoId", EstatutoId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaEstatuto(WebEstatutoModel est, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEstatutoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@EstatutoId", est.EstatutoId);
                cmd.Parameters.AddWithValue("@NomeEstatuto", est.NomeEstatuto);
                cmd.Parameters.AddWithValue("@DescricaoEstatuto", est.DescricaoEstatuto);
                cmd.ExecuteNonQuery();
            }
        }
        //public DataSet CarregaEscritoriosPag()
        //{
        //    using (var db = new Conexao())
        //    {
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        var cmd = db.CriarComando("WebEscritorioCarregaPag", CommandType.StoredProcedure);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //}
    }
}
