<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="LegislacaoEdita.aspx.cs" Inherits="Painel_Modulos_LegislacaoEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Legislação 
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Legislação<span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Legislação para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <h5>
                                 <asp:Label ID="lblLegislacaoId" runat="server" Text="" Visible="false"></asp:Label></h5>
                                <asp:Label ID="lblLegislacaoNome" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtNome" Display="Dynamic" ValidationGroup="Banner" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" title="Text"></asp:TextBox>
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

