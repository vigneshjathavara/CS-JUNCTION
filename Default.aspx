<%@ Page Title="CS JUNCTION:Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_GB/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));</script>
   
   
    <div style="width:100%">
    <div>   
    <asp:Label class="categoryheader" runat="server">
        Welcome to CS JUNCTION!!!!
    </asp:Label>
     </div>
     <br />
     <div style="width:96%">
       CS JUNCTION is a website which aims at developing a community of Computer Science enthusiasts and provide a platform for the exchange of information.Register now to start posting Articles and Questions. It's absolutely free!!!
     </div>
    <br />
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    </div>
    <div style="width:100%">
    <div class="homepagemainleft">
       <div class="marq">
         
            <strong>
                <p>
                    Computers themselves, and software yet to be developed, will revolutionize the way we learn. -&nbsp;&nbsp; Steve Jobs
                </p>
               
            </strong>
        
          
        </div>
        
      <a target="_blank" href="http://x.co/vigiboi"><img src="http://affiliate.godaddy.com/ads/900BF4A1663084D5854F5153C6A40A52B00C2012F51111AA52434E68A196C61E5AE418B1F4882399894506B54D456F72B84EA0A3E2D6CCD105EE89B440D26D64" border="0" width="200"  height="200" alt="Go Daddy Asia Pacific Data Center - Fast & Secure!"/></a>  
       

    </div>
    <div class="homepagemaincenter">
        
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Height="1200px" ScrollBars="Vertical">
            
            <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1" >
                <HeaderTemplate>
                  Categories
                </HeaderTemplate>
                <ContentTemplate>
                    <div>
                        <asp:PlaceHolder ID="tab1ph" runat="server"/>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            
            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2" style="background-color:Beige">
                <HeaderTemplate>
                    Recent Articles
                </HeaderTemplate>
                <ContentTemplate>
                    <div>
                        <asp:PlaceHolder ID="tab2ph" runat="server"/>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
            
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" style="background-color:Beige">
                <HeaderTemplate>
                    Top Users
                </HeaderTemplate>
                <ContentTemplate>
                    <div>
                        <asp:PlaceHolder ID="tab3ph" runat="server"/>
                    </div>
                </ContentTemplate>       
            </asp:TabPanel>
        
         <asp:TabPanel runat="server" HeaderText="TabPanel4" ID="TabPanel4" style="background-color:Beige" >
                <HeaderTemplate>
                  Unanswered Questions
                </HeaderTemplate>
                <ContentTemplate>
                    <div>
                       <asp:PlaceHolder ID="tab4ph" runat="server"/>
                    </div>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>

    </div>
    <div class="homepagemainright">
     
      
    <script type="text/javascript" src="http://jc.revolvermaps.com/r.js"></script><script type="text/javascript">
      rm_f1st('2', '230', 'true', 'false', '000000', '2ttdqaoukea', 'true', 'ff0000');
    </script>
    <noscript>
    <applet codebase="http://rc.revolvermaps.com/j" code="core.RE" width="180" height="180" archive="g.jar">
    <param name="cabbase" value="g.cab" /><param name="r" value="true" />
    <param name="n" value="false" />
    <param name="i" value="2ttdqaoukea" />
    <param name="m" value="2" />
    <param name="s" value="230" />
    <param name="c" value="ff0000" />
    <param name="v" value="true" />
    <param name="b" value="000000" />
    <param name="rfc" value="true" />
    </applet>
    </noscript>
    <div class="fb-like-box" data-href="https://www.facebook.com/pages/CS-Junction/152324294837769" data-width="250" data-show-faces="true" data-border-color="red" data-stream="false" data-header="true">
        </div>
    </div>
    <div class="clear">
    </div>
    
    </div>
    
</asp:Content>
