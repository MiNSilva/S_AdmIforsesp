using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL.DB;
using DIAPOIO.DAL;
using System.Data;
using System.Data.SqlClient;

namespace DIAPOIO.DAL
{
    public class GaleriaImgDAL
    {
        int conexao = 2;
        public void AtualizaGaleria(GaleriaImgModel galeria, int Operacao, string imagens)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAtualizarGaleria", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@DataEvento", galeria.DataEvento);
                cmd.Parameters.AddWithValue("@Titulo", galeria.Titulo);
                cmd.Parameters.AddWithValue("@IdUsuario", galeria.IdUsuarioweb);
                cmd.Parameters.AddWithValue("@URl", galeria.Url);
                cmd.Parameters.AddWithValue("@imgPrincipal", galeria.ImgPrincipal);
                cmd.Parameters.AddWithValue("@Id", galeria.Galeriaimgid);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                cmd.Parameters.AddWithValue("@imagens", imagens);
                cmd.Parameters.AddWithValue("@IdTipoGaleriaImg", galeria.IdTipoGaleriaimg);
                cmd.Parameters.AddWithValue("@IdRegional", galeria.IdRegional);
                cmd.Parameters.AddWithValue("@webcoloniaid", galeria.Webcoloniaid);
                cmd.ExecuteNonQuery();
            }
        }


        public void AtualizaTituloGal(string url, string titulo)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebatualizarTitulogal", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.ExecuteNonQuery();
            }
        }


        public DataSet CarregaGaleriaTop(int Qtde, int tipogaleria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriaTop", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Qtde", Qtde);
                cmd.Parameters.AddWithValue("@tipogaleria", tipogaleria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        //public DataSet CarregaGaleriaUrl(string url)
        //{
        //    using (var db = new Conexao())
        //    {
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter();
        //        var cmd = db.CriarComando("WebGaleriaUrl", CommandType.StoredProcedure);
        //        cmd.Parameters.AddWithValue("@url", url);
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        return ds;
        //    }
        //}

        public DataSet CarregaGaleriaWebcoloniaid(int webcoloniaId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriaWebcoloniaId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@webcoloniaid", webcoloniaId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public string ProcuraColoniaporUrl(string url)
        {
            using (var db = new Conexao())
            {
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebProcuraColoniaPorUrl", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                da.SelectCommand = cmd;

                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["titulo"] != DBNull.Value)
                        url = (string)result["titulo"];
                    return url;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<GaleriaImgModel> CarregaGaleriaUrl(string url)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGaleriaUrl", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                var dr = cmd.ExecuteReader();

                List<GaleriaImgModel> list = new List<GaleriaImgModel>();

                while (dr.Read())
                {
                    GaleriaImgModel img = new GaleriaImgModel();
                    img.Galeriaimgid = (int)dr["GaleriaImgId"];
                    img.DataEvento = (DateTime)dr["DataEvento"];
                    img.Titulo = (string)dr["Titulo"];
                    img.Data = (DateTime)dr["Data"];
                    img.IdUsuarioweb = (int)dr["IdUsuarioWeb"];
                    img.Url = (string)dr["url"];
                    img.ImgPrincipal = (string)dr["ImgPrincipal"];
                    img.Imagem = (string)dr["imagem"];
                    img.IdTipoGaleriaimg = (int)dr["IdTipoGaleriaImg"];
                    img.IdRegional = (int)dr["IdRegional"];
                    list.Add(img);
                }
                dr.Close();
                return list;
            }
        }

        public List<GaleriaImgModel> CarregaGaleriaColonia(string colonia)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebGaleriaColonia", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@webcoloniaid", colonia);
                var dr = cmd.ExecuteReader();

                List<GaleriaImgModel> list = new List<GaleriaImgModel>();

                while (dr.Read())
                {
                    GaleriaImgModel img = new GaleriaImgModel();
                    img.Galeriaimgid = (int)dr["GaleriaImgId"];
                    img.DataEvento = (DateTime)dr["DataEvento"];
                    img.Titulo = (string)dr["Titulo"];
                    img.Data = (DateTime)dr["Data"];
                    img.IdUsuarioweb = (int)dr["IdUsuarioWeb"];
                    img.Url = (string)dr["url"];
                    img.ImgPrincipal = (string)dr["ImgPrincipal"];
                    img.Imagem = (string)dr["imagem"];
                    img.IdTipoGaleriaimg = (int)dr["IdTipoGaleriaImg"];
                    img.IdRegional = (int)dr["IdRegional"];
                    list.Add(img);
                }
                dr.Close();
                return list;
            }
        }

        public DataSet CarregaMesAno(int TipoGaleria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriaMesAno", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@TipoGaleria", TipoGaleria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaGaleriaByData(string Mes, string Ano, int TipoGaleria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriaByData", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Mes", Mes);
                cmd.Parameters.AddWithValue("@Ano", Ano);
                cmd.Parameters.AddWithValue("@TipoGaleria", TipoGaleria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaTodasGalerias()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriasAll", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaGaleriasByIdRegional(int IdRegional, int TipoGaleria)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriasByIdRegional", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdRegional", IdRegional);
                cmd.Parameters.AddWithValue("@TipoGaleria", TipoGaleria);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaGaleriasById(string url, int webColoniaid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriasById", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                cmd.Parameters.AddWithValue("@webColoniaid", webColoniaid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet CarregaTipoGaleriaImg()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebTipoGaleriaImgAll", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet CarregaGaleriaTodas()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriaMesAnoAll", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaGaleriaByUrl(string url)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebGaleriasByUrl", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@url", url);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
