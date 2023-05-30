<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Permissoes.aspx.cs" Inherits="Painel_Administracao_Permissoes" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $('#btnSalvar').click(function () {
            if (FileUpload2.value.length == 0) {    // CHECK IF FILE(S) SELECTED.
                alert('No files selected.');
                return false;
            }
        });
    </script>
    <%-- Oculta 1º Coluna do Grid --%>
    <style>
        .rowNone {
            width: 0px;
            min-width: 0px;
            display: none;
        }
    </style>
    
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Permissões
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <asp:Label ID="lblIdUsuario" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblNomeUsuario" runat="server" Visible="false"></asp:Label>
                    <div class="col-xl-6">

                        <div id="panel-1" class="panel">
                            <div class="panel-hdr">
                                <h2>Dados de acesso do<span class="fw-300"><i>Usuário</i></span></h2>
                            </div>
                            <div class="panel-container show">
                                <div class="panel-content">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtNome" Display="Dynamic" ValidationGroup="Usuario" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">E-mail </label>
                                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtLogin" Display="Dynamic" ValidationGroup="Usuario" ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="valExMail" runat="server" ControlToValidate="txtLogin"
                                            ErrorMessage="E-mail Inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ForeColor="Red" Display="Dynamic" ValidationGroup="Usuario"></asp:RegularExpressionValidator><br />
                                        <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                  
                                    <div class="form-group">
                                        <label class="form-label">Grupo </label>
                                        <asp:RequiredFieldValidator ID="rfvGrupo" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="ddlGrupo" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlGrupo" runat="server" AppendDataBoundItems="True"
                                            CssClass="form-control" Width="200px"
                                            AutoPostBack="True">
                                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label">Senha</label>
                                        <%--<asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtSenha" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><br />--%>
                                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control" Width="200px"
                                            placeholder="**********" MaxLength="8"></asp:TextBox>

                                    </div>

                                    <div class="form-group">
                                        <label class="form-label">Ativo</label>
                                        <asp:RequiredFieldValidator ID="rfvAtivo" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="ddlAtivo" Display="Dynamic" ValidationGroup="Usuario" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="ddlAtivo" runat="server" AppendDataBoundItems="True"
                                            CssClass="form-control" Width="200px" AutoPostBack="True">
                                            <asp:ListItem Value="1" Selected="True">SIM</asp:ListItem>
                                            <asp:ListItem Value="0">NÃO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <label class="col-sm-12 col-md-12">
                                            <asp:LinkButton ID="btnSalvar" runat="server" 
                                                CssClass="btn btn-primary waves-effect waves-themed float-right"
                                                data-target="#myModal"
                                                OnClick="btnSalvar_Click" ValidationGroup="Usuario">Salvar</asp:LinkButton>
                                        </label>
                                        
                                    </div>
                                     <hr />
                                    <div class="form-group">
                                        <label class="col-sm-12 col-md-12">
                                     <asp:Label ID="lblErro" runat="server" Text="Label" Visible="false" CssClass="panel-tag"></asp:Label>
                                            </label>
                                        </div>
                                </div>

                               

                            </div>
                        </div>

                    </div>
                    <div class="col-xl-6">

                        <div id="panel-1" class="panel">
                            <div class="panel-hdr">
                                <h2>Permissões dos<span class="fw-300"><i>Usuários</i></span></h2>
                            </div>
                            <div class="panel-container show">
                                <div class="panel-content">
                                    <%--<div class="panel-tag">
                                Para alteração informar a uma nova senha e confirma-la novamente.
                            </div>--%>
                                    <div>
                                        <asp:GridView ID="gvSubMenu" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="id_menu" AllowPaging="True" PageSize="999"
                                            CssClass="table m-0 table-bordered table-hover table-sm table-striped"
                                            OnDataBound="gvSubMenu_DataBound">
                                            <Columns>
                                                <asp:BoundField HtmlEncode="false" DataField="Hierarquia_menu" HeaderText="MENU" />
                                                <asp:BoundField HtmlEncode="false" DataField="Descr_menu" HeaderText="SUBMENU" />
                                                <asp:BoundField DataField="id_menu" HeaderText="id_menu">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="">
                                                    <%-- <HeaderTemplate>
                                                <asp:CheckBox ID="chkview" runat="server" AutoPostBack="true" OnCheckedChanged="chkview_CheckedChanged" />
                                            </HeaderTemplate>--%>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckPerm" runat="server" Checked='<%# bool.Parse(Eval("Permitido").ToString()) %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não existe item(s) para o Menu</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                        <br />
                                        <hr />
                                        <div class="form-group">
                                            <label class="col-sm-12 col-md-12">
                                                <asp:LinkButton ID="btnAtualizarPer" runat="server"
                                                    CssClass="btn btn-primary waves-effect waves-themed float-right"
                                                    OnClick="btnAtualizarPer_Click">Atualizar</asp:LinkButton>
                                            </label>
                                        </div>
                                        <%--<div class="accordion" id="accordionExample">
                                    <asp:Repeater ID="dlMenu" runat="server" OnItemDataBound="dlMenu_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="card">
                                                <div class="card-header" id="'<%# Eval("ID_MENU") %>'">
                                                    <a href="javascript:void(0);" class="card-title" data-toggle="collapse"
                                                        data-target='#<%# Eval("ID_MENU") %>' aria-expanded="true"
                                                        aria-controls="collapseOne"><%# Eval("DESCR_MENU") %>

                                                        <span class="ml-auto">
                                                            <span class="collapsed-reveal">
                                                                <i class="fal fa-minus-circle text-danger"></i>
                                                            </span>
                                                            <span class="collapsed-hidden">
                                                                <i class="fal fa-plus-circle text-success"></i>
                                                            </span>
                                                        </span>
                                                    </a>
                                                </div>
                                                <asp:Repeater ID="dlSubMenu" runat="server">
                                                    <ItemTemplate>
                                                        <div id="<%# Eval("ID_MENU") %>" class="collapse show" aria-labelledby="<%# Eval("ID_MENU") %>"
                                                            data-parent="#accordionExample" style="">
                                                            <div class="card-body">
                                                                <asp:CheckBox ID="CheckPerm" runat="server" Checked='<%# bool.Parse(Eval("Permitido").ToString()) %>' />&nbsp;&nbsp;<%# Eval("DESCR_MENU") %>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-xl-12">
                        <div class="form-group">
                            <%--  <label>
                        <asp:LinkButton ID="btnIncluir" runat="server" CssClass="btn btn-primary waves-effect waves-themed float-right"
                            OnClick="btnIncluir_Click" ValidationGroup="Usuario">Inserir</asp:LinkButton>
                    </label>
                    <label>
                        <asp:LinkButton ID="btnSalvarTudo" runat="server" CssClass="btn btn-primary waves-effect waves-themed float-right"
                            OnClick="btnSalvarTudo_Click">Salvar</asp:LinkButton>
                    </label>--%>
                            <label>
                                <asp:LinkButton ID="btnVoltar" runat="server" CssClass="btn btn-outline-primary waves-effect waves-themed float-right"
                                    OnClick="btnVoltar_Click">Voltar</asp:LinkButton>
                            </label>
                        </div>
                    </div>


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAtualizarPer" />
                <asp:PostBackTrigger ControlID="btnVoltar" />
            </Triggers>
        </asp:UpdatePanel>
    </main>

</asp:Content>

