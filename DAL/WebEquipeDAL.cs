using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;


namespace DIAPOIO.DAL
{
    public class WebEquipeDAL
    {
        
        public DataSet CarregaEquipe(int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEquipeCarrega", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEquipePorId(int EquipeId)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("[WebEquipeCarregaId]", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@EquipeId", EquipeId);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }


        public void AtualizaEquipe(WebEquipeModel equi, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEquipeAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@EquipeId", equi.EquipeId);
                cmd.Parameters.AddWithValue("@Nome", equi.Nome);
                cmd.Parameters.AddWithValue("@Descricao", equi.Descricao);
                cmd.Parameters.AddWithValue("@OrganizacaoId", equi.OrganizacaoId);
                cmd.Parameters.AddWithValue("@CargoId", equi.CargoId);
                cmd.Parameters.AddWithValue("@ImageUrl", equi.ImageUrl);
                cmd.Parameters.AddWithValue("@IdRegional", equi.IdRegional);
                cmd.ExecuteNonQuery();
            }
        }
        public int ValidaEquipe(WebEquipeModel equi, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebEquipeValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@EquipeId", equi.EquipeId);
                cmd.Parameters.AddWithValue("@Nome", equi.Nome);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public DataSet CarregaEquipeCargo()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEquipeCarregaCargo", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaEquipeByIdRegional(int Id)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEquipeByIdRegional", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@IdRegional", Id);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
    }
}
