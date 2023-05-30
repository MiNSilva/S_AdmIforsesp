using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Modulos_PublicacoesItem : System.Web.UI.Page
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
                lblLegislacaoItem.Text = dados[1].ToString();

                if (Convert.ToInt32(lblLegislacaoId.Text) >= 1)
                {
                    CarregarGridItem();
                }
            }
        }
    }

    protected void CarregarGridItem()
    {
        ModuloPublicacaoItemBLL obj = new ModuloPublicacaoItemBLL();
        string pesq = string.Empty;
        if (!string.IsNullOrEmpty(txtPesquisa.Text))
        {
            pesq = txtPesquisa.Text.Trim();
        }
        DataSet ds = obj.CarregaPublicacaoItem(pesq, Convert.ToInt32(lblLegislacaoId.Text));
        gvLegislacaoItem.DataSource = ds;
        gvLegislacaoItem.DataBind();
    }

    protected void gvLegislacaoItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloPublicacaoItemModel legis = new ModuloPublicacaoItemModel();
            ModuloPublicacaoItemBLL obj = new ModuloPublicacaoItemBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvLegislacaoItem.Rows.Count && gvLegislacaoItem.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                lblOrdem.Text = gvLegislacaoItem.Rows[i].Cells[4].Text;
                lblIdLegislacaoItemId.Text = index.ToString();
                Param = crypt.ActionEncrypt(index + "#" + lblLegislacaoId.Text + "#" + gvLegislacaoItem.Rows[i].Cells[4].Text + "#" + lblLegislacaoItem.Text);               
                Response.RedirectToRoute("ModPublicacoesItemEdita", new { Param = Param });
                
            }

            if (e.CommandName.Equals("Excluir"))
            {
                lblIdLegislacaoItemId.Text = e.CommandArgument.ToString();
                legis = obj.GetPublicacaoItemById(Convert.ToInt32(lblIdLegislacaoItemId.Text));

                obj.AtualizaPublicacaoItem(legis, 3, ControleAcesso.LerTicket().CadastroId);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Publicacoes Item", ControleAcesso.LerTicket().CadastroId);

                string caminho = Server.MapPath("~/Download/Legislacao/" + legis.Arquivo);

                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                CarregarGridItem();
            }

            if (e.CommandName.Equals("Subir"))
            {
                int Ordem = Convert.ToInt32(gvLegislacaoItem.Rows[i].Cells[4].Text);
                if (Ordem == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Publicacoes é o primeiro da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaPublicacaoItem(Convert.ToInt32(e.CommandArgument), Ordem, 1);
                    CarregarGridItem();
                }
            }

            if (e.CommandName.Equals("Descer"))
            {
                int Ordem = Convert.ToInt32(gvLegislacaoItem.Rows[i].Cells[4].Text);
                int OrdemMax = obj.GetPublicacaoItemOrdem(Convert.ToInt32(lblLegislacaoId.Text));
                if (Ordem == OrdemMax)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Publicacoes é o último da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaPublicacaoItem(Convert.ToInt32(e.CommandArgument), Ordem, 2);
                    CarregarGridItem();
                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvLegislacaoItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvLegislacaoItem.PageIndex = e.NewPageIndex;
            CarregarGridItem();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0" + "#" + lblLegislacaoId.Text + "#" + "0#" + lblLegislacaoItem.Text);
        Response.RedirectToRoute("ModPublicacoesItemEdita", new {Param = Param });
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModPublicacoes", new object{ });
    }

    protected void btnBusca_Click(object sender, EventArgs e)
    {
        ModuloPublicacaoItemBLL obj = new ModuloPublicacaoItemBLL();
        DataSet ds = obj.CarregaPublicacaoItem(txtPesquisa.Text.Trim(), Convert.ToInt32(lblLegislacaoId.Text));
        gvLegislacaoItem.DataSource = ds;
        gvLegislacaoItem.DataBind();
    }
}