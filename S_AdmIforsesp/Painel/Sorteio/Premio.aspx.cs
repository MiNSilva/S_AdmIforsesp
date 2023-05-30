using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using DIAPOIO.BLL;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Sorteio_Premio : System.Web.UI.Page
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
                lblIdSorteio.Text = dados[0].ToString();

                int IdSorteio = Convert.ToInt32(lblIdSorteio.Text);

                if (IdSorteio >= 1)
                {
                    ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();
                    gvSorteioPremio.DataSource = obj.CarregaGridPremio(Convert.ToInt32(lblIdSorteio.Text));
                    gvSorteioPremio.DataBind();
                }
            }
            
        }
    }
    protected void CarregarGrid(int IdSorteio)
    {
        ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();
        gvSorteioPremio.DataSource = obj.CarregaGridPremio(Convert.ToInt32(lblIdSorteio.Text));
        gvSorteioPremio.DataBind();
    }

    protected void gvSorteioPremio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloSorteioPremioModel sortpre = new ModuloSorteioPremioModel();
            ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvSorteioPremio.Rows.Count && gvSorteioPremio.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {

                Param = crypt.ActionEncrypt(index.ToString() + "#" + lblIdSorteio.Text);
                Response.RedirectToRoute("SorteioPremioEdita", new { Param = Param });

            }

            if (e.CommandName.Equals("Excluir"))
            {
                lblIdSorteioPremio.Text = e.CommandArgument.ToString();
                sortpre = obj.CarregaSorteioPremioId(Convert.ToInt32(lblIdSorteioPremio.Text), Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[1].Text));
                obj.OrdernaPremio(Convert.ToInt32(e.CommandArgument), Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[5].Text), 2, Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[1].Text));

                obj.AtualizaPremio(sortpre, 3);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Premio", ControleAcesso.LerTicket().CadastroId);

                CarregarGrid(Convert.ToInt32(lblIdSorteio.Text));

            }
            if (e.CommandName.Equals("Subir"))
            {
                int Ordem = Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[5].Text);
                if (Ordem == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Premio é a primeira da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaPremio(Convert.ToInt32(e.CommandArgument), Ordem, 1, Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[1].Text));
                    CarregarGrid(Convert.ToInt32(lblIdSorteio.Text));
                }

            }

            if (e.CommandName.Equals("Descer"))
            {
                int Ordem = Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[5].Text);
                int OrdemMax = obj.GetShowPremio(Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[1].Text));
                if (Ordem == OrdemMax)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Premio é a última da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaPremio(Convert.ToInt32(e.CommandArgument), Ordem, 2, Convert.ToInt32(gvSorteioPremio.Rows[i].Cells[1].Text));
                    CarregarGrid(Convert.ToInt32(lblIdSorteio.Text));
                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvSorteio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSorteioPremio.PageIndex = e.NewPageIndex;
            CarregarGrid(Convert.ToInt32(lblIdSorteio.Text));
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0" + "#" + lblIdSorteio.Text);
        Response.RedirectToRoute("SorteioPremioEdita", new { Param = Param });
    }


    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("Sorteio", new object { });
    }
}