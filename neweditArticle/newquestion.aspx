<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="newquestion.aspx.cs" Inherits="neweditArticle_newquestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
       <div>
        <asp:Label ID="Label1" runat="server" CssClass="categoryheader" Text="Ask a Question" />
       </div>
       <div>
         Make sure you give a title and category.<br />
         The tite box gives the names of similar articles.<br />
         Make it a point to read the recomendations before adding an article.<br />
         Please do not repeat if already present.Help preventing duplicates.<br />
         
       </div>
       <div style="width:96%">
            <div style="float:left;width:50%">
                <asp:TextBox runat="server" Text="Enter the Title" ID="title" style="width:100%"/>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="title" ServicePath="~/search.asmx" ServiceMethod="searchpredictq" MinimumPrefixLength="1">
                </asp:AutoCompleteExtender>
            </div>
            <div style="width:50%;float:left">
               <asp:TextBox runat="server" ID="keywords" Width="100%" Text="Enetr keywords(better noticeability)" />
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

