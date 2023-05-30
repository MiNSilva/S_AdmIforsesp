<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="SorteioEdita.aspx.cs" Inherits="Painel_Sorteio_SorteioEdita" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Sorteio
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Cadastro de Convênios <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Sorteio para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblIdSorteio" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Sorteio"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Data</label>
                                        <asp:RequiredFieldValidator ID="rfvInicio" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="txtData" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtData" ValidationGroup="Sorteio"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtData" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <label class="form-label">QTDE GANHADORES</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtqtdeganhadores"
                                        ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Sorteio"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtqtdeganhadores" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-1">
                                    <div class="form-group">
                                        <label class="form-label">Ativo</label>
                                        <asp:RequiredFieldValidator ID="rfvAtivo" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="ddlAtivo" Display="Dynamic" ValidationGroup="Sorteio" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>

                                        <asp:DropDownList ID="ddlAtivo" runat="server" AppendDataBoundItems="True" Width="100px"
                                            CssClass="form-control" AutoPostBack="True">
                                            <asp:ListItem Value="1">Sim</asp:ListItem>
                                            <asp:ListItem Value="0">Não</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-7">
                                    <div class="form-group">
                                        <label class="form-label">Informativo</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInformativo"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Sorteio"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtInformativo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Regras</label>
                                        <CKEditor:CKEditorControl ID="txtRegras" runat="server"></CKEditor:CKEditorControl>
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

