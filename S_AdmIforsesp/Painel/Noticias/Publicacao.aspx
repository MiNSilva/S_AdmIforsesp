<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Publicacao.aspx.cs" Inherits="Painel_Noticias_Publicacao" %>


<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Publicação
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <asp:Label ID="lblcontrole" runat="server" Text="Label" Visible="false"></asp:Label>
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Publicação<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="alert alert-danger" role="alert">
                                    <strong>
                                        <asp:Label ID="lblMsgErro" runat="server" Text="Label"></asp:Label></strong>
                                </div>
                            </asp:Panel>
                            <div class="row">
                                <asp:Label ID="lblNoticiaId" runat="server" Text="Label" Visible="false"></asp:Label>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Departamento </label>
                                        <asp:RequiredFieldValidator ID="rfvDepto" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="ddlDepto" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:DropDownList ID="ddlDepto" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDepto_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Categoria</label>
                                        <asp:RequiredFieldValidator ID="rfvCat" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="ddlCat" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator><br />
                                        <asp:DropDownList ID="ddlCat" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Data da Notícia</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtData" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtData" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtData" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Tipo da Notícia</label>
                                        <asp:RadioButtonList ID="rbldestaque" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                                            <asp:ListItem Value="0">&nbsp;Comum&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="1">&nbsp;Destaque</asp:ListItem>
                                            <asp:ListItem Value="2">&nbsp;Super Destaque</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Título</label>
                                        <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtTitulo" ValidationGroup="Autor" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" title="Text"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Resumo</label>
                                        <%-- <asp:RequiredFieldValidator ID="rfvResumo" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtResumo" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvResumo" runat="server"
                                            ControlToValidate="txtResumo" ErrorMessage="*O resumo deve ter no máximo 220 caracteres"
                                            OnServerValidate="cvSummary_ServerValidate" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"></asp:CustomValidator><br />--%>
                                        <asp:TextBox ID="txtResumo" runat="server" MaxLength="220" TextMode="MultiLine" CssClass="form-control"
                                            onkeypress="textCounter(this,this.form.counter,220);"></asp:TextBox><br />
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                                            <label class="form-label">Imagem Principal</label>
                                            <asp:RequiredFieldValidator ID="rvfImagem" runat="server" ControlToValidate="FileUpload1"
                                                ErrorMessage="Selecionar Imagem" ForeColor="Red" Display="Dynamic" ValidationGroup="Autor"></asp:RequiredFieldValidator><br />
                                            <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="true" />
                                            <asp:TextBox ID="txtImg" runat="server" Enabled="false" Style="width: auto" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtImgOriginal" runat="server" Visible="false"></asp:TextBox>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">
                                                    <asp:LinkButton ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" CssClass="close">
                                                            <i class="fal fa-times"></i></asp:LinkButton>
                                                    <strong>Arquivo: 
                                                            <asp:Label ID="lblarq" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lblarqori" runat="server" Text="Label" Visible="false"></asp:Label>
                                                    </strong>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Notícia </label>
                                        <asp:RequiredFieldValidator ID="rfvNoticia" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtNoticia" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <CKEditor:CKEditorControl ID="txtNoticia" runat="server"></CKEditor:CKEditorControl>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="btnSend" runat="server"
                                        CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnSend_Click" ValidationGroup="Autor">Salvar</asp:LinkButton>

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

