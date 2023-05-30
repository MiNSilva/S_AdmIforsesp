<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Alerta.aspx.cs" Inherits="Painel_Alerta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-window'></i>Informativo
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <!--Basic alerts-->
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Alerta <span class="fw-300"><i>Informativo</i></span>
                        </h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="demo-v-spacing">
                                <asp:Panel ID="plMsgAlerta" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <strong><asp:Label ID="lblMsgAlerta" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="plMsgSucesso" runat="server">
                                    <div class="alert alert-success" role="alert">
                                        <strong><asp:Label ID="lblMsgSucesso" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="plMsgErro" runat="server">
                                    <div class="alert alert-danger" role="alert">
                                        <strong><asp:Label ID="lblMsgErro" runat="server" Text="Label"></asp:Label></strong>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

