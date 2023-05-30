using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Administracao_GrupoEdita : System.Web.UI.Page
{
    CryptUtil crypt = new CryptUtil();
    string Param;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {

                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblGrupoId.Text = dados[0].ToString();
                lblGrupo.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    txtGrupo.Text = dados[1].ToString();
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            WebGrupoMODEL grup = new WebGrupoMODEL();
            WebGrupoBLL obj = new WebGrupoBLL();

            grup.GrupoId = Convert.ToInt32(lblGrupoId.Text);
            grup.Descricao = txtGrupo.Text.Trim();

            //Atualiza Feriado
            obj.AtualizaGrupo(grup, (lblGrupoId.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Alterou Grupo ' " + grup.Descricao , ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("AdmGrupo", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });

        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("AdmGrupo", new object { });
    }
}