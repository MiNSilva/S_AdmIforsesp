using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class ModuloPublicacaoBLL
    {
        public DataSet CarregaPublicacao()
        {
            ModuloPublicacaoDAL obj = new ModuloPublicacaoDAL();
            return obj.CarregaPublicacao();
        }

        public void AtualizaPublicacao(ModuloPublicacaoModel pub, int operacao)
        {
            ModuloPublicacaoDAL obj = new ModuloPublicacaoDAL();
            obj.AtualizaPublicacao(pub, operacao);
        }

        public int ValidaPublicacao(ModuloPublicacaoModel pub, int operacao)
        {
            ModuloPublicacaoDAL obj = new ModuloPublicacaoDAL();
            return obj.ValidaPublicacao(pub, operacao);
        }
    }
}
