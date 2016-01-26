<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width:96.5%">
    <asp:Label ID="user" runat="server" Width="85%" Text="USER" CssClass="categoryheader"/>
    <asp:HyperLink runat="server" Text="CHANGE PASSWORD" NavigateUrl="~/Account/ChangePassword.aspx"  Width="14%"/>
    </div>

    <div style="width:96.5%">
        <asp:Label runat="server" Text="ARTICLES WRITTEN" CssClass="userlabel1" Width="40%"/>
        <br />
        <div style="width:45%;float:left">
         <asp:ListBox ID="ArticleBox1" runat="server" height="320px"></asp:ListBox>
        </div>
        <div style="width:20%;float:left">
            <div>
            <asp:Button runat="server" ID="edit" Text="EDIT" CssClass="sbutton2" Width="80px" 
                    onclick="edit_Click" />
            <br /><br />
            <asp:Button runat="server" ID="view" Text="VIEW" CssClass="sbutton2" Width="80px" 
                    onclick="view_Click" />
            <br /><br />
            <asp:Button runat="server" ID="remove" Text="REMOVE" CssClass="sbutton2" 
                    Width="80px" onclick="remove_Click"/>
                    <asp:Label ID="select" runat="server" />
            </div>
            <div>
                
                <asp:Panel ID="pan" Visible="false" runat="server" Width="100%">
                    <br /><br /><p>The article will be deleted permanently</p>
                    <asp:Button runat="server" ID="yes" Text="CONFIRM" CssClass="sbutton2" 
                        Width="80px" onclick="yes_Click" />
                    <br /><br />
                    <asp:Label ID="result" runat="server" Text="Label"></asp:Label>
                    <br /><br />
                    <asp:Button runat="server" ID="no" Text="CANCEL" CssClass="sbutton2" 
                        Width="80px" onclick="no_Click"/> 
                </asp:Panel>
            </div>
        </div>
        <div style="width:35%;float:left">
            <div>
            <asp:Label runat="server" Text="Asked Questions" />
            <br />
            <asp:PlaceHolder runat="server" ID="aqph" />
            </div>
            <br />
            <div>
             <asp:Label ID="Label1" runat="server" Text="Answered Questions" />
             <br />
             <asp:PlaceHolder runat="server" ID="ansqph" />
            </div>
        
        </div>
       <div class="clear" /> 
        
    </div>

</asp:Content>

