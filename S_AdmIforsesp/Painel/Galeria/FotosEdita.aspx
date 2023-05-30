<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="FotosEdita.aspx.cs" Inherits="Painel_Galeria_FotosEdita" %>

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
                        <h2>Edição de Imagens <span class="fw-300"><i>Alteração.</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <%--<div class="panel-tag">
                                Informar a descrição da galeria para Alteração.
                            </div>--%>
                            <div class="row">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblurl" runat="server" Visible="false"></asp:Label>
                                <div class="col-lg-8">
                                    <div class="form-group">
                                        <%--<label class="form-label">Titulo</label>--%>
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass=" form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    
                                    <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                        OnClick="btnSalvar_Click" ValidationGroup="Senha">Alterar Título</asp:LinkButton>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <hr />
                                    </div>
                                </div>


                                <div class="col-lg-12">
                                    <label class="form-label">Upload das imagens</label>
                                    <asp:FileUpload ID="fileUpload" multiple="true" runat="server" CssClass="input-group-text" />
                                    <p>
                                        <asp:Label ID="lblFileList" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblUploadStatus" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblFailedStatus" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="col-lg-2">
                                    <label class="form-label"></label>
                                    <asp:LinkButton ID="btUpload" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                        OnClick="uploadedFile_Click" ValidationGroup="Senha">Upload Imagens</asp:LinkButton>

                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <hr />
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <asp:GridView ID="grdPreVisualizacao" runat="server" AutoGenerateColumns="false"
                                        OnRowCommand="grdPreVisualizacao_RowCommand" CssClass="table table-bordered table-striped with-check">
                                        <Columns>
                                            <asp:BoundField DataField="NomeArquivo" HeaderText="Nome_arquivo" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="Tamanho" HeaderText="Tamanho">
                                                <ControlStyle Width="0px" CssClass="rowNone" />
                                                <FooterStyle Width="0px" CssClass="rowNone" />
                                                <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                            </asp:BoundField>
                                            <%--                                                 <asp:BoundField DataField="Tamanho" HeaderText="Tamanho (bytes)" DataFormatString="{0:#,##0}"
                                                    ItemStyle-HorizontalAlign="Center" />--%>
                                            <%--  <asp:BoundField DataField="DataCriacao" HeaderText="Dt. Criação" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}"
                                                    ItemStyle-HorizontalAlign="Center" />--%>
                                            <asp:TemplateField HeaderText="Visualização">
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:Image ID="imagesArquivo" runat="server" Height="150px" Width="150px" ImageUrl='<%# Eval("URL") %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Excluir" ImageUrl="~/images/excluir.gif" HeaderText="Excluir">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </div>


                                <div class="col-lg-6">
                                    <asp:GridView ID="grdPreVisu" runat="server" AutoGenerateColumns="false"
                                        OnRowCommand="grdPreVisu_RowCommand" CssClass="table table-bordered table-striped with-check">
                                        <Columns>
                                            <asp:BoundField DataField="NomeArquivo" HeaderText="Arquivo" HeaderStyle-HorizontalAlign="Left" />
                                            <asp:TemplateField HeaderText="Visualização">
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:Image ID="imagesArquivo" runat="server" Height="150px" Width="150px" ImageUrl='<%# Eval("URL") %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>



                                <div class="col-lg-1">
                                    <asp:LinkButton ID="btnCancelarUpload" runat="server" CssClass="btn btn-outline-primary waves-effect waves-themed float-right"
                                        OnClick="btnCancelarUpload_Click">Voltar</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <%-- <div class="form-group">
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
                                </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

