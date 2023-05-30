using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIAPOIO.MODEL;
using System.Web;
using DIAPOIO.BLL;
using System.Web.Security;


namespace DIAPOIO.BLL.Autenticacao
{

    public static class ControleAcesso
    {
        public static void CriarTicket(UsuarioWebModel usuario)
        {
            DadosAcesso acesso = new DadosAcesso(usuario);
            string dadosAcesso = acesso.ToString();


            //Criando o ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                usuario.Nome, //Nome do Usuário
                DateTime.Now, // Data de Criação do Cookie
                DateTime.Now.AddMinutes(360),  // Tempo Limite para logar novamente
                true, // Mantenha Conectado
                dadosAcesso, // Roles
                FormsAuthentication.FormsCookiePath); // Tipo de Autenticação por Formulário e Cookie
            // Criptografa o cookie
            string criptografado = FormsAuthentication.Encrypt(ticket);
            // Criando o cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, criptografado);
            // Expiração do cokkie
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            // Gravando o cookie no browser
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static DadosAcesso LerTicket()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];


            //if (cookie == null)
            //    return null;


            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string dadosTicket = ticket.UserData;
            DadosAcesso acesso = new DadosAcesso(dadosTicket);
            return acesso;
        }


        public static void CriarTicket(WebCadastrosModel cad)
        {
            DadosAcesso acesso = new DadosAcesso(cad);
            string dadosAcesso = acesso.ToString();


            //Criando o ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                cad.Nome, //Nome do Usuário
                DateTime.Now, // Data de Criação do Cookie
                DateTime.Now.AddMinutes(30),  // Tempo Limite para logar novamente
                true, // Mantenha Conectado
                dadosAcesso, // Roles
                FormsAuthentication.FormsCookiePath); // Tipo de Autenticação por Formulário e Cookie
            // Criptografa o cookie
            string criptografado = FormsAuthentication.Encrypt(ticket);
            // Criando o cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, criptografado);
            // Expiração do cokkie
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            // Gravando o cookie no browser
            HttpContext.Current.Response.Cookies.Add(cookie);
        }


    }
}