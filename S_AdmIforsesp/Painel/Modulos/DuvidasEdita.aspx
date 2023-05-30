<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="DuvidasEdita.aspx.cs" Inherits="Painel_Modulos_DuvidasEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Dùvidas
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de Dùvidas <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Dùvidas para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblDuvidaId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblPergunta" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblResposta" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Pergunta</label>
                                        <asp:RequiredFieldValidator ID="rfvPergunta" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtPergunta" Display="Dynamic" ValidationGroup="Duvida" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtPergunta" runat="server" CssClass=" form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Resposta</label>
                                        <asp:RequiredFieldValidator ID="rfvResposta" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtResposta" Display="Dynamic" ValidationGroup="Duvida" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtResposta" runat="server" CssClass=" form-control" TextMode="MultiLine"></asp:TextBox>
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
                                        OnClick="btnSalvar_Click" ValidationGroup="Duvida">Salvar</asp:LinkButton>

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

