﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="PremioEdita.aspx.cs" Inherits="Painel_Sorteio_PremioEdita" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Premiação
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de prêmio <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da prêmio para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblIdSorteioPremio" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblIdSorteio" runat="server" Text="Label" Visible="false"></asp:Label>
                                <asp:Label ID="lblOrdem" runat="server" Text="Label" Visible="false"></asp:Label>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Sorteio </label>
                                        <asp:RequiredFieldValidator ID="rfvSorteio" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="ddlSorteio" Display="Dynamic" ValidationGroup="Sorteio" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="ddlSorteio" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Item</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtItem"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Sorteio"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtItem" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                  <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Descrição</label>
                                        <CKEditor:CKEditorControl ID="txtDescricao" runat="server"></CKEditor:CKEditorControl>
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

