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

public partial class Painel_Modulos_Utilidades : System.Web.UI.Page
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
        ModuloUtilidadesBLL obj = new ModuloUtilidadesBLL();
        gvUtilidade.DataSource = obj.CarregaGrid();
        gvUtilidade.DataBind();
    }

    protected void gvUtilidade_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloUtilidadesModel util = new ModuloUtilidadesModel();
            ModuloUtilidadesBLL obj = new ModuloUtilidadesBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvUtilidade.Rows.Count && gvUtilidade.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("ModUtilidadesEdita", new { Param = Param });

            }

            if (e.CommandName.Equals("Excluir"))
            {
                lblIdUtilidade.Text = e.CommandArgument.ToString();
                util.Nome = string.Empty;
                util.Imagem = string.Empty;
                util.Link = string.Empty;
                util.Ordem = 0;
                util.WebUtilidadeId = Convert.ToInt32(lblIdUtilidade.Text);
                util.Externo = 0;

                obj.Atualiza(util, 3);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Utilidade", ControleAcesso.LerTicket().CadastroId);

                string caminho = Server.MapPath("~/images/Utilidades/" + util.Imagem);

                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                CarregarGrid();

            }

            if (e.CommandName.Equals("Subir"))
            {
                int Ordem = Convert.ToInt32(gvUtilidade.Rows[i].Cells[6].Text);
                if (Ordem == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Utilidade é a primeira da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.Orderna(Convert.ToInt32(e.CommandArgument), Ordem, 1);
                    CarregarGrid();
                }

            }

            if (e.CommandName.Equals("Descer"))
            {
                int Ordem = Convert.ToInt32(gvUtilidade.Rows[i].Cells[6].Text);
                int OrdemMax = obj.GetOrdem();
                if (Ordem == OrdemMax)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Utilidade é a última da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.Orderna(Convert.ToInt32(e.CommandArgument), Ordem, 2);
                    CarregarGrid();
                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvUtilidade_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvUtilidade.PageIndex = e.NewPageIndex;
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
        Response.RedirectToRoute("ModUtilidadesEdita", new { Param = Param });
    }
}