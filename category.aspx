<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="category.aspx.cs" Inherits="category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
       <h1><asp:Label runat="server" CssClass="categoryheader" ID="category_title" Text="CATEGORY" Width="60%"/></h1>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:TextBox runat="server" ID="searchbox" Width="25%" Text="Search"/>
       <asp:Button ID="searchbutton" runat="server" Text="SEARCH" CssClass="sbutton" 
            onclick="searchbutton_Click"  />
        <asp:AutoCompleteExtender
            ID="AutoCompleteExtender1" runat="server" TargetControlID="searchbox" ServicePath="~/search.asmx" ServiceMethod="searchpredict" MinimumPrefixLength="1">
        </asp:AutoCompleteExtender>
        
        <br />
        <br />
    </div>

    <div style="width: 96%">
         
        <div class="categoryleft">
            <h3>MOST RECENT</h3>
            <br/>
            <asp:PlaceHolder runat="server" ID="mostrecentph" />
        </div>

        <div class="categorycenter">
            <h3>HIGHEST RATED</h3>
            <br />
            <asp:PlaceHolder runat="server" ID="highestratedph" />
        </div>
        
        <div class="categoryright">
            <h3>SEARCH RESULTS</h3>
             <br/>
             
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                 <asp:PlaceHolder runat="server" ID="searchresults"/>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="searchbutton">
                    </asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>

        <div class="clear" />
    </div>

</asp:Content>

