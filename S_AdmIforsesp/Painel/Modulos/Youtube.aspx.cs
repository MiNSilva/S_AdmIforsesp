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


public partial class Painel_Modulos_Youtube : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaVideo();
        }
    }

    protected void CarregaVideo()
    {
        WebYoutubeBLL obj = new WebYoutubeBLL();
        gvYoutube.DataSource = obj.CarregaVideo(2);
        gvYoutube.DataBind();
    }

    protected void gvYoutube_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            WebYoutubeModel video = new WebYoutubeModel();
            WebYoutubeBLL obj = new WebYoutubeBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvYoutube.Rows.Count && gvYoutube.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {

                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvYoutube.Rows[i].Cells[1].Text);
                Response.RedirectToRoute("ModYoutubeEdita", new { Param = Param });
            }

            if (e.CommandName.Equals("Excluir"))
            {

                lblIdYoutube.Text = e.CommandArgument.ToString();
                video.YoutubeId = Convert.ToInt32(lblIdYoutube.Text);
                video.LinkYoutube = string.Empty;
                video.TituloYoutube = string.Empty;
                video.DescrYoutube = string.Empty;
                video.OrdemYoutube = 0;
                video.AtivoYoutube = 0;
                video.DataYoutube = DateTime.Now;
                video.LinkYoutube = string.Empty;

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Excluido Video Youtube:" + video.TituloYoutube, ControleAcesso.LerTicket().CadastroId);

                obj.AtualizaVideo(video, 3);

                string urlr = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objc = new FuncoesBLL();
                objf.Atividades(url, "Excluiu Video", ControleAcesso.LerTicket().CadastroId);

                CarregaVideo();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Excluido Video com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

            }

            if (e.CommandName.Equals("Subir"))
            {
                int Ordem = Convert.ToInt32(gvYoutube.Rows[i].Cells[4].Text);
                if (Ordem == 1)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    //lblTitulo.Visible = true;
                    //lblConteudo.Visible = true;
                    //lblTitulo.Text = "Video é a primeiro da Ordem";
                    //lblConteudo.Text = " ";
                    return;
                }
                else
                {
                    obj.Orderna(Convert.ToInt32(e.CommandArgument), Ordem, 1);
                    CarregaVideo();
                }

            }

            if (e.CommandName.Equals("Descer"))
            {
                int Ordem = Convert.ToInt32(gvYoutube.Rows[i].Cells[4].Text);
                int OrdemMax = obj.GetOrdem();
                if (Ordem == OrdemMax)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    //lblTitulo.Visible = true;
                    //lblConteudo.Visible = true;
                    //lblTitulo.Text = "Video é a último da Ordem";
                    //lblConteudo.Text = " ";
                    return;
                }
                else
                {
                    obj.Orderna(Convert.ToInt32(e.CommandArgument), Ordem, 2);
                    CarregaVideo();
                }
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0");
        Response.RedirectToRoute("ModYoutubeEdita", new { Param = Param });
    }
  
    protected void gvYoutube_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvYoutube.PageIndex = e.NewPageIndex;
            CarregaVideo();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
}