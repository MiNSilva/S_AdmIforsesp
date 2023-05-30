using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            plMsg.Visible = false;

            if (Page.RouteData.Values["Param"] != null)
            {
                try
                {
                    CryptUtil crypt = new CryptUtil();
                    string Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                    string[] dados = Param.Split('#');
                    string Aviso = dados[1].ToString();

                    plMsg.Visible = true;
                    lblMsgErro.Text = Aviso;
                }
                catch (Exception ex)
                {
                    plMsg.Visible = true;
                    lblMsgErro.Text = ex.Message;
                }
            }
            else
            {
                Response.RedirectToRoute("Inicio", new object { });
            }
        }
    }

    protected void lkVOltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("Inicio", new object { });
    }
}