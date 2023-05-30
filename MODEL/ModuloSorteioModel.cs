using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloSorteioModel
    {
        private int _IdSorteio;
        private string _Nome;
        private DateTime _Data;
        private int _Qtde_ganhadores;
        private int _Ativo;
        private string _Regras;
        private string _Informativo;

        public int IdSorteio
        {
            get{return _IdSorteio;}
            set{_IdSorteio = value;}
        }

        public string Nome
        {
            get{return _Nome;}
            set{_Nome = value;}
        }

        public DateTime Data
        {
            get{return _Data;}
            set{_Data = value;}
        }

        public int Qtde_ganhadores
        {
            get{return _Qtde_ganhadores;}
            set{_Qtde_ganhadores = value;}
        }

        public int Ativo
        {
            get{return _Ativo;}
            set{_Ativo = value;}
        }

        public string Regras
        {
            get{return _Regras;}
            set{_Regras = value;}
        }

        public string Informativo
        {
            get{return _Informativo;}
            set{_Informativo = value;}
        }
    }
}
