using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIAPOIO.MODEL
{
    
    public class UsuarioWebModel
    {        
        private int _UsuarioWebId;
        private string _Nome;
        private string _Login;
        private string _Senha;
        private string _Grupo;
        private string _Ativo;
        private int _defineresponsavel;
        private string _Cargo;
        private int deletado;
        private string assinatura;
        private int _ExclusaoMens;
        private int _ConcluirMens;
        private int _IdRegional;

        #region Membros
        public int UsuarioWebId
        {
            get { return _UsuarioWebId; }
            set { _UsuarioWebId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Login
        {
            get { return _Login; }
            set { _Login = value; }
        }
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }
        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

        public string Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
        public int Defineresponsavel
        {
            get { return _defineresponsavel; }
            set { _defineresponsavel = value; }
        }

        public string Cargo
        {
            get{return _Cargo;}
            set{_Cargo = value;}
        }

        public int Deletado
        {
            get{return deletado;}
            set{deletado = value;}
        }

        public string Assinatura
        {
            get{return assinatura;}
            set{assinatura = value;}
        }

        public int ExclusaoMens
        {
            get{return _ExclusaoMens;}
            set{_ExclusaoMens = value;}
        }

        public int ConcluirMens
        {
            get{return _ConcluirMens;}
            set{_ConcluirMens = value;}
        }

        public int IdRegional
        {
            get{return _IdRegional;}
            set{_IdRegional = value;}
        }
        #endregion
    }
}
