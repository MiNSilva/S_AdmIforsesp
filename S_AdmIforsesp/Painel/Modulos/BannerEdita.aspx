<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="BannerEdita.aspx.cs" Inherits="Painel_Modulos_BannerEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Banner 
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Banner<span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da banner para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <h5>
                                    <asp:Label ID="lblBannerId" runat="server" Text="" Visible="false"></asp:Label></h5>
                                <asp:Label ID="lblBannerNome" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Banner"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Largura</label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLargura"
                                            ErrorMessage="*Somente Números." ValidationExpression="[0-9]*" ValidationGroup="Banner"
                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtLargura" Display="Dynamic" ValidationGroup="Banner" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtLargura" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Altura</label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAltura"
                                            ErrorMessage="*Somente Números." ValidationExpression="[0-9]*" ValidationGroup="Banner"
                                            ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtAltura" Display="Dynamic" ValidationGroup="Banner" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:TextBox ID="txtAltura" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
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

