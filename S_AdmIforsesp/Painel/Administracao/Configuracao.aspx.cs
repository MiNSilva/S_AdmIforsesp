using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System.Web.UI.WebControls;
using System.Data;

public partial class Painel_Administracao_Configuracao : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarConfiguracao();
        }
    }

    protected void CarregarConfiguracao()
    {
        WebConfigModel config = new WebConfigModel();
        WebConfigBLL obj = new WebConfigBLL();

        DataSet ds = obj.CarregaConfig();

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtDiaRespEmail.Text = ds.Tables[0].Rows[0]["EmailDiasResposta"].ToString();
            lblId.Text = ds.Tables[0].Rows[0]["Id"].ToString();

            txtServidorImagem.Text = ds.Tables[0].Rows[0]["ServidorAdm"].ToString();

            TxtServidorSite.Text = ds.Tables[0].Rows[0]["ServidorSite"].ToString();
        }
        else
        {
            //lblMsgErro.Visible = true;
            //lblMsgErro.Text = "Não há conteúdo pertinente a este assunto !!!";
        }
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            WebConfigModel config = new WebConfigModel();
            WebConfigBLL obj = new WebConfigBLL();

            if (!String.IsNullOrEmpty(txtDiaRespEmail.Text))
            {
                config.Id = Convert.ToInt32(lblId.Text);
                config.EmailDiasResposta = Convert.ToInt32(txtDiaRespEmail.Text);
            }
            else
            {
                config.EmailDiasResposta = 0;
                config.Id = 0;
            }

            config.ServidorAdm = txtServidorImagem.Text;
            config.ServidorSite = TxtServidorSite.Text;

            obj.AtualizaConfiguracao(config, (config.Id == 0 ? 1 : 2));

            Param = crypt.ActionEncrypt("2#CONFIGURAÇÕES ALTUALIZADA COM SUCESSO !!!!");
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Atualizou as configurações do sistema", ControleAcesso.LerTicket().CadastroId);

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
}