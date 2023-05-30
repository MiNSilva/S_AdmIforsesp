using DIAPOIO.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;

namespace DIAPOIO.DAL
{
    public class WebAdvogadosDAL
    {

        public DataSet CarregaAdvogados()
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebAdvogadoCarrega", CommandType.StoredProcedure);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }
        public void AtualizaAdvogados(WebAdvogadoModel adv, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAdvogadoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", adv.Usuariowebid);
                cmd.Parameters.AddWithValue("@nome", adv.Nome);
                cmd.Parameters.AddWithValue("@login", adv.Login);
                cmd.Parameters.AddWithValue("@senha", adv.Senha);
                cmd.Parameters.AddWithValue("@ativo", adv.Ativo);
                cmd.Parameters.AddWithValue("@deletado", adv.Deletado);
                cmd.ExecuteNonQuery();
            }
        }
        public int ValidaaAdvogados(WebAdvogadoModel adv, int operacao)
        {
            int result = 0;
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebServicosValidacao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", adv.Usuariowebid);
                cmd.Parameters.AddWithValue("@Nome", adv.Nome);
                cmd.Parameters.AddWithValue("@login", adv.Login);
                result = (int)cmd.ExecuteScalar();
                return result;
            }
        }
        public DataSet CarregaDepartamentoAdvogados(int usuariowebid, int operacao)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebAdvogadoCarregaDepartamentoUsuario", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet SalvarMenuDepartamento(int operacao, int usuariowebid, int SituacaoContatoId, int Responsavel)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebAdvogadoSituacaoContatoAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                cmd.Parameters.AddWithValue("@SituacaoContatoId", SituacaoContatoId);
                cmd.Parameters.AddWithValue("@Responsavel", Responsavel);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaAdvogadosPorDepartamento(string depto)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebAdvogadoCarregaPorDepartamento", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@depto", depto);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public DataSet CarregaPorUsuarioWebId(int usuariowebid)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebEmailCarregapPorUsuarioWebId", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@usuariowebid", usuariowebid);
                
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
        }

        public void ExcluirDepartamentos(int idUsuario)
        {
            using (var db = new Conexao())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = db.CriarComando("WebAdvogadosExcluiUsuarioEspecifico", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }
    }

}
