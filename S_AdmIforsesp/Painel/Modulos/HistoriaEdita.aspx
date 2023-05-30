<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="HistoriaEdita.aspx.cs" Inherits="Painel_Modulos_HostoriaEdita" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>História 
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>História<span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da História para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <h5>
                                    <asp:Label ID="lblHistoriaId" runat="server" Text="" Visible="false"></asp:Label></h5>
                                <asp:Label ID="lblBannerNome" runat="server" Text="" Visible="false"></asp:Label>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label class="form-label">Data Presidente</label>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtDataPresidente" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtDataPresidente" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label class="form-label">Mandato Presidente</label>
                    <%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMandatoPres"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator>--%>
                                        <br />
                                        <asp:TextBox ID="txtMandatoPres" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Foto Presidente</label>
                                       <%-- <asp:RequiredFieldValidator ID="rfvFoto" runat="server" ControlToValidate="FilePresidente"
                                            ErrorMessage="Selecionar Foto" ForeColor="Red" Display="Dynamic" ValidationGroup="Salvar"></asp:RequiredFieldValidator>--%><br />
                                        <asp:FileUpload ID="FilePresidente" runat="server" CssClass="form-control-file" />
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">

                                                    <strong>Arquivo: 
                                                            <asp:Label ID="lblpres" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lblpresp" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <%--<asp:TextBox ID="txtImg" runat="server" Enabled="false" Visible="false"
                                                                    Style="width: auto" CssClass="form-control"></asp:TextBox>--%>
                                                    </strong>
                                                    <%--<asp:TextBox ID="txtImgOriginal" runat="server" Visible="false"></asp:TextBox>--%>


                                                    <asp:LinkButton ID="lkbExcluir" runat="server" OnClick="lkbExcluir_Click">
                                                         <span aria-hidden="true">(<i class="fal fa-times"></i>)</span>
                                                    </asp:LinkButton>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Email Presidente</label>
                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmailPresidente"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator>--%><br />
                                        <asp:TextBox ID="txtEmailPresidente" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Registro Sindical</label>
                                       <%-- <asp:RequiredFieldValidator ID="rvfRegSind" runat="server" ControlToValidate="FileRegSindical"
                                            ErrorMessage="Selecionar Arquivo" ForeColor="Red" Display="Dynamic" ValidationGroup="Salvar"></asp:RequiredFieldValidator>--%><br />
                                        <asp:FileUpload ID="FileRegSindical" runat="server" CssClass="form-control-file" />
                                        <asp:Panel ID="Panel2" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">

                                                    <strong>Arquivo:
                                                        <asp:Label ID="lblrsind" runat="server"></asp:Label>
                                                        <asp:Label ID="lblrsindp" runat="server" Visible="false"></asp:Label>
                                                    </strong>
                                                    <asp:LinkButton ID="lkbRS" runat="server" OnClick="lkbRS_Click">
                                                         <span aria-hidden="true">(<i class="fal fa-times"></i>)</span>
                                                    </asp:LinkButton>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtQuemSomos"
                                            ErrorMessage="*Campo Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtQuemSomos" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label class="form-label">Estatuo</label>
                                        <%--<asp:RequiredFieldValidator ID="rfvEstatuto" runat="server" ControlToValidate="FileEstatuo"
                                            ErrorMessage="Selecionar Arquivo" ForeColor="Red" Display="Dynamic" ValidationGroup="Salvar"></asp:RequiredFieldValidator>--%><br />
                                        <asp:FileUpload ID="FileEstatuo" runat="server" CssClass="form-control-file" />
                                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">
                                                    <strong>PDF: 
                                                            <asp:Label ID="lblEst" runat="server"></asp:Label>
                                                        <asp:Label ID="lblEstp" runat="server" Visible="false"></asp:Label>
                                                    </strong>
                                                    <asp:LinkButton ID="lkbEstatuto" runat="server" OnClick="lkbEstatuto_Click">
                                                         <span aria-hidden="true">(<i class="fal fa-times"></i>)</span>
                                                    </asp:LinkButton>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Descrição</label>
                                        <CKEditor:CKEditorControl ID="txtDescQuemSomos" runat="server" Height="300px"></CKEditor:CKEditorControl>
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
                                        OnClick="btnSalvar_Click" ValidationGroup="Salvar">Salvar</asp:LinkButton>

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

