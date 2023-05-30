<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="RegistroSindical.aspx.cs" Inherits="Painel_Modulos_RegistroSindical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Registro Sindical
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">

            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Registro Sindical <span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Para <code>Permissões</code> clique no botão  &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-user"></i></asp:LinkButton>
                                &nbsp; e <code>Exclusão</code> clique no botão   &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                            </div>

                            <asp:Label ID="lblIdUsuario" runat="server" Visible="false"></asp:Label>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnNovo" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnNovo_Click">Novo</asp:LinkButton>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

