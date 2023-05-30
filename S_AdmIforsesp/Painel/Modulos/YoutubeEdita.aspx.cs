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

public partial class Painel_Modulos_YoutubeEdita : System.Web.UI.Page
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
                lblIdYoutube.Text = dados[0].ToString();

                if (dados.Length > 1)
                {
                    WebYoutubeModel video = new WebYoutubeModel();
                    WebYoutubeBLL obj = new WebYoutubeBLL();

                    video.YoutubeId = Convert.ToInt32(lblIdYoutube.Text);
                    video.LinkYoutube = dados[1].ToString();

                    int id = Convert.ToInt32(lblIdYoutube.Text);
                    DataSet ds = obj.GetYoutubeById(id);

                    if (ds.Tables.Count > 0)
                    {

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            txtTitulo.Text = ds.Tables[0].Rows[0]["TituloYoutube"].ToString();
                            txtDescricao.Text = ds.Tables[0].Rows[0]["descrYoutube"].ToString();
                            txtLink.Text = ds.Tables[0].Rows[0]["LinkYoutube"].ToString();

                            ListItem selectAtivo = ddlAtivo.Items.FindByValue(ds.Tables[0].Rows[0]["ativoYoutube"].ToString());
                            if (selectAtivo != null)
                            {
                                ddlAtivo.ClearSelection();
                                selectAtivo.Selected = true;
                            }
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
        try
        {
            WebYoutubeModel video = new WebYoutubeModel();
            WebYoutubeBLL obj = new WebYoutubeBLL();

            if (lblIdYoutube.Text == "0")
            {
                video.YoutubeId = 0;
            }
            else
            {
                video.YoutubeId = Convert.ToInt32(lblIdYoutube.Text);
            }

            video.YoutubeId = Convert.ToInt32(lblIdYoutube.Text);
            video.LinkYoutube = txtLink.Text;
            video.TituloYoutube = txtTitulo.Text;
            video.DescrYoutube = txtDescricao.Text;
            video.AtivoYoutube = Convert.ToInt32(ddlAtivo.SelectedValue);

            if (video.AtivoYoutube == 1)
            {
                if (Convert.ToInt32(lblIdYoutube.Text) == 0)
                {
                    video.OrdemYoutube = obj.GetOrdem() + 1;
                }
                else
                {
                    video.OrdemYoutube = Convert.ToInt32(lblIdYoutube.Text);
                }
            }
            else
            {
                video.OrdemYoutube = 0;
            }

            video.DataYoutube = DateTime.Now;
            video.Usuariowebid = Convert.ToInt32(Session["IdUsuario"]);

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Alterou Video Youtube: '" + video.TituloYoutube + "'", ControleAcesso.LerTicket().CadastroId);

            obj.AtualizaVideo(video, (lblIdYoutube.Text == "0" ? 1 : 2));

            Response.RedirectToRoute("ModYoutube", new { Param = Param });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void Voltar(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModYoutube", new object { });
    }

  
}