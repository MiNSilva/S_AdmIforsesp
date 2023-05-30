<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <div class="card p-12 order-top-left-radius-0 border-top-right-radius-10">
        <div>
            <div class="form-group">
                 <h1>
                    <asp:Panel ID="plMsg" runat="server">
                        <asp:Label ID="lblMsgErro" runat="server"></asp:Label>
                    </asp:Panel>
                </h1>
                <h2>Advocacia Marcatto.</h2>
   
                <div class="container-login100-form-btn p-t-10">
                    <h2>
                    <asp:LinkButton ID="lkVOltar" runat="server" OnClick="lkVOltar_Click"
                        CssClass="txt1"> <i class="fa fa-long-arrow-left"></i> &nbsp;Voltar </asp:LinkButton></h2>
                </div>

                </div>
            </div>
        </div>
    
    
    
      
</asp:Content>

