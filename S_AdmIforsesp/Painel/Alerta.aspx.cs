using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Alerta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            plMsgAlerta.Visible = false;
            plMsgErro.Visible = false;
            plMsgSucesso.Visible = false;

            if (Page.RouteData.Values["Param"] != null)
            {
                try
                {
                    CryptUtil crypt = new CryptUtil();
                    string Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                    string[] dados = Param.Split('#');
                    int Tipo = Convert.ToInt32(dados[0].ToString());
                    string Msg = dados[1].ToString();

                    switch (Tipo)
                    {
                        case 1:
                            plMsgAlerta.Visible = true;
                            plMsgSucesso.Visible = false;
                            plMsgErro.Visible = false;
                            lblMsgAlerta.Text = Msg;
                            break;
                        case 2:
                            plMsgAlerta.Visible = false;
                            plMsgSucesso.Visible = true;
                            plMsgErro.Visible = false;
                            lblMsgSucesso.Text = Msg;
                            break;
                        case 3:
                            plMsgAlerta.Visible = false;
                            plMsgSucesso.Visible = false;
                            plMsgErro.Visible = true;
                            lblMsgErro.Text = Msg;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    plMsgErro.Visible = true;
                    lblMsgErro.Text = ex.Message;
                }
            }
            else
            {
                Response.RedirectToRoute("PnlInicio", new object { });
            }
        }
    }
}