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
    public class ModuloSorteioDAL
    {
        public DataSet CarregaGrid()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloSorteioCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public void Atualiza(ModuloSorteioModel sort, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebMmoduloSorteioAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@IdSorteio", sort.IdSorteio);
                cmd.Parameters.AddWithValue("@Nome", sort.Nome);
                cmd.Parameters.AddWithValue("@Data", sort.Data);
                cmd.Parameters.AddWithValue("@Qtde_Ganhadores", sort.Qtde_ganhadores);
                cmd.Parameters.AddWithValue("@Ativo", sort.Ativo);
                cmd.Parameters.AddWithValue("@Regras", sort.Regras);
                cmd.Parameters.AddWithValue("@Informativo", sort.Informativo);
                cmd.ExecuteNonQuery();
            }
        }
        public DataSet CarregaSorteioId(ModuloSorteioModel sort, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloSorteioCarregaid", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@IdSorteio", sort.IdSorteio);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet SortearPremio(int IdSorteio, int UsuarioWeb, DateTime Data)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebModuloGerasorteio", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                cmd.Parameters.AddWithValue("@UsuarioWebId", UsuarioWeb);
                cmd.Parameters.AddWithValue("@Data", Data);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public int ValidaResultadoSorteio(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebModuloSorteioResultadoValida", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int LimpaResultadoSorteio(int IdSorteio, int usuarioalt, DateTime dataAlt)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("[WebmodulosorteioLimpaResultado]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                cmd.Parameters.AddWithValue("@usuarioalt", usuarioalt);
                cmd.Parameters.AddWithValue("@Dataalt", dataAlt);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int ReplicaParticipantes(int IdSorteio)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("[WebModuloSorteioReplicaParticipantes]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdSorteio", IdSorteio);
                var result = cmd.ExecuteReader();
                if (result.Read())
                {

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
