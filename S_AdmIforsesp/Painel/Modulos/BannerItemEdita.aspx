<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="BannerItemEdita.aspx.cs" Inherits="Painel_BannerItemEdita" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Banner Item
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Banner Item <span class="fw-300"><i>Inserção | Edição</i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblBannerId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblBannerItemId" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblAltura" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblLargura" runat="server" Visible="false"></asp:Label>

                        <div class="panel-content">
                            <div class="panel-tag">
                                Informar a descrição da Item (banner) para Inclusão | Alteração.
                            </div>
                            <div class="row">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label class="form-label">Nome</label>
                                        <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNomeBanItem"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtNomeBanItem" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="col-lg-3">
                                    <div class="form-group">
                                        <label class="form-label">Palavra Principal</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPalavra0"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtPalavra0" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Palavra 1</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPalavra1"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtPalavra1" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Palavra 2</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPalavra2"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtPalavra2" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Palavra 3</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPalavra3"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtPalavra3" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Titulo</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo"
                                            ErrorMessage="*Obrigatório" Display="Dynamic" ForeColor="Red" ValidationGroup="Salvar"></asp:RequiredFieldValidator><br />
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="form-label">Descrição</label>
                                        <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="txtDescricao" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="cvResumo" runat="server"
                                            ControlToValidate="txtDescricao" ErrorMessage="*Descrição deve ter no máximo 220 caracteres"
                                            OnServerValidate="cvSummary_ServerValidate" Display="Dynamic" ValidationGroup="Item" ForeColor="Red"></asp:CustomValidator><br />
                                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="220" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Ativo</label>
                                        <asp:RequiredFieldValidator ID="rfvAtivo" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="ddlAtivo" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"
                                            InitialValue="Selecione"></asp:RequiredFieldValidator>

                                        <asp:DropDownList ID="ddlAtivo" runat="server" AppendDataBoundItems="True" Width="100px"
                                            CssClass="form-control" AutoPostBack="True">
                                            <asp:ListItem Value="1">Sim</asp:ListItem>
                                            <asp:ListItem Value="0">Não</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Início</label>
                                        <asp:RequiredFieldValidator ID="rfvInicio" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="txtInicio" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtInicio" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtInicio" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label">Final</label>
                                        <asp:CompareValidator ID="cvData" runat="server" ErrorMessage="Data Final menor que Data Inicio"
                                            ControlToValidate="txtFinal" ControlToCompare="txtInicio" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                            ValidationGroup="Salvar" Operator="GreaterThanEqual" Type="Date" CultureInvariantValues="true" EnableClientScript="true"></asp:CompareValidator>
                                        <asp:CompareValidator ID="cvDataAtual" runat="server" ErrorMessage=" Data Final menor que Data Atual"
                                            ControlToValidate="txtFinal" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                            ValidationGroup="Salvar" Type="Date" Operator="GreaterThanEqual"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="rfvFinal" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="txtFinal" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Data Inválida"
                                            ForeColor="Red" Display="Dynamic" ControlToValidate="txtFinal" ValidationGroup="Salvar"
                                            ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"></asp:RegularExpressionValidator>
                                        <asp:TextBox ID="txtFinal" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-10">
                                    <div class="form-group">
                                        <label class="form-label">Link</label>
                                        <%--<asp:RequiredFieldValidator ID="rfvLink" runat="server" ErrorMessage="*Obrigatório"
                                            ControlToValidate="txtLink" Display="Dynamic" ValidationGroup="Salvar" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                     --%>   
                                            <asp:TextBox ID="txtLink" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label class="form-label"></label>
                                        <br />
                                        <br />
                                        <asp:CheckBox ID="ckExterno" runat="server" Text="&nbsp;Externo" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label class="form-label">Imagem</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
                                         <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <div class="panel-content p-0 mb-g">
                                                <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">
                                                  <%--  <button type="button" class="close" data-dismiss="alert" aria-label="Close" onclick="imgbtn_Click">
                                                        <span aria-hidden="true"><i class="fal fa-times"></i></span>
                                                    </button>--%>
                                                    <asp:LinkButton ID="btnExcluir" runat="server" 
                                                        CssClass="float-right" OnClick="btnExcluir_Click">x</asp:LinkButton>

                                                    <strong>Arquivo: 
                                                            <asp:Label ID="lblarq" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lblarqori" runat="server" Text="Label" Visible="false"></asp:Label>
                                                        <%--<asp:TextBox ID="txtImg" runat="server" Enabled="false" Visible="false"
                                                                    Style="width: auto" CssClass="form-control"></asp:TextBox>--%>
                                                    </strong>
                                                    <%--<asp:TextBox ID="txtImgOriginal" runat="server" Visible="false"></asp:TextBox>--%>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="row">
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
        </div>
    </main>
</asp:Content>

