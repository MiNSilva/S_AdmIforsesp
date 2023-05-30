using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIAPOIO.UPLOAD
{
    public class Arquivo
    {
        public string NomeArquivo { get; set; }
        public string NomeArquivoData { get; set; }
        public string CaminhoCompleto { get; set; }
        public string URL { get; set; }
        public DateTime DataCriacao { get; set; }
        public long Tamanho { get; set; }
    }
}