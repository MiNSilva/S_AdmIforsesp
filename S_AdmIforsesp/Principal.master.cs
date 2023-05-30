using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ///Recupera Cookie
            HttpCookie cookie = Request.Cookies.Get("ADM");

            // Verifica se existe  Cookie 
            if (cookie == null)
            {
                Panel2.Visible = true;
            }
            else if (cookie.Value == "ADM_IFORSESP")
            {
                Panel2.Visible = false;
            }


        }
    }
    protected void btnAceitar_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;

        //Cria a estancia do obj HttpCookie passando o nome do mesmo
        HttpCookie cookie = new HttpCookie("ADM");

        //Define o valor do cookie
        cookie.Value = "ADM_IFORSESP";

        //Time para expiração (1min)
        //DateTime dtNow = DateTime.Now;
        //TimeSpan tsMinute = new TimeSpan(0, 0, 1, 0);
        //cookie.Expires = dtNow + tsMinute;

        //Time para expiração (1 dia)
        cookie.Expires = DateTime.Now.AddDays(1);

        //Adiciona o cookie
        Response.Cookies.Add(cookie);

    }


    protected void lkbCookies_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;

    }


    protected void Fechar_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}
