using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloBannerItemModel
    {
        private int _WebBannerItemId;
        private int _WebBannerId;
        private string _Nome;
        private string _Titulo;
        private string _Descricao;
        private string _Tempo;
        private int _Ativo;
        private int _Ordem;
        private DateTime _Inicio;
        private DateTime _Final;
        private string _Arquivo;
        private string _Link;
        private int _Externo;
        private DateTime _Data;
        private int _IdUsuario;
        private string _Palavra0;
        private string _Palavra1;
        private string _Palavra2;
        private string _Palavra3;

        #region Propriedades
        public int WebBannerItemId
        {
            get { return _WebBannerItemId; }
            set { _WebBannerItemId = value; }
        }
        public int WebBannerId
        {
            get { return _WebBannerId; }
            set { _WebBannerId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }
        public string Tempo
        {
            get { return _Tempo; }
            set { _Tempo = value; }
        }
        public int Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
        public int Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }
        public DateTime Inicio
        {
            get { return _Inicio; }
            set { _Inicio = value; }
        }
        public DateTime Final
        {
            get { return _Final; }
            set { _Final = value; }
        }
        public string Arquivo
        {
            get { return _Arquivo; }
            set { _Arquivo = value; }
        }
        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
        public int Externo
        {
            get { return _Externo; }
            set { _Externo = value; }
        }
        public DateTime Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public string Palavra0
        {
            get
            {
                return _Palavra0;
            }

            set
            {
                _Palavra0 = value;
            }
        }

        public string Palavra1
        {
            get
            {
                return _Palavra1;
            }

            set
            {
                _Palavra1 = value;
            }
        }

        public string Palavra2
        {
            get
            {
                return _Palavra2;
            }

            set
            {
                _Palavra2 = value;
            }
        }

        public string Palavra3
        {
            get
            {
                return _Palavra3;
            }

            set
            {
                _Palavra3 = value;
            }
        }
        #endregion

    }
}
