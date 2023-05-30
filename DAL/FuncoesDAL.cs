using DIAPOIO.DAL.DB;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAPOIO.DAL
{
    public class FuncoesDAL
    {
        public static int LiberaTravaRegistro(string cTabela, int Id, int Operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebFuncLiberaTravaRegistro", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@nOperacao", Operacao);
                cmd.Parameters.AddWithValue("@cTabela", cTabela);
                cmd.Parameters.AddWithValue("@nId", Id);
                return (int)cmd.ExecuteScalar();
            }
        }

        public static int ValidaExclusao(string cTabela, string cCampo, int Id)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebFuncValidaExclusao", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@cTabela", cTabela);
                cmd.Parameters.AddWithValue("@cCampo", cCampo);
                cmd.Parameters.AddWithValue("@nId", Id);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void AtualizaAtividade(WebAtividadeModel atividade, int operacao)
        {
            using (var db = new Conexao())
            {
                var cmd = db.CriarComando("WebAtividadeAtualiza", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@operacao", operacao);
                cmd.Parameters.AddWithValue("@Atividadeid", atividade.Atividadeid);
                cmd.Parameters.AddWithValue("@DescAtividade", atividade.DescAtividade);
                cmd.Parameters.AddWithValue("@Usuariowebid", atividade.Usuariowebid);
                cmd.Parameters.AddWithValue("@Url", atividade.Url);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
