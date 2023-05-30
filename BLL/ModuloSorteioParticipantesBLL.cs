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
    public class ModuloSorteioParticipantesBLL
    {
        public DataSet CarregaGridParticipantes(int IdSorteio)
        {
            ModuloSorteioParticipantesDAL obj = new ModuloSorteioParticipantesDAL();
            return obj.CarregaGridParticipantes(IdSorteio);
        }
        public int CarregaGridtotal(int IdSorteio)
        {
            ModuloSorteioParticipantesDAL obj = new ModuloSorteioParticipantesDAL();
            return obj.CarregaGridtotal(IdSorteio);
        }
    }
}
