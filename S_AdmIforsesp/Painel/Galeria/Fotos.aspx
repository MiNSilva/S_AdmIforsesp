<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Fotos.aspx.cs" Inherits="Painel_Galeria_Fotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- Oculta 1º Coluna do Grid --%>
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
                <i class='subheader-icon fal fa-edit'></i>Galeria de Fotos
                <%--<small>A senha de uso individual nunca informe a outro usuário</small>--%>
            </h1>
        </div>
        <div class="row">
            <div class="col-md-12 col-xl-12">
                <div id="panel-1" class="panel">
                    <div class="panel-hdr">
                        <h2>Galeria de Fotos<span class="fw-300"><i></i></span></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <asp:Label ID="lblOrdem" runat="server" Visible="false"></asp:Label>
                            <div class="panel-tag">
                                Para <code>Alteração</code> clique no botão &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-check"></i></asp:LinkButton>
                                , &nbsp;  <code>Exclusão</code>  &nbsp;
                                    <asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed"><i class="fal fa-times"></i></asp:LinkButton>
                            </div>
                            <div id="dt-basic-example_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblurl" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblIdGaleria" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblData" runat="server"></asp:Label>
                                        <asp:GridView ID="gvwTodasGalerias" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped with-check"
                                            DataKeyNames="url" AllowPaging="True" PageSize="10" OnRowCommand="gvwTodasGalerias_RowCommand"
                                            OnPageIndexChanging="gvwTodasGalerias_PageIndexChanging">
                                            <Columns>
                                                <%--    <asp:HyperLinkField DataNavigateUrlFields="url" 
                                                        DataNavigateUrlFormatString="../GaleriaImg/GaleriaVisualizar.aspx?url={0}" Text="Visualizar" 
                                                        HeaderText="Visualizar"/>--%>
                                              
                                                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                                <asp:BoundField DataField="dataevento" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="Data" HeaderText="Atualizado" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="DescTipoGaleria" HeaderText="Tipo Galeria" />
                                                   <asp:BoundField DataField="url" HeaderText="url">
                                                    <ControlStyle Width="0px" CssClass="rowNone" />
                                                    <FooterStyle Width="0px" CssClass="rowNone" />
                                                    <HeaderStyle Width="0px" CssClass="rowNone"></HeaderStyle>
                                                    <ItemStyle Width="0px" BorderWidth="0px" CssClass="rowNone"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEditar" runat="server" class="btn btn-outline-success btn-xs btn-icon waves-effect waves-themed" 
                                                            CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "url" ) %>'><i class="fal fa-check"></i></asp:LinkButton>

                                                        <asp:LinkButton ID="lnkDelete" runat="server" class="btn btn-outline-danger btn-xs btn-icon waves-effect waves-themed" 
                                                            CommandName="Excluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "url" ) %>'><i class="fal fa-times"></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--    <asp:BoundField DataField="NomeRegional" HeaderText="Regional" />--%>
                                                <%-- <asp:BoundField HeaderText="Status" />--%>
                                                <%--            <asp:ButtonField ButtonType="Image" CommandName="Aprovar" ImageUrl="~/images/aprove.gif" HeaderText="Aprovar">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Reprovar" ImageUrl="~/images/reprove.gif" HeaderText="Reprovar">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>--%>



<%--                                                <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/images/editar.gif" HeaderText="Editar">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Excluir" ImageUrl="~/images/excluir.gif" HeaderText="Excluir">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:ButtonField>--%>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <h5>Não Há Galerias(s) Cadastrada(s)</h5>
                                            </EmptyDataTemplate>
                                            <PagerSettings Mode="NumericFirstLast" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content py-3 rounded-bottom border-faded border-left-0 border-right-0 border-bottom-0">
                            <asp:LinkButton ID="btnNovo" runat="server" CssClass="btn btn-primary waves-effect waves-themed"
                                OnClick="btnNovo_Click">Novo</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </main>
</asp:Content>

