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

public partial class Painel_Noticias_Departamento : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGridDepto();
        }
    }

    protected void CarregarGridDepto()
    {
        NoticiaDepartamentoBLL obj = new NoticiaDepartamentoBLL();
        gvDepartamentos.DataSource = obj.CarregaDepartamento();
        gvDepartamentos.DataBind();
    }

    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("NotDepartamentoEdita", new { Param = Param });
    }
    protected void gvDepartamentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            NoticiaDepartamentoModel depto = new NoticiaDepartamentoModel();
            NoticiaDepartamentoBLL obj = new NoticiaDepartamentoBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            i = 0;
            while (i < gvDepartamentos.Rows.Count && gvDepartamentos.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvDepartamentos.Rows[i].Cells[1].Text);
                Response.RedirectToRoute("NotDepartamentoEdita", new { Param = Param });
            }

            if (e.CommandName.Equals("Excluir"))
            {
                depto.NoticiaDepartamentoID = Convert.ToInt32(e.CommandArgument); ;
                depto.Departamento = gvDepartamentos.Rows[i].Cells[1].Text;

                DataSet ds = obj.ValidaDepto(depto, 1);

                int noticiadepartamentoid = Convert.ToInt32(ds.Tables[0].Rows[0]["noticiadepartamentoid"]);

                if (noticiadepartamentoid == 0)
                {

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Excluiu Departamento:'" + gvDepartamentos.Rows[i].Cells[1].Text + "'", ControleAcesso.LerTicket().CadastroId);

                    obj.AtualizaDepartamento(depto, 3);
                    CarregarGridDepto();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Departamento excluído com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Departamento não pode ser excluído, existem notícia(s) cadastrada(s) para o mesmo";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
            }

            if (e.CommandName.Equals("Categorias"))
            {
                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvDepartamentos.Rows[i].Cells[1].Text);
                Response.RedirectToRoute("NotCategoria", new { Param = Param });
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

}