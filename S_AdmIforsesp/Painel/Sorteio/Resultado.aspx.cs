using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKFinder;

public partial class Painel_Sorteio_Resultado : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();
    string erro;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblIdSorteio.Text = dados[0].ToString();


                if (Convert.ToInt32(lblIdSorteio.Text) >= 1)
                {
                    CarregarGrid();

                    //ModuloSorteioResultadoBLL obj = new ModuloSorteioResultadoBLL();
                    //ModuloSorteioResultadoModel sort = new ModuloSorteioResultadoModel();

                    //sort.IdSorteio = Convert.ToInt32(lblIdSorteio.Text);

                    //DataSet ds = obj.CarregaSorteioResultadoId(sort, 1);

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    foreach (DataRow row in ds.Tables[0].Rows)
                    //    {
                    //        //txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                    //        //txtData.Text = ds.Tables[0].Rows[0]["Data"].ToString();
                    //        //txtqtdeganhadores.Text = ds.Tables[0].Rows[0]["Qtde_ganhadores"].ToString();
                    //        //ddlAtivo.SelectedValue = ds.Tables[0].Rows[0]["Ativo"].ToString();
                    //        //txtRegras.Text = ds.Tables[0].Rows[0]["Regras"].ToString();
                    //        //txtInformativo.Text = ds.Tables[0].Rows[0]["Informativo"].ToString();

                    //    }
                    //}
                }

            }
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("Sorteio", new object { });
    }
    protected void lkbImprimir_Click(object sender, EventArgs e)
    {
        CarregarGrid();
    }
    protected void CarregarGrid()
    {
        ModuloSorteioResultadoBLL obj = new ModuloSorteioResultadoBLL();
        ModuloSorteioResultadoModel sort = new ModuloSorteioResultadoModel();

        sort.IdSorteio = Convert.ToInt32(lblIdSorteio.Text);
        DataSet ds = obj.CarregaSorteioResultadoId(sort, 1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblSorteio.Text = ds.Tables[0].Rows[0]["Sorteio"].ToString();
            lblResposavel.Text = ds.Tables[0].Rows[0]["Responsavel"].ToString();
            lblData.Text = ds.Tables[0].Rows[0]["Data"].ToString();
            gvSorteioResultado.DataSource = ds;
            gvSorteioResultado.DataBind();
        }
        else
        {
            Panel1.Visible = false;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Não existe resultado para esse sorteio";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";
        }

        
    }
    protected void gvSorteioResultado_DataBound(object sender, EventArgs e)
    {
        int RowSpan = 2;
        for (int i = gvSorteioResultado.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow currRow = gvSorteioResultado.Rows[i];
            GridViewRow prevRow = gvSorteioResultado.Rows[i + 1];
            if (currRow.Cells[0].Text == prevRow.Cells[0].Text)
            {
                currRow.Cells[0].RowSpan = RowSpan;
                prevRow.Cells[0].Visible = false;
                RowSpan += 1;
            }
            else
                RowSpan = 2;
        }
    }

    protected void btnVoltar_Click1(object sender, EventArgs e)
    {
        Response.RedirectToRoute("Sorteio", new object { });
    }
}