using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebCadastrosModel
    {
        private int _CadastroId;
        private string _Nome;
        private string _Email;
        private string _Senha;
        private string _CPF;
        private string _DDITel;
        private string _DDDTel;
        private string _Telefone;
        private string _DDICel;
        private string _DDDCel;
        private string _Celular;
        private int _TipoServidorId;
        private string _TipoServidor;
        private int _TipoStatusId;
        private string _TipoStatus;
        private int _TipoCadastroId;
        private string _TipoCadastro;
        private int _Cliente;
        private string _CEP;
        private string _Bairro;
        private string _Endereco;
        private string _EstadoId;
        private string _CidadeId;
        private int _ReceberEmail;
        private DateTime _DataModificado;

        private int _Autorizainfoterceiros;
        private string _NomeIndicacao;
        private string _TipoIndicacao;



        #region 

        public int CadastroId
        {
            get { return _CadastroId; }
            set { _CadastroId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }
        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }
        public string DDITel
        {
            get { return _DDITel; }
            set { _DDITel = value; }
        }
        public string DDDTel
        {
            get { return _DDDTel; }
            set { _DDDTel = value; }
        }
        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }
        public string DDICel
        {
            get { return _DDICel; }
            set { _DDICel = value; }
        }
        public string DDDCel
        {
            get { return _DDDCel; }
            set { _DDDCel = value; }
        }
        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }
        public int TipoServidorId
        {
            get { return _TipoServidorId; }
            set { _TipoServidorId = value; }
        }
        public string TipoServidor
        {
            get { return _TipoServidor; }
            set { _TipoServidor = value; }
        }
        public int TipoStatusId
        {
            get { return _TipoStatusId; }
            set { _TipoStatusId = value; }
        }
        public string TipoStatus
        {
            get { return _TipoStatus; }
            set { _TipoStatus = value; }
        }
        public int TipoCadastroId
        {
            get { return _TipoCadastroId; }
            set { _TipoCadastroId = value; }
        }
        public string TipoCadastro
        {
            get { return _TipoCadastro; }
            set { _TipoCadastro = value; }
        }
        public int Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }
        public string Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }
        public string EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }
        public string CidadeId
        {
            get { return _CidadeId; }
            set { _CidadeId = value; }
        }
        public int ReceberEmail
        {
            get { return _ReceberEmail; }
            set { _ReceberEmail = value; }
        }
        public DateTime DataModificado
        {
            get { return _DataModificado; }
            set { _DataModificado = value; }
        }

        public int Autorizainfoterceiros
        {
            get{return _Autorizainfoterceiros;}
            set{_Autorizainfoterceiros = value;}
        }

        public string NomeIndicacao
        {
            get{return _NomeIndicacao;}
            set{_NomeIndicacao = value;}
        }

        public string TipoIndicacao
        {
            get{return _TipoIndicacao;}
            set{_TipoIndicacao = value;}
        }


        #endregion

    }
}
