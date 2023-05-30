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
    public class WebQuemSomosDAL
    {
        public DataSet CarregaQuemSomos()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebQuemSomosCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaQuemSomosPaginas()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebQuemSomosCarregaPagina", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaCentenario()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebCentenarioCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public DataSet CarregaQuemSomosID(int id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebQuemSomosCarregaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@QuemSomosId", id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaQuemSomos(WebQuemSomosModel est, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("[WebquemsomosatualizaNova]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@QuemSomosId", est.QuemSomosId);
                cmd.Parameters.AddWithValue("@NomeQuemSomos", est.NomeQuemSomos);
                cmd.Parameters.AddWithValue("@DescricaoQuemSomos", est.DescricaoQuemSomos);
                cmd.Parameters.AddWithValue("@FotoPresidente", est.FotoPresidente);
                cmd.Parameters.AddWithValue("@RegistroSindical", est.RegistroSindical);

                cmd.Parameters.AddWithValue("@DataPresidente", est.DataPresidente);
                cmd.Parameters.AddWithValue("@MandatoPresidente", est.MandatoPresidente);
                cmd.Parameters.AddWithValue("@EmailPresidente", est.EmailPresidente);
                cmd.Parameters.AddWithValue("@Estatuto", est.Estatuto);

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
