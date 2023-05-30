<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="LegislacaoItem.aspx.cs" Inherits="Painel_Modulos_LegislacaoItem" %>

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
                <i class='subheader-icon fal fa-edit'></i>Legislação Iten(s)
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>
                            <asp:Label ID="lblLegislacaoItem" runat="server"></asp:Label>
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
                            <div class="row">
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label text-muted">
                                            <asp:TextBox ID="txtPesquisa" runat="server" CssClass="form-control border-top-left-radius-0 border-bottom-left-radius-0 ml-0 width-lg shadow-inset-1" MaxLength="10"
                                                AutoPostBack="true" OnTextChanged="btnBusca_Click" placeholder="Pesquisar"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblLegislacaoId" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIdLegislacaoItemId" runat="server" Visible="false"></asp:Label>

                                        <asp:GridView ID="gvLegislacaoItem" runat="server" AutoGenerateColumns="False"
                                             CssClass="table table-striped table-bordered table-hover"
                                            DataKeyNames="WebLegislacaoItemID" OnRowCommand="gvLegislacaoItem_RowCommand" AllowPaging="True"
                                            PageSize="10" OnPageIndexChanging="gvLegislacaoItem_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="WebLegislacaoItemID" HeaderText="WebLegislacaoItemID">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Qtde">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HtmlEncode="false" DataField="Nome" HeaderText="Nome" />
                                                <asp:TemplateField HeaderText="Arquivo">
                                                    <ItemTemplate>
                                                        <a href="<%# DataBinder.Eval(Container.DataItem, "arquivo","../../../Download/Legislacao/{0}")%>" target="_blank">
                                                            <img src="../../../images/PDFICON.jpg" alt="" /><%# DataBinder.Eval(Container.DataItem, "arquivo")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HtmlEncode="false" DataField="Ordem" HeaderText="Ordem" />
                                                <asp:TemplateField HeaderText="Ordenação">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSubirr" runat="server" CommandName="Subir"
                                                            class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebLegislacaoItemID")%>'>
                                                        <i class="fal fa-angle-up"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDescer" runat="server" CommandName="Descer"
                                                            class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebLegislacaoItemID")%>'>
                                                         <i class="fal fa-angle-down"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Editar" Text="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebLegislacaoItemID")%>'><i class="fal fa-check"></i>
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WebLegislacaoItemID" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não há Item(s) para a Legislação Selecionada</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>

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

