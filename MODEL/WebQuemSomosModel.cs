using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebQuemSomosModel
    {
        private int _QuemSomosId;
        private string _NomeQuemSomos;
        private string _DescricaoQuemSomos;
        private int _exibe;
        private DateTime _inicio;
        private DateTime _final;
        private string _FotoPresidente;
        private string _RegistroSindical;

        private DateTime _DataPresidente;
        private string _EmailPresidente;
        private string _MandatoPresidente;
        private string _Estatuto;



        public int QuemSomosId
        {
            get { return _QuemSomosId; }
            set { _QuemSomosId = value; }
        }
        public string NomeQuemSomos
        {
            get { return _NomeQuemSomos; }
            set { _NomeQuemSomos = value; }
        }
        public string DescricaoQuemSomos
        {
            get { return _DescricaoQuemSomos; }
            set { _DescricaoQuemSomos = value; }
        }
        public int Exibe
        {
            get { return _exibe; }
            set { _exibe = value; }
        }

        public DateTime Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }

        public DateTime Final
        {
            get { return _final; }
            set { _final = value; }
        }

        public string FotoPresidente
        {
            get{return _FotoPresidente;}
            set{_FotoPresidente = value;}
        }

        public string RegistroSindical
        {
            get{return _RegistroSindical;}
            set{_RegistroSindical = value;}
        }

        public DateTime DataPresidente
        {
            get{return _DataPresidente;}
            set{_DataPresidente = value;}
        }

        public string EmailPresidente
        {
            get{return _EmailPresidente;}
            set{_EmailPresidente = value;}
        }

        public string MandatoPresidente
        {
            get{return _MandatoPresidente;}
            set{_MandatoPresidente = value;}
        }

        public string Estatuto
        {
            get
            {
                return _Estatuto;
            }

            set
            {
                _Estatuto = value;
            }
        }
    }
}
