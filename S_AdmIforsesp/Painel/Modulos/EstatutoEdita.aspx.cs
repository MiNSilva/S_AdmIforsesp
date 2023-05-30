using CKFinder;
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

public partial class Painel_Modulos_EstatutoEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {

        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtDescEstatuto);

        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblEstatutoId.Text = dados[0].ToString();
                lblNomeEstatuto.Text = dados[1].ToString();

                if (dados.Length > 1)
                {
                    WebEstatutoModel est = new WebEstatutoModel();
                    WebEstatutoBLL obj = new WebEstatutoBLL();

                    est.EstatutoId = Convert.ToInt32(lblEstatutoId.Text);

                    DataSet ds = obj.CarregaEstatutoID(est.EstatutoId);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtEstatuto.Text = ds.Tables[0].Rows[0]["NomeEstatuto"].ToString();
                            txtDescEstatuto.Text = ds.Tables[0].Rows[0]["DescricaoEstatuto"].ToString();
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
            WebEstatutoModel est = new WebEstatutoModel();
            WebEstatutoBLL obj = new WebEstatutoBLL();

            est.EstatutoId = Convert.ToInt32(lblEstatutoId.Text);
            est.NomeEstatuto = txtEstatuto.Text;
            est.DescricaoEstatuto = txtDescEstatuto.Text;

            obj.AtualizaEstatuto(est, (lblEstatutoId.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Alterou Duvida", ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("ModEstatuto", new object { });

        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModEstatuto", new object { });
    }

}