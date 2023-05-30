using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Administracao_Usuario : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            CarregarGrid();
        }
    }
   
    protected void CarregarGrid()
    {
        UsuarioWebBLL obj = new UsuarioWebBLL();
        gvUsuario.DataSource = obj.CarregaUsuario();
        gvUsuario.DataBind();
    }
    

    protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            UsuarioWebModel user = new UsuarioWebModel();
            UsuarioWebBLL obj = new UsuarioWebBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvUsuario.Rows.Count && gvUsuario.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }
          
            if (e.CommandName.Equals("Excluir"))
            {
                //EXCLUINDO DADOS USUARIO
                user.UsuarioWebId = index;
                user.Nome = String.Empty;
                user.Login = String.Empty;
                user.Senha = String.Empty;
                user.Grupo = String.Empty;
                user.Ativo = String.Empty;
               

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Usuário:'" + gvUsuario.Rows[i].Cells[1].Text + "'", ControleAcesso.LerTicket().CadastroId);


                obj.AtualizaUsuario(user, 3);

                // EXCLUINDO PERMISSAO
                WebMenuBLL objperm = new WebMenuBLL();
                objperm.ExcluirPermissoes(index);

                CarregarGrid();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Usuário Excluido com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

            }
            if (e.CommandName.Equals("Permissoes"))
            {
                Response.RedirectToRoute("AdmPermissoes", new {UsuarioWebID = index });
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {

        Response.RedirectToRoute("AdmPermissoes", new { UsuarioWebID = 0 });
    }
   
}