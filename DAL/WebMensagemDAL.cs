using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using DIAPOIO.DAL.DB;
using System.Data;

namespace DIAPOIO.DAL
{
    public class WebMensagemDAL
    {
        public void AtualizaMsg(WebMensagemModel msg)
        {
            using (var db = new Conexao())
            {
                // Initialize command
                var cmd = db.CriarComando("WebAtualizarMsg", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@mensagem", msg.Mensagem);
                cmd.Parameters.AddWithValue("@exibe", msg.Exibe);
                cmd.Parameters.AddWithValue("@inicio", msg.Inicio);
                cmd.Parameters.AddWithValue("@final", msg.Final);
                cmd.Parameters.AddWithValue("@Titulo", msg.Titulo);
                // Execute command
                cmd.ExecuteNonQuery();
            }
        }

        public void VerificaMsg(WebMensagemModel msg, int Operacao)
        {
            using (var db = new Conexao())
            {
                // Initialize command
                var cmd = db.CriarComando("WebVerificaMsg", CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@Operacao", Operacao);
                // Execute command               
                var result = cmd.ExecuteReader();
                if (result.Read())
                {
                    msg.WebMensagemId = (int)result["WebMensagemId"];
                    msg.Exibe = (int)result["Exibe"];
                    if (result["Mensagem"] != DBNull.Value)
                        msg.Mensagem = (string)result["Mensagem"];
                    
                    if (result["Inicio"] != DBNull.Value)
                        msg.Inicio = (DateTime)result["Inicio"];
                    if (result["Final"] != DBNull.Value)
                        msg.Final = (DateTime)result["Final"];
                    if(result["Titulo"] != DBNull.Value)
                        msg.Titulo = (string)result["Titulo"];
                }
            }
        }
    }
}
