using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloSorteioParticipantesModel
    {
        private int _IdSorteioParticipantes;
        private int _IdSorteio;
        private string _CPF;
        private string _Nome;
        private string _Email;
        private string _Telefone;

        public int IdSorteioParticipantes
        {
            get{return _IdSorteioParticipantes;}
            set{_IdSorteioParticipantes = value;}
        }

        public int IdSorteio
        {
            get{return _IdSorteio;}
            set{_IdSorteio = value;}
        }

        public string CPF
        {
            get{return _CPF;}
            set{_CPF = value;}
        }

        public string Nome
        {
            get{return _Nome;}
            set{_Nome = value;}
        }

        public string Email
        {
            get{return _Email;}
            set{_Email = value;}
        }

        public string Telefone
        {
            get{return _Telefone;}
            set{_Telefone = value;}
        }
    }
}
