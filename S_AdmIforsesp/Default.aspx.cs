using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using System.Data.SqlClient;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.BLL;
using System.Net.Mail;
using System.Text;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        //txtEmail.Text = "ellem@advocaciamarcatto.com.br";
        //txtSenha.Text = "a.123";

        this.Form.DefaultButton = lkbNovaConta.UniqueID;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CryptUtil crypt = new CryptUtil();

        try
        {
            UsuarioWebModel usuario = new UsuarioWebModel();
            usuario.Login = txtEmail.Text;
            usuario.Senha = txtSenha.Text;


            UsuarioWebBLL obj = new UsuarioWebBLL();
            usuario = obj.Logar(usuario);

            if (usuario != null)
            {
                if (usuario.Deletado == 0)
                {
                    ControleAcesso.CriarTicket(usuario);

                    //if (usuario.Grupo != null)
                    //{
                    Session["IdUsuario"] = usuario.UsuarioWebId;
                    string id = HttpContext.Current.User.Identity.Name;

                    Response.RedirectToRoute("PnlInicio", new object { });
                    //}
                    //else
                    //{
                    //Param = crypt.ActionDecrypt("#" + "ACESSO NEGADO !!!!");
                    //Param = crypt.ActionEncrypt(Param);
                    //Response.RedirectToRoute("Errorpage", new { Param = Param });
                    //}
                }
                else
                {
                    Panel1.Visible = true;
                    lblMsg.Text = "Usuário não existe ou não tem permissão";

                    //Param = crypt.ActionEncrypt("#" + "Usuário ou Senha Inválido - Entrar em contato com o suporte ");
                    //Response.RedirectToRoute("Errorpage", new { Param = Param });
                }
            }
            else
            {

                Panel1.Visible = true;
                lblMsg.Text = "Usuário ou Senha Inválido";

                //Param = crypt.ActionEncrypt("#" + "Usuário não existe ou não tem permissão ");
                //Response.RedirectToRoute("Errorpage", new { Param = Param });
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionDecrypt(ex.Message);
            Param = crypt.ActionEncrypt(Param);
            Response.RedirectToRoute("Aviso", new { Param = Param });
        }
    }

}