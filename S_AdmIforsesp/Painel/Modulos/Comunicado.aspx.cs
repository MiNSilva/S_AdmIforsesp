using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using CKFinder;

public partial class Painel_Modulos_Comunicado : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtInicio.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtInicio.Attributes.Add("onBlur", "MascaraData(this,event);");
        txtFinal.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtFinal.Attributes.Add("onBlur", "MascaraData(this,event);");


        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtComunicado);


        if (!IsPostBack)
        {
            WebMensagemModel msg = new WebMensagemModel();
            WebMensagemBLL obj = new WebMensagemBLL();

            obj.VerificaMsg(msg, 0);
            if (msg.WebMensagemId > 0)
            {
                cbExibeMsg.Checked = Convert.ToBoolean(msg.Exibe);
                txtInicio.Text = msg.Inicio.ToString("dd/MM/yyyy");
                txtFinal.Text = msg.Final.ToString("dd/MM/yyyy");
                txtTitulo.Text = msg.Titulo;
                txtComunicado.Text = msg.Mensagem;
               
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                WebMensagemModel msg = new WebMensagemModel();
                msg.Mensagem = txtComunicado.Text;
                msg.Exibe = Convert.ToInt32(cbExibeMsg.Checked);
                msg.Inicio = Convert.ToDateTime(txtInicio.Text);
                msg.Final = Convert.ToDateTime(txtFinal.Text);
                msg.Titulo = txtTitulo.Text;

                WebMensagemBLL obj = new WebMensagemBLL();
                obj.AtualizaMsg(msg);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Mensagem Salva com Sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou Comunicado", ControleAcesso.LerTicket().CadastroId);

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
}