<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="EsqueceuSenha.aspx.cs" Inherits="EsqueceuSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card p-4 border-top-left-radius-0 border-top-right-radius-0">
        <div>
            <div class="form-group">
                <label class="form-label" for="username">
                    E-mail
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                        ForeColor="Red" ValidationGroup="LoginEmailRec">*</asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail" type="email"></asp:TextBox>
                <asp:RegularExpressionValidator ID="LoginAdm" runat="server"
                    ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="LoginEmailRec">*E-mail Inválido</asp:RegularExpressionValidator><br />
            </div>
            <asp:LinkButton ID="lkbNovaConta" runat="server" OnClick="btnEsqSenha_Click" ValidationGroup="LoginEmailRec"
                CssClass="btn btn-default float-right">Recuperar Senha</asp:LinkButton>
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-danger" role="alert">
                    <strong>
                        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label></strong>
                </div>
            </asp:Panel>
        </div>
    </div>
    <div class="blankpage-footer text-center">
        <a href="<%: Page.GetRouteUrl("Inicio", new object{}) %>"><strong>Voltar</strong></a>
    </div>


</asp:Content>

