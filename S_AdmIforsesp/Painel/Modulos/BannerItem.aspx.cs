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
using System.IO;

public partial class Painel_Modulos_BannerItem : System.Web.UI.Page
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
                lblBannerId.Text = dados[0].ToString();
                lblLargura.Text = dados[1].ToString();
                lblAltura.Text = dados[2].ToString();


                if (Convert.ToInt32(lblBannerId.Text) >= 1)
                {
                    CarregarGrid();
                }
            }
        }
    }

    protected void CarregarGrid()
    {
        ModuloBannerModel ban = new ModuloBannerModel();
        ModuloBannerBLL obj = new ModuloBannerBLL();

        ban.WebBannerId = Convert.ToInt32(lblBannerId.Text);

        DataSet ds = obj.CarregaBannerItens(ban);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblArquivo.Text = ds.Tables[0].Rows[0]["arquivo"].ToString();        
        }
        gvBannerItem.DataSource = ds;
        gvBannerItem.DataBind();
    }

    protected void gvBannerItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloBannerItemModel ban = new ModuloBannerItemModel();
            ModuloBannerItemBLL obj = new ModuloBannerItemBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvBannerItem.Rows.Count && gvBannerItem.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                lblIdBannerItem.Text = gvBannerItem.Rows[i].Cells[0].Text;

                Param = crypt.ActionEncrypt(lblBannerId.Text + "#" + index.ToString() + "#" + lblLargura.Text + "#" + lblAltura.Text);
                Response.RedirectToRoute("ModBannerItemEdita", new { Param = Param });

            }

            if (e.CommandName.Equals("Excluir"))
            {
                lblIdBannerItem.Text = e.CommandArgument.ToString();
                ban = obj.GetBannerItemById(Convert.ToInt32(lblIdBannerItem.Text));

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Banner:" + gvBannerItem.Rows[i].Cells[1].Text, ControleAcesso.LerTicket().CadastroId);

                obj.AtualizaBannerItem(ban, 3);
               

                string caminho = Server.MapPath("~/images/Site/Slide/" + lblArquivo.Text);
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Banner Excluido com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

                CarregarGrid(); 
            }

            if (e.CommandName.Equals("Subir"))
            {
                
                int ativo = Convert.ToInt32(gvBannerItem.Rows[i].Cells[5].Text);
                int Ordem = Convert.ToInt32(gvBannerItem.Rows[i].Cells[6].Text);

                if (ativo == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Banner não esta ativo";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
                else
                {
                    if (Ordem == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                        lblMsgTit.Visible = true;
                        lblMsgTit.Text = "Banner é o primeiro da Ordem";

                        Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                        lblMsgCont.Visible = true;
                        lblMsgCont.Text = " ";

                        return;
                    }
                    else
                    {
                        obj.OrdernaBannerItem(Convert.ToInt32(e.CommandArgument), Ordem, 1);
                        CarregarGrid();
                    }
                }
            }

            if (e.CommandName.Equals("Descer"))
            {
                int ativo = Convert.ToInt32(gvBannerItem.Rows[i].Cells[5].Text);
                int Ordem = Convert.ToInt32(gvBannerItem.Rows[i].Cells[6].Text);
                int OrdemMax = obj.GetBannerItemOrdem();

                if (ativo == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Banner não esta ativo";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
                else
                {
                    if (Ordem == OrdemMax)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                        lblMsgTit.Visible = true;
                        lblMsgTit.Text = "Parceiro é o último da Ordem";

                        Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                        lblMsgCont.Visible = true;
                        lblMsgCont.Text = " ";

                        return;
                    }
                    else
                    {
                        obj.OrdernaBannerItem(Convert.ToInt32(e.CommandArgument), Ordem, 2);
                        CarregarGrid();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvBannerItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBannerItem.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModBanner", new object{});
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblBannerId.Text +"#" + "0" + "#" + lblLargura.Text + "#" + lblAltura.Text);
        Response.RedirectToRoute("ModBannerItemEdita", new { Param = Param });
    }
}