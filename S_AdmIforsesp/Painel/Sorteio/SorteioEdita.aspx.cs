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

public partial class Painel_Sorteio_SorteioEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();
    string erro;

    protected void Page_Load(object sender, EventArgs e)
    {
        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtRegras);

        txtData.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtData.Attributes.Add("onBlur", "MascaraData(this,event);");


        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblIdSorteio.Text = dados[0].ToString();


                if (Convert.ToInt32(lblIdSorteio.Text) >= 1)
                {
                    ModuloSorteioBLL obj = new ModuloSorteioBLL();
                    ModuloSorteioModel sort = new ModuloSorteioModel();

                    sort.IdSorteio = Convert.ToInt32(lblIdSorteio.Text);

                    DataSet ds = obj.CarregaSorteioId(sort, 1);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            txtNome.Text = ds.Tables[0].Rows[0]["nome"].ToString();
                            txtData.Text = ds.Tables[0].Rows[0]["Data"].ToString();
                            txtqtdeganhadores.Text = ds.Tables[0].Rows[0]["Qtde_ganhadores"].ToString();
                            ddlAtivo.SelectedValue = ds.Tables[0].Rows[0]["Ativo"].ToString();
                            txtRegras.Text = ds.Tables[0].Rows[0]["Regras"].ToString();
                            txtInformativo.Text = ds.Tables[0].Rows[0]["Informativo"].ToString();

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
            ModuloSorteioBLL obj = new ModuloSorteioBLL();
            ModuloSorteioModel sort = new ModuloSorteioModel();


            if (lblIdSorteio.Text == "0")
            {
                sort.IdSorteio = 0;
            }
            else
            {
                sort.IdSorteio = Convert.ToInt32(lblIdSorteio.Text);
            }

            sort.Nome = txtNome.Text;
            sort.Data = Convert.ToDateTime(txtData.Text);
            sort.Qtde_ganhadores = Convert.ToInt32(txtqtdeganhadores.Text);
            sort.Ativo = Convert.ToInt32(ddlAtivo.SelectedValue);
            sort.Regras = txtRegras.Text;
            sort.Informativo = txtInformativo.Text;

            obj.Atualiza(sort, (lblIdSorteio.Text == "0" ? 1 : 2));

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            FuncoesBLL objf = new FuncoesBLL();
            objf.Atividades(url, "Inseriu ou Alterou Sorteio", ControleAcesso.LerTicket().CadastroId);

            Response.RedirectToRoute("Sorteio", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("Sorteio", new object { });
    }
}