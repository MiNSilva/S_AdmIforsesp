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

public partial class Painel_Modulos_PublicacoesItemEdita : System.Web.UI.Page
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
                lblLegislacaoItemId.Text = dados[0].ToString();
                lblLegislacaoId.Text = dados[1].ToString();
                lblOrdem.Text = dados[2].ToString();
                lblLegislacaoItem.Text = dados[3].ToString();

                if (lblLegislacaoItemId.Text != "0")
                {
                    imgbtn.Visible = true;
                    txtImg.Visible = true;
                    rvfArquivo.Enabled = false;
                    FileUpload1.Visible = false;

                    ModuloPublicacaoItemModel legis = new ModuloPublicacaoItemModel();
                    ModuloPublicacaoItemBLL obj = new ModuloPublicacaoItemBLL();

                    lblIdLegislacaoItem.Text = lblLegislacaoItemId.Text;
                    legis = obj.GetPublicacaoItemById(Convert.ToInt32(lblLegislacaoItemId.Text));

                    lblOrdem.Text = legis.Ordem.ToString();
                    txtNomeItem.Text = legis.Nome;
                    txtImg.Text = legis.Arquivo.Substring(legis.Arquivo.IndexOf("]") + 1);
                    txtImgOriginal.Text = legis.Arquivo;
                }
            }
        }
    }

    protected void imgbtn_Click(object sender, ImageClickEventArgs e)
    {
        FileUpload1.Visible = true;
        FileUpload1.Dispose();
        txtImg.Text = string.Empty;
        imgbtn.Visible = false;
        txtImg.Visible = false;
        rvfArquivo.Enabled = true;

        //string caminho = Server.MapPath("~/Download/Publicacoes/" + txtImgOriginal.Text.Trim());

        //if (File.Exists(caminho))
        //{
        //    File.Delete(caminho);
        //    txtImg.Text = string.Empty;
        //    imgbtn.Visible = false;
        //    txtImg.Visible = false;
        //    rvfArquivo.Enabled = true;
        //    FileUpload1.Visible = true;
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
        //    lblMsgTit.Visible = true;
        //    lblMsgTit.Text = "Arquivo não encontrada no servidor. Exclua este item e cadastre um Novo";

        //    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
        //    lblMsgCont.Visible = true;
        //    lblMsgCont.Text = " ";
        //}
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtImg.Text.Length > 0 && !String.IsNullOrEmpty(FileUpload1.FileName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Excluir o arquivo já cadastrada, caso queira alterar o mesmo";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";
                return;
            }

            ModuloPublicacaoItemModel pub = new ModuloPublicacaoItemModel();
            ModuloPublicacaoItemBLL obj = new ModuloPublicacaoItemBLL();

            if (txtImg.Text.Length > 0)
            {
                pub.Arquivo = txtImgOriginal.Text;
            }
            else
            {
                if (FileUpload1.FileBytes.Length > 15728640)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Tamanho máximo permito 15MB";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";
                    return;
                }


                // Apagando a imagem antiga
                string caminho = Server.MapPath("~/Download/Publicacoes/" + txtImgOriginal.Text.Trim());
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                //inserindo nova imagem
                pub.Arquivo = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;
                string path = Server.MapPath("~/Download/Publicacoes/" + pub.Arquivo);
                if (!File.Exists(path))
                {
                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(path);
                    }
                }
            }

            if (lblLegislacaoItemId.Text == "0")
            {
                pub.WebPublicacaoItemId = 0;
            }
            else
            {
                pub.WebPublicacaoItemId = Convert.ToInt32(lblIdLegislacaoItem.Text);
            }
           
            pub.WebPublicacaoId = Convert.ToInt32(lblLegislacaoId.Text);
            pub.Nome = txtNomeItem.Text.Trim();

            if (Convert.ToInt32(lblOrdem.Text) == 0)
            {
                pub.Ordem = obj.GetPublicacaoItemOrdem(Convert.ToInt32(lblLegislacaoId.Text)) + 1;
            }
            else
            {
                pub.Ordem = Convert.ToInt32(lblOrdem.Text);
            }

            obj.AtualizaPublicacaoItem(pub, (lblLegislacaoItemId.Text == "0" ? 1 : 2), ControleAcesso.LerTicket().CadastroId);
            

            if (lblLegislacaoItemId.Text == "0")
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Incluiu Publicacoes:' " + pub.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }
            else
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou Publicacoes:' " + pub.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }

            Param = crypt.ActionEncrypt(lblLegislacaoId.Text + "#" + lblLegislacaoItemId.Text);
            Response.RedirectToRoute("ModPublicacoesItem", new { Param = Param });

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblLegislacaoId.Text + "#" + lblLegislacaoItem.Text);
        Response.RedirectToRoute("ModPublicacoesItem", new { Param = Param });
    }
}