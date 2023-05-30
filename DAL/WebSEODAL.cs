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
    public class WebSEODAL
    {
        public DataSet CarregaSEO()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSEOCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaSEO(WebSEOModel seo, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebSEOAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@SEOId", seo.SEOId);
                cmd.Parameters.AddWithValue("@Nome", seo.Nome);
                cmd.Parameters.AddWithValue("@Paginas", seo.Paginas);
                cmd.Parameters.AddWithValue("@Titulo", seo.Titulo);
                cmd.Parameters.AddWithValue("@Descricao", seo.Descricao);
                cmd.Parameters.AddWithValue("@PalavrasChave", seo.PalavrasChave);
                cmd.Parameters.AddWithValue("@Empresa", seo.Empresa);
                cmd.Parameters.AddWithValue("@Rating", seo.Rating);
                cmd.Parameters.AddWithValue("@Robots", seo.Robots);
                cmd.Parameters.AddWithValue("@RevisitAfter", seo.RevisitAfter);
                cmd.Parameters.AddWithValue("@Language", seo.Language);
                cmd.Parameters.AddWithValue("@Enconding", seo.Enconding);
                cmd.Parameters.AddWithValue("@URL", seo.URL);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet ValidaSEO(string page)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebSEOPesquisaPagina", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Paginas",page);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
