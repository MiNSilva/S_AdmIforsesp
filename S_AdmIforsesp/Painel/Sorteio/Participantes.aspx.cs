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

public partial class Painel_Sorteio_Participantes : System.Web.UI.Page
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
                lblIdSorteioParticipantes.Text = dados[0].ToString();
                lblIdSorteio.Text = dados[0].ToString();

                int IdSorteio = Convert.ToInt32(lblIdSorteio.Text);

                if (IdSorteio >= 1)
                {
                    ModuloSorteioParticipantesBLL obj = new ModuloSorteioParticipantesBLL();
                    gvSorteioParticipantes.DataSource = obj.CarregaGridParticipantes(IdSorteio);
                    gvSorteioParticipantes.DataBind();
                }
            }

            CarregaTotal(Convert.ToInt32(lblIdSorteio.Text));
        }
    }

    protected void CarregarGrid(int IdSorteio)
    {
        ModuloSorteioParticipantesBLL obj = new ModuloSorteioParticipantesBLL();
        gvSorteioParticipantes.DataSource = obj.CarregaGridParticipantes(Convert.ToInt32(lblIdSorteio.Text));
        gvSorteioParticipantes.DataBind();
    }


    protected void CarregaTotal (int IdSorteio)
    {
        ModuloSorteioParticipantesBLL obj = new ModuloSorteioParticipantesBLL();
        lbltotal.Text = "Total de cadastros:" + obj.CarregaGridtotal(Convert.ToInt32(lblIdSorteio.Text));
    }




    protected void gvSorteioParticipantes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloSorteioPremioModel sortpre = new ModuloSorteioPremioModel();
            ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvSorteioParticipantes.Rows.Count && gvSorteioParticipantes.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }
           
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvSorteioParticipantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSorteioParticipantes.PageIndex = e.NewPageIndex;
            CarregarGrid(Convert.ToInt32(lblIdSorteio.Text));
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("Sorteio", new object { });
    }
}