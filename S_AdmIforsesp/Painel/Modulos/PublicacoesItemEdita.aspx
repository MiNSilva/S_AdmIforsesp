<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="PublicacoesItemEdita.aspx.cs" Inherits="Painel_Modulos_PublicacoesItemEdita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Publicações Item
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2><asp:Label ID="lblLegislacaoItem" runat="server"></asp:Label><span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <asp:Label ID="lblLegislacaoItemId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblLegislacaoId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblIdLegislacaoItem" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>

                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar o nome da Publicação e carregar o arquivo para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNomeItem" runat="server" ControlToValidate="txtNomeItem"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Item"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNomeItem" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Arquivo</label>
                                        <asp:RegularExpressionValidator ID="rev" runat="server" ControlToValidate="FileUpload1" ForeColor="Red" Display="Dynamic" ValidationGroup="Item"
                                            ErrorMessage="Somente Arquivos do Tipo .PDF" ValidationExpression="^([a-zA-Z].*|[1-9].*)\.(((p|P)(d|D)(f|F)))$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="rvfArquivo" runat="server" ControlToValidate="FileUpload1"
                                            ErrorMessage="Selecionar Arquivo" ForeColor="Red" Display="Dynamic" ValidationGroup="Item"></asp:RequiredFieldValidator><br />
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:TextBox ID="txtImg" runat="server" Enabled="false" Style="width: auto" Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="~/images/reprove.gif" Style="height: 16px" 
                                            OnClick="imgbtn_Click" Visible="false" />
                                        <asp:TextBox ID="txtImgOriginal" runat="server" Visible="false"></asp:TextBox>
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

