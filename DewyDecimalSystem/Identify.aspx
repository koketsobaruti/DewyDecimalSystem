<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Identify.aspx.cs" Inherits="DewyDecimalSystem.Identify" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/Identify.css" runat="server" />

    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Identify an Area"
            CssClass="header-label"
            runat="server" >
        </asp:Label>
    </div>
    
    <asp:Button
        ID="Button1"
        runat="server"
        Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        runat="server"
        ID="mp1"
        TargetControlID="Button1"
        PopupControlID="Panel1"
        CancelControlID="startBtn"
        BackgroundCssClass="Background">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center">

        <div class="inner-panel">
            <div class="text-div">
                <asp:Label
                    ID="Label1"
                    Text="Match the call numbers to their description."
                    CssClass="main-instructions-label"
                    runat="server">
                </asp:Label>
            </div>

            <div class="btnDiv">
                <asp:Button
                    ID="startBtn"
                    runat="server"
                    Text="Start"
                    CssClass="start-btn"
                    UseSubmitBehavior="false" 
                    CausesValidation="False" 
                    OnClick="startBtn_Click" />
            </div>
        </div>
    </asp:Panel>

      <ajaxToolkit:ModalPopupExtender 
        runat="server"
        ID="mpHelp"
        TargetControlID="helpBtn"
        PopupControlID="Panel4"
        CancelControlID="returnBtn" 
        BackgroundCssClass="Background">

    </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="Panel4" runat="server" CssClass="Popup-3" align="center">

            <div class="inner-panel-2">

                <div class="heading-container">
                <asp:Label
                    ID="Label9"
                    Text = "Help"
                    CssClass="header-label"
                    runat="server">
                </asp:Label>
                  </div>
                <asp:Label
                    ID="Label10"
                    Text = "1. Examine the list of possible and match these to their correct classification."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                <br />
           <b><u>Example:</u> 650 would belong to the technology category</b>
                <br />
                        <br />
                <asp:Label
                    ID="Label11"
                    Text = "2. If the possible answers are descriptions, match them to their call number."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                        <br />
           <b><u>Example:</u> Relegion would belong to 203.</b>
               
            </div>
                
            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="returnBtn"
                    runat="server"
                    Text ="Close"
                    CssClass="close-btn" 
                    UseSubmitBehavior="false"
                    CausesValidation="False"/>
            </div>
            

        </asp:Panel>
    <div class="page-container">

    <div class="instructions-container">
        <asp:Label ID="Label3" 
            runat="server" 
            Text="Match the call numbers 
            or descriptions on the left 
            with the corresponding call number/description." 
            CssClass="instructions-label">
        </asp:Label>

    </div>

        <div class="options-container">
            <asp:Label
                ID="Label4"
                CssClass="answer-label"
                runat="server"
                Text="Possible Answers: "
                style="text-align:left">
            </asp:Label>
            <br />
            <asp:BulletedList 
                ID="BulletedList2" 
                runat="server"
                CssClass="bullet-list">
            </asp:BulletedList>

             <div class="btnDiv">
                <asp:Button
                    ID="helpBtn"
                    runat="server"
                    Text ="Help"
                    CssClass="help-btn" />
            </div>
        </div>

        <div class="answers-container">
            <asp:Label
                ID="Label5"
                CssClass="answer-label"
                runat="server"
                Text="Match your answers here: "
                style="text-align:left">
            </asp:Label>
            <br />

            <asp:Label
                ID="errorLabel"
                CssClass="answer-label"
                runat="server"
                Style="color: orangered">
            </asp:Label>
            <div class="answer-inner-container">
                <div>
                    <asp:Label
                    ID="txt1"
                    CssClass="answer-label"
                    runat="server">
                </asp:Label>
                </div>
                <div>
                    <asp:DropDownList
                    ID="dd1"
                    runat="server"
                    CssClass="mydropdownlist">
                </asp:DropDownList>
                </div>
            </div>

            <div class="answer-inner-container">
                <div>
                    <asp:Label
                    ID="txt2"
                    CssClass="answer-label"
                    runat="server">
                </asp:Label>
                </div>
                <div>
                    <asp:DropDownList
                    ID="dd2"
                    runat="server"
                    CssClass="mydropdownlist">
                </asp:DropDownList>
            </div>
            </div>

            <div class="answer-inner-container">
                <div>
                    <asp:Label
                    ID="txt3"
                    CssClass="answer-label"
                    runat="server">
                </asp:Label>
                </div>

                <div>
                    <asp:DropDownList
                    ID="dd3"
                    runat="server"
                    CssClass="mydropdownlist">
                </asp:DropDownList>
                </div>
            </div>

            <div class="answer-inner-container">
                <div>
                    <asp:Label
                    ID="txt4"
                    CssClass="answer-label"
                    runat="server">
                </asp:Label>
                </div>

                <div>
                    <asp:DropDownList
                    ID="dd4"
                    runat="server"
                    CssClass="mydropdownlist">
                </asp:DropDownList>
                </div>
            </div>

            <div class="btnDiv">
                <asp:Button
                    ID="nextBtn"
                    class="btn"
                    runat="server"
                    Text="Next" OnClick="nextBtn_Click" />
            </div>

        </div>

        <div class="stopwatch-container">
            <div class="game-header-container">
                <asp:Label
                    ID="Label6"
                    CssClass="game-label"
                    runat="server"
                    Text="Play a Game!">
                </asp:Label>
            </div>

            <div class="image-container">
                <asp:Image 
                ID="Image1" 
                runat="server" 
                ImageUrl="https://cdn-icons-png.flaticon.com/512/2088/2088617.png"
                Height="150px" Width="150px"/>
            </div>
            <div class="game-instructions-container">
                <div style="text-align:center;">
                    <asp:Label
                    ID="Label7"
                    runat="server"
                    Text="Do you want to compete for the fastest time?"
                    Style="font-size: 20px;">
                </asp:Label>
                
            <br />
            <asp:Label
                    ID="Label8"
                    CssClass="answer-label"
                    runat="server"
                    Text="Click on Play to see whether you can complete the matching task in record time and
                          view your score on the leaderboard."
                    Style="font-size: 15px;">
                </asp:Label>
            </div>
            </div>
            <div>

            </div>

            <div class="game-btnDiv">
                <asp:Button
                    ID="startGameBtn"
                    class="game-btn"
                    runat="server"
                    Text="Play" 
                    OnClick="startGameBtn_Click" />
            </div>

            
        </div>
        
    </div>



</asp:Content>
