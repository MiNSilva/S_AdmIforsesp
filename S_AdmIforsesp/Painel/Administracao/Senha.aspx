<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Senha.aspx.cs" Inherits="Administrador_Senha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Alteração de Senha
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Alteração de <span class="fw-300"><i>Senha</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Para alteração informar a uma nova senha e confirma-la novamente.
                            </div>
                            <div>
                                <div class="form-group">
                                    <label class="form-label" for="example-email-2">Nova Senha</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtNovaSenha" Display="Dynamic"
                                        ErrorMessage="Informar Nova Senha" ForeColor="Red" ValidationGroup="Senha"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNovaSenha"
                                        Display="Dynamic" ErrorMessage="Mínimo 4 e Máximo 8 digitos" ForeColor="Red"
                                        ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,8}$" ValidationGroup="Senha"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="form-label" for="example-password">Confirma Senha</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmaSenhaAlteracao"
                                        Display="Dynamic" ErrorMessage="Confirmar Senha" ForeColor="Red" ValidationGroup="Senha"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="valCompare" runat="server" ControlToCompare="txtNovaSenha"
                                        ControlToValidate="txtConfirmaSenhaAlteracao" Display="Dynamic" ErrorMessage="Senhas não conferem" ForeColor="Red"
                                        ValidationGroup="Senha"></asp:CompareValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtConfirmaSenhaAlteracao"
                                        Display="Dynamic" ErrorMessage="Mínimo 4 e Máximo 8 digitos" ForeColor="Red"
                                        ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,8}$" ValidationGroup="Senha"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtConfirmaSenhaAlteracao" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <asp:LinkButton ID="btnAlterar" runat="server" CssClass="btn btn-primary waves-effect waves-themed" OnClick="btnAlterar_Click" ValidationGroup="Senha">Salvar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

