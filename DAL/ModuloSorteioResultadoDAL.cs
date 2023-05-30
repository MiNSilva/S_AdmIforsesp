using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.DAL
{
    public class ModuloSorteioResultadoDAL
    {
        public DataSet CarregaSorteioResultadoId(ModuloSorteioResultadoModel sort, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloSorteioResultadoCarregaid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", sort.IdSorteio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
