using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using DIAPOIO.DAL;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Painel_Administracao_Diretoria : System.Web.UI.Page
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
        WebEquipeBLL obj = new WebEquipeBLL();
        gvEquipe.DataSource = obj.CarregaEquipe(4);
        gvEquipe.DataBind();
    }

    protected void gvEquipe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebEquipeModel eqp = new WebEquipeModel();
            WebEquipeBLL obj = new WebEquipeBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvEquipe.Rows.Count && gvEquipe.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvEquipe.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvEquipe.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("ModDiretoriaEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                eqp.EquipeId = index;
                eqp.Nome = string.Empty;
                eqp.Descricao = string.Empty;
                eqp.OrganizacaoId = "0";
                eqp.CargoId = "0";
                eqp.ImageUrl = string.Empty;
                eqp.IdRegional = 0;

                obj.AtualizaEquipe(eqp, 3);
                CarregarGrid();

                //if (obj.ValidaEquipe(eqp, 2) == 0)
                //{
                    
                    //string caminho = Server.MapPath("~/images/Equipe/" + gvEquipe.Rows[i].Cells[5].Text.Trim());

                    //if (File.Exists(caminho))
                    //{
                    //    File.Delete(caminho);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    //    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    //    lblMsgTit.Visible = true;
                    //    lblMsgTit.Text = "Imagem não encontrada no servidor. Exclua esta foto e cadastre uma nova";

                    //    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    //    lblMsgCont.Visible = true;
                    //    lblMsgCont.Text = " ";
                    //}
                //    CarregarGrid();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                //    lblMsgTit.Visible = true;
                //    lblMsgTit.Text = "Essa pessoa não pode ser excluído, esta vinculado a uma Cargo";

                //    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                //    lblMsgCont.Visible = true;
                //    lblMsgCont.Text = " ";
                //}
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void gvEquipe_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gvEquipe.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(0 + "#" + 0);
        Response.RedirectToRoute("ModDiretoriaEdita", new { Param = Param });
    }
}