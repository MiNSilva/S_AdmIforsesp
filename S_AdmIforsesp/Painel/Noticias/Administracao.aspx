<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Administracao.aspx.cs" Inherits="Painel_Noticias_Administracao" %>

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
                <i class='subheader-icon fal fa-edit'></i>Administração
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Administração<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Para <code>Aprovar</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-thumbs-up"></i></asp:LinkButton>
                                &nbsp;, <code>Reprovar</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-warning btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-thumbs-down"></i></asp:LinkButton>
                                &nbsp;e <code>Excluir</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                            </div>
                            <div class="row">
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label text-muted">
                                            <asp:TextBox ID="txtPesquisa" runat="server" CssClass="form-control border-top-left-radius-0 border-bottom-left-radius-0 ml-0 width-lg shadow-inset-1" MaxLength="10"
                                                AutoPostBack="true" OnTextChanged="txtPesquisa_TextChanged" placeholder="Pesquisar"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        
                                        <asp:GridView ID="gvwTodasNoticias" runat="server" AutoGenerateColumns="False" HTMLENCODE="false"
                                            DataKeyNames="NoticiaID" EnableViewState="False" AllowPaging="True" PageSize="10"
                                            CssClass="table table-bordered table-hover table-striped w-100 dataTable dtr-inline"
                                            OnPageIndexChanging="gvwTodasNoticias_PageIndexChanging"
                                            OnRowCreated="gvwTodasNoticias_RowCreated"
                                            OnRowCommand="gvwTodasNoticias_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbVizu" runat="server" class="btn btn-outline-info  btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Visualizar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaID" ) %>'><i class="fal fa-file-image"></i></asp:LinkButton>
                                                        <%--<a href="<%# Page.GetRouteUrl("NotAdministracaoVizualizar", new { Param = Eval("NoticiaID")}) %>">Visualizar</a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                                <asp:BoundField DataField="Autor" HeaderText="Autor" />
                                                <asp:BoundField DataField="DataNoticia" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="Data" HeaderText="Atualizado" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="Status" />
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbAprovar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Aprovar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaID" ) %>'><i class="fal fa-thumbs-up"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbReprovar" runat="server" class="btn btn-outline-warning  btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Reprovar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaID" ) %>'><i class="fal fa-thumbs-down"></i></asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lkbExcluir" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "NoticiaID" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--<asp:BoundField HeaderText="Status" />
                                                <asp:ButtonField ButtonType="Image" CommandName="Aprovar" ImageUrl="~/img/aprove.gif" HeaderText="A">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Reprovar" ImageUrl="~/img/reprove.gif" HeaderText="R">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Excluir" ImageUrl="~/img/excluir.gif" HeaderText="E">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>--%>
                                            </Columns>

                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não existe Notícia(s)</span>
                                            </EmptyDataTemplate>

                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

