<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="FotosUpload.aspx.cs" Inherits="Painel_Galeria_FotosUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Galeria de Fotos
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Upload de Imagens <span class="fw-300"><i>Inserção</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <%--<div class="panel-tag">
                                Informar a descrição da galeria para Inclusão | Alteração.
                            </div>--%>
                            <div class="row">
                               
                                <div class="col-lg-8">
                                    <label class="form-label" for="example-email-2">Título:</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Informar Titulo"
                                        ForeColor="Red" Display="Dynamic" ControlToValidate="txtTitulo" ValidationGroup="up"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col-lg-2">
                                    <label>Data: </label>
                                    <asp:RequiredFieldValidator ID="rvData" runat="server" ErrorMessage="Informar Data"
                                        ForeColor="Red" Display="Dynamic" ControlToValidate="txtData" ValidationGroup="up"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtData" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                </div>
                                <div class="col-lg-4">
                                    <label>Tipo Galeria: </label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Campo Obrigatório"
                                        ControlToValidate="ddlTipoGaleria" Display="Dynamic" ValidationGroup="Autor" ForeColor="Red"
                                        InitialValue="Selecione"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:DropDownList ID="ddlTipoGaleria" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                        AutoPostBack="True">
                                        <asp:ListItem Selected="True">Selecione</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-4">
                                </div>
                             <div class="col-lg-4">
                                    <asp:Label ID="lblImgPrincipal" runat="server" Text="Label">Imagem Principal:</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload1"
                                        ErrorMessage="Selecionar Imagem Principal" ForeColor="Red" Display="Dynamic" ValidationGroup="up"></asp:RequiredFieldValidator>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input-group-text" />
                                </div>
                                <div class="col-lg-6">
                                    <label>Imagens:</label>
                                    <asp:FileUpload runat="server" ID="UploadImages" AllowMultiple="true"  CssClass="input-group-text" />
                                    <asp:Label ID="listofuploadedfiles" runat="server"  />
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

