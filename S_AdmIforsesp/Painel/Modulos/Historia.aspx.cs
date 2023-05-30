using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Modulos_Historia : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaHistoria();
        }

    }
    protected void CarregaHistoria()
    {
        WebQuemSomosBLL obj = new WebQuemSomosBLL();
        gvQuemSomos.DataSource = obj.CarregaQuemSomos();
        gvQuemSomos.DataBind();
    }

    protected void gvQuemSomos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebQuemSomosModel est = new WebQuemSomosModel();
            WebQuemSomosBLL obj = new WebQuemSomosBLL();


            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvQuemSomos.Rows.Count && gvQuemSomos.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvQuemSomos.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvQuemSomos.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("ModHistoriaEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                est.QuemSomosId = index;
                est.NomeQuemSomos = String.Empty;
                est.DescricaoQuemSomos = String.Empty;

                //Exclui História
                obj.AtualizaQuemSomos(est, 3);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "História excluida com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";
                
                CarregaHistoria();
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
    protected void gvQuemSomos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvQuemSomos.PageIndex = e.NewPageIndex;
            CarregaHistoria();
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
        Response.RedirectToRoute("ModHistoriaEdita", new { Param = Param });
    }
}