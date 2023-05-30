using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebInformativoModel
    {
        private int _InformativoId;
        private string _Nome;
        private string _Descricao;
        private DateTime _Data;
        private int _Ativo;


        public int InformativoId
        {
            get{return _InformativoId;}
            set{_InformativoId = value;}
        }

        public string Nome
        {
            get{return _Nome;}
            set{_Nome = value;}
        }

        public string Descricao
        {
            get{return _Descricao;}
            set{_Descricao = value;}
        }

        public DateTime Data
        {
            get{return _Data;}
            set{_Data = value;}
        }

        public int Ativo
        {
            get{return _Ativo;}
            set{_Ativo = value;}
        }
    }
}
