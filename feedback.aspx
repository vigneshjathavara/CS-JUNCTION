<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="width: 935px">
    <asp:PlaceHolder ID="ph" runat="server" />
    <br />
    <asp:TextBox ID="txtb" runat="server" Text="Enter your feedback or suggestions" TextMode="MultiLine" Width="300px" Height="200px" />
    <br />
    <br />
    <asp:Button ID="submit" runat="server" onclick="submit_Click" Text="submit" CssClass="sbutton" />
    <asp:Label ID="lbl1" runat="server" />

    </div>
</asp:Content>

