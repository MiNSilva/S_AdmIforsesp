<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="DiretoriaEditar.aspx.cs" Inherits="Painel_Administracao_DiretoriaEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Diretoria 
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de Diretoria <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Diretoria para Inclusão | Alteração.
                            </div>
                            <asp:Label ID="lblEquipeId" runat="server" Visible="false"></asp:Label>

                            <div class="row">
                                <div class="col-lg-7">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-5">
                                    <div class="form-group">
                                        <label class="form-label">Cargo</label>
                                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Departamento</label>
                                        <asp:DropDownList ID="ddlCargo" runat="server" AppendDataBoundItems="True"
                                            AutoPostBack="True"    CssClass="form-control">
                                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%--<div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close" onclick="imgbtn_Click">
                                                        <span aria-hidden="true"><i class="fal fa-times"></i></span>
                                                    </button>
                                                    <strong>Arquivo: 
                                                            <asp:Label ID="lblarq" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lblarqori" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtImg" runat="server" Enabled="false" Visible="false"
                                                                    Style="width: auto" CssClass="form-control"></asp:TextBox>
                                                    </strong>
                                                    <asp:TextBox ID="txtImgOriginal" runat="server" Visible="false"></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>--%>
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

