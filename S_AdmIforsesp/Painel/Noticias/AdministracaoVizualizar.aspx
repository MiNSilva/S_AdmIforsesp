<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="AdministracaoVizualizar.aspx.cs" Inherits="Painel_Noticias_AdministracaoVizualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        <h2>Administração<span class="fw-300"><i>Visualizar notícia</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblNoticiaId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lblTitulo" runat="server" Text="" Visible="false"></asp:Label>
                            <div class="row">
                                <asp:DataList ID="dlNoticiaById" runat="server" RepeatColumns="1"
                                    ProRepeatDirection="Horizontal" EnableViewState="False">
                                    <ItemTemplate>
                                        <div class="form-group">
                                            <div class="col-sm-12 col-md-12">

                                                <div class="card mb-g">
                                                    <div class="card-body pb-0 px-4">
                                                        <div class="d-flex flex-row pb-3 pt-2  border-top-0 border-left-0 border-right-0">
                                                           <%-- <div class="d-inline-block align-middle status status-success mr-3">
                                                                <span class="profile-image rounded-circle d-block" style="background-image: url('img/demo/avatars/avatar-admin.png'); background-size: cover;"></span>
                                                            </div>--%>
                                                            <h5 class="mb-0 flex-1 text-dark fw-500"><%# Eval("Categoria") %>
                                                                <small class="m-0 l-h-n">
                                                                    <%# Eval("DataNoticia", "{0:dd/MM/yyyy}").ToUpper() %>
                                                                </small>
                                                            </h5>
                                                            <span class="text-muted fs-xs opacity-70">
                                                                <a href="javascript:void(0);" class="d-inline-flex align-items-center text-dark">
                                                                <i class="fal fa-laptop fs-xs mr-1"></i><span><%# Eval("Contador") %></span>
                                                            </a>
                                                            </span>
                                                        </div>
                                                        <div class="pb-3 pt-2 border-top-0 border-left-0 border-right-0 text-muted">
                                                            <p></p>
                                                            <!-- URL post -->
                                                            <div class="d-flex overflow-hidden rounded w-100 border">
                                                                <div class="row no-gutters">
                                                                   <%-- <div class="col-2 col-sm-3" style="background-image: url('img/demo/profile/article-healthyfood.png'); background-size: cover;"></div>--%>
                                                                    <div class="col">
                                                                        <div class="bg-faded flex-1 p-4 h-100">
                                                                            <h2 class="text-dark fw-500"><%# Eval("Titulo") %></h2>
                                                                            <h5><i><%# Eval("Resumo") %></i></h5>
                                                                            <p class="m-0">
                                                                                <%# Eval("Noticia") %>
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>

                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="btnEditar" runat="server"
                                        CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnEditar_Click" ValidationGroup="Parceiros">Editar</asp:LinkButton>

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

