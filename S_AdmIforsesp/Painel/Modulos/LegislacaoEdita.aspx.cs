using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System.Data;
using System.Data.SqlClient;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Modulos_LegislacaoEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblLegislacaoId.Text = dados[0].ToString();
                lblLegislacaoNome.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    txtNome.Text = lblLegislacaoNome.Text;
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            ModuloLegislacaoModel legis = new ModuloLegislacaoModel();
            legis.Nome = txtNome.Text.Trim();

            if (lblLegislacaoId.Text == "0")
            {
                legis.WebLesgislacaoId = 0;
            }
            else
            {
                legis.WebLesgislacaoId = Convert.ToInt32(lblLegislacaoId.Text);
            }

            ModuloLegislacaoBLL obj = new ModuloLegislacaoBLL();

            if (obj.ValidaLegislacao(legis, 2) > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Já existe Categoria com esse nome.";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";
                
            }
            else
            {
                obj.AtualizaLegislacao(legis, (lblLegislacaoId.Text == "0" ? 1 : 2));

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou o Legislacao: " + legis.Nome, ControleAcesso.LerTicket().CadastroId);

                Response.RedirectToRoute("ModLegislacao", new object { });

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModLegislacao", new object { });
    }
}