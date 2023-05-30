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
    public class ModuloSorteioParticipantesDAL
    {
        public DataSet CarregaGridParticipantes(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebmodulosorteioParticipantescarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public int CarregaGridtotal(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("Webmodulosorteioparticipantestotal", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    if (result["total"] != DBNull.Value)
                    {
                        return (int)result["total"];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }


        }
    }
}
