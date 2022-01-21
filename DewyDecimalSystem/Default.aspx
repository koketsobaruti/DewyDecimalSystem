<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DewyDecimalSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/DefaultStyles.css" runat="server" />

    <div class="page-container">
        <div class="heading-container">
       <asp:Label
           ID="Label2"
           Text="Welcome to the Dewey Decimal"
           CssClass="header-label"
           runat="server">
       </asp:Label>
       <br />
       <asp:Label
           ID="Label1"
           Text="Classification Training System"
           CssClass="header-label"
           runat="server">
       </asp:Label>
   </div>
        
        <div class="main-body">

        <div class="replace-container">
            
            <div class="image-container">
                <asp:Image
                    ID="Image1"
                    runat="server"
                    ImageUrl="~/Images/replace.png"
                    CssClass="image" />
            </div>

            <div class="inner-header-container">
                
                <asp:Button 
                    ID="replaceBtn" 
                    runat="server" 
                    Text="Replace a Book"
                    style="font-size:1.6vw"
                    CssClass="btn" OnClick="replaceBtn_Click1"
                    />
            </div>
        </div>

        <div class="identify-container">

            <div class="image-container">
                <asp:Image
                    ID="Image2"
                    runat="server"
                    ImageUrl="~/Images/identify.png" 
                    CssClass="image" />
            </div>

            <div class="inner-header-container">
                
                <asp:Button 
                    ID="identifyBtn" 
                    runat="server" 
                    Text="Identify an Area"
                    style="font-size:1.6vw"
                    CssClass="btn" OnClick="identifyBtn_Click" 
                    />
            </div>
        </div>

        <div class="search-container">

            <div class="image-container">
                <asp:Image
                    ID="Image3"
                    runat="server"
                    ImageUrl="~/Images/search.png"
                    CssClass="image" />
            </div>
            
            <div class="inner-header-container">
                
                <asp:Button 
                    ID="searchBtn" 
                    runat="server" 
                    Text="Find a Call Number"
                    style="font-size:1.4vw"
                    CssClass="btn" OnClick="searchBtn_Click" 
                    />
            </div>
        </div>

    </div>
    </div>
   
</asp:Content>
