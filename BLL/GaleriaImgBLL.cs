using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System.Data;

namespace DIAPOIO.BLL
{
    public class GaleriaimagesBLL
    {
        public void AtualizaGaleria(GaleriaImgModel galeria, int Operacao, string imagens)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            obj.AtualizaGaleria(galeria, Operacao, imagens);
        }

        public void AtualizaTituloGal(string url, string titulo)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            obj.AtualizaTituloGal(url, titulo);
        }


        public DataSet CarregaGaleriaTop(int Qtde, int tipoGaleria)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaTop(Qtde, tipoGaleria);
        }
        public DataSet CarregaGaleriaWebcoloniaid(int webcoloniaid)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaWebcoloniaid(webcoloniaid);
        }

        public string ProcuraColoniaporUrl(string url)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.ProcuraColoniaporUrl(url);
        }


        public List<GaleriaImgModel> CarregaGaleriaUrl(string url)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaUrl(url);
        }
        public List<GaleriaImgModel> CarregaGaleriaColonia(string colonia)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaColonia(colonia);
        }

        //public DataSet CarregaGaleriaUrl(string url)
        //{
        //    GaleriaImgDAL obj = new GaleriaImgDAL();
        //    return obj.CarregaGaleriaUrl(url);
        //}

        public DataSet CarregaMesAno(int TipoGaleria)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaMesAno(TipoGaleria);
        }

        public DataSet CarregaGaleriaByData(string Mes, string Ano,int TipoGaleria)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaByData(Mes, Ano, TipoGaleria);
        }

        public DataSet CarregaTodasGalerias()
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaTodasGalerias();
        }

        public DataSet CarregaGaleriasByIdRegional(int id, int TipoGaleria)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriasByIdRegional(id, TipoGaleria);
        }

        public DataSet CarregaGaleriasById(string  url, int TipoGaleria)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriasById(url, TipoGaleria);
        }

        public DataSet CarregaTipoGaleriaimages()
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaTipoGaleriaImg();
        }

        public DataSet CarregaGaleriaTodas()
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaTodas();
        }

        public DataSet CarregaGaleriaByUrl(string url)
        {
            GaleriaImgDAL obj = new GaleriaImgDAL();
            return obj.CarregaGaleriaByUrl(url);
        }

    }
}
