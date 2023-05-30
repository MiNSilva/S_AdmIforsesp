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
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Administracao_Grupo : System.Web.UI.Page
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
        WebGrupoBLL obj = new WebGrupoBLL();
        gvGrupo.DataSource = obj.CarregaGrupo();
        gvGrupo.DataBind();
    }


    protected void gvGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebGrupoMODEL grup = new WebGrupoMODEL();
            WebGrupoBLL obj = new WebGrupoBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvGrupo.Rows.Count && gvGrupo.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvGrupo.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvGrupo.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("AdmGrupoEdita", new { Param = Param });

                    //txtdesc.Text = gvGrupo.Rows[i].Cells[1].Text;
                    //lblGrupoId.Text = index.ToString();
                    //btnSalvar.Visible = true;
                    //btnIncluir.Visible = false;
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                grup.GrupoId = index;
                grup.Descricao = String.Empty;


                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Grupo excluido:" + gvGrupo.Rows[i].Cells[1].Text, ControleAcesso.LerTicket().CadastroId);

                if (obj.ValidaGrupo(grup, 2) == 0)
                {
                    obj.AtualizaGrupo(grup, 3);
                    CarregarGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Esse grupo não pode ser excluído, esta vinculado a um Usuário";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                }
            }

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(0 + "#" + "");
        Response.RedirectToRoute("AdmGrupoEdita", new { Param = Param });

    }
}