using System;
using System.Collections.Generic;
using System.Linq;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.BLL.Autenticacao;

public partial class Painel_Noticias_CategoriaEdita : System.Web.UI.Page
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
                lblCatID.Text = dados[0].ToString();
                lblCat.Text = dados[1].ToString().ToString();
                lblDepto.Text = dados[2].ToString().ToString();
                lblDeptoId.Text = dados[3].ToString().ToString();
                

                if (dados.Length > 1)
                {
                    NoticiaCategoriaModel categoria = new NoticiaCategoriaModel();
                    NoticiaCategoriaBLL obj = new NoticiaCategoriaBLL();

                    categoria.NoticiaCategoriaID = Convert.ToInt32(lblCatID.Text);
                    categoria.Categoria = dados[1].ToString();

                    DataSet ds = obj.ValidaCategoria(categoria, 1);

                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtCat.Text = ds.Tables[0].Rows[0]["Categoria"].ToString();
                            //lblCatID.Text = ds.Tables[0].Rows[0]["NoticiaCategoriaID"].ToString();
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

        NoticiaCategoriaModel categoria = new NoticiaCategoriaModel();
        NoticiaCategoriaBLL obj = new NoticiaCategoriaBLL();

        if (lblCatID.Text == "0")
        {
            categoria.NoticiaCategoriaID = 0;
        }
        else
        {
            categoria.NoticiaCategoriaID = Convert.ToInt32(lblCatID.Text);
        }
        categoria.Categoria = txtCat.Text.Trim();
        categoria.NoticiaDepartamentoID = Convert.ToInt32(lblDeptoId.Text);

        DataSet ds = obj.ValidaCategoria(categoria, 1);

        if (ds.Tables.Count == 1)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Inseriu/Alterou Categoria de' " + categoria.Categoria + "'", ControleAcesso.LerTicket().CadastroId);

            obj.AtualizaCategoria(categoria, (lblCatID.Text == "0" ? 1 : 2));

            Param = crypt.ActionEncrypt(lblDeptoId.Text + "#" + lblDepto.Text);
            Response.RedirectToRoute("NotCategoria", new { Param = Param });
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Já existe Categoria com esse nome";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
        }
       
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblDeptoId.Text + "#" + lblDepto.Text);
        Response.RedirectToRoute("NotCategoria", new { Param = Param });
    }
}