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

public partial class Painel_Administracao_Permissoes : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["UsuarioWebID"] != null)
            {
                lblIdUsuario.Text = Page.RouteData.Values["UsuarioWebID"].ToString();

                if (lblIdUsuario.Text == "0")
                {
                    btnSalvar.Visible = true;
                    btnAtualizarPer.Visible = true;
                    CarregarddlGrupo();
                }
                else
                {
                    btnSalvar.Visible = true;
                    btnAtualizarPer.Visible = true;
                }
                CarregarMenuUsuario(lblIdUsuario.Text);
                CarregarDadosUsuarios(lblIdUsuario.Text);


            }
            else
            {
                Response.RedirectToRoute("AdmUsuarios", new object { });
            }
        }
    }

    protected void CarregarddlGrupo()
    {
        ddlGrupo.Items.Clear();
        ddlGrupo.DataValueField = "GrupoId";
        ddlGrupo.DataTextField = "Descricao";
        ddlGrupo.DataSource = new WebGrupoBLL().CarregaGrupo();
        ddlGrupo.DataBind();
    }


    protected void CarregarDadosUsuarios(string idUsuario)
    {
        UsuarioWebBLL obj = new UsuarioWebBLL();
        DataSet ds = obj.CarregaUsuarioEspecifico(Convert.ToInt32(idUsuario));

        if (ds.Tables.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                lblNomeUsuario.Text = txtNome.Text;
                txtLogin.Text = ds.Tables[0].Rows[0]["login"].ToString();

                CarregarddlGrupo();
                ListItem selectGrupo = ddlGrupo.Items.FindByText(ds.Tables[0].Rows[0]["grupo"].ToString());
                if (selectGrupo != null)
                {
                    ddlGrupo.ClearSelection();
                    selectGrupo.Selected = true;
                };

                string ativo = ds.Tables[0].Rows[0]["ativo"].ToString();

                if (ativo == "NÃO")
                {
                    ddlAtivo.SelectedValue = "0";
                }
                else
                {
                    ddlAtivo.SelectedValue = "1";
                }
                txtSenha.Text = ds.Tables[0].Rows[0]["senha"].ToString();
            }
        }
        else
        {
            Param = crypt.ActionEncrypt("2#Nâo existe usuário !!!!");
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }

    }

    protected void CarregarMenuUsuario(string idUsuario)
    {
        WebMenuBLL obj = new WebMenuBLL();
        DataSet ds = obj.CarregaMenuPermissoes(idUsuario, 2, "0");

        gvSubMenu.DataSource = ds;
        gvSubMenu.DataBind();
    }

    protected void gvSubMenu_DataBound(object sender, EventArgs e)
    {
        int RowSpan = 2;
        for (int i = gvSubMenu.Rows.Count - 2; i >= 0; i--)
        {
            GridViewRow currRow = gvSubMenu.Rows[i];
            GridViewRow prevRow = gvSubMenu.Rows[i + 1];
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

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("AdmUsuarios", new object { });
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            //SALVANDO DADOS USUARIO

            UsuarioWebModel user = new UsuarioWebModel();
            UsuarioWebBLL obj = new UsuarioWebBLL();

            user.Nome = txtNome.Text.ToUpper();
            lblNomeUsuario.Text = user.Nome;
            user.Login = txtLogin.Text;
            user.Grupo = ddlGrupo.SelectedValue;
            user.Senha = txtSenha.Text;
            user.Ativo = ddlAtivo.SelectedValue;


            if (lblIdUsuario.Text == "0")
            {
                user.UsuarioWebId = 0;
            }
            else
            {
                user.UsuarioWebId = Convert.ToInt32(lblIdUsuario.Text);
            }


            //if (obj.ValidaUsuario(user, 1) == 0)
            //{
            if (lblIdUsuario.Text == "0")
            {
                int id = obj.AtualizaUsuario(user, 1);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Inserindo Usuario", ControleAcesso.LerTicket().CadastroId);

                lblIdUsuario.Text = id.ToString();
                btnAtualizarPer.Visible = true;
                lblErro.Visible = true;
                lblErro.Text = "Cadastro inserido com sucesso";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //Label lblMsgTit = Page.FindControl("lblTitulo") as Label;
                //lblMsgTit.Visible = true;
                //lblMsgTit.Text = "Cadastro Realizado com Sucesso";

                //Label lblMsgCont = Page.FindControl("lblConteudo") as Label;
                //lblMsgCont.Visible = true;
                //lblMsgCont.Text = ".... Continue o cadastro ... ";
            }
            else
            {
                int id = obj.AtualizaUsuario(user, 2);

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterando Usuario", ControleAcesso.LerTicket().CadastroId);

                CarregarDadosUsuarios(lblIdUsuario.Text);
                lblErro.Visible = true;
                lblErro.Text = "Cadastro atualizado com sucesso";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                //lblMsgTit.Visible = true;
                //lblMsgTit.Text = "Cadastro atualizado com Sucesso";

                //Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                //lblMsgCont.Visible = true;
                //lblMsgCont.Text = " ";
            }

            //}
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void btnAtualizarPer_Click(object sender, EventArgs e)
    {
        try
        {
            //SALVANDO DADOS PERMISSAO
            WebMenuModel perm = new WebMenuModel();
            WebMenuBLL objperm = new WebMenuBLL();

            int i = 0;

            DataSet ds = new DataSet();
            foreach (GridViewRow row in gvSubMenu.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("CheckPerm");
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        int idmenuinsere = Convert.ToInt32(gvSubMenu.Rows[i].Cells[2].Text);
                        ds = objperm.SalvarSubmenu(1, Convert.ToInt32(lblIdUsuario.Text), idmenuinsere);
                        i++;
                    }
                    else
                    {
                        int idmenudelete = Convert.ToInt32(gvSubMenu.Rows[i].Cells[2].Text);
                        ds = objperm.SalvarSubmenu(2, Convert.ToInt32(lblIdUsuario.Text), idmenudelete);
                        i++;
                    }
                }
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Permissões atualizado com Sucesso";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Permissões atualizado do usuário:" + lblNomeUsuario.Text, ControleAcesso.LerTicket().CadastroId);


        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


}
