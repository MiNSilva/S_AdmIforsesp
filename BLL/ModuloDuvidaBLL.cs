using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DIAPOIO.DAL;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL
{
    public class ModuloDuvidaBLL
    {
        public DataSet CarregaGrid()
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            return obj.CarregaGrid();
        }

        public void AtualizaDuvida(ModuloDuvidaModel duv, int operacao)
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            obj.AtualizaDuvida(duv, operacao);
        }

        public int ValidaDuvida(ModuloDuvidaModel duv, int operacao)
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            return obj.ValidaDuvida(duv, operacao);
        }

        public DataSet CarregaDuvidaId(ModuloDuvidaModel duv, int operacao)
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            return obj.CarregaDuvidaId(duv, operacao);
        }

        public int GetDuvidaOrdem()
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            return obj.GetDuvidaOrdem();
        }

        public void OrdernaDuvida(int Id, int Ordem, int Operacao)
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            obj.OrdernaDuvida(Id, Ordem, Operacao);
        }

        public DataSet GetDuvidaShow()
        {
            ModuloDuvidaDAL obj = new ModuloDuvidaDAL();
            return obj.GetDuvidaShow();
        }
    }
}
