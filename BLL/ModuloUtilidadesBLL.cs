using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DIAPOIO.BLL
{
    public class ModuloUtilidadesBLL
    {
        public DataSet CarregaGrid()
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            return obj.CarregaGrid();
        }

        public void Atualiza(ModuloUtilidadesModel util, int operacao)
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            obj.Atualiza(util, operacao);
        }

        public int GetOrdem()
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            return obj.GetOrdem();
        }

        public void Orderna(int Id, int Ordem, int Operacao)
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            obj.Orderna(Id, Ordem, Operacao);
        }

        public DataSet GetShow()
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            return obj.GetShow();
        }
        public DataSet CarregaUtilidadeId(ModuloUtilidadesModel util, int operacao)
        {
            ModuloUtilidadesDAL obj = new ModuloUtilidadesDAL();
            return obj.CarregaUtilidadeId(util, operacao);
        }
    }
}
