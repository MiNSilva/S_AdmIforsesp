using System;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using DIAPOIO.BLL.Autenticacao;
//using System.Data.SqlClient;
//using System.Data;
using System.Web;
//using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
//using System.Configuration;
//using System.Web;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.Drawing;

public partial class Painel_BannerItemEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        cvDataAtual.ValueToCompare = DateTime.Now.ToString("d");
        txtInicio.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtInicio.Attributes.Add("onBlur", "MascaraData(this,event);");
        txtFinal.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtFinal.Attributes.Add("onBlur", "MascaraData(this,event);");

        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblBannerId.Text = dados[0].ToString();
                lblBannerItemId.Text = dados[1].ToString();
                lblLargura.Text = dados[2].ToString();
                lblAltura.Text = dados[3].ToString();

                if (lblBannerItemId.Text != "0")
                {
                    Panel1.Visible = true;

                    ModuloBannerItemModel ban = new ModuloBannerItemModel();
                    ModuloBannerItemBLL obj = new ModuloBannerItemBLL();

                    ban = obj.GetBannerItemById(Convert.ToInt32(lblBannerItemId.Text));

                    lblOrdem.Text = ban.Ordem.ToString();
                    txtNomeBanItem.Text = ban.Nome;
                    txtTitulo.Text = ban.Titulo;
                    //txtPalavra0.Text = ban.Palavra0;
                    //txtPalavra1.Text = ban.Palavra1;
                    //txtPalavra2.Text = ban.Palavra2;
                    //txtPalavra3.Text = ban.Palavra3;
                    txtDescricao.Text = ban.Descricao;
                    ddlAtivo.SelectedValue = ban.Ativo.ToString();
                    txtInicio.Text = ban.Inicio.ToString("dd/MM/yyyy");
                    txtFinal.Text = ban.Final.ToString("dd/MM/yyyy");
                    txtLink.Text = ban.Link;
                    if (ban.Externo == 1)
                    {
                        ckExterno.Checked = true;
                    }
                    else
                    {
                        ckExterno.Checked = false;
                    }
                    lblarq.Text = ban.Arquivo.Substring(ban.Arquivo.IndexOf("]") + 1);
                    lblarqori.Text = ban.Arquivo;
                }
            }
        }


    }

    protected void cvSummary_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtDescricao.Text.Length > 220)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        //try
        //{
            ModuloBannerItemModel ban = new ModuloBannerItemModel();
            ModuloBannerItemBLL obj = new ModuloBannerItemBLL();

            if (lblBannerItemId.Text == "0")
            {
                ban.WebBannerItemId = 0;
            }
            else
            {
                ban.WebBannerItemId = Convert.ToInt32(lblBannerItemId.Text);
            }

            ban.WebBannerId = Convert.ToInt32(lblBannerId.Text);
            ban.Nome = txtNomeBanItem.Text.Trim();
            ban.Palavra0 = string.Empty;
            ban.Palavra1 = string.Empty;
            ban.Palavra2 = string.Empty;
            ban.Palavra3 = string.Empty;
            ban.Titulo = txtTitulo.Text.Trim();
            ban.Descricao = txtDescricao.Text.Trim();
            ban.Tempo = string.Empty;
            ban.Ativo = Convert.ToInt32(ddlAtivo.SelectedValue);

            if (Convert.ToInt32(ddlAtivo.SelectedValue) == 1)
            {
                ban.Ordem = 1;
            }
            else
            {
                ban.Ordem = 0;
            }
            ban.Inicio = Convert.ToDateTime(txtInicio.Text);
            ban.Final = Convert.ToDateTime(txtFinal.Text);
            ban.Link = txtLink.Text;
            ban.Externo = Convert.ToInt32(ckExterno.Checked);
            ban.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);

            ban.Arquivo = FileUpload1.FileName;

            //if (ban.Arquivo != "Label" || string.IsNullOrEmpty(lblarq.Text))
            if (string.IsNullOrEmpty(ban.Arquivo))
            {
                ban.Arquivo = lblarqori.Text;
            }
            else
            {
                // Apagando a imagem antiga no diretorio
                string caminho = Server.MapPath("~/images/Slide/" + lblarqori.Text.Trim());
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                ban.Arquivo = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;
                string erro = VerificaTamanho(FileUpload1, Convert.ToInt32(lblLargura.Text), Convert.ToInt32(lblAltura.Text));
                if (erro.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = erro;

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                    return;
                }

                string path = Server.MapPath("~/images/Slide/" + ban.Arquivo);
                if (!File.Exists(path))
                {
                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(path);
                    }
                }
            }

            obj.AtualizaBannerItem(ban, (lblBannerItemId.Text == "0" ? 1 : 2));

            if (lblBannerId.Text == "0")
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Incluiu Banner:' " + ban.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }
            else
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou Banner:' " + ban.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }


            Response.RedirectToRoute("ModBanner", new object{});

            //Param = crypt.ActionEncrypt(lblBannerId.Text + "#" + lblBannerItemId.Text + "#" + lblAltura.Text + "#" + lblLargura.Text);
            //Response.RedirectToRoute("ModBannerItem", new { Param = Param });

        //}
        //catch (Exception ex)
        //{
        //    Param = crypt.ActionEncrypt("3#" + ex.Message);
        //    Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        //}
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblBannerId.Text + "#" + lblBannerItemId.Text + "#" + lblAltura.Text + "#" + lblLargura.Text);
        Response.RedirectToRoute("ModBannerItem", new { Param = Param });

    }

    protected string VerificaTamanho(FileUpload upload, int Largura, int Altura)
    {
        string msg = "";
        Bitmap Tamanho = new Bitmap(upload.PostedFile.InputStream, false);
        if (Tamanho.Width > Largura || Tamanho.Width < Largura)
        {
            msg = "Largura da imagem Menor ou Maior que " + Largura + "px. Redimensione em um editor de imagem (Ex: Paint do Windows)!";
        }
        if (Tamanho.Height > Altura || Tamanho.Height < Altura)
        {
            msg = "Altura da imagem Menor ou Maior que " + Altura + "px. Redimensione em um editor de imagem (Ex: Paint do Windows)!";
        }
        return msg;
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        FileUpload1.Dispose();
        FileUpload1.Visible = true;
        lblarq.Visible = false;
        lblarqori.Visible = false;

        //string caminho = Server.MapPath("~/images/Site/Slide/" + lblarqori.Text.Trim());

        //if (File.Exists(caminho))
        //{
        //    File.Delete(caminho);
        //    lblarq.Text = string.Empty;
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
        //    lblMsgTit.Visible = true;
        //    lblMsgTit.Text = "Imagem não encontrada no servidor";

        //    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
        //    lblMsgCont.Visible = true;
        //    lblMsgCont.Text = "Exclua este parceiros e cadastre um Novo ";
        //}
    }
}