using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebYoutubeModel
    {
        private int _YoutubeId;
        private string _linkYoutube;
        private string _TituloYoutube;
        private string _descrYoutube;
        private int _ordemYoutube;
        private int _ativoYoutube;
        private DateTime _dataYoutube;
        private int _usuariowebid;

        public int YoutubeId
        {
            get { return _YoutubeId; }
            set { _YoutubeId = value; }
        }
        public string LinkYoutube
        {
            get { return _linkYoutube; }
            set { _linkYoutube = value; }
        }
        public string TituloYoutube
        {
            get { return _TituloYoutube; }
            set { _TituloYoutube = value; }
        }
        public string DescrYoutube
        {
            get { return _descrYoutube; }
            set { _descrYoutube = value; }
        }
        public int OrdemYoutube
        {
            get { return _ordemYoutube; }
            set { _ordemYoutube = value; }
        }
        public int AtivoYoutube
        {
            get { return _ativoYoutube; }
            set { _ativoYoutube = value; }
        }
        public DateTime DataYoutube
        {
            get { return _dataYoutube; }
            set { _dataYoutube = value; }
        }
        public int Usuariowebid
        {
            get { return _usuariowebid; }
            set { _usuariowebid = value; }
        }
    }
}
