<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="NovoEmail.aspx.cs" Inherits="Painel_Email_NovoEmail" %>


<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $('#btnEnviar').click(function () {
            if (FileUploadNovoEmail.value.length == 0) {    // CHECK IF FILE(S) SELECTED.
                alert('No files selected.');
                return false;
            }
        });
    </script>


    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>E-mail
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h1><span class="fw-300"><b>
                            <asp:Label ID="lblMensagemNR" runat="server" Text="Label"></asp:Label></b></span></h1>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="lblcontrol" runat="server" Text="Label" Visible="false"></asp:Label>

                            <div class="row">
                                <asp:Label ID="lblServicosId" runat="server" Visible="false"></asp:Label>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="valEmail" runat="server" ValidationGroup="Contato" ControlToValidate="txtEmail"
                                        ErrorMessage="Informar o E-mail." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="valExMail" runat="server" ValidationGroup="Contato" ControlToValidate="txtEmail"
                                        ErrorMessage="E-mail Inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-mail" AutoPostBack="true"
                                        CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"
                                        OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="rfvcpf" runat="server" ValidationGroup="Contato" ControlToValidate="txtcpf"
                                        ErrorMessage="Informar o CPF" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtCPF" runat="server" class="form-control" placeholder="CPF" MaxLength="14"
                                        OnKeyPress="MascaraCPF(this,event);" onBlur="MascaraCPF(this,event);"
                                        CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"
                                        AutoPostBack="true" OnTextChanged="txtCPF_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="valName" runat="server"
                                        ControlToValidate="txtNome" ErrorMessage="Informar o Nome." ValidationGroup="Contato"
                                        ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtNome" runat="server" Text="" placeholder="Nome"
                                        CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="rfvAssunto" runat="server"
                                        ControlToValidate="txtAssunto" ErrorMessage="Informar o assunto."
                                        ValidationGroup="Contato" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:TextBox ID="txtAssunto" runat="server" Text="" class="form-control"
                                        placeholder="Assunto" CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="rfvSituacao" runat="server" ErrorMessage="*Campo Obrigatório"
                                        ControlToValidate="ddlSituacao" Display="Dynamic" ValidationGroup="Contato" ForeColor="Red"
                                        InitialValue="0"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="ddlSituacao" runat="server" AutoPostBack="True"
                                        CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"
                                        AppendDataBoundItems="True" ValidationGroup="Contato">
                                        <asp:ListItem Value="0" Selected="True">Selecione o motivo</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="col-lg-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Campo Obrigatório"
                                        ControlToValidate="ddlResp" Display="Dynamic" ValidationGroup="Contato" ForeColor="Red"
                                        InitialValue="0"></asp:RequiredFieldValidator><br />
                                    <asp:DropDownList ID="ddlResp" runat="server" AppendDataBoundItems="True"
                                        CssClass="form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5">
                                        <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <br />
                                        <label class="form-label">Mensagem</label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Campo Obrigatório"
                                            ControlToValidate="txtMessage" Display="Dynamic" ValidationGroup="Servicos" ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                        <CKEditor:CKEditorControl ID="txtMessage" runat="server"></CKEditor:CKEditorControl>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUploadNovoEmail"
                                            ValidationGroup="Email" Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="Somente as seguintes extesões (.pdf, .jpg, .jpeg, .doc, .docx, .zip, .rar, .xls, .xlsx ) são permitidos"
                                            ValidationExpression="(.*\.([Pp][Dd][Ff])|.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Dd][Oo][Cc][Xx])|.*\.([Dd][Oo][Cc])|.*\.([Zz][Ii][Pp])|.*\.([Rr][Aa][Rr])|.*\.([Xx][Ll][Ss][Xx])|.*\.([Xx][Ll][Ss])$)"></asp:RegularExpressionValidator><br />
                                        <asp:FileUpload ID="FileUploadNovoEmail" multiple="true" runat="server" CssClass="pro_btn pro_inf" />
                                        <p>
                                            <asp:Label ID="lblUploadStatus" runat="server"></asp:Label>
                                        </p>
                                        <p>
                                            <asp:Label ID="iUploadedCnt" runat="server"></asp:Label>
                                        </p>
                                        <p>
                                            <asp:Label ID="lblFailedStatus" runat="server"></asp:Label>
                                        </p>
                                        <br />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <div class="form-group">
                                <label class="col-sm-12 col-md-12">
                                    <asp:LinkButton ID="btnEnviar" runat="server"
                                      CssClass="btn btn-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnEnviar_Click">Enviar</asp:LinkButton>

                                     <asp:LinkButton ID="btnVoltar" runat="server"
                                           CssClass="btn btn-outline-primary waves-effect waves-themed"
                                        data-target="#myModal"
                                        OnClick="btnVoltar_Click" ValidationGroup="Email">Voltar</asp:LinkButton>
                                </label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </main>
    
</asp:Content>

