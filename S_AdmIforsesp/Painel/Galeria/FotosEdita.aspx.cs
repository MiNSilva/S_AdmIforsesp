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
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web.SessionState;
using DIAPOIO.UPLOAD;

public partial class Painel_Galeria_FotosEdita : System.Web.UI.Page
{
    string Param, pasta;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //String pasta = Page.RouteData.Values["url"].ToString();
            //CarregaGrid(pasta);

            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                //lblId.Text = dados[0].ToString();
                lblurl.Text = dados[0].ToString();

                GaleriaImgModel galeria = new GaleriaImgModel();
                GaleriaimagesBLL obj = new GaleriaimagesBLL();

                DataSet ds = obj.CarregaGaleriaByUrl(lblurl.Text);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTitulo.Text = ds.Tables[0].Rows[0]["Titulo"].ToString();
                }
                pasta = lblurl.Text;
                CarregaGrid(pasta);
            }
        }
    }

    private void CarregaGrid(string pasta)
    {

        //Marca o diretório a ser listado
        DirectoryInfo diretorio = new DirectoryInfo(Server.MapPath("~/images/Galeria/" + pasta));
        //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
        FileInfo[] ArquivosDiretorio = diretorio.GetFiles("*.*", SearchOption.AllDirectories);

        List<Arquivo> arquivos = new List<Arquivo>();
        string caminho = Server.MapPath("~/images/Galeria/" + pasta);

        for (int i = 0; i < ArquivosDiretorio.Count(); i++)
        {
            FileInfo f = new FileInfo(caminho + "//" + ArquivosDiretorio[i]);

            Arquivo arqImagem = new Arquivo();
            arqImagem.NomeArquivo = f.Name.Substring(f.Name.IndexOf("]") + 1);

            if (arqImagem.NomeArquivo == "Principal.jpg" || arqImagem.NomeArquivo == "Principal.png" || arqImagem.NomeArquivo == "Principal.jpeg")
            {
                FileInfo f1 = new FileInfo(caminho + "//Principal//" + ArquivosDiretorio[i]);
                arqImagem.NomeArquivoData = f.Name;
                arqImagem.CaminhoCompleto = f1.FullName;
                arqImagem.URL = "~/images/Galeria/" + caminho.Substring(caminho.IndexOf("["), 19) + "/Principal/" + f1.Name;
                arqImagem.Tamanho = f1.Length;
            }
            else
            {
                arqImagem.NomeArquivoData = f.Name;
                arqImagem.CaminhoCompleto = f.FullName;
                arqImagem.URL = "~/images/Galeria/" + caminho.Substring(caminho.IndexOf("["), 19) + "/" + f.Name;
                arqImagem.DataCriacao = f.CreationTime;
                arqImagem.Tamanho = f.Length;
            }
            arquivos.Add(arqImagem);
        }

        grdPreVisualizacao.DataSource = arquivos;
        grdPreVisualizacao.DataBind();

    }

    protected void grdPreVisualizacao_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Excluir")
        {

            GaleriaimagesBLL obj = new GaleriaimagesBLL();
            GaleriaImgModel img = new GaleriaImgModel();

            string pasta = lblurl.Text;
            string caminho = Server.MapPath("~/images/Galeria/" + pasta.ToString());
            string images = (string)grdPreVisualizacao.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

            // Marca o diretório a ser listado
            DirectoryInfo diretorio = new DirectoryInfo(caminho);
            // Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
            FileInfo[] ArquivosDiretorio = diretorio.GetFiles("*.*", SearchOption.AllDirectories);

            int Qtde = ArquivosDiretorio.Count();

            if (File.Exists(caminho + "/Thumbs.db"))
            {
                File.Delete(caminho + "/Thumbs.db");
                Qtde = Qtde - 1;
            }


            if (Qtde == 1)
            {
                Directory.Delete(caminho, true);
                Response.RedirectToRoute("GalFotos", new object { });
                //Response.Redirect("~/Administrador/GaleriaImg/Administracao.aspx");
            }
            else
            {

                for (int i = 0; i < Qtde; i++)
                {
                    FileInfo f = new FileInfo(caminho + "//" + ArquivosDiretorio[i]);

                    if (f.Name == images)
                    {

                        img.Url = pasta;
                        img.Galeriaimgid = 0;
                        img.Titulo = string.Empty;
                        img.IdUsuarioweb = 0;
                        img.Imagem = string.Empty;
                        img.ImgPrincipal = string.Empty;
                        img.DataEvento = DateTime.Now;
                        img.Data = DateTime.Now;

                        obj.AtualizaGaleria(img, 5, f.Name);

                        File.Delete(caminho + "\\" + f.Name);

                        lblUploadStatus.Visible = false;
                        lblFailedStatus.Visible = false;
                        lblFileList.Visible = false;
                        break;

                    }
                }
            }
            CarregaGrid(lblurl.Text);
        }
    }

    protected void grdPreVisu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string pasta = lblurl.Text;
    }

    protected void btnCancelarUpload_Click(object sender, EventArgs e)
    {
        PreVisualizacaoHelper.RemoverArquivosListaPreVisualizacao(Session);

        Response.RedirectToRoute("GalFotos", new object { });
    }

    protected void uploadedFile_Click(object sender, EventArgs e)
    {
        if (fileUpload.HasFile)     // CHECK IF ANY FILE HAS BEEN SELECTED.
        {
            GaleriaImgModel galeria = new GaleriaImgModel();
            GaleriaimagesBLL obj = new GaleriaimagesBLL();

            string pasta = lblurl.Text;
            string caminho = Server.MapPath("~/images/Galeria/" + pasta.ToString());


            int iUploadedCnt = 0;
            int iFailedCnt = 0;
            HttpFileCollection hfc = Request.Files;
            lblFileList.Text = "Select <b>" + hfc.Count + "</b> file(s)";

            if (hfc.Count <= 10)    // 10 FILES RESTRICTION.
            {
                for (int i = 0; i <= hfc.Count - 1; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (!File.Exists(Server.MapPath("CopyFiles\\") +
                            Path.GetFileName(hpf.FileName)))
                        {
                            //DirectoryInfo objDir = 
                            //    new DirectoryInfo(Server.MapPath("CopyFiles\\"));

                            string sFileName = Path.GetFileName(hpf.FileName);
                            string sFileExt = Path.GetExtension(hpf.FileName);

                            DirectoryInfo diretorio = new DirectoryInfo(caminho);

                            // CHECK FOR DUPLICATE FILES.
                            FileInfo[] objFI =
                                diretorio.GetFiles(sFileName.Replace(sFileExt, "") + ".*");

                            if (objFI.Length > 0)
                            {
                                // CHECK IF FILE WITH THE SAME NAME EXISTS IGNORING THE EXTENTIONS
                                foreach (FileInfo file in objFI)
                                {
                                    string sFileName1 = objFI[0].Name;
                                    string sFileExt1 = Path.GetExtension(objFI[0].Name);

                                    if (sFileName1.Replace(sFileExt1, "") ==
                                            sFileName.Replace(sFileExt, ""))
                                    {
                                        iFailedCnt += 1;        // NOT ALLOWING DUPLICATE.
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                // SAVE THE FILE IN A FOLDER.
                                hpf.SaveAs(Server.MapPath("~/images/Galeria/" + pasta + "/") +
                                    Path.GetFileName(hpf.FileName));

                                DataSet dt = obj.CarregaGaleriaByUrl(pasta);

                                foreach (DataRow rows in dt.Tables[0].Rows)
                                {

                                    galeria.Galeriaimgid = 0;
                                    galeria.DataEvento = Convert.ToDateTime(dt.Tables[0].Rows[0]["dataevento"]);
                                    galeria.Titulo = dt.Tables[0].Rows[0]["titulo"].ToString();
                                    galeria.IdUsuarioweb = ControleAcesso.LerTicket().CadastroId;
                                    galeria.Url = dt.Tables[0].Rows[0]["url"].ToString();
                                    galeria.ImgPrincipal = dt.Tables[0].Rows[0]["ImgPrincipal"].ToString(); ;
                                    galeria.IdTipoGaleriaimg = Convert.ToInt32(dt.Tables[0].Rows[0]["IdTipoGaleriaimg"]);
                                    galeria.IdRegional = Convert.ToInt32(dt.Tables[0].Rows[0]["IdRegional"]);

                                }
                                obj.AtualizaGaleria(galeria, 4, hpf.FileName);

                                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                                FuncoesBLL objf = new FuncoesBLL();
                                objf.Atividades(url, "Editou Galeria", ControleAcesso.LerTicket().CadastroId);

                                iUploadedCnt += 1;


                            }
                        }
                    }
                }
                lblUploadStatus.Text = "<b>" + iUploadedCnt + "</b> arquivo(s) Carregado.";
                lblFailedStatus.Text = "<b>" + iFailedCnt +
                    "</b> duplicado arquivo (s) não pôde ser carregado.";
            }
            else lblUploadStatus.Text = "Max. 10 arquivos permitido.";
        }
        else lblUploadStatus.Text = "Nenhum arquivo selecionado.";
        CarregaGrid(lblurl.Text);
    }




    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        GaleriaImgModel galeria = new GaleriaImgModel();
        GaleriaimagesBLL obj = new GaleriaimagesBLL();

        string pasta = lblurl.Text;

        obj.AtualizaTituloGal(pasta, txtTitulo.Text.ToString());

        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        FuncoesBLL objf = new FuncoesBLL();
        objf.Atividades(url, "Editou Galeria", ControleAcesso.LerTicket().CadastroId);



    }
}