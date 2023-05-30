using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DIAPOIO.BLL
{
    public class ModuloConvenioBLL
    {
        public DataSet CarregaGrid()
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            return obj.CarregaGrid();
        }

        public void Atualiza(ModuloConvenioModel util, int operacao)
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            obj.Atualiza(util, operacao);
        }

        public int GetOrdem()
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            return obj.GetOrdem();
        }

        public void Orderna(int Id, int Ordem, int Operacao)
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            obj.Orderna(Id, Ordem, Operacao);
        }

        public DataSet GetShow()
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            return obj.GetShow();
        }
        public DataSet CarregaConveniosId(ModuloConvenioModel util, int operacao)
        {
            ModuloConvenioDAL obj = new ModuloConvenioDAL();
            return obj.CarregaConveniosId(util, operacao);
        }
    }
}
