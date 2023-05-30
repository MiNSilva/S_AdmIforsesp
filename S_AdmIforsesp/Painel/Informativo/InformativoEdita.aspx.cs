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
using CKFinder;

public partial class Painel_Informativo_InformativoEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();
    string erro;


    protected void Page_Load(object sender, EventArgs e)
    {
        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtDescricao);
   


        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblIdInformativo.Text = dados[0].ToString();


                if (Convert.ToInt32(lblIdInformativo.Text) >= 1)
                {
                    WebInformativoBLL obj = new WebInformativoBLL();
                    WebInformativoModel info = new WebInformativoModel();

                    info.InformativoId = Convert.ToInt32(lblIdInformativo.Text);

                    DataSet ds = obj.CarregaSorteioId(info, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                            txtDescricao.Text = ds.Tables[0].Rows[0]["Descricao"].ToString();

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
            WebInformativoBLL obj = new WebInformativoBLL();
            WebInformativoModel info = new WebInformativoModel();


            if (lblIdInformativo.Text == "0")
            {
                info.InformativoId = 0;
            }
            else
            {
                info.InformativoId = Convert.ToInt32(lblIdInformativo.Text);
            }

            info.Nome = txtNome.Text;
            info.Descricao = txtDescricao.Text;

            obj.Atualiza(info, (lblIdInformativo.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Inseriu ou Alterou Informativo", ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("Informativo", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("Informativo", new object { });
    }
}