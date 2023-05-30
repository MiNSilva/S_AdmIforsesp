using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class GaleriaImgModel
    {
        private int _Galeriaimgid;
        private DateTime _DataEvento;
        private string _Titulo;
        private DateTime _Data;
        private int _IdUsuarioweb;
        private string _Url;
        private string _ImgPrincipal;
        private string _Imagem;
        private int _IdTipoGaleriaimg;
        private int _IdRegional;
        private int _webcoloniaid;

     

        #region Propriedades

        public int Galeriaimgid
        {
            get { return _Galeriaimgid; }
            set { _Galeriaimgid = value; }
        }
        public DateTime DataEvento
        {
            get { return _DataEvento; }
            set { _DataEvento = value; }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public DateTime Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public int IdUsuarioweb
        {
            get { return _IdUsuarioweb; }
            set { _IdUsuarioweb = value; }
        }
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        public string ImgPrincipal
        {
            get { return _ImgPrincipal; }
            set { _ImgPrincipal = value; }
        }
        public string Imagem
        {
            get { return _Imagem; }
            set { _Imagem = value; }
        }
        public int IdTipoGaleriaimg
        {
            get { return _IdTipoGaleriaimg; }
            set { _IdTipoGaleriaimg = value; }
        }
        public int IdRegional
        {
            get { return _IdRegional; }
            set { _IdRegional = value; }
        }
        public int Webcoloniaid
        {
            get { return _webcoloniaid; }
            set { _webcoloniaid = value; }
        }

        #endregion
    }

}
