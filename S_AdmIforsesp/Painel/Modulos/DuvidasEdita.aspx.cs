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

public partial class Painel_Modulos_DuvidasEdita : System.Web.UI.Page
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
                lblDuvidaId.Text = dados[0].ToString();
                lblPergunta.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    ModuloDuvidaModel duv = new ModuloDuvidaModel();
                    ModuloDuvidaBLL obj = new ModuloDuvidaBLL();

                    duv.WebDuvidaId = Convert.ToInt32(lblDuvidaId.Text);
                    duv.Pergunta = lblPergunta.Text;

                    DataSet ds = obj.CarregaDuvidaId(duv, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtPergunta.Text = ds.Tables[0].Rows[0]["pergunta"].ToString();
                            txtResposta.Text = ds.Tables[0].Rows[0]["resposta"].ToString();
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
            ModuloDuvidaModel duv = new ModuloDuvidaModel();
            duv.Pergunta = txtPergunta.Text.Trim();
            duv.Resposta = txtResposta.Text.Trim();
            duv.WebDuvidaId = Convert.ToInt32(lblDuvidaId.Text);

            ModuloDuvidaBLL obj = new ModuloDuvidaBLL();

            if (obj.ValidaDuvida(duv, 1) >= 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                lblMsgTit.Visible = true;
                lblMsgTit.Text = "Já existe está Pergunta.";

                Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                lblMsgCont.Visible = true;
                lblMsgCont.Text = " ";

            }
            else
            {
                obj.AtualizaDuvida(duv, (lblDuvidaId.Text == "0" ? 1 : 2));

                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                FuncoesBLL objf = new FuncoesBLL();
                objf.Atividades(url, "Alterou Duvida", ControleAcesso.LerTicket().CadastroId);

                Response.RedirectToRoute("ModDuvidas", new object { });

            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModDuvidas", new object { });
    }


}