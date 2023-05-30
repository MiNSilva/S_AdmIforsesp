using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebMenuModel
    {
        private int _ID_MENU;
        private string _DESCR_MENU;
        private string _NOME_MENU;
        private string _HIERARQUIA_MENU;
        private string _LINK_MENU;
        private string _PERMITIDO;

        public int ID_MENU
        {
            get { return _ID_MENU; }
            set { _ID_MENU = value; }
        }
        public string DESCR_MENU
        {
            get { return _DESCR_MENU; }
            set { _DESCR_MENU = value; }
        }
        public string NOME_MENU
        {
            get { return _NOME_MENU; }
            set { _NOME_MENU = value; }
        }
        public string HIERARQUIA_MENU
        {
            get { return _HIERARQUIA_MENU; }
            set { _HIERARQUIA_MENU = value; }
        }
        public string LINK_MENU
        {
            get { return _LINK_MENU; }
            set { _LINK_MENU = value; }
        }
        public string PERMITIDO
        {
            get { return _PERMITIDO; }
            set { _PERMITIDO = value; }
        }
    }
}
