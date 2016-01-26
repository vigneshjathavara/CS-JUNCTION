<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ArticleDisplay.aspx.cs" Inherits="ArticleDisplay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="width:96%">
        <div class="adispmainleft">
           <div>
           <h1><asp:Label runat="server" CssClass="categoryheader" ID="category_title" Text="ARTICLE" Width="100%" /></h1>
            <br />
            <asp:Label runat="server" ID="Author" Text="VIGNESH JATHAVAR" Width="29%" Font-Bold="True" />
            <asp:Label runat="server" ID="pdate" Text="post date: 16-05-2012" Font-Bold="True" 
                   Width="22%" />
            
            <asp:Label runat="server" Text="RATING:4.5" Font-Bold="true" ID="rating" />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/star.jpg" 
                   Height="25px" Width="26px" />
            <asp:LoginView ID="LoginView1" runat="server">
               <AnonymousTemplate>
                    Login to Rate
               </AnonymousTemplate>
               <LoggedInTemplate>
                <asp:DropDownList ID="DDL1" runat="server">
                <asp:ListItem Selected="True"></asp:ListItem>
                <asp:ListItem Value="-1"></asp:ListItem>
                <asp:ListItem Value="-2"></asp:ListItem>
                <asp:ListItem Value="-3"></asp:ListItem>
                <asp:ListItem Value="-4"></asp:ListItem>
                <asp:ListItem Value="-5"></asp:ListItem>
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>
                <asp:ListItem Value="5"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button text="RATE IT" runat="server" ID="rate" onclick="rate_Click" />
                <asp:Label runat="server" ID="rlabel"/>
              </LoggedInTemplate>
            </asp:LoginView>
            <br />
            <hr style="width:100%"/>
            <asp:Label ID="keywds" runat="server" />
            <br />
            </div> 
            <div style="width:100%">
                <div style="width:35%;float:left">
                    
                    IMAGE upload will be available shortly
                </div>
                <div style="width:63%;float:left">
                   <div style="width:100%;word-wrap:break-word">
                        <asp:Literal ID="textDisplay" runat="server" />
                        <br />
                        <hr size="3pt" />
                   </div>
                   <div style="width:100%;word-wrap:break-word;height:auto">
            
                        <asp:PlaceHolder ID="ph" runat="server" />
                         <br />        
                    </div> 
                    <div>    
                        <asp:LoginView ID="LoginView2" runat="server">
                        <AnonymousTemplate>
                            Login to comment
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <asp:TextBox runat="server" Text="Enter comment" ID="ncom" TextMode="MultiLine" style="width:100%;height:200px" />
                            <asp:Button ID="Button1" runat="server" Text="Submit Comment" OnClick="Button1_Click"/>
                            <asp:Label runat="server" ID="qw" />
                        </LoggedInTemplate>
        
                    </asp:LoginView>
                </div> 
                <br />
                <asp:Label runat="server" ID="res" />
                </div>
            </div>       
        </div>
        <div class="adispmainright">
            ADS
        </div>
        
        <div class="clear" />
        
    </div>
</asp:Content>

