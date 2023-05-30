<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Comunicado.aspx.cs" Inherits="Painel_Modulos_Comunicado" %>

<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Comunicado
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Comunicado<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <%--    <div class="panel-tag">
                               
                            </div>--%>
                            <div class="row">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Início </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Selecionar Data Início"
                                            ControlToValidate="txtInicio" Display="Dynamic" ValidationGroup="Msg" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtInicio" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtInicio" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Final </label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Selecionar Data Final"
                                            ControlToValidate="txtFinal" Display="Dynamic" ValidationGroup="Msg" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtFinal" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtFinal" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label"></label>
                                        <br />
                                        <br />
                                        <asp:CheckBox ID="cbExibeMsg" runat="server" Text="Exibir Mensagem" />
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
                                        <label class="form-label"></label>
                                        <asp:RequiredFieldValidator ID="rfvNoticia" runat="server" ErrorMessage="Informar Mensagem"
                                            ControlToValidate="txtComunicado" Display="Dynamic" ValidationGroup="Msg" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <CKEditor:CKEditorControl ID="txtComunicado" runat="server"></CKEditor:CKEditorControl>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <asp:LinkButton ID="btnSalvar" runat="server"
                                    CssClass="btn btn-primary waves-effect waves-themed"
                                    data-target="#myModal" OnClick="btnSave_Click" ValidationGroup="Msg">Salvar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

