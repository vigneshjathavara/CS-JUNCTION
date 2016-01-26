<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QDisplay.aspx.cs" Inherits="QDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width:96%">
        <div class="adispmainleft">
           <div>
            <asp:Label runat="server" CssClass="categoryheader" ID="category_title" Text="ARTICLE" Width="100%" />
            <br />
            <asp:Label runat="server" ID="Author" Text="VIGNESH JATHAVAR" Width="29%" Font-Bold="True" />
            <asp:Label runat="server" ID="pdate" Text="post date: 16-05-2012" Font-Bold="True" 
                   Width="22%" />
            <br />
            <hr style="width:100%"/>
            <br />
            </div> 
            <div style="width:100%">
                <div style="width:100%;word-wrap:break-word">
                        <asp:Literal ID="textDisplay" runat="server" />
                        <br />
                        <hr size="3pt" />
                   </div>
                   <div style="width:100%;word-wrap:break-word;height:auto">
            
                        <asp:PlaceHolder ID="ph" runat="server" />
                         <br />        
                    </div> 
                    <div style="width:100%">    
                        <asp:LoginView ID="LoginView2" runat="server">
                        <AnonymousTemplate>
                            Login to Answer
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <asp:TextBox runat="server" Text="Enter comment" ID="ncom" TextMode="MultiLine" 
                                Width="100%" Height="300px" />
                            <asp:Button ID="Button1" runat="server" Text="Submit Comment" OnClick="Button1_Click"/>
                            <asp:Label runat="server" ID="qw" />
                        </LoggedInTemplate>
        
                    </asp:LoginView>
                </div> 
                <br />
                <asp:Label runat="server" ID="res" />
                </div>       
        </div>
        <div class="adispmainright">
            ADS
        </div>
        
        <div class="clear" />
        
    </div>
</asp:Content>

