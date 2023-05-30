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

public partial class Painel_Sorteio_PremioEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();
    string erro;
    int retorno;

    protected void Page_Load(object sender, EventArgs e)
    {
        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtDescricao);

        if (!IsPostBack)
        {
            ddlSorteio.DataValueField = "IdSorteio";
            ddlSorteio.DataTextField = "Nome";
            ddlSorteio.DataSource = new ModuloSorteioBLL().CarregaGrid();
            ddlSorteio.DataBind();
            ddlSorteio.Enabled = true;


            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblIdSorteioPremio.Text = dados[0].ToString();
                lblIdSorteio.Text = dados[1].ToString();

                if (Convert.ToInt32(lblIdSorteioPremio.Text) >= 1)
                {
                    ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();
                    ModuloSorteioPremioModel sortpre = new ModuloSorteioPremioModel();

                    sortpre.IdSorteioPremio = Convert.ToInt32(lblIdSorteioPremio.Text);

                    DataSet ds = obj.CarregaSorteioPremioId(sortpre, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            ddlSorteio.DataValueField = "IdSorteio";
                            ddlSorteio.DataTextField = "Nome";
                            ddlSorteio.DataSource = new ModuloSorteioBLL().CarregaGrid();
                            ddlSorteio.DataBind();
                            ddlSorteio.Enabled = true;

                            ListItem selectDepto = ddlSorteio.Items.FindByValue(ds.Tables[0].Rows[0]["IdSorteio"].ToString());
                            if (selectDepto != null)
                            {
                                ddlSorteio.ClearSelection();
                                selectDepto.Selected = true;
                            }

                            //ddlSorteio.SelectedValue = ds.Tables[0].Rows[0]["IdSorteio"].ToString();
                            txtItem.Text = ds.Tables[0].Rows[0]["Item"].ToString();
                            txtDescricao.Text = ds.Tables[0].Rows[0]["Descricao"].ToString();

                            lblIdSorteio.Text = ds.Tables[0].Rows[0]["IdSorteio"].ToString();
                            lblOrdem.Text = ds.Tables[0].Rows[0]["Ordem"].ToString();
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
            ModuloSorteioPremioBLL obj = new ModuloSorteioPremioBLL();
            ModuloSorteioPremioModel sortpre = new ModuloSorteioPremioModel();


            if (lblIdSorteioPremio.Text == "0")
            {
                sortpre.IdSorteioPremio = 0;
                sortpre.Ordem = obj.GetShowPremio(Convert.ToInt32(ddlSorteio.SelectedValue)) + 1;

                // validar quantidade de ganhadores do sorteio
                retorno = obj.ValidaQtdeSorteio(Convert.ToInt32(ddlSorteio.SelectedValue));
            }
            else
            {
                sortpre.IdSorteioPremio = Convert.ToInt32(lblIdSorteioPremio.Text);
                sortpre.Ordem = Convert.ToInt32(lblOrdem.Text);
                retorno = 0;
            }

            sortpre.IdSorteio = Convert.ToInt32(ddlSorteio.SelectedValue);
            sortpre.Item = txtItem.Text;
            sortpre.Descricao = txtDescricao.Text;

           

            if (retorno == 0)
            {
                obj.AtualizaPremio(sortpre, (lblIdSorteioPremio.Text == "0" ? 1 : 2));

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Inseriu ou Alterou Premio", ControleAcesso.LerTicket().CadastroId);

                Param = crypt.ActionEncrypt(ddlSorteio.SelectedValue);
                Response.RedirectToRoute("SorteioPremio", new { Param = Param });
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Excedido o valor de premios cadastrados";

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

        Param = crypt.ActionEncrypt(lblIdSorteio.Text);
        Response.RedirectToRoute("SorteioPremio", new { Param = Param });

    }
}