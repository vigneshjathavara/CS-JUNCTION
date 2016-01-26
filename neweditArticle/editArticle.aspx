<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="editArticle.aspx.cs" Inherits="neweditArticle_editArticle" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
       <div>
        <asp:Label ID="Label1" runat="server" CssClass="categoryheader" Text="New Article Addition" />
       </div>
       <div style="width:96%">
            <div style="float:left;width:50%">
                <asp:TextBox runat="server" Text="Enter the Title" ID="title" style="width:100%"/>
            </div>
            <div style="width:50%;float:left">
                <asp:Label ID="Label2" runat="server" Text="Select Category" style="margin-left:10px"/>
                <asp:DropDownList ID="ddl" runat="server" CssClass="cb" Width="70%">
                     <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">C</asp:ListItem>
                    <asp:ListItem Value="2">C++</asp:ListItem>
                    <asp:ListItem Value="3">C#</asp:ListItem>
                    <asp:ListItem Value="4">JAVA</asp:ListItem>
                    <asp:ListItem Value="5">VISUAL BASIC</asp:ListItem>
                    <asp:ListItem Value="6">ASP.NET</asp:ListItem>
                    <asp:ListItem Value="7">PHP</asp:ListItem>
                    <asp:ListItem Value="8">JAVASCRIPT</asp:ListItem>
                    <asp:ListItem Value="9">CSS</asp:ListItem>
                    <asp:ListItem Value="10">HTML</asp:ListItem>
                    <asp:ListItem Value="11">NETWORKING</asp:ListItem>
                    <asp:ListItem Value="12">WINDOWS</asp:ListItem>
                    <asp:ListItem Value="13">LINUX</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="clear:both"/>
       
       </div>
       <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
           <cc1:Editor ID="Editor1" runat="server" />
        </div>
        <asp:Button ID="Button1" runat="server" Text="SUBMIT" onclick="Button1_Click" CssClass="sbutton" />
        <asp:Label runat="server" ID="result"/>
        <div>
         
        </div>
    </div>
</asp:Content>

