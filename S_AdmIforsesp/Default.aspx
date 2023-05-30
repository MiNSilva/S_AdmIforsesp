<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card p-4 border-top-left-radius-0 border-top-right-radius-0">
        <div>
            <div class="form-group">

                <asp:RegularExpressionValidator ID="LoginAdm" runat="server"
                    ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="LoginEmailRec">*E-mail Inválido</asp:RegularExpressionValidator><br />
                <label class="form-label" for="username">
                    E-mail
                    <asp:RequiredFieldValidator ID="reqLoginEmailRec" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                        ForeColor="Red" ValidationGroup="LoginAdm">*</asp:RequiredFieldValidator><br />
                </label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail" type="email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="form-label" for="password">
                    Senha
                        <asp:RequiredFieldValidator ID="rvSenhaAdm" runat="server" ControlToValidate="txtSenha"
                            Display="Dynamic" ForeColor="Red" ValidationGroup="LoginAdm">*</asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" placeholder="Senha" TextMode="Password" MaxLength="8  "></asp:TextBox>
                <asp:RegularExpressionValidator ID="reSenhaAdm" runat="server" ControlToValidate="txtSenha"
                    Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,8}$"
                    ValidationGroup="LoginAdm">*Mínimo 4 e Máximo 8 digitos</asp:RegularExpressionValidator>
            </div>
            <asp:LinkButton ID="lkbNovaConta" runat="server" OnClick="btnLogin_Click"
                CssClass="btn btn-default float-right" ValidationGroup="LoginAdm">Logar</asp:LinkButton>
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
        <a href="<%: Page.GetRouteUrl("EsqueceuSenha", new object{}) %>#"><strong>Esqueceu Senha</strong></a>
    </div>
</asp:Content>

