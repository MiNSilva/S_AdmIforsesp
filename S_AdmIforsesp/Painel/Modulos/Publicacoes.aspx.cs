﻿using DIAPOIO.BLL;
using DIAPOIO.BLL.Autenticacao;
using DIAPOIO.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Painel_Modulos_Publicacoes : System.Web.UI.Page
{
    string Param;
    CryptUtil crypt = new CryptUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarGrid();
        }
    }

    protected void CarregarGrid()
    {
        ModuloPublicacaoBLL obj = new ModuloPublicacaoBLL();
        DataSet ds = obj.CarregaPublicacao();
        gvLegislacao.DataSource = ds;
        gvLegislacao.DataBind();
    }

    protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            ModuloPublicacaoModel legis = new ModuloPublicacaoModel();
            ModuloPublicacaoBLL obj = new ModuloPublicacaoBLL();

            int index = Convert.ToInt32(e.CommandArgument);
            int i = 0;
            while (i < gvLegislacao.Rows.Count && gvLegislacao.Rows[i].Cells[0].Text != index.ToString())
            {
                i++;
            }

            if (e.CommandName.Equals("Editar"))
            {
                if (i < gvLegislacao.Rows.Count)
                {
                    Param = crypt.ActionEncrypt(index.ToString() + "#" + gvLegislacao.Rows[i].Cells[1].Text);
                    Response.RedirectToRoute("ModPublicacoesEdita", new { Param = Param });
                }
            }

            if (e.CommandName.Equals("Excluir"))
            {
                legis.WebPublicacaoId = Convert.ToInt32(e.CommandArgument); ;
                legis.Nome = String.Empty;

                if (obj.ValidaPublicacao(legis, 1) == 0)
                {
                    obj.AtualizaPublicacao(legis, 3);

                    string url = HttpContext.Current.Request.Url.AbsoluteUri;
                    FuncoesBLL objf = new FuncoesBLL();
                    objf.Atividades(url, "Excluiu Legislação", ControleAcesso.LerTicket().CadastroId);

                    CarregarGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Label lblMsgTit = Page.Master.FindControl("lblTitulo") as Label;
                    lblMsgTit.Visible = true;
                    lblMsgTit.Text = "Há Item(s) cadastrado(s) para esta Categoria";

                    Label lblMsgCont = Page.Master.FindControl("lblConteudo") as Label;
                    lblMsgCont.Visible = true;
                    lblMsgCont.Text = " ";

                }
            }

            if (e.CommandName.Equals("Itens"))
            {
                Param = crypt.ActionEncrypt(index.ToString() + "#" + gvLegislacao.Rows[i].Cells[1].Text);
                Response.RedirectToRoute("ModPublicacoesItem", new { Param = Param });
            }
        }
        catch (Exception ex)
        {
            Param = crypt.ActionEncrypt("3#" + ex.Message);
            Response.RedirectToRoute("PnlAlerta", new { Param = Param });
        }
    }


    protected void btnNovoGrid_Click(object sender, EventArgs e)
    {
        Param = crypt.ActionEncrypt("0" + "#" + "");
        Response.RedirectToRoute("ModPublicacoesEdita", new { Param = Param });
    }
}