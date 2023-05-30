using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebGrupoMODEL
    {
        private int _GrupoId;
        private string _Descricao;

        #region propriedades

        public int GrupoId
        {
            get { return _GrupoId; }
            set { _GrupoId = value; }
        }
        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        #endregion
    }
}
