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

public partial class Painel_Modulos_BannerEdita : System.Web.UI.Page
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
                lblBannerNome.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    ModuloBannerModel ban = new ModuloBannerModel();
                    ModuloBannerBLL obj = new ModuloBannerBLL();

                    ban.WebBannerId = Convert.ToInt32(lblBannerId.Text);
                    ban.Nome = lblBannerNome.Text;

                    DataSet ds = obj.ValidaBanner(ban, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                            txtAltura.Text = ds.Tables[0].Rows[0]["Altura"].ToString();
                            txtLargura.Text = ds.Tables[0].Rows[0]["Largura"].ToString();
                        }
                    }
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            ModuloBannerModel ban = new ModuloBannerModel();
            ModuloBannerBLL obj = new ModuloBannerBLL();

            if (lblBannerId.Text == "0")
            {
                ban.WebBannerId = 0;
            }
            else
            {
                ban.WebBannerId = Convert.ToInt32(lblBannerId.Text);
            }

            ban.Nome = txtNome.Text.Trim();
            ban.Largura = Convert.ToInt32(txtLargura.Text);
            ban.Altura = Convert.ToInt32(txtAltura.Text);

            DataSet ds = obj.ValidaBanner(ban, 2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                obj.AtualizaBanner(ban, (lblBannerId.Text == "0" ? 1 : 2));

                if (lblBannerId.Text == "0")
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Criou o Banner: " + ban.Nome, ControleAcesso.LerTicket().CadastroId);
                }
                else
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Alterou o Banner: " + ban.Nome, ControleAcesso.LerTicket().CadastroId);
                }

                Response.RedirectToRoute("ModBanner", new object { });
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Já existe o Banner";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";
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
        Response.RedirectToRoute("ModBanner", new object{});
    }
}