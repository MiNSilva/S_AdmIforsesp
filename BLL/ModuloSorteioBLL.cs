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
    public class ModuloSorteioBLL
    {
        public DataSet CarregaGrid()
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.CarregaGrid();
        }
        public void Atualiza(ModuloSorteioModel sort, int operacao)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            obj.Atualiza(sort, operacao);
        }
        public DataSet CarregaSorteioId(ModuloSorteioModel sort, int operacao)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.CarregaSorteioId(sort, operacao);
        }

        public DataSet SortearPremio(int IdSorteio, int UsuarioWeb, DateTime Data)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.SortearPremio(IdSorteio, UsuarioWeb, Data);
        }

        public int ValidaResultadoSorteio(int IdSorteio)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.ValidaResultadoSorteio(IdSorteio);
        }

        public int LimpaResultadoSorteio(int IdSorteio, int usuarioalt, DateTime dataAlt)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.LimpaResultadoSorteio(IdSorteio, usuarioalt, dataAlt);
        }

        public int ReplicaParticipantes(int IdSorteio)
        {
            ModuloSorteioDAL obj = new ModuloSorteioDAL();
            return obj.ReplicaParticipantes(IdSorteio);
        }

    }
}
