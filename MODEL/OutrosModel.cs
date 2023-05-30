using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    [Serializable]
    public class AnexoModel
    {
        private string _Anexo;

        public string Anexo
        {
            get{return _Anexo; }
            set{ _Anexo = value;}
        }
    }


    [Serializable]
    public class MembrosModel
    {
        private int _UsuarioWebId;
        private string _Nome;

        public int UsuarioWebId
        {
            get
            {
                return _UsuarioWebId;
            }

            set
            {
                _UsuarioWebId = value;
            }
        }

        public string Nome
        {
            get
            {
                return _Nome;
            }

            set
            {
                _Nome = value;
            }
        }
    }

    [Serializable]
    public class RespostaModel
    {
        private int _Id;
        private int _IdQuestionario;
        private string _Resposta;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int IdQuestionario
        {
            get { return _IdQuestionario; }
            set { _IdQuestionario = value; }
        }
        public string Resposta
        {
            get { return _Resposta; }
            set { _Resposta = value; }
        }
    }

}
