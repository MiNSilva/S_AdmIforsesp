using System;
using System.Web.UI.WebControls;
using DIAPOIO.MODEL;
using DIAPOIO.BLL;
using System.Data.SqlClient;
using System.Web.UI;
using System.Drawing.Imaging;
using System.Web;
using System.Drawing;
using System.IO;
using CKFinder;
using System.Text.RegularExpressions;
using DIAPOIO.BLL.Autenticacao;
using System.Data;

public partial class Painel_Noticias_Publicacao : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtData.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtData.Attributes.Add("onBlur", "MascaraData(this,event);");

        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtNoticia);

        if (!IsPostBack)
        {
            rvfImagem.Enabled = true;
            txtImg.Text = string.Empty;
            txtImg.Visible = false;

            ddlDepto.DataValueField = "NoticiaDepartamentoId";
            ddlDepto.DataTextField = "Departamento";
            ddlDepto.DataSource = new NoticiaDepartamentoBLL().GetDepartamento();
            ddlDepto.DataBind();
            ddlCat.Enabled = false;

            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                int id = Convert.ToInt32(dados[0].ToString());
                lblNoticiaId.Text = id.ToString();
                int Editar = Convert.ToInt32(dados[1].ToString());

                if (Editar == 1)
                {
                    btnSend.Visible = true;
                    //txtImg.Visible = true;

                    NoticiaModel noticia = new NoticiaModel();
                    noticia.NoticiaID = id;

                    NoticiaBLL obj = new NoticiaBLL();
                    DataSet ds = obj.CarregaNoticiaById(noticia.NoticiaID);

                    NoticiaCategoriaModel cat = new NoticiaCategoriaModel();
                    cat.NoticiaDepartamentoID = Convert.ToInt32(ds.Tables[0].Rows[0]["NoticiaDepartamentoID"]);

                    ddlCat.DataValueField = "NoticiaCategoriaId";
                    ddlCat.DataTextField = "Categoria";
                    ddlCat.DataSource = new NoticiaCategoriaBLL().GetCategoria(cat);
                    ddlCat.DataBind();
                    ddlCat.Enabled = true;

                    ListItem selectDepto = ddlDepto.Items.FindByValue(ds.Tables[0].Rows[0]["NoticiaDepartamentoID"].ToString());
                    if (selectDepto != null)
                    {
                        ddlDepto.ClearSelection();
                        selectDepto.Selected = true;
                    }

                    ListItem selectCateg = ddlCat.Items.FindByValue(ds.Tables[0].Rows[0]["NoticiaCategoriaID"].ToString());
                    if (selectCateg != null)
                    {
                        ddlCat.ClearSelection();
                        selectCateg.Selected = true;
                    }

                    txtTitulo.Text = ds.Tables[0].Rows[0]["Titulo"].ToString();
                    txtResumo.Text = ds.Tables[0].Rows[0]["Resumo"].ToString();
                    txtNoticia.Text = ds.Tables[0].Rows[0]["Noticia"].ToString();

                    //txtData.Text = ds.Tables[0].Rows[0]["DataNoticia"].ToString("dd/MM/yyyy");
                    txtData.Text = ds.Tables[0].Rows[0]["DataNoticia"].ToString();


                    if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["Imagem1"].ToString()))
                    {
                        Panel2.Visible = false;
                        lblarq.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString().Substring(ds.Tables[0].Rows[0]["Imagem1"].ToString().IndexOf("]") + 1);
                        lblarqori.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString();
                        txtImg.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString();
                        Panel3.Visible = true;

                    }
                    else
                    {
                        Panel2.Visible = true;
                        lblarq.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString().Substring(ds.Tables[0].Rows[0]["Imagem1"].ToString().IndexOf("]") + 1);
                        lblarqori.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString();
                        txtImg.Text = ds.Tables[0].Rows[0]["Imagem1"].ToString();
                    }

                    rbldestaque.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["DestaqueId"]);

                    lblcontrole.Text = "1";
                }
            }
            else
            {
                Panel3.Visible = true;
                lblNoticiaId.Text = "0";
            }
        }
    }

    protected void ddlDepto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepto.SelectedItem.Text == "Selecione")
        {
            ddlCat.Enabled = false;
            ddlCat.SelectedItem.Text = "Selecione";
        }
        else
        {
            NoticiaCategoriaModel noticia = new NoticiaCategoriaModel();
            noticia.NoticiaDepartamentoID = Convert.ToInt32(ddlDepto.SelectedValue);
            ddlCat.Items.Clear();
            ddlCat.Items.Add("Selecione");
            ddlCat.DataValueField = "NoticiaCategoriaId";
            ddlCat.DataTextField = "Categoria";
            ddlCat.DataSource = new NoticiaCategoriaBLL().GetCategoria(noticia);
            ddlCat.DataBind();
            ddlCat.Enabled = true;
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {

                NoticiaBLL obj = new NoticiaBLL();
                NoticiaModel noticia = new NoticiaModel();

                noticia.NoticiaDepartamentoID = Convert.ToInt32(ddlDepto.SelectedValue);
                noticia.NoticiaCategoriaID = Convert.ToInt32(ddlCat.SelectedValue);
                noticia.Titulo = txtTitulo.Text.Trim();
                noticia.Resumo = txtResumo.Text.Trim();
                noticia.Noticia = txtNoticia.Text;                
                noticia.Autor = HttpContext.Current.User.Identity.Name;
                noticia.Situacao = 'N'.ToString();
                noticia.Contador = 1;
                noticia.DataNoticia = Convert.ToDateTime(txtData.Text);
                noticia.Usuariowebid = ControleAcesso.LerTicket().CadastroId;
                noticia.IdRegional = ControleAcesso.LerTicket().IdRegional;
                noticia.DestaqueId = rbldestaque.SelectedIndex;
                noticia.NoticiaID = Convert.ToInt32(lblNoticiaId.Text);
                noticia.TipoDep = 0;

                //if (!string.IsNullOrEmpty(noticia.Imagem1))
                if (txtImg.Text.Length > 0)
                {
                    noticia.Imagem1 = lblarqori.Text;
                }
                else
                {
                    if (FileUpload1.HasFile)
                    {
                        lblMsgErro.Text = VerificaTamanho(FileUpload1); 
                        if (String.IsNullOrEmpty(lblMsgErro.Text))
                        {
                            noticia.Imagem1 = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;

                            String path = Server.MapPath("~/images/Noticias/Original/" + noticia.Imagem1);
                            if (!File.Exists(path))
                            {
                                if (FileUpload1.HasFile)
                                {
                                    FileUpload1.SaveAs(path);
                                }
                            }
                        }
                        else
                        {

                            Panel1.Visible = true;
                            lblMsgErro.Visible = true;

                            //Label lblMsgTit1 = Page.Master.FindControl("lblTitulo") as Label;
                            //lblMsgTit1.Visible = true;
                            //lblMsgTit1.Text = lblMsgErro.Text;

                            //Label lblMsgCont1 = Page.Master.FindControl("lblConteudo") as Label;
                            //lblMsgCont1.Visible = true;
                            //lblMsgCont1.Text = " ";

                            return;
                        }   
                    }
                }

                
                obj.AtualizaNoticia(noticia, (lblNoticiaId.Text == "0" ? 1 : 2));
                //obj.EmailAprovador(Convert.ToInt32(ddlDepto.SelectedValue));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Notícia Inserida com sucesso";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Incluiu Notícia:'" + noticia.Titulo + "'", ControleAcesso.LerTicket().CadastroId);

                Response.RedirectToRoute("NotAdministracao", new { });

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (IsValid)
    //        {
    //            NoticiaModel noticia = new NoticiaModel();
    //            noticia.NoticiaDepartamentoID = Convert.ToInt32(ddlDepto.SelectedValue);
    //            noticia.NoticiaCategoriaID = Convert.ToInt32(ddlCat.SelectedValue);
    //            noticia.Titulo = txtTitulo.Text.Trim();
    //            noticia.Resumo = txtResumo.Text.Trim();
    //            noticia.Noticia = txtNoticia.Text;
    //            noticia.Imagem1 = FileUpload1.FileName;
    //            noticia.Imagem2 = string.Empty;
    //            noticia.Imagem3 = string.Empty;
    //            noticia.Imagem4 = string.Empty;
    //            noticia.Arquivo1 = string.Empty;
    //            noticia.Arquivo2 = string.Empty;
    //            noticia.Data = Convert.ToDateTime(txtData.Text);
    //            noticia.Autor = HttpContext.Current.User.Identity.Name;

    //            // Se for edição só salva senão coloca pra aprovação
    //            if (lblcontrole.Text == "1")
    //            {
    //                noticia.Situacao = 'A'.ToString();
    //            }
    //            else
    //            {
    //                noticia.Situacao = 'N'.ToString();
    //            }

    //            noticia.DataNoticia = Convert.ToDateTime(txtData.Text);
    //            noticia.Contador = 0;
    //            noticia.NoticiaID = Convert.ToInt32(lblNoticiaId.Text);


    //            if (txtImg.Text.Length > 0)
    //            {
    //                noticia.Imagem1 = txtImgOriginal.Text;
    //            }
    //            else
    //            {
    //                if (FileUpload1.HasFile)
    //                {

    //                    Panel1.Visible = true;
    //                    lblMsgErro.Text = VerificaTamanho(FileUpload1);

    //                    if (lblMsgErro.Text.Length > 0) return;
    //                    String path = Server.MapPath("~/images/Noticias/Original/" + FileUpload1.FileName);
    //                    //noticia.Imagem1 = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;
    //                    noticia.Imagem1 = FileUpload1.FileName;

    //                    if (!File.Exists(path))
    //                    {
    //                        if (FileUpload1.HasFile)
    //                        {
    //                            FileUpload1.SaveAs(path);
    //                        }
    //                    }
    //                }
    //            }


    //            NoticiaBLL obj = new NoticiaBLL();
    //            obj.AtualizaNoticia(noticia, 2);
    //            //obj.EmailAprovador(Convert.ToInt32(ddlDepto.SelectedValue));

    //            ClearTextBox(this);
    //            txtNoticia.Text = string.Empty;
    //            ddlCat.ClearSelection();
    //            ddlDepto.ClearSelection();

    //            Response.RedirectToRoute("NotAdministracao", new { });
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Param = crypt.ActionEncrypt("3#" + ex.Message);
    //        Response.RedirectToRoute("PnlAlerta", new { Param = Param });
    //    }
    //}

    protected string VerificaTamanho(FileUpload upload)
    {
        string msg = "";
        Bitmap Tamanho = new Bitmap(upload.PostedFile.InputStream, false);
        if (Tamanho.Width > 1300)
        {
            msg = "Tamanho da imagem muito alta, reduza a largura para menor que 1000px em um editor de imagem (Ex: Paint do Windows)!";

        }
        else if (Tamanho.Width < 300)
        {
            msg = "Tamanho da imagem muito baixa, aumente a largura para maior que 500px em um editor de imagem (Ex: Paint do Windows)!";

        }
        return msg;
    }

    public void CreateThumbnail(int largura, int altura, string srcpath, string destpath)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile(srcpath);
        System.Drawing.Image imgthumb = img.GetThumbnailImage(largura, altura, null, new System.IntPtr(0));
        imgthumb.Save(destpath, ImageFormat.Jpeg);
        img.Dispose();
        imgthumb.Dispose();
    }

    protected void ClearTextBox(Control pai)
    {
        foreach (Control ctl in pai.Controls)
            if (ctl is TextBox)
                ((TextBox)ctl).Text = string.Empty;
            else if (ctl.Controls.Count > 0)
                ClearTextBox(ctl);
    }

    protected void cvSummary_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtResumo.Text.Length > 220)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    public static string removerAcentos(string texto)
    {
        string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
        string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

        for (int i = 0; i < comAcentos.Length; i++)
        {
            texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
        }
        return texto;
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {

        string caminho = Server.MapPath("~/images/Noticias/Original/" + lblarqori.Text.Trim());

        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            File.Delete(Server.MapPath("~/images/Noticias/Original/" + lblarqori.Text.Trim()));
            txtImg.Text = string.Empty;
            txtImg.Visible = false;
            rvfImagem.Enabled = true;

            NoticiaModel noticia = new NoticiaModel();
            noticia.NoticiaDepartamentoID = Convert.ToInt32(ddlDepto.SelectedValue);
            noticia.NoticiaCategoriaID = Convert.ToInt32(ddlCat.SelectedValue);
            noticia.Titulo = txtTitulo.Text.Trim();
            noticia.Resumo = txtResumo.Text.Trim();
            noticia.Noticia = txtNoticia.Text;
            noticia.Imagem1 = FileUpload1.FileName;
            noticia.Imagem2 = string.Empty;
            noticia.Imagem3 = string.Empty;
            noticia.Imagem4 = string.Empty;
            noticia.Arquivo1 = string.Empty;
            noticia.Arquivo2 = string.Empty;
            noticia.Data = Convert.ToDateTime(txtData.Text);
            noticia.Autor = HttpContext.Current.User.Identity.Name;
            noticia.Situacao = 'N'.ToString();
            noticia.DataNoticia = Convert.ToDateTime(txtData.Text);
            noticia.Contador = 0;
            noticia.NoticiaID = Convert.ToInt32(lblNoticiaId.Text);

            NoticiaBLL obj = new NoticiaBLL();
            obj.AtualizaNoticia(noticia, 2);

            Panel3.Visible = true;
            Panel2.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
            lblMsgTit.Visible = true;
            lblMsgTit.Text = "Imagem não encontrada no servidor";

            Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
            lblMsgCont.Visible = true;
            lblMsgCont.Text = " ";

            Panel3.Visible = true;
            Panel2.Visible = false;

        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("NotAdministracao", new { });
    }
}