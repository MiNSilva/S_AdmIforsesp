using System;
using System.Collections.Generic;
using System.Linq;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Noticias_Categoria : System.Web.UI.Page
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
                lblIdDepto.Text = dados[0].ToString();
                lblDepto.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    CarregarGridCategoria();
                }
                else
                {
                    Response.RedirectToRoute("NotDepartamento", new object{ });
                }
            }
        }
    }

    protected void CarregarGridCategoria()
    {
        NoticiaCategoriaModel categoria = new NoticiaCategoriaModel();
        categoria.NoticiaDepartamentoID = Convert.ToInt32(lblIdDepto.Text);

        NoticiaCategoriaBLL obj = new NoticiaCategoriaBLL();
        gvCategorias.DataSource = obj.CarregaCategoria(Convert.ToInt32(lblIdDepto.Text));
        gvCategorias.DataBind();
    }

    protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            NoticiaCategoriaModel categ = new NoticiaCategoriaModel();
            NoticiaCategoriaBLL obj = new NoticiaCategoriaBLL();


            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            i = 0;
            while (i < gvCategorias.Rows.Count && gvCategorias.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }


            if (e.CommandName.Equals("Editar"))
            {
                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvCategorias.Rows[i].Cells[1].Text + "#" + lblDepto.Text + "#" + lblIdDepto.Text) ;

                Response.RedirectToRoute("NotCategoriaEdita", new { Param = Param });
            }

            if (e.CommandName.Equals("Excluir"))
            {
                categ.NoticiaCategoriaID = Convert.ToInt32(e.CommandArgument); ;
                categ.Categoria = "";

                DataSet ds = obj.ValidaCategoria(categ, 2);

                int noticiacategoriaid = Convert.ToInt32(ds.Tables[0].Rows[0]["noticiacategoriaid"]);

                if (noticiacategoriaid == 0)
                {
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Excluiu Categoria:'" + gvCategorias.Rows[i].Cells[1].Text + "'", ControleAcesso.LerTicket().CadastroId);

                    obj.AtualizaCategoria(categ, 3);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Categoria excluído com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Categoria não pode ser excluído, existem notícia(s) cadastrada(s) para o mesmo";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
            }
            CarregarGridCategoria();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0" +"#" + "0" + "#" + lblDepto.Text + "#" + lblIdDepto.Text);
        Response.RedirectToRoute("NotCategoriaEdita", new { Param = Param });
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("NotDepartamento", new object { });
    }
}