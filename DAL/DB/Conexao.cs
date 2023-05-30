using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL.DB;
using System.Data;

namespace DIAPOIO.DAL.DB
{
    public class Conexao : IDisposable
    {
        private SqlConnection conn;

        public Conexao()
        {
            conn = new SqlConnection();
            conn.ConnectionString = Dados.StringDeConexao; 
            conn.Open();
        }

        public SqlCommand CriarComando(string sql, CommandType tipo)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = tipo;
            return cmd;
        }

        #region IDisposable Members

        public void Dispose()
        {
            conn.Close();
        }

        #endregion
    }
}
