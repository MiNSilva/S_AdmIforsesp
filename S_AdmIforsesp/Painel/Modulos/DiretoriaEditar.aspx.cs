using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Administracao_DiretoriaEditar : System.Web.UI.Page
{
    CryptUtil crypt = new CryptUtil();
    string Param;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CarregarddlCargo();

            if (Page.RouteData.Values["Param"] != null)
            {

                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblEquipeId.Text = dados[0].ToString();

                if (lblEquipeId.Text != "0")
                {
                    WebEquipeBLL obj = new WebEquipeBLL();
                    DataSet ds = obj.CarregaEquipePorId(Convert.ToInt32(lblEquipeId.Text));

                    if (ds.Tables.Count > 0)
                    {

                        txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                        txtDescricao.Text = ds.Tables[0].Rows[0]["Descricao"].ToString();

                        CarregarddlCargo();
                        ListItem selectGrupo = ddlCargo.Items.FindByText(ds.Tables[0].Rows[0]["Cargo"].ToString());
                        if (selectGrupo != null)
                        {
                            ddlCargo.ClearSelection();
                            selectGrupo.Selected = true;
                        };

                        //lblarq.Text = ds.Tables[0].Rows[0]["ImageUrl"].ToString().Substring(ds.Tables[0].Rows[0]["ImageUrl"].ToString().IndexOf("]") + 1);
                        //lblarqori.Text = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                    }
                    else
                    {
                        Param = crypt.ActionEncrypt("2#Nâo existe usuário !!!!");
                        Response.RedirectToRoute("PnlAlerta", new { Param = Param });
                    }



                }
            }
        }
    }


    protected void CarregarddlCargo()
    {
        ddlCargo.Items.Clear();
        ddlCargo.DataValueField = "CargoId";
        ddlCargo.DataTextField = "Nome";
        ddlCargo.DataSource = new WebCargoBLL().CarregaCargo();
        ddlCargo.DataBind();
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            WebEquipeModel equipe = new WebEquipeModel();
            WebEquipeBLL obj = new WebEquipeBLL();

            equipe.EquipeId = Convert.ToInt32(lblEquipeId.Text);
            equipe.Nome = txtNome.Text.Trim();
            equipe.Descricao = txtDescricao.Text.Trim();
            equipe.OrganizacaoId = "0";
            equipe.CargoId = ddlCargo.SelectedValue;
            equipe.ImageUrl = string.Empty ;
            equipe.IdRegional = ControleAcesso.LerTicket().IdRegional ;

            //Atualiza 
            obj.AtualizaEquipe(equipe, (lblEquipeId.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Alterou Equipe ' " + equipe.Descricao, ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("ModDiretoria", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });

        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModDiretoria", new object { });
    }
}