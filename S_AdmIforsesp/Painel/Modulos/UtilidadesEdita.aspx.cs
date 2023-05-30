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

public partial class Painel_Modulos_UtilidadesEdita : System.Web.UI.Page
{

    string Param;
    CryptUtil crypt = new CryptUtil();
    int Largura = 161;
    int Altura = 152;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblUtilidadeId.Text = dados[0].ToString();
                

                if (Convert.ToInt32(lblUtilidadeId.Text) >= 1)
                {
                    ModuloUtilidadesBLL obj = new ModuloUtilidadesBLL();
                    ModuloUtilidadesModel uti = new ModuloUtilidadesModel();

                    uti.WebUtilidadeId = Convert.ToInt32(lblUtilidadeId.Text);

                    DataSet ds = obj.CarregaUtilidadeId(uti, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            imgbtn.Visible = true;
                            txtImg.Visible = true;
                            rvfImagem.Enabled = true;
                            FileUpload1.Visible = false;
                            
                            lblOrdem.Text = ds.Tables[0].Rows[0]["ordem"].ToString();
                            txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                            txtLink.Text = ds.Tables[0].Rows[0]["link"].ToString();

                            if (ds.Tables[0].Rows[0]["externo"].ToString() == "1")
                            {
                                ckExterno.Checked = true;
                            }
                            else
                            {
                                ckExterno.Checked = false;
                            }
                            txtImg.Text = ds.Tables[0].Rows[0]["imagem"].ToString().Substring(ds.Tables[0].Rows[0]["imagem"].ToString().IndexOf("]") + 1);
                            txtImgOriginal.Text = ds.Tables[0].Rows[0]["imagem"].ToString();

                        }
                    }
                }
                
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            ModuloUtilidadesBLL obj = new ModuloUtilidadesBLL();
            ModuloUtilidadesModel util = new ModuloUtilidadesModel();


            if (lblUtilidadeId.Text == "0")
            {
                util.WebUtilidadeId = 0;
            }
            else
            {
                util.WebUtilidadeId = Convert.ToInt32(lblUtilidadeId.Text);
            }


            util.Nome = txtNome.Text.Trim();
            util.Link = txtLink.Text;
            util.Externo = Convert.ToInt32(ckExterno.Checked);
            util.Imagem = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;
            util.Ordem = obj.GetOrdem() + 1;

            string erro = VerificaTamanho(FileUpload1, Largura, Altura);
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
            if (txtImg.Text.Length > 0)
            {
                util.Imagem = txtImgOriginal.Text;
            }
            else
            {
                // Apagando a imagem antiga
                string caminho = Server.MapPath("~/images/Utilidades/" + txtImgOriginal.Text.Trim());
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                //inserindo nova imagem
                string path = Server.MapPath("~/images/Utilidades/" + util.Imagem);
                if (!File.Exists(path))
                {
                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(path);
                    }
                }
            }
            obj.Atualiza(util, (lblUtilidadeId.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Inseriu ou Alterou Utilidade", ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("ModUtilidades", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModUtilidades", new object { });
    }

    protected string VerificaTamanho(FileUpload upload, int Largura, int Altura)
    {
        string msg = "";
        Bitmap Tamanho = new Bitmap(upload.PostedFile.InputStream, false);
        if (Tamanho.Width > Largura || Tamanho.Width < Largura)
        {
            msg = "Largura da imagem Menor ou Maior que " + Largura + "px. Redimensione em um editor de imagem (Ex: Paint do Windows)!";
        }
        if (Tamanho.Height > Altura || Tamanho.Width < Altura)
        {
            msg = "Altura da imagem Menor ou Maior que " + Altura + "px. Redimensione em um editor de imagem (Ex: Paint do Windows)!";
        }
        return msg;
    }

    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        txtImg.Text = string.Empty;
        imgbtn.Visible = false;
        txtImg.Visible = false;
        rvfImagem.Enabled = true;
        FileUpload1.Visible = true;
        FileUpload1.Dispose();

        //string caminho = Server.MapPath("~/images/Utilidades/" + txtImgOriginal.Text.Trim());

        //if (File.Exists(caminho))
        //{
        //    File.Delete(caminho);
        //    txtImg.Text = string.Empty;
        //    imgbtn.Visible = false;
        //    txtImg.Visible = false;
        //    rvfImagem.Enabled = true;
        //    FileUpload1.Visible = true;
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
        //    lblMsgTit.Visible = true;
        //    lblMsgTit.Text = "Imagem não encontrada no servidor. Exclua esta banner e cadastre um Novo";

        //    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
        //    lblMsgCont.Visible = true;
        //    lblMsgCont.Text = " ";

        //}
    }
}