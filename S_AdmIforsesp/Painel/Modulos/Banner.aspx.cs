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
using System.Drawing;
using System.IO;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Modulos_Banner : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (!IsPostBack)
        {
            CarregarGridBanner();
        }
    }

    protected void CarregarGridBanner()
    {
        ModuloBannerBLL obj = new ModuloBannerBLL();
        gvBanner.DataSource = obj.CarregaBanner();
        gvBanner.DataBind();
    }
    protected void gvBanner_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloBannerModel ban = new ModuloBannerModel();
            ModuloBannerBLL obj = new ModuloBannerBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvBanner.Rows.Count && gvBanner.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }


            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvBanner.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvBanner.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("ModBannerEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                ban.WebBannerId = Convert.ToInt32(e.CommandArgument);
                ban.Nome = String.Empty;
                ban.Altura = 0;
                ban.Largura = 0;
                
                DataSet ds = obj.ValidaBanner(ban, 3);

                if (ds.Tables[0].Rows.Count > 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Banner não pode ser excluido, possui Itens";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
                else
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Exclusão do Banner:" + gvBanner.Rows[i].Cells[1].Text, ControleAcesso.LerTicket().CadastroId);

                    obj.AtualizaBanner(ban, 3);
                    CarregarGridBanner();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Banner excluido com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
            }
            if (e.CommandName.Equals("Banner"))
            {

                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvBanner.Rows[i].Cells[2].Text + "#" + gvBanner.Rows[i].Cells[3].Text);
                Response.RedirectToRoute("ModBannerItem", new { Param = Param });
                
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
        Param = crypt.ActionEncrypt("0" + "#" + "");
        Response.RedirectToRoute("ModBannerEdita", new { Param = Param });

    }

}