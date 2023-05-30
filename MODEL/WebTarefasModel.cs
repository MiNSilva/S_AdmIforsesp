using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebTarefasModel
    {
        private int _Id;
        private string _Titulo;
        private int _IdCategoria;
        private string _Categoria;
        private int _IdPrioridade;
        private string _Prioridade;
        private int _IdSituacao;
        private string _Situacao;
        private DateTime _DataEntrega;
        private string _Descricao;
        private string _Anexo;
        private string _Membros;
        private DateTime _Data;
        private int _IdUsuario;
        private int _Flag;
        private string _Status;
        private string _Class;

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

        public int IdPrioridade
        {
            get
            {
                return _IdPrioridade;
            }

            set
            {
                _IdPrioridade = value;
            }
        }

        public DateTime DataEntrega
        {
            get
            {
                return _DataEntrega;
            }

            set
            {
                _DataEntrega = value;
            }
        }

        public string Descricao
        {
            get
            {
                return _Descricao;
            }

            set
            {
                _Descricao = value;
            }
        }

        public string Anexo
        {
            get
            {
                return _Anexo;
            }

            set
            {
                _Anexo = value;
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

        public int IdSituacao
        {
            get
            {
                return _IdSituacao;
            }

            set
            {
                _IdSituacao = value;
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

        public string Membros
        {
            get
            {
                return _Membros;
            }

            set
            {
                _Membros = value;
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

        public string Prioridade
        {
            get
            {
                return _Prioridade;
            }

            set
            {
                _Prioridade = value;
            }
        }

        public string Situacao
        {
            get
            {
                return _Situacao;
            }

            set
            {
                _Situacao = value;
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

        public string Class
        {
            get
            {
                return _Class;
            }

            set
            {
                _Class = value;
            }
        }

        #endregion
    }

    public class WebTarefasPrioridadeModel
    {
        private int _id;
        private string _Prioridade;
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

        public string Prioridade
        {
            get
            {
                return _Prioridade;
            }

            set
            {
                _Prioridade = value;
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

    public class WebTarefasCategoriaModel
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

    public class WebTarefasSituacaoModel
    {
        private int _id;
        private string _Situacao;
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

        public string Situacao
        {
            get
            {
                return _Situacao;
            }

            set
            {
                _Situacao = value;
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

}
