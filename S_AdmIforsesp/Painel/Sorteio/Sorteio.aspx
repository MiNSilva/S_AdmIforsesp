<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Sorteio.aspx.cs" Inherits="Painel_Sorteio_Sorteio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
                <i class='subheader-icon fal fa-edit'></i>Sorteio
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Sorteio<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">

                            <div class="panel-tag">
                                Para <code>Alteração</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-check"></i></asp:LinkButton>
                                , &nbsp;  <code>Exclusão</code>  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                                <%--, <code>subir</code> &nbsp;
                                    <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-angle-up"></i></asp:LinkButton>
                                &nbsp; e <code>descer</code> &nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-angle-down"></i></asp:LinkButton>--%>
                            </div>

                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblIdSorteio" runat="server" Visible="false"></asp:Label>
                                        <asp:GridView ID="gvSorteio" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="IdSorteio" OnRowCommand="gvSorteio_RowCommand"
                                            AllowPaging="True" PageSize="10"
                                            CssClass="table table-striped table-bordered table-hover"
                                            OnPageIndexChanging="gvSorteio_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="IdSorteio" HeaderText="IdSorteio">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HtmlEncode="false" DataField="Nome" HeaderText="Nome" />
                                                <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HtmlEncode="false" DataField="qtde_ganhadores" HeaderText="Ganhadores" />
                                                <%-- <asp:BoundField HtmlEncode="false" DataField="qtde_ganhadores" HeaderText="qtde_ganhadores">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField HtmlEncode="false" DataField="Ativo" HeaderText="Ativo" />
                                                <asp:BoundField HtmlEncode="false" DataField="Regras" HeaderText="Regras">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HtmlEncode="false" DataField="Informativo" HeaderText="Informativo">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio" ) %>'><i class="fal fa-check"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Premio">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkPremio" runat="server" CommandName="Premio"
                                                            class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'>
                                                        <i class="fa fa-trophy "></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Participantes">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkParticipantes" runat="server" CommandName="Participantes"
                                                            class="btn btn-outline-info btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'>
                                                        <i class="fa fa-user "></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkCopiaPart" runat="server" CommandName="CopiaPart"
                                                            class="btn btn-outline-sucess btn-xs btn-icon waves-effect waves-themed" CausesValidation="false" 
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'> 
                                                        <i class="fa fa-user-plus "></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Resultados">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkResultados" runat="server" CommandName="Resultados"
                                                            class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" CausesValidation="false"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'>
                                                        <i class="fa fa-file "></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Link para o Site">
                                                    <ItemTemplate>
                                                        <%-- <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("http://ifosesp.com.br/Sorteio.aspx?sorteio={0}",
                                                        HttpUtility.UrlEncode(Eval("IdSorteio").ToString())) %>'
                                                        Text='<%# string.Format("http://ifosesp.com.br/Sorteio.aspx?sorteio={0}",
                                                        HttpUtility.UrlEncode(Eval("IdSorteio").ToString())) %>' />--%>

                                                        <asp:Label ID="lblLink" runat="server" Text='<%# string.Format("http://ifosesp.com.br/Sorteio.aspx?sorteio={0}",
                                                        HttpUtility.UrlEncode(Eval("IdSorteio").ToString())) %>'></asp:Label>

                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Gerar Sorteio">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnRodaSorteio" runat="server" Text="Sortear" CommandName="GerarSorteio"
                                                            CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Limpar Sorteio">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnLimparSorteio" runat="server" Text="Limpar" CommandName="LimparSorteio"
                                                            CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdSorteio")%>'/>
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="pro_info pro_info_important">Não há Sorteio cadastrados(s)</span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnNovoGrid" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnNovoGrid_Click">Novo</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

