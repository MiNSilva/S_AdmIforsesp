using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebCargoModel
    {
        private int _CargoId;
        private string _Nome;
        
        public int CargoId
        {
            get { return _CargoId; }
            set { _CargoId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
    }
}
