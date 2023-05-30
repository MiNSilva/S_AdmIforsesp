<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="YoutubeEdita.aspx.cs" Inherits="Painel_Modulos_YoutubeEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Vídeos
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de Vídeos <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da parceiros para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblIdYoutube" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Titulo</label>
                                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Util"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtTitulo" runat="server" Width="300px" CssClass=" form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Descricao</label>
                                        <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Util">
                                        </asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtDescricao" runat="server" Width="300px" CssClass=" form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Ativo</label>
                                        <asp:DropDownList ID="ddlAtivo" runat="server" Width="80px" CssClass=" form-control">
                                            <asp:ListItem Value="0">Não</asp:ListItem>
                                            <asp:ListItem Value="1">Sim</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Link</label>
                                        <asp:RequiredFieldValidator ID="rfvLink" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtLink" Display="Dynamic" ValidationGroup="Util" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtLink" runat="server" Width="500px" CssClass=" form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="LinkButton1" runat="server"
                                        CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnSalvar_Click" ValidationGroup="Parceiros">Salvar</asp:LinkButton>

                                    <asp:LinkButton ID="LinkButton2" runat="server"
                                        CssClass="btn btn-outline-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="Voltar">Voltar</asp:LinkButton>
                                </label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

