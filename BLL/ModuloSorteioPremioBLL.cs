using DIAPOIO.DAL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.BLL
{
    public class ModuloSorteioPremioBLL
    {
        public DataSet CarregaGridPremio(int IdSorteio)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            return obj.CarregaGridPremio(IdSorteio);
        }
        public void AtualizaPremio(ModuloSorteioPremioModel sortpre, int operacao)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            obj.AtualizaPremio(sortpre, operacao);
        }
        public DataSet CarregaSorteioPremioId(ModuloSorteioPremioModel sortpre, int operacao)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            return obj.CarregaSorteioPremioId(sortpre, operacao);
        }
        public void OrdernaPremio(int Id, int Ordem, int Operacao, int IdSorteio)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            obj.OrdernaPremio(Id, Ordem, Operacao, IdSorteio);
        }
        //public DataSet GetShowPremio()
        //{
        //    ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
        //    return obj.GetShowPremio();
        //}
        public int GetShowPremio(int IdSorteio)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            return obj.GetShowPremio(IdSorteio);
        }
        public int ValidaQtdeSorteio(int IdSorteio)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            return obj.ValidaQtdeSorteio(IdSorteio);
        }
        public ModuloSorteioPremioModel CarregaSorteioPremioId(int IdSorteioPremio, int IdSorteio)
        {
            ModuloSorteioPremioDAL obj = new ModuloSorteioPremioDAL();
            return obj.CarregaSorteioPremioId(IdSorteioPremio, IdSorteio);
        }
    }
}
