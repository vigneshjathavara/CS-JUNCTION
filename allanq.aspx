<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="allanq.aspx.cs" Inherits="allanq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div style="width:100%">
    
    <div style="width:50%;float:left">
        <label class="categoryheader">ARTICLES</label><br />
        <asp:PlaceHolder ID="articlesph" runat="server" />    
    </div>
    <div style="width:50%;float:left">
        <label class="categoryheader">Questions</label><br />
        <asp:PlaceHolder runat="server" ID="quesph" />
    </div>
    <div class="clear" />

</div>
</asp:Content>

