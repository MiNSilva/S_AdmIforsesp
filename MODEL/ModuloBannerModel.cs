using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class ModuloBannerModel
    {
        private int _WebBannerId;
        private string _Nome;
        private int _Altura;
        private int _Largura;

        public int WebBannerId
        {
            get { return _WebBannerId; }
            set { _WebBannerId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public int Altura
        {
            get { return _Altura; }
            set { _Altura = value; }
        }
        public int Largura
        {
            get { return _Largura; }
            set { _Largura = value; }
        }
    }
}
