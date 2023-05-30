<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="GrupoEdita.aspx.cs" Inherits="Painel_Administracao_GrupoEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Grupos
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de Grupos <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Grupos para Inclusão | Alteração.
                            </div>
                            <asp:Label ID="lblGrupoId" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblGrupo" runat="server" Visible="false"></asp:Label>
                            <div class="row">
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Grupo</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtGrupo" Display="Dynamic" ValidationGroup="txtGrupo" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                    OnClick="btnSalvar_Click" ValidationGroup="Feriado">Salvar</asp:LinkButton>
                                <asp:LinkButton ID="btnVoltar" runat="server" CssClass="btn btn-outline-primary waves-effect waves-themed"
                                    OnClick="btnVoltar_Click">Voltar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

