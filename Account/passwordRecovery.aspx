<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="passwordRecovery.aspx.cs" Inherits="Account_passwordRecovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:Label ID="l" runat="server" />

    <asp:Label ID="Label1" runat="server" Text="Enter username" Width="200px"></asp:Label>
    <asp:TextBox ID="tb1" runat="server"></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="submit" onclick="submit_Click" />
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
</asp:Content>

