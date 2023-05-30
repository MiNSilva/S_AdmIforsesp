using CKFinder;
using DIAPOIO.BLL;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Painel_Modulos_HostoriaEdita : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();


    protected void Page_Load(object sender, EventArgs e)
    {
        CKFinder.FileBrowser _fb = new FileBrowser();
        _fb.BasePath = "/../../../ckfinder/";
        _fb.SetupCKEditor(txtDescQuemSomos);

        txtDataPresidente.Attributes.Add("OnKeyPress", "MascaraData(this,event);");
        txtDataPresidente.Attributes.Add("onBlur", "MascaraData(this,event);");

        if (!IsPostBack)
        {
            if (Page.RouteData.Values["Param"] != null)
            {
                Param = crypt.ActionDecrypt(Page.RouteData.Values["Param"].ToString());
                string[] dados = Param.Split('#');
                lblHistoriaId.Text = dados[0].ToString();

                if (lblHistoriaId.Text != "0")
                {
                    WebQuemSomosBLL obj = new WebQuemSomosBLL();

                    WebQuemSomosModel est = new WebQuemSomosModel();


                    est.QuemSomosId = Convert.ToInt32(lblHistoriaId.Text);

                    DataSet ds = obj.CarregaQuemSomosID(Convert.ToInt32(lblHistoriaId.Text));

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            lblHistoriaId.Text = dados[0].ToString();
                            txtQuemSomos.Text = ds.Tables[0].Rows[0]["nomequemsomos"].ToString();
                            txtDescQuemSomos.Text = ds.Tables[0].Rows[0]["DescricaoQuemSomos"].ToString();

                            string fotopres = ds.Tables[0].Rows[0]["FotoPresidente"].ToString();
                            string arqrs = ds.Tables[0].Rows[0]["RegistroSindical"].ToString();
                            string estatuto = ds.Tables[0].Rows[0]["Estatuto"].ToString();

                            if (!String.IsNullOrEmpty(fotopres))
                            {
                                Panel1.Visible = true;
                                lblpres.Text = ds.Tables[0].Rows[0]["FotoPresidente"].ToString().Substring(ds.Tables[0].Rows[0]["FotoPresidente"].ToString().IndexOf("]") + 1);
                                lblpresp.Text = ds.Tables[0].Rows[0]["FotoPresidente"].ToString();
                                FilePresidente.Visible = false;
                            }
                            else
                            {
                                Panel1.Visible = false;
                            }

                            if (!String.IsNullOrEmpty(arqrs))
                            {
                                Panel2.Visible = true;
                                lblrsind.Text = ds.Tables[0].Rows[0]["RegistroSindical"].ToString().Substring(ds.Tables[0].Rows[0]["RegistroSindical"].ToString().IndexOf("]") + 1);
                                lblrsind.Visible = true;
                                lblrsindp.Text = ds.Tables[0].Rows[0]["RegistroSindical"].ToString();
                                FileRegSindical.Visible = false;
                            }
                            else
                            {
                                Panel2.Visible = false;
                            }


                            if (!String.IsNullOrEmpty(estatuto))
                            {
                                Panel3.Visible = true;
                                lblEst.Text = ds.Tables[0].Rows[0]["Estatuto"].ToString().Substring(ds.Tables[0].Rows[0]["Estatuto"].ToString().IndexOf("]") + 1);
                                lblEstp.Text = ds.Tables[0].Rows[0]["Estatuto"].ToString();
                                FileEstatuo.Visible = false;
                            }
                            else
                            {
                                Panel3.Visible = false;
                            }


                            txtDataPresidente.Text = ds.Tables[0].Rows[0]["DataPresidente"].ToString();
                            txtEmailPresidente.Text = ds.Tables[0].Rows[0]["EmailPresidente"].ToString();
                            txtMandatoPres.Text = ds.Tables[0].Rows[0]["MandatoPresidente"].ToString();
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
            WebQuemSomosModel est = new WebQuemSomosModel();
            WebQuemSomosBLL obj = new WebQuemSomosBLL();

            if (lblHistoriaId.Text == "0")
            {
                est.QuemSomosId = 0;
            }
            else
            {
                est.QuemSomosId = Convert.ToInt32(lblHistoriaId.Text);
            }

            est.NomeQuemSomos = txtQuemSomos.Text;
            est.DescricaoQuemSomos = txtDescQuemSomos.Text;


            if (lblpres.Text != "Label")
            {
                est.FotoPresidente = lblpresp.Text;
            }
            else
            {
                est.FotoPresidente = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FilePresidente.FileName;

                string path = Server.MapPath("~/images/Presidentes/" + est.FotoPresidente);
                if (!File.Exists(path))
                {
                    if (FilePresidente.HasFile)
                    {
                        FilePresidente.SaveAs(path);
                    }
                }

            }


            if (!string.IsNullOrEmpty(lblrsind.Text))
            {
                est.RegistroSindical = lblrsindp.Text;
            }
            else
            {
                est.RegistroSindical = String.Format("[{0}]", DateTime.Now.ToString("ddMMyyyyHHmmssfff")) + FileRegSindical.FileName;

                string pathr = Server.MapPath("~/Download/" + est.RegistroSindical);
                if (!File.Exists(pathr))
                {
                    if (FileRegSindical.HasFile)
                    {
                        FileRegSindical.SaveAs(pathr);
                    }
                }

            }


            if (!string.IsNullOrEmpty(lblEst.Text))
            {
                est.Estatuto = lblEstp.Text;
            }
            else
            {

                string uploadFolder = Request.PhysicalApplicationPath + "Download\\";
                if (FileEstatuo.HasFile)
                {
                    string extension = Path.GetExtension(FileEstatuo.PostedFile.FileName);
                    FileEstatuo.SaveAs(uploadFolder + "Estatuto" + extension);
                }
                est.Estatuto = "Estatuto.pdf";
            }

            est.DataPresidente = Convert.ToDateTime(txtDataPresidente.Text);
            est.MandatoPresidente = txtMandatoPres.Text;
            est.EmailPresidente = txtEmailPresidente.Text;



            obj.AtualizaQuemSomos(est, (lblHistoriaId.Text == "0" ? 1 : 2));

            Response.RedirectToRoute("ModHistoria", new object { });
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.RedirectToRoute("ModHistoria", new object { });
    }

    protected void lkbExcluir_Click(object sender, EventArgs e)
    {
        WebQuemSomosModel est = new WebQuemSomosModel();
        WebQuemSomosBLL obj = new WebQuemSomosBLL();

        string caminho = Server.MapPath("~/images/Presidentes/" + lblpresp.Text.Trim());

        if (File.Exists(caminho))
        {
            File.Delete(caminho);
            lblpres.Text = string.Empty;

            est.QuemSomosId = Convert.ToInt32(lblHistoriaId.Text);
            est.NomeQuemSomos = txtQuemSomos.Text;
            est.DescricaoQuemSomos = txtDescQuemSomos.Text;
            est.FotoPresidente = String.Empty;
            est.RegistroSindical = lblrsindp.Text;

            //Atualiza FotoPresidente vazia
            obj.AtualizaQuemSomos(est, 2);

            FilePresidente.Visible = true;
            Panel1.Visible = false;
        }

    }

    protected void lkbRS_Click(object sender, EventArgs e)
    {
        WebQuemSomosModel est = new WebQuemSomosModel();
        WebQuemSomosBLL obj = new WebQuemSomosBLL();

        string caminhors = Server.MapPath("~/Download/" + lblrsindp.Text.Trim());

        if (File.Exists(caminhors))
        {
            File.Delete(caminhors);
            lblrsind.Text = string.Empty;
            est.QuemSomosId = Convert.ToInt32(lblHistoriaId.Text);
            est.NomeQuemSomos = txtQuemSomos.Text;
            est.DescricaoQuemSomos = txtDescQuemSomos.Text;
            est.FotoPresidente = lblpresp.Text;
            est.RegistroSindical = string.Empty;
            est.Estatuto = lblEstp.Text;
            est.DataPresidente = Convert.ToDateTime(txtDataPresidente.Text);
            est.MandatoPresidente = txtMandatoPres.Text;
            est.EmailPresidente = txtEmailPresidente.Text;
            obj.AtualizaQuemSomos(est, 2);

            FileRegSindical.Visible = true;
            Panel2.Visible = false;
        }
        else
        {
            Param = crypt.ActionEncrypt("3#" + "Arquivo não Encontrado para Exclusão");
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }

    protected void lkbEstatuto_Click(object sender, EventArgs e)
    {
        WebQuemSomosModel est = new WebQuemSomosModel();
        WebQuemSomosBLL obj = new WebQuemSomosBLL();

        string caminhors = Server.MapPath("~/Download/" + lblEstp.Text.Trim());

        if (File.Exists(caminhors))
        {
            File.Delete(caminhors);
            lblEst.Text = string.Empty;

            est.QuemSomosId = Convert.ToInt32(lblHistoriaId.Text);
            est.NomeQuemSomos = txtQuemSomos.Text;
            est.DescricaoQuemSomos = txtDescQuemSomos.Text;
            est.FotoPresidente = lblpresp.Text;
            est.RegistroSindical = lblrsindp.Text;
            est.Estatuto = string.Empty;
            est.DataPresidente = Convert.ToDateTime(txtDataPresidente.Text);
            est.MandatoPresidente = txtMandatoPres.Text;
            est.EmailPresidente = txtEmailPresidente.Text;
            obj.AtualizaQuemSomos(est, 2);

            FileEstatuo.Visible = true;
            Panel3.Visible = false;
        }
        else
        {
            Param = crypt.ActionEncrypt("3#" + "Arquivo não Encontrado para Exclusão");
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }
}