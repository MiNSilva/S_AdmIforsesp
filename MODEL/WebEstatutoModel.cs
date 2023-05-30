using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebEstatutoModel
    {
        private int _EstatutoId;
        private string _NomeEstatuto;
        private string _DescricaoEstatuto;
        private int _exibe;
        private DateTime _inicio;
        private DateTime _final;

        

        public int EstatutoId
        {
            get { return _EstatutoId; }
            set { _EstatutoId = value; }
        }
        public string NomeEstatuto
        {
            get { return _NomeEstatuto; }
            set { _NomeEstatuto = value; }
        }
        public string DescricaoEstatuto
        {
            get { return _DescricaoEstatuto; }
            set { _DescricaoEstatuto = value; }
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
    }
}
