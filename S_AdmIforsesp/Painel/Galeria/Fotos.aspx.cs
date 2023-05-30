using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System.Data;
using System.IO;
using DIAPOIO.BLL.Autenticacao;
using System.Text.RegularExpressions;

public partial class Painel_Galeria_Fotos: Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarTodasGalerias();
        }
    }

    protected void CarregarTodasGalerias()
    {

        GaleriaimagesBLL galeria = new GaleriaimagesBLL();
        DataSet gal = galeria.CarregaTodasGalerias();
        gvwTodasGalerias.DataSource = gal;
        gvwTodasGalerias.DataBind();
    }

    protected void gvwTodasGalerias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvwTodasGalerias.PageIndex = e.NewPageIndex;
            CarregarTodasGalerias();
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void gvwTodasGalerias_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Excluir")
        {
            GaleriaimagesBLL obj = new GaleriaimagesBLL();
            GaleriaImgModel images = new GaleriaImgModel();
            images.Url = e.CommandArgument.ToString();
            images.Galeriaimgid = 0;
            images.Titulo = string.Empty;
            images.IdUsuarioweb = 0;
            images.Imagem = string.Empty;
            images.ImgPrincipal = string.Empty;
            images.DataEvento = DateTime.Now;
            images.Data = DateTime.Now;

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Excluido Galeria:" + images.Titulo, ControleAcesso.LerTicket().CadastroId);

            obj.AtualizaGaleria(images, 3, "");

            string path = Server.MapPath("~/images/Galeria/" + images.Url);

            if (Directory.Exists(path))
                Directory.Delete(path, true);

            CarregarTodasGalerias();
        }
        else if (e.CommandName == "Editar")
        {
            GaleriaimagesBLL obj = new GaleriaimagesBLL();
            GaleriaImgModel images = new GaleriaImgModel();

            lblurl.Text = e.CommandArgument.ToString();
            
            Param = crypt.ActionEncrypt(lblurl.Text);
            Response.RedirectToRoute("GalFotosEdita", new { Param = Param });

            //Response.Redirect("EdicaoGaleria.aspx?url=" + url);

        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("GalFotosUpload", new object { });
    }
}