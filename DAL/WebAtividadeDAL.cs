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
    public class WebAtividadeDAL
    {
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
