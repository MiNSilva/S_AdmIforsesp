using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebEquipeModel
    {
        private int _EquipeId;
        private string _Nome;
        private string _Descricao;
        private string _CargoId;
        private string _OrganizacaoId;
        private string _ImageUrl;
        private int _IdRegional;

       

        #region propriedades
      
        public int EquipeId
        {
            get { return _EquipeId; }
            set { _EquipeId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }
        public string OrganizacaoId
        {
            get { return _OrganizacaoId; }
            set { _OrganizacaoId = value; }
        }
        public string CargoId
        {
            get { return _CargoId; }
            set { _CargoId = value; }
        }
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; }
        }
        public int IdRegional
        {
            get { return _IdRegional; }
            set { _IdRegional = value; }
        }

        #endregion
    }
}
