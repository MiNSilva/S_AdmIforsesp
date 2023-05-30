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

public partial class Painel_Sorteio_Sorteio : System.Web.UI.Page
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
        ModuloSorteioBLL obj = new ModuloSorteioBLL();
        gvSorteio.DataSource = obj.CarregaGrid();
        gvSorteio.DataBind();
    }

    protected void gvSorteio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloSorteioModel sort = new ModuloSorteioModel();
            ModuloSorteioBLL obj = new ModuloSorteioBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvSorteio.Rows.Count && gvSorteio.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("SorteioEdita", new { Param = Param });

            }
            if (e.CommandName.Equals("Premio"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("SorteioPremio", new { Param = Param });

            }
            if (e.CommandName.Equals("Participantes"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("SorteioParticipantes", new { Param = Param });

            }

            if (e.CommandName.Equals("CopiaPart"))
            {

                obj.ReplicaParticipantes(Convert.ToInt32(index.ToString()));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Participantes do último sorteio inseridos com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";
            }
            if (e.CommandName.Equals("Resultados"))
            {

                Param = crypt.ActionEncrypt(index.ToString());
                Response.RedirectToRoute("SorteioResultado", new { Param = Param });

            }
            if (e.CommandName.Equals("GerarSorteio"))
            {
                lblIdSorteio.Text = e.CommandArgument.ToString();

                int retorno = obj.ValidaResultadoSorteio(Convert.ToInt32(lblIdSorteio.Text));
                DateTime Data = DateTime.Now;

                if (retorno == 0)
                {

                    DataSet ds = obj.SortearPremio(Convert.ToInt32(lblIdSorteio.Text), ControleAcesso.LerTicket().CadastroId, Data);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Param = crypt.ActionEncrypt(index.ToString());
                        Response.RedirectToRoute("SorteioResultado", new { Param = Param });
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                        Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                        lblMsgTit.Visible = true;
                        lblMsgTit.Text = "Não existe participantes para esse sorteio";

                        Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                        lblMsgCont.Visible = true;
                        lblMsgCont.Text = " ";

                    }
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Sorteio já realizado, acesse os Resultados e verifique";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }

                //Button btnRodaSorteio = (Button)sender;
                //btnRodaSorteio.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                //lblMsgTit.Visible = true;
                //lblMsgTit.Text = "Sorteio gerado com sucesso, verifique os premiados em Resultados";

                //Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                //lblMsgCont.Visible = true;
                //lblMsgCont.Text = " ";

            }

            if (e.CommandName.Equals("LimparSorteio"))
            {

                lblIdSorteio.Text = e.CommandArgument.ToString();
                int usuarioalt = ControleAcesso.LerTicket().CadastroId;
                DateTime dataAlt = DateTime.Now;

                int retorno = obj.LimpaResultadoSorteio(Convert.ToInt32(lblIdSorteio.Text), usuarioalt, dataAlt);

                if (retorno == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Sorteio foi zerado.";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
                else
                {

                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                lblIdSorteio.Text = e.CommandArgument.ToString();
                sort.IdSorteio = Convert.ToInt32(lblIdSorteio.Text);
                sort.Nome = string.Empty;
                sort.Data = DateTime.Now;
                sort.Qtde_ganhadores = 0;
                sort.Ativo = 0;
                sort.Regras = string.Empty;
                sort.Informativo = string.Empty;

                obj.Atualiza(sort, 3);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Sorteio", ControleAcesso.LerTicket().CadastroId);

                CarregarGrid();

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvSorteio_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSorteio.PageIndex = e.NewPageIndex;
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
        Response.RedirectToRoute("SorteioEdita", new { Param = Param });
    }

}