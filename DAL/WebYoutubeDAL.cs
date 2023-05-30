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
    public class WebYoutubeDAL
    {
        public DataSet CarregaVideo(int Id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloYoutube", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id", Id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaVideoHome()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebYoutubeHome", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void AtualizaVideo(WebYoutubeModel video, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAtualizarYoutube", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@YoutubeId", video.YoutubeId);
                cmd.Parameters.AddWithValue("@linkYoutube", video.LinkYoutube);
                cmd.Parameters.AddWithValue("@TituloYoutube", video.TituloYoutube);
                cmd.Parameters.AddWithValue("@descrYoutube", video.DescrYoutube);
                cmd.Parameters.AddWithValue("@ordemYoutube", video.OrdemYoutube);
                cmd.Parameters.AddWithValue("@ativoYoutube", video.AtivoYoutube);
                cmd.Parameters.AddWithValue("@dataYoutube", video.DataYoutube);
                cmd.Parameters.AddWithValue("@usuariowebid", video.Usuariowebid);
                cmd.ExecuteNonQuery();
            }
        }



        public DataSet GetYoutubeById(int id)
        {
            using (var db = new Conexao())
            {

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGetModuloYoutubeById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id", id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

                //var cmd = db.CriarComando("WebGetModuloYoutubeById", CommandType.StoredProcedure);
                //cmd.Parameters.AddWithValue("@id", id);
                //var result = cmd.ExecuteReader();
                //if (result.Read())
                //{
                //    WebYoutubeModel video = new WebYoutubeModel();
                //    video.YoutubeId = (int)result["YoutubeId"];
                //    video.LinkYoutube = (string)result["LinkYoutube"];
                //    video.TituloYoutube = (string)result["TituloYoutube"];
                //    video.DescrYoutube = (string)result["DescrYoutube"];
                //    video.OrdemYoutube = (int)result["OrdemYoutube"];
                //    video.AtivoYoutube = (int)result["AtivoYoutube"];
                //    video.DataYoutube = (DateTime)result["DataYoutube"];
                //    video.Usuariowebid = (int)result["Usuariowebid"];
                //    return video;
                //}
                //else
                //{
                //    return null;
                //}
            }
        }

        public int GetOrdem()
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGetModuloYoutubeOrdem", CommandType.StoredProcedure);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["ordem"] != DBNull.Value)
                    {
                        return (int)result["ordem"];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Orderna(int Id, int Ordem, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloYoutubeOrdenaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@YoutubeId", Id);
                cmd.Parameters.AddWithValue("@Ordem", Ordem);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.ExecuteNonQuery();
            }
        }
       
    }
}
