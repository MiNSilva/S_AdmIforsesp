using DIAPOIO.DAL;
using DIAPOIO.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using DIAPOIO.BLL.Autenticacao;
using System.Data;
using System.Web.Services;

public partial class Administrador_Administracao : System.Web.UI.MasterPage
{
    //

    private object dlSubMenu;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string idUsuario = ControleAcesso.LerTicket().CadastroId.ToString();

            if (!string.IsNullOrEmpty(idUsuario))
            {
                MontaMenu(idUsuario);
            }
        }
    }
    protected void LoginStatus1_Logout(object sender, EventArgs e)
    {
        if (Request.AppRelativeCurrentExecutionFilePath == "~/")
            HttpContext.Current.RewritePath("Default.aspx");
    }


    public void MontaMenu(string idUsuario)
    {
        WebMenuBLL obj = new WebMenuBLL();
        DataSet ds = obj.CarregaMenu(idUsuario);

        ds.Relations.Add(new DataRelation("CategoriesRelation",
                ds.Tables[0].Columns["DESCR_MENU"],
                ds.Tables[1].Columns["HIERARQUIA_MENU"]));
        dlMenu.DataSource = ds.Tables[0];
        dlMenu.DataBind();

    }
    protected void dlMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            Repeater childRepeater = (Repeater)e.Item.FindControl("dlSubMenu");
            childRepeater.DataSource = drv.CreateChildView("CategoriesRelation");
            childRepeater.DataBind();
            
        }
    }

    [WebMethod()]
    public static void metodo()
    {
        string a = "0";
    }

}
