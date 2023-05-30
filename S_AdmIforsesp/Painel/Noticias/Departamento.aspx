<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Departamento.aspx.cs" Inherits="Painel_Noticias_Departamento" %>

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
                <i class='subheader-icon fal fa-edit'></i>Departamento
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Configuração<span class="fw-300"><i>Departamento / Categoria</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Para <code>Alteração</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-check"></i></asp:LinkButton>
                                &nbsp;, <code>Exclusão</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                                &nbsp; e <code>Categorias</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton5" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-list-alt"></i></asp:LinkButton>
                            </div>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:GridView ID="gvDepartamentos" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-bordered table-hover table-striped w-100 dataTable dtr-inline"
                                            DataKeyNames="NoticiaDepartamentoID" OnRowCommand="gvDepartamentos_RowCommand">
                                            <Columns>
                                                <asp:BoundField DataField="NoticiaDepartamentoID" HeaderText="NoticiaDepartamentoID">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HtmlEncode="false" DataField="Departamento" HeaderText="Departamento" />
                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaDepartamentoID" ) %>'><i class="fal fa-check"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaDepartamentoID" ) %>'><i class="fal fa-times"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkCategorias" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Categorias" Text="Categorias"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaDepartamentoID")%>'><i class="fal fa-list-alt"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não há Departamento(s) Cadastrado(s)</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnNovoGrid" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnNovoGrid_Click">Novo</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

