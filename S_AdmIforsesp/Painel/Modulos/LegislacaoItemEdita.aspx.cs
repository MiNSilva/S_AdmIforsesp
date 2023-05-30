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

public partial class Painel_Modulos_LegislacaoItemEdita : System.Web.UI.Page
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

                if (lblLegislacaoItemId.Text != "0")
                {
                    imgbtn.Visible = true;
                    txtImg.Visible = true;
                    rvfArquivo.Enabled = false;
                    FileUpload1.Visible = false;

                    ModuloLegislacaoItemModel legis = new ModuloLegislacaoItemModel();
                    ModuloLegislacaoItemBLL obj = new ModuloLegislacaoItemBLL();

                    lblIdLegislacaoItem.Text = lblLegislacaoItemId.Text;
                    legis = obj.GetLegislacaoItemById(Convert.ToInt32(lblLegislacaoItemId.Text));

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
        txtImg.Text = string.Empty;
        imgbtn.Visible = false;
        txtImg.Visible = false;
        rvfArquivo.Enabled = true;
        FileUpload1.Visible = true;
        FileUpload1.Dispose();

        //string caminho = Server.MapPath("~/Download/Legislacao/" + txtImgOriginal.Text.Trim());

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

            ModuloLegislacaoItemModel legis = new ModuloLegislacaoItemModel();
            ModuloLegislacaoItemBLL obj = new ModuloLegislacaoItemBLL();

            if (txtImg.Text.Length > 0)
            {
                legis.Arquivo = txtImgOriginal.Text;
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
                string caminho = Server.MapPath("~/Download/Legislacao/" + txtImgOriginal.Text.Trim());
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }

                //inserindo nova imagem
                legis.Arquivo = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileUpload1.FileName;
                string path = Server.MapPath("~/Download/Legislacao/" + legis.Arquivo);
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
                legis.WebLegislacaoItemId = 0;
            }
            else
            {
                legis.WebLegislacaoItemId = Convert.ToInt32(lblIdLegislacaoItem.Text);
            }
           
            legis.WebLegislacaoId = Convert.ToInt32(lblLegislacaoId.Text);
            legis.Nome = txtNomeItem.Text.Trim();

            if (Convert.ToInt32(lblOrdem.Text) == 0)
            {
                legis.Ordem = obj.GetLegislacaoItemOrdem(Convert.ToInt32(lblLegislacaoId.Text)) + 1;
            }
            else
            {
                legis.Ordem = Convert.ToInt32(lblOrdem.Text);
            }

            obj.AtualizaLegislacaoItem(legis, (lblLegislacaoItemId.Text == "0" ? 1 : 2));
            

            if (lblLegislacaoItemId.Text == "0")
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Incluiu Banner:' " + legis.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }
            else
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou Banner:' " + legis.Nome + "'", ControleAcesso.LerTicket().CadastroId);
            }

            Param = crypt.ActionEncrypt(lblLegislacaoId.Text + "#" + lblLegislacaoItemId.Text);
            Response.RedirectToRoute("ModLegislacaoItem", new { Param = Param });

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt(lblLegislacaoId.Text + "#" + lblLegislacaoItemId.Text);
        Response.RedirectToRoute("ModLegislacaoItem", new { Param = Param });
    }
}