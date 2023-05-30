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

public partial class Painel_Noticias_DepartamentoEdita : System.Web.UI.Page
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
                lblID.Text = dados[0].ToString();

                if (dados.Length > 1)
                {
                    NoticiaDepartamentoModel depto = new NoticiaDepartamentoModel();
                    NoticiaDepartamentoBLL obj = new NoticiaDepartamentoBLL();

                    depto.NoticiaDepartamentoID = Convert.ToInt32(lblID.Text);
                    depto.Departamento = dados[1].ToString();

                    DataSet ds = obj.ValidaDepto(depto, 3);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtDepto.Text = ds.Tables[0].Rows[0]["Departamento"].ToString();
                            lblID.Text = ds.Tables[0].Rows[0]["NoticiaDepartamentoID"].ToString();
                        }
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

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            NoticiaDepartamentoModel depto = new NoticiaDepartamentoModel();
            NoticiaDepartamentoBLL obj = new NoticiaDepartamentoBLL();

            if (lblID.Text == "0")
            {
                depto.NoticiaDepartamentoID = 0;
            }
            else
            {
                depto.NoticiaDepartamentoID = Convert.ToInt32(lblID.Text);
            }
            depto.Departamento = txtDepto.Text.Trim();

            DataSet ds = obj.ValidaDepto(depto, 3);

            if (ds.Tables.Count == 1)
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Inseriu/Alterou Departamento de' " + depto.Departamento + "'", ControleAcesso.LerTicket().CadastroId);

                obj.AtualizaDepartamento(depto, (lblID.Text == "0" ? 1 : 2));
                Response.RedirectToRoute("NotDepartamento", new object { });
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Já existe Departamento com esse nome";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("NotDepartamento", new object { });
    }
}