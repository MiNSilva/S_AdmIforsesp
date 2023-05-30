using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Painel_Noticias_AdministracaoVizualizar : System.Web.UI.Page
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
                lblNoticiaId.Text = dados[0].ToString();
                int id = Convert.ToInt32(lblNoticiaId.Text);

                NoticiaBLL obj = new NoticiaBLL();
                dlNoticiaById.DataSource = obj.CarregaNoticiaById(id);
                dlNoticiaById.DataBind();

            }
            else
            {
                Param = crypt.ActionEncrypt("2#Nâo existe usuário !!!!");
                Response.RedirectToRoute("PnlAlerta", new { Param = Param });
            }

        }
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("NotAdministracao", new object{ });
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblNoticiaId.Text + "#" + 1);
        Response.RedirectToRoute("NotPublicacaoP", new { Param = Param });
    }
}