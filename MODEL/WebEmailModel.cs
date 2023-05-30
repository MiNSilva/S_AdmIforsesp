using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebEmailModel
    {
        private int _EmailId;
        private string _nome;
        private string _email;
        private int _ddi;
        private int _ddd;
        private string _telefone;
        private string _cliente;
        private string _servidor;
        private string _status;
        private string _Assunto;
        private string _mensagem;
        private int _formulario;
        private int _SituacaoId;
        private int _Visualizado;
        private string _CPF;
        private int _Prioridade;
        //private string _EmailCopia;


        #region
        public int EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int Ddi
        {
            get { return _ddi; }
            set { _ddi = value; }
        }
        public int Ddd
        {
            get { return _ddd; }
            set { _ddd = value; }
        }
        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public string Servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string Assunto
        {
            get { return _Assunto; }
            set { _Assunto = value; }
        }
        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; }
        }
        public int Formulario
        {
            get { return _formulario; }
            set { _formulario = value; }
        }

        public int SituacaoId
        {
            get{return _SituacaoId;}
            set{_SituacaoId = value;}
        }

        public int Visualizado
        {
            get{return _Visualizado;}
            set{_Visualizado = value;}
        }

        public string CPF
        {
            get{return _CPF;}
            set{_CPF = value;}
        }

        public int Prioridade
        {
            get{return _Prioridade;}
            set{_Prioridade = value;}
        }

        //public string EmailCopia
        //{
        //    get{ return _EmailCopia;}
        //    set{_EmailCopia = value;}
        //}
        #endregion
    }
}
