using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;

namespace DIAPOIO.BLL.Autenticacao
{

    public class DadosAcesso
    {
        public int CadastroId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public int defineresponsavel { get; set; }
        public int IdRegional { get; set; }
        public string Grupo { get; set; }



        public DadosAcesso(WebCadastrosModel cad)
        {
            CadastroId = cad.CadastroId;
            Email = cad.Email;
            Nome = cad.Nome;
            CPF = cad.CPF;
        }


        public DadosAcesso(UsuarioWebModel usuario)
        {
            CadastroId = usuario.UsuarioWebId;
            Email = usuario.Login;
            Nome = usuario.Nome;
            Senha = usuario.Senha;
            defineresponsavel = usuario.Defineresponsavel;
            IdRegional = 1;
            Grupo = usuario.Grupo;
            
        }


        public DadosAcesso(string dadosTicket)
        {

            string[] dados = dadosTicket.Split('#');
            CadastroId = Int32.Parse(dados[0]);
            Email = dados[1];
            Nome = dados[2];
            Senha = dados[3];
            CPF = dados[4];
            defineresponsavel = Int32.Parse(dados[5]);
            IdRegional = Int32.Parse(dados[6]);
            Grupo = dados[7];
        }

        public override string ToString()
        {
            return CadastroId + "#" + Email + "#" + Nome + "#" + Senha + "#" + CPF + "#" + defineresponsavel + "#" + IdRegional + "#" + Grupo;
        }
    }
}