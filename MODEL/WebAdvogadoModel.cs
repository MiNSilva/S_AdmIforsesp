using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebAdvogadoModel
    {
        private int _usuariowebid;
        private string _nome;
        private string _login;
        private string _senha;
        private int _grupo;
        private DateTime _data;
        private int _ativo;
        private int _deletado;

        #region
        public int Usuariowebid
        {
            get
            {
                return _usuariowebid;
            }

            set
            {
                _usuariowebid = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public string Senha
        {
            get
            {
                return _senha;
            }

            set
            {
                _senha = value;
            }
        }

        public int Grupo
        {
            get
            {
                return _grupo;
            }

            set
            {
                _grupo = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public int Ativo
        {
            get
            {
                return _ativo;
            }

            set
            {
                _ativo = value;
            }
        }

        public int Deletado
        {
            get
            {
                return _deletado;
            }

            set
            {
                _deletado = value;
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        #endregion

    }

}
