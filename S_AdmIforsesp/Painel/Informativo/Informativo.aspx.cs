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

public partial class Painel_Informativo_Informativo : System.Web.UI.Page
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
        WebInformativoBLL obj = new WebInformativoBLL();
        gvInformativo.DataSource = obj.CarregaGrid();
        gvInformativo.DataBind();
    }

    protected void gvInformativo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebInformativoModel info = new WebInformativoModel();
            WebInformativoBLL obj = new WebInformativoBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvInformativo.Rows.Count && gvInformativo.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("InformativoEdita", new { Param = Param });

            }
           
            if (e.CommandName.Equals("Excluir"))
            {
                lblIdInformativo.Text = e.CommandArgument.ToString();
                info.InformativoId = Convert.ToInt32(lblIdInformativo.Text);
                info.Nome = string.Empty;
                info.Descricao = string.Empty;
                info.Data = DateTime.Now;
                obj.Atualiza(info, 3);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Informativo", ControleAcesso.LerTicket().CadastroId);

                CarregarGrid();

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvInformativo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvInformativo.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("InformativoEdita", new { Param = Param });
    }

}