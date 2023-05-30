using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_Senha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        string Param;
        CryptUtil crypt = new CryptUtil();

        try
        {
            UsuarioWebModel usuario = new UsuarioWebModel();
            UsuarioWebBLL obj = new UsuarioWebBLL();

            usuario.UsuarioWebId = ControleAcesso.LerTicket().CadastroId;
            usuario.Senha = txtNovaSenha.Text;
            obj.AtualizaSenha(usuario);

            txtNovaSenha.Text = string.Empty;
            txtConfirmaSenhaAlteracao.Text = string.Empty;

            Param = crypt.ActionEncrypt("2#SENHA ALTERADA COM SUCESSO !!!!");
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });


            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Alterou Senha", ControleAcesso.LerTicket().CadastroId);
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
}