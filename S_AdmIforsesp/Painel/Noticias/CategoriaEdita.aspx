<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="CategoriaEdita.aspx.cs" Inherits="Painel_Noticias_CategoriaEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Categoria
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Categoria<span class="fw-300"><i>Inserção e Alteração</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblCatID" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblDeptoId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblDepto" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblCat" runat="server" Visible="false"></asp:Label>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-label">Categoria </label>
                                    <asp:RequiredFieldValidator ID="rvfCategoria" runat="server" ErrorMessage="Informar a Categoria"
                                        ControlToValidate="txtCat" ValidationGroup="Cat" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtCat" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="btnSalvar" runat="server"
                                        CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnSalvar_Click" ValidationGroup="Parceiros">Salvar</asp:LinkButton>

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

