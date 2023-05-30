using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using DIAPOIO.BLL;
using System.Data.SqlClient;
using DIAPOIO.BLL.Autenticacao;


public partial class Painel_Noticias_Administracao : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();
    string grupo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (!IsPostBack)
            //{
                    CarregarGrid();
            //}
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void CarregarGrid()
    {
        NoticiaBLL obj = new NoticiaBLL();

        DataSet ds = obj.CarregaTodasNoticias(txtPesquisa.Text.Trim());

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvwTodasNoticias.DataSource = ds;
            gvwTodasNoticias.DataBind();
        }
        else
        {
            gvwTodasNoticias.DataSource = ds;
            gvwTodasNoticias.DataBind();

        }
    }

    protected void gvwTodasNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvwTodasNoticias.PageIndex = e.NewPageIndex;
            CarregarGrid();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }

    }
    protected void gvwTodasNoticias_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string x = (DataBinder.Eval(e.Row.DataItem, "Situacao") as string);

            if (x == "A")
            {
                e.Row.Cells[5].Text = "<b style='color: green';>Aprovado</b>";
            }
            else if (x == "R")
            {
                e.Row.Cells[5].Text = "<b style='color: orange';>Reprovado</b>";
            }
            else
            {
                e.Row.Cells[5].Text = "<b style='color: blue';>Nova</b>";
            }

        }
    }

    protected void gvwTodasNoticias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvwTodasNoticias.Rows.Count && gvwTodasNoticias.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            grupo = ControleAcesso.LerTicket().Grupo;

            if (grupo == "ADM")
            {

                if (e.CommandName == "Excluir")
                {
                    NoticiaModel noticia = new NoticiaModel();
                    noticia.NoticiaID = index;
                    NoticiaBLL obj = new NoticiaBLL();
                    noticia.NoticiaDepartamentoID = 0;
                    noticia.NoticiaCategoriaID = 0;
                    noticia.Titulo = "";
                    noticia.Resumo = "";
                    noticia.Noticia = "";
                    noticia.Imagem1 = "";
                    noticia.Imagem2 = "";
                    noticia.Imagem3 = "";
                    noticia.Imagem4 = "";
                    noticia.Arquivo1 = "";
                    noticia.Arquivo2 = "";
                    noticia.Data = DateTime.Now;
                    noticia.Autor = "";
                    noticia.Situacao = "E";
                    noticia.Contador = 0;
                    noticia.DataNoticia = DateTime.Now;


                    obj.AtualizaNoticia(noticia, 3);

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Excluiu Noticia", ControleAcesso.LerTicket().CadastroId);

                    CarregarGrid();


                    string urlc = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objc = new FuncoesBLL();
                    objf.Atividades(url, "Excluiu Noticia ADM", ControleAcesso.LerTicket().CadastroId);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Notícia excluida com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";


                }
                else if (e.CommandName == "Aprovar")
                {
                    NoticiaModel noticia = new NoticiaModel();
                    noticia.NoticiaID = index;
                    NoticiaBLL obj = new NoticiaBLL();
                    noticia.Situacao = "A";
                    obj.AlteraSituacaoNoticia(noticia);
                    CarregarGrid();

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Aprovou Noticia ADM", ControleAcesso.LerTicket().CadastroId);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Notícia aprovada com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
                else if (e.CommandName == "Reprovar")
                {
                    NoticiaModel noticia = new NoticiaModel();
                    noticia.NoticiaID = index;
                    NoticiaBLL obj = new NoticiaBLL();
                    noticia.Situacao = "R";
                    obj.AlteraSituacaoNoticia(noticia);
                    CarregarGrid();

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Reprovou Noticia ADM", ControleAcesso.LerTicket().CadastroId);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Notícia reprovada com sucesso";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
                else if (e.CommandName == "Visualizar")
                {
                    Param = crypt.ActionEncrypt(index.ToString());
                    Response.RedirectToRoute("NotAdministracaoVizualizar", new { Param = Param });

                }
            }
            else
            {
                if (e.CommandName == "Visualizar")
                {
                    Param = crypt.ActionEncrypt(index.ToString());
                    Response.RedirectToRoute("NotAdministracaoVizualizar", new { Param = Param });

                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void txtPesquisa_TextChanged(object sender, EventArgs e)
    {
        CarregarGrid();
    }
}