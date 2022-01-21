<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="DewyDecimalSystem.Leaderboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/IdentifyGameStyles.css" runat="server" />

    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Leaderboard"
            CssClass="header-label"
            runat="server">
        </asp:Label>
    </div>

    <div class="instructions-container">
        <asp:Label
            ID="Label3"
            runat="server"
            Text="Well done "
            CssClass="instructions-label">
        </asp:Label>
        <br />
        <asp:Label
            ID="scorelbl"
            runat="server"
            Text="0"
            CssClass="instructions-label"
            Style="color: #122352">
        </asp:Label>
    </div>

    <div class="page-container" style="height:auto">
        <div class="heading-container">
        <asp:Label
            ID="Label1"
            Text="Top 10"
            CssClass="header-label"
            style="font-size:30px;"
            runat="server">
        </asp:Label>
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"  OnRowDataBound="GridView1_RowDataBound" CssClass="mydatagrid"/>
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_USERConnectionString %>" SelectCommand="SELECT TOP 10 * FROM TBL_USER ORDER BY SCORE DESC"></asp:SqlDataSource>
   <br />
        <div class="btnDiv">
                <asp:Button
                    ID="done"
                    class="game-btn"
                    runat="server"
                    Text="Finish" 
                    style="float:right; width:30%;" OnClick="done_Click"/>
            </div>

    </div>
    
    


</asp:Content>