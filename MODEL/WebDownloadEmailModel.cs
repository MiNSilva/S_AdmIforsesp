using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebDownloadEmailModel
    {
        private int _DownloadEmailid;
        private string _NomeArquivo;
        private int _Ativo;
        private string _Arquivo;
        private int _EmailId;
        private DateTime _DataEmailId;
        private int _EmailRespostaId;

        public int DownloadEmailid
        {
            get { return _DownloadEmailid; }
            set { _DownloadEmailid = value; }
        }
        public string NomeArquivo
        {
            get { return _NomeArquivo; }
            set { _NomeArquivo = value; }
        }
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
        public string Arquivo
        {
            get { return _Arquivo; }
            set { _Arquivo = value; }
        }
        public int EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        public DateTime DataEmailId
        {
            get { return _DataEmailId; }
            set { _DataEmailId = value; }
        }
        public int EmailRespostaId
        {
            get { return _EmailRespostaId; }
            set { _EmailRespostaId = value; }
        }
    }
}
