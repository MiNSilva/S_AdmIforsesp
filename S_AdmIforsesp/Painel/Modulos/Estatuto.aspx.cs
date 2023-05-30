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

public partial class Painel_Modulos_Estatuto : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGrid();
        }
    }

    protected void CarregarGrid()
    {
        WebEstatutoBLL obj = new WebEstatutoBLL();
        gvEstatuto.DataSource = obj.CarregaEstatuto();
        gvEstatuto.DataBind();
    }

    protected void gvEstatuto_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvEstatuto.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvEstatuto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebEstatutoModel est = new WebEstatutoModel();
            WebEstatutoBLL obj = new WebEstatutoBLL();


            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvEstatuto.Rows.Count && gvEstatuto.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvEstatuto.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvEstatuto.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("ModEstatutoEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                est.EstatutoId = index;
                est.NomeEstatuto = String.Empty;
                est.DescricaoEstatuto = String.Empty;

                obj.AtualizaEstatuto(est, 3);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Estatuto", ControleAcesso.LerTicket().CadastroId);
                CarregarGrid();
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
        Param = crypt.ActionEncrypt("0" + "#" + "0");
        Response.RedirectToRoute("ModEstatutoEdita", new { Param = Param });
    }
}