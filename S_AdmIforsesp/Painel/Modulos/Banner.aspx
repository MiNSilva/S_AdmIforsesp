﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Banner.aspx.cs" Inherits="Painel_Modulos_Banner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- Oculta 1º Coluna do Grid --%>
    <style>
        .rowNone {
            width: 0px;
            min-width: 0px;
            display: none;
        }
    </style>
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Banner
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Banner<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>
                            <div class="panel-tag">
                                Para <code>Alteração</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-check"></i></asp:LinkButton>
                                &nbsp;, <code>Exclusão</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                                &nbsp; e <code>Itens</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-list-alt"></i></asp:LinkButton>
                            </div>

                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblIdBannerItem" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblBannerId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblLargura" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblAltura" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblBanner" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIdBanner" runat="server" Visible="false"></asp:Label>

                                        <asp:GridView ID="gvBanner" runat="server" AutoGenerateColumns="false" 
                                            CssClass="table table-striped table-bordered table-hover"
                                            DataKeyNames="WebBannerID" OnRowCommand="gvBanner_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="WebBannerID" HeaderText="WebBannerID">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HtmlEncode="false" DataField="Nome" HeaderText="Pagina" />
                                                <asp:BoundField HtmlEncode="false" DataField="Largura" HeaderText="Largura" />
                                                <asp:BoundField HtmlEncode="false" DataField="Altura" HeaderText="Altura" />
                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>

                                                        <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Editar" Text="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerID")%>'><i class="fal fa-check"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerID" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                               
                                                        <asp:LinkButton ID="lnkItens" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Banner" Text="Banner"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerID")%>'><i class="fal fa-list-alt"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não há Banner(s) Cadastrado(s)</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnNovoGrid" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnNovo_Click">Novo</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

