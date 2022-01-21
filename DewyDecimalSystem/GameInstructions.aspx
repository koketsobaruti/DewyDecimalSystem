<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameInstructions.aspx.cs" Inherits="DewyDecimalSystem.GameInstructions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/IdentifyGameStyles.css" runat="server" />
    
    <asp:Button
        ID="Button1"
        runat="server"
        Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        runat="server"
        ID="mp1"
        TargetControlID="startBtn"
        PopupControlID="Panel1"
        CancelControlID="Button1"
        BackgroundCssClass="Background">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center">

        <div class="inner-panel">
            <div class="text-div">
                <asp:Label
                    ID="Label9"
                    Text="Enter your name and surname to add your perfomance to the leaderboard."
                    CssClass="main-instructions-label"
                    Style="font-size: 25px;"
                    runat="server">
                </asp:Label>
                <br />
                <asp:Label
                    ID="errorLbl"
                    CssClass="main-instructions-label"
                    Style="font-size: 18px; color:orangered;"
                    runat="server">
                </asp:Label>

            </div>
            <div class="textbox-container">
                <asp:TextBox
                    ID="txbName"
                    placeholder="Name"
                    runat="server"
                    class="txt-box">
                </asp:TextBox>

                <asp:TextBox
                    ID="txbSurname"
                    placeholder="Surname"
                    runat="server"
                    class="txt-box">
                </asp:TextBox>
            </div>
            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="proceedBtn"
                    runat="server"
                    Text="Proceed"
                    CssClass="btn" 
                    OnClick="proceedBtn_Click" />
            </div>
        </div>
    </asp:Panel>

    <div class="page-container" style="margin-top: 2em; border-style: solid; border-width: 3px; border-color: #4632a8; height: 600px; overflow: hidden; padding:20px;">
        <div class="heading-container" >
            <asp:Label
                ID="Label2"
                Text="Game Intructions"
                CssClass="header-label"
                runat="server"
                Style="color: #122352">
            </asp:Label>
        </div>

        <div class="instructions-container" style="background-color: none">
            <asp:Label ID="Label3"
                runat="server"
                Text="You have 60 seconds to match the call numbers to their descriptions."
                CssClass="instructions-label"
                Style="color: #4632a8">
            </asp:Label>
            <br />
            <asp:Label ID="Label1"
                runat="server"
                Text="You will not be able to pause or restart the time. You can only end your game."
                CssClass="instructions-label"
                style="color:#4632a8">
            </asp:Label>
            <br />
            <div style="padding:10px;">
                 <div class="options-container" style="width:20%; height:260px;">
                <asp:Label ID="Label4"
                    runat="server"
                    Text="Extra help:"
                    CssClass="instructions-label"
                Style="color: #122352">
                </asp:Label>
            </div>

            <div class="answers-container" style="width:65%; padding:20px; height:260px;">
                <asp:Label ID="Label8"
                    runat="server"
                    Text="1) The timer will begin as soon as you click on Start, so make sure that you are ready."
                    CssClass="instructions-label"
                    style="font-size:17px; line-height:2em; color: #122352;">
                </asp:Label>
                <br />
                <asp:Label ID="Label5"
                    runat="server"
                    Text="2) Make sure that every entry is unique before clicking on Next."
                    CssClass="instructions-label"
                    style="font-size:17px; line-height:2em; color: #122352;">
                </asp:Label>
                <br />
                <asp:Label ID="Label6"
                    runat="server"
                    Text="3) The question will change between matching call numbers to their description to matching descriptions to their call numbers."
                    CssClass="instructions-label"
                    style="font-size:17px; line-height:2em; color: #122352;">
                </asp:Label>
                <br />
                <asp:Label ID="Label7"
                    runat="server"
                    Text="4) Try to get as many matches as you can, but most importantly, have fun! :)"
                    CssClass="instructions-label"
                    style="font-size:17px; line-height:2em; color: #122352;">
                </asp:Label>
            </div>

        </div>
            </div>
           

        <div class="btnDiv">
                <asp:Button
                    ID="returnBtn"
                    class="game-btn"
                    runat="server"
                    Text="Go Back" 
                    style="float:left; width:30%;" OnClick="returnBtn_Click"/>
                <asp:Button
                    ID="startBtn"
                    class="btn"
                    runat="server"
                    Text="Start" 
                    style="float:right; width:30%;"/>
            </div>

    </div>
    

</asp:Content>
