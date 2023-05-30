using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CarregarEmailEstatisticas();
            //CarregarCadastroEstatisticas();
            //CarregaNotificaçõesEmail();
            //lblNome.Text = ControleAcesso.LerTicket().Nome;
        }
    }
    protected void CarregarEmailEstatisticas()
    {
        int usuariowebid = ControleAcesso.LerTicket().CadastroId;

        WebEmailBLL obj = new WebEmailBLL();

        DataSet ds = obj.CarregaEmailEstatistica(usuariowebid);
        if (ds.Tables[0].Rows.Count > 0)
        {
        //    dlEmailEstatistica.DataSource = ds;
        //    dlEmailEstatistica.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Não há conteúdo pertinente a este assunto !!!";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";
        }
    }

    protected void CarregarCadastroEstatisticas()
    {
        WebCadastrosBLL obj = new WebCadastrosBLL();

        DataSet ds = obj.CarregaCadastroEstatisticas();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ddlCadastro.DataSource = ds;
            //ddlCadastro.DataBind();
            //lblMensagem.Visible = true;
            //lblMensagem.Text = "  " + ds.Tables[0].Rows.Count;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Não existe cadastro de cliente atualizado !!!";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";
        }
    }
    protected void CarregaNotificaçõesEmail()
    {
        int usuariowebid = ControleAcesso.LerTicket().CadastroId;
        WebEmailBLL obj = new WebEmailBLL();

        DataSet ds = obj.CarregaNotificacoesEmail(usuariowebid);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //dlNotificacao.DataSource = ds;
            //dlNotificacao.DataBind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Não existem notificações para você !!!";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";
        }
    }

}