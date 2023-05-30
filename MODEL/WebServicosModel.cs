using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.MODEL
{
    public class WebServicosModel
    {
        private int _ServicoId;
        private string _Nome;
        private string _Slug;
        private string _Resumo;
        private string _Conteudo;
     

        public int ServicoId
        {
            get { return _ServicoId; }
            set { _ServicoId = value; }
        }
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public string Slug
        {
            get { return _Slug; }
            set { _Slug = value; }
        }
        public string Resumo
        {
            get { return _Resumo; }
            set { _Resumo = value; }
        }
        public string Conteudo
        {
            get { return _Conteudo; }
            set { _Conteudo = value; }
        }
    }
}
