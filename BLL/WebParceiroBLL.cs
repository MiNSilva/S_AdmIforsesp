using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DIAPOIO.BLL
{
    public class WebParceiroBLL
    {
        public DataSet CarregaGrid()
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            return obj.CarregaGrid();
        }

        public void Atualiza(WebParceiroMODEL parc, int operacao)
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            obj.Atualiza(parc, operacao);
        }

        public int GetOrdem()
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            return obj.GetOrdem();
        }

        public void Orderna(int Id, int Ordem, int Operacao)
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            obj.Orderna(Id, Ordem, Operacao);
        }

        public DataSet GetShow()
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            return obj.GetShow();
        }
        public DataSet ValidaParceiros(WebParceiroMODEL parc, int operacao)
        {
            WebParceiroDAL obj = new WebParceiroDAL();
            return obj.ValidaParceiros(parc, operacao);
        }
    }
}
