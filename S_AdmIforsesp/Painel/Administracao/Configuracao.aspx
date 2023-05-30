<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Configuracao.aspx.cs" Inherits="Painel_Administracao_Configuracao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-edit'></i>Configurações
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Configurações<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div class="panel-tag">
                                Abaixo, você encontrará configurações do sistema. A alteração das configurações impactará nas atividades diárias.
                            </div>
                            <div class="row">
                                <div class="col-xl-4">
                                    <div class="form-group">
                                        <label class="form-label" for="validationDefault01">Servidor ADM (Imagens)</label>
                                        <asp:TextBox ID="txtServidorImagem" runat="server" placeholder=""
                                            class="form-control"></asp:TextBox>
                                    </div>



                                    <%--                       <div class="form-group">
                                        <label class="form-label" for="message">Message</label>
                                        <textarea class="form-control" id="message" rows="5" placeholder="Enter a message ..."></textarea>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="closeButton">
                                        <label class="custom-control-label" for="closeButton">Close Button</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="addBehaviorOnToastClick">
                                        <label class="custom-control-label" for="addBehaviorOnToastClick">Add behavior on toast click</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="debugInfo">
                                        <label class="custom-control-label" for="debugInfo">Debug</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="progressBar" checked="">
                                        <label class="custom-control-label" for="progressBar">Progress Bar</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="preventDuplicates" checked="">
                                        <label class="custom-control-label" for="preventDuplicates">Prevent Duplicates</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="addClear">
                                        <label class="custom-control-label" for="addClear">Add button to force clearing a toast, ignoring focus</label>
                                    </div>
                                    <div class="custom-control custom-checkbox mb-2">
                                        <input type="checkbox" class="custom-control-input" id="newestOnTop" checked="">
                                        <label class="custom-control-label" for="newestOnTop">Newest on top</label>
                                    </div>--%>
                                </div>
                                <div class="col-xl-4">
                                    <div class="form-group">
                                        <label class="form-label" for="validationDefault01">Servidor Site (Imagens)</label>
                                        <asp:TextBox ID="TxtServidorSite" runat="server" placeholder=""
                                            class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xl-2">
                                    <div class="form-group">
                                        <asp:Label ID="lblId" runat="server" Text="Label" Visible="false"></asp:Label>

                                       <%-- <label class="form-label" for="validationDefault01">Dias / Resposta(Email)</label>--%>
                                        <asp:TextBox ID="txtDiaRespEmail" runat="server" placeholder="Qtde/Dias"  visible=" false"
                                            class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--      <div class="col-xl-2">
                                    <fieldset class="form-group" id="toastTypeGroup">
                                        <label>
                                            <strong>Toast Type</strong>
                                        </label>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input " name="toasts" id="typesuccess" type="radio" value="success" checked="">
                                            <label class="custom-control-label" for="typesuccess">Success </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input " name="toasts" id="typeinfo" type="radio" value="info">
                                            <label class="custom-control-label" for="typeinfo">Info </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="toasts" id="typewarning" type="radio" value="warning">
                                            <label class="custom-control-label" for="typewarning">Warning </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="toasts" id="typeerror" type="radio" value="error">
                                            <label class="custom-control-label" for="typeerror">Error </label>
                                        </div>
                                    </fieldset>
                                    <fieldset class="form-group" id="positionGroup">
                                        <label>
                                            <strong>Position</strong>
                                        </label>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="topright" type="radio" value="toast-top-right" checked="">
                                            <label class="custom-control-label" for="topright">Top Right </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="bottomright" type="radio" value="toast-bottom-right">
                                            <label class="custom-control-label" for="bottomright">Bottom Right </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="bottomleft" type="radio" value="toast-bottom-left">
                                            <label class="custom-control-label" for="bottomleft">Bottom Left </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="topleft" type="radio" value="toast-top-left">
                                            <label class="custom-control-label" for="topleft">Top Left </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="topfullwidth" type="radio" value="toast-top-full-width">
                                            <label class="custom-control-label" for="topfullwidth">Top Full Width </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="bottomfullwidth" type="radio" value="toast-bottom-full-width">
                                            <label class="custom-control-label" for="bottomfullwidth">Bottom Full Width </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="topcenter" type="radio" value="toast-top-center">
                                            <label class="custom-control-label" for="topcenter">Top Center </label>
                                        </div>
                                        <div class="custom-control custom-radio mb-2">
                                            <input class="custom-control-input" name="position" id="bottomcenter" type="radio" value="toast-bottom-center">
                                            <label class="custom-control-label" for="bottomcenter">Bottom Center </label>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-xl-2">
                                    <div class="form-group">
                                        <label class="form-label" for="showDuration">Show Duration</label>
                                        <div class="input-group flex-nowrap">
                                            <input type="number" class="form-control" id="showDuration" placeholder="ms" value="300">
                                            <div class="input-group-append">
                                                <span class="input-group-text">ms
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="hideDuration">Hide Duration</label>
                                        <div class="input-group flex-nowrap">
                                            <input type="number" class="form-control" id="hideDuration" placeholder="ms" value="100">
                                            <div class="input-group-append">
                                                <span class="input-group-text">ms
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="timeOut">Timeout</label>
                                        <div class="input-group flex-nowrap">
                                            <input type="number" class="form-control" id="timeOut" placeholder="ms" value="5000">
                                            <div class="input-group-append">
                                                <span class="input-group-text">ms
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="extendedTimeOut">Extended time out</label>
                                        <div class="input-group flex-nowrap">
                                            <input type="number" class="form-control" id="extendedTimeOut" placeholder="ms" value="1000">
                                            <div class="input-group-append">
                                                <span class="input-group-text">ms
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-2">
                                    <div class="form-group">
                                        <label class="form-label" for="showEasing">Show Easing</label>
                                        <input type="text" class="form-control" id="showEasing" placeholder="swing, linear" value="swing">
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="hideEasing">Hide Easing</label>
                                        <input type="text" class="form-control" id="hideEasing" placeholder="swing, linear" value="linear">
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="showMethod">Show Method</label>
                                        <input type="text" class="form-control" id="showMethod" placeholder="show, fadeIn, slideDown" value="fadeIn">
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label" for="hideMethod">Hide Method</label>
                                        <input type="text" class="form-control" id="hideMethod" placeholder="hide, fadeOut, slideUp" value="fadeOut">
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnAtualizar" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnAtualizar_Click" ValidationGroup="Senha">Atualizar</asp:LinkButton>
                            <%--<button class="btn btn-outline-primary mr-1 waves-effect waves-themed" type="button" id="clearlasttoast">Limpar Tudo </button>
                            <button class="btn btn-outline-primary mr-1 waves-effect waves-themed" type="button" id="cleartoasts">Clear All Toasts </button>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

