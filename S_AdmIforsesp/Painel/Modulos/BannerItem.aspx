<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="BannerItem.aspx.cs" Inherits="Painel_Modulos_BannerItem" %>

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
                <i class='subheader-icon fal fa-edit'></i>Banner Iten(s)
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2><asp:Label ID="lblBannerItem" runat="server"></asp:Label>
                            <span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>
                              <div class="panel-tag">
                                Para <code>Alteração</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-check"></i></asp:LinkButton>
                                , &nbsp;  <code>Exclusão</code>  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                                , <code>subir</code> &nbsp;
                                    <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-angle-up"></i></asp:LinkButton>
                                &nbsp; e <code>descer</code> &nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-angle-down"></i></asp:LinkButton>
                            </div>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblIdBannerItem" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblBannerId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblLargura" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblAltura" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblBanner" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblNomeBanner" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblArquivo" runat="server" Visible="false"></asp:Label>

                                        <asp:GridView ID="gvBannerItem" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered table-hover"
                                            DataKeyNames="WebBannerItemID" OnRowCommand="gvBannerItem_RowCommand"
                                            AllowPaging="True" PageSize="10"
                                            OnPageIndexChanging="gvBannerItem_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="WebBannerItemID" HeaderText="WebBannerItemID">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                               <%-- <asp:TemplateField HeaderText="Qtde">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField HtmlEncode="false" DataField="Nome" HeaderText="Nome" />
                                                <asp:BoundField HtmlEncode="false" DataField="Titulo" HeaderText="Titulo" />
                                                <asp:BoundField HtmlEncode="false" DataField="Inicio" HeaderText="Início" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HtmlEncode="false" DataField="Final" HeaderText="Final" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HtmlEncode="false" DataField="ativo" HeaderText="Ativo" />
                                                <asp:BoundField HtmlEncode="false" DataField="Ordem" HeaderText="Ordem" />
                                                 <asp:TemplateField HeaderText="Ordenação">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSubirr" runat="server" CommandName="Subir"
                                                            class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerItemID")%>'>
                                                        <i class="fal fa-angle-up"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDescer" runat="server" CommandName="Descer"
                                                            class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerItemID")%>'>
                                                         <i class="fal fa-angle-down"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Editar" Text="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerItemID")%>'><i class="fal fa-check"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebBannerItemID" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não há Item(s) para o Banner(s) Selecionado</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                        <%-- <div class="form-actions">
                                                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnCommand="btnNovo_Click"
                                                    CssClass="btn btn-success" />
                                            </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="btnNovo" runat="server"
                                        CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnNovo_Click" ValidationGroup="BannerItem">Novo</asp:LinkButton>

                                    <asp:LinkButton ID="btnVoltar" runat="server"
                                        CssClass="btn btn-outline-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnVoltar_Click">Voltar</asp:LinkButton>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

