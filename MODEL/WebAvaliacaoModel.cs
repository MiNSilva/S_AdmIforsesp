using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebAvaliacaoModel
    {
        private int _Id;
        private int _IdQuestionario;
        private string _IdResposta;
        private DateTime _Data;

        #region Propriedades
        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string IdResposta
        {
            get
            {
                return _IdResposta;
            }

            set
            {
                _IdResposta = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }

        public int IdQuestionario
        {
            get
            {
                return _IdQuestionario;
            }

            set
            {
                _IdQuestionario = value;
            }
        }
        #endregion
    }

    public class WebAvaliacaoQuestionarioModel
    {
        private int _Id;
        private int _IdCategoria;
        private string _Titulo;
        private DateTime _Data;
        private int _IdUsuario;
        private int _Flag;
        private DateTime _DataExpira;
        private int _Ativo;
        private string _Status;

        #region Propriedades

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
            }
        }

        public string Titulo
        {
            get
            {
                return _Titulo;
            }

            set
            {
                _Titulo = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }


        public int IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public int Flag
        {
            get
            {
                return _Flag;
            }

            set
            {
                _Flag = value;
            }
        }

        public DateTime DataExpira
        {
            get
            {
                return _DataExpira;
            }

            set
            {
                _DataExpira = value;
            }
        }

        public int Ativo
        {
            get
            {
                return _Ativo;
            }

            set
            {
                _Ativo = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }

            set
            {
                _Status = value;
            }
        }
        #endregion
    }

    public class WebAvaliacaoCategoriaModel
    {
        private int _id;
        private string _Categoria;
        private DateTime _Data;
        private int _IdUsuario;
        private int _Flag;

        #region Propriedades

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Categoria
        {
            get
            {
                return _Categoria;
            }

            set
            {
                _Categoria = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public int Flag
        {
            get
            {
                return _Flag;
            }

            set
            {
                _Flag = value;
            }
        }

        #endregion
    }

    public class WebAvaliacaoPerguntaModel
    {
        private int _Id;
        private int _IdQuestionario;
        private int _IdTipoResposta;
        private string _Pergunta;
        private DateTime _Data;
        private int _IdUsuario;
        private int _Flag;
        private string _Resposta;

        #region Propriedades

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public int IdQuestionario
        {
            get
            {
                return _IdQuestionario;
            }

            set
            {
                _IdQuestionario = value;
            }
        }

        public int IdTipoResposta
        {
            get
            {
                return _IdTipoResposta;
            }

            set
            {
                _IdTipoResposta = value;
            }
        }

        public string Pergunta
        {
            get
            {
                return _Pergunta;
            }

            set
            {
                _Pergunta = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public int Flag
        {
            get
            {
                return _Flag;
            }

            set
            {
                _Flag = value;
            }
        }

        public string Resposta
        {
            get
            {
                return _Resposta;
            }

            set
            {
                _Resposta = value;
            }
        }

        #endregion
    }

    public class WebAvaliacaoModeloRespostaModel
    {
        private int _Id;
        private string _Modelo;

        #region Propriedades

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Modelo
        {
            get
            {
                return _Modelo;
            }

            set
            {
                _Modelo = value;
            }
        }

        #endregion
    }

    public class WebAvaliacaoRespostaModel
    {
        private int _Id;
        private string _Resposta;

        #region Propriedades

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Resposta
        {
            get
            {
                return _Resposta;
            }

            set
            {
                _Resposta = value;
            }
        }
        #endregion
    }

}
