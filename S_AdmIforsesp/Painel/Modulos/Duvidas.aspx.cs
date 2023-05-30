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
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Modulos_Duvidas : System.Web.UI.Page
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
        ModuloDuvidaBLL obj = new ModuloDuvidaBLL();
        gvDuvidas.DataSource = obj.CarregaGrid();
        gvDuvidas.DataBind();
    }

    protected void gvDuvida_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloDuvidaModel duv = new ModuloDuvidaModel();
            ModuloDuvidaBLL obj = new ModuloDuvidaBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvDuvidas.Rows.Count && gvDuvidas.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvDuvidas.Rows.Count)
                {

                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvDuvidas.Rows[i].Cells[3].Text);
                    Response.RedirectToRoute("ModDuvidasEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                duv.WebDuvidaId = Convert.ToInt32(e.CommandArgument); ;
                duv.Pergunta = String.Empty;
                duv.Resposta = string.Empty;
                duv.Ordem = 0;
                obj.AtualizaDuvida(duv, 3);


                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Duvida", ControleAcesso.LerTicket().CadastroId);
                CarregarGrid();
            }

            if (e.CommandName.Equals("Subir"))
            {
                int Ordem = Convert.ToInt32(gvDuvidas.Rows[i].Cells[4].Text);
                if (Ordem == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Pergunta é a primeira da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaDuvida(Convert.ToInt32(e.CommandArgument), Ordem, 1);
                    CarregarGrid();
                }
            }

            if (e.CommandName.Equals("Descer"))
            {
                int Ordem = Convert.ToInt32(gvDuvidas.Rows[i].Cells[4].Text);
                int OrdemMax = obj.GetDuvidaOrdem();
                if (Ordem == OrdemMax)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Pergunta é a última da Ordem";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                    return;
                }
                else
                {
                    obj.OrdernaDuvida(Convert.ToInt32(e.CommandArgument), Ordem, 2);
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

    protected void gvDuvida_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDuvidas.PageIndex = e.NewPageIndex;
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
        Param = crypt.ActionEncrypt("0" + "#" + "0");
        Response.RedirectToRoute("ModDuvidasEdita", new { Param = Param });
    }
}