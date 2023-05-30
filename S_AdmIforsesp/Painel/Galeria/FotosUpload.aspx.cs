using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using DIAPOIO.UPLOAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;


public partial class Painel_Galeria_FotosUpload : System.Web.UI.Page
{
    private string imagens;
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtData.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtData.Attributes.Add("onBlur", "MascaraData(this,event);");

        if (!IsPostBack)
        {
            CarregarddlTipoGaleria();
        }
    }

    protected void CarregarddlTipoGaleria()
    {
        ddlTipoGaleria.Items.Clear();
        ddlTipoGaleria.DataValueField = "IdTipoGaleriaImg";
        ddlTipoGaleria.DataTextField = "DescTipoGaleria";
        ddlTipoGaleria.DataSource = new GaleriaimagesBLL().CarregaTipoGaleriaimages();
        ddlTipoGaleria.DataBind();

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            String path = Server.MapPath("~/images/Galeria/");
            String pasta = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff"));

            GaleriaImgModel galeria = new GaleriaImgModel();
            galeria.Galeriaimgid = 0;
            galeria.DataEvento = Convert.ToDateTime(txtData.Text);
            galeria.Titulo = txtTitulo.Text.ToUpper();
            galeria.IdUsuarioweb = Convert.ToInt32(Session["IdUsuario"]);
            galeria.Url = pasta;
            galeria.ImgPrincipal = FileUpload1.FileName;
            galeria.ImgPrincipal = "Principal" + galeria.ImgPrincipal.Substring(FileUpload1.FileName.LastIndexOf("."));


            galeria.IdTipoGaleriaimg = Convert.ToInt32(ddlTipoGaleria.SelectedValue);
            galeria.IdRegional = 1;

            if (UploadImages.HasFile)
            {
                // Criando pasta datahora de inserção das imagens
                if (!Directory.Exists(path + pasta))
                    Directory.CreateDirectory(path + pasta);

                // Criando pasta da imagem principal
                if (!Directory.Exists(path + pasta + "\\Principal"))
                    Directory.CreateDirectory(path + pasta + "\\Principal");
                FileUpload1.SaveAs(path + pasta + "\\Principal\\" + "Principal" + galeria.ImgPrincipal.Substring(galeria.ImgPrincipal.LastIndexOf(".")));


                if (!File.Exists(path))
                {
                    foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
                    {
                        uploadedFile.SaveAs(path + "" + pasta + "\\" + uploadedFile.FileName);
                        listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                    }
                }
            }

            GaleriaimagesBLL obj = new GaleriaimagesBLL();

            string[] list = Directory.GetFiles(path + pasta);
            var aList = from fileName in Directory.GetFiles(path)
                        select string.Format(path + "\\{0}", Path.GetFileName(fileName));

            for (int i = 0; i < list.Count(); i++)
            {
                imagens += list[i].ToString() + ",";
            }

            obj.AtualizaGaleria(galeria, 1, imagens);

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Inseriu ou Alterou Galeria de Imagem", ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("GalFotos", new object { });

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("GalFotos", new object { });
    }
}