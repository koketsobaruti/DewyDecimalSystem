<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Find.aspx.cs" Inherits="DewyDecimalSystem.Find"  Async="true"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/FindingStyles.css" runat="server" />
    <asp:HiddenField ID="keyVal" runat="server" />

    <asp:Button
        ID="Button1"
        runat="server"
        Style="display: none" />

    <ajaxtoolkit:modalpopupextender
        id="mp1"
        runat="server"
        backgroundcssclass="Background"
        cancelcontrolid="startBtn"
        popupcontrolid="Panel1"
        targetcontrolid="Button1">
    </ajaxtoolkit:modalpopupextender>

    <asp:Panel ID="Panel1" runat="server" align="center" CssClass="Popup">

        <div class="inner-panel">
            <div class="text-div">
                <asp:Label
                    ID="Label4"
                    runat="server"
                    CssClass="main-instructions-label"
                    Text="Match the description to the correct classifications.">
                </asp:Label>
            </div>

            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="startBtn"
                    runat="server"
                    CausesValidation="False"
                    CssClass="start-btn"
                    Text="Start"
                    UseSubmitBehavior="false" OnClick="startBtn_Click" />
            </div>
        </div>
    </asp:Panel>

        <asp:Button
        ID="Button2"
        runat="server"
        Style="display: none" />

    <ajaxtoolkit:modalpopupextender
        id="mp2"
        runat="server"
        backgroundcssclass="Background"
        cancelcontrolid="restartBtn"
        popupcontrolid="Panel2"
        targetcontrolid="Button2">
    </ajaxtoolkit:modalpopupextender>

    <asp:Panel ID="Panel2" runat="server" align="center" CssClass="error-popup">

        <div class="inner-error-panel">
            <div class="error-image-container">
                <asp:Image
                    ID="Image3"
                    runat="server"
                    ImageUrl="https://cdn-icons-png.flaticon.com/512/1277/1277612.png"
                    CssClass="image"/>
                </div>
            
            <br />
            <div class="error-content-container">
                <div class="text-div">
                <asp:Label
                    ID="Label5"
                    runat="server"
                    CssClass="error-instructions-label"
                    Text="Incorrect answer.">
                </asp:Label>
                    <br />
                    <asp:Label
                    ID="Label9"
                    runat="server"
                    CssClass="error-instructions-label"
                    Text="Start again.">
                </asp:Label>
            </div>

            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="restartBtn"
                    runat="server"
                    CausesValidation="False"
                    CssClass="restart-btn"
                    Text="Restart"
                    UseSubmitBehavior="false" OnClick="restartBtn_Click"/>
            </div>
            </div>
            
        </div>
    </asp:Panel>

      <ajaxtoolkit:ModalPopupExtender 
        runat="server"
        ID="mpHelp"
        TargetControlID="helpBtn"
        PopupControlID="Panel4"
        CancelControlID="returnBtn" 
        BackgroundCssClass="Background">

    </ajaxtoolkit:ModalPopupExtender>

        <asp:Panel ID="Panel4" runat="server" CssClass="Popup-3" align="center">

            <div class="inner-panel-2">

                <div class="heading-container">
                <asp:Label
                    ID="Label10"
                    Text = "Help"
                    CssClass="header-label"
                    runat="server">
                </asp:Label>
                  </div>
                <asp:Label
                    ID="Label11"
                    Text = "1. Correctly match the third level description to the correct first level class definition."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                <br />
           <b><u>Example:</u> 'The political process' belongs to the first class definiton: 300, Social sciences, sociology and anthropology.</b>
                <br />
                        <br />
                <asp:Label
                    ID="Label12"
                    Text = "2. If you have correctly matched the answer, you will then need to match the descripiton to the second level class defintion."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                        <br />
           <b><u>Example:</u> 'The political process' belongs to the second class definiton: 320, Political Sciences.</b>
               
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

    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Find a Call Number"
            CssClass="header-label"
            style="color:#122352;"
            runat="server" > </asp:Label>
    </div>

    <div class="page-container">

        <div class="instructions-container">
            <asp:Label ID="Label3"
                runat="server"
                Text="Select the correct classification until you reach the furthest correct answer."
                CssClass="instructions-label"
                style="color:#122352;"> </asp:Label>
        </div>
        <br />
        <div class="content-container">
            <div class="text-container">
                <asp:Label
                ID="Label1"
                Text="Correctly identify the class of: "
                CssClass="second-instructions-label"
                style="color:#122352;"
                runat="server"> </asp:Label>
                <br />
            <asp:Label
                ID="classLabel"
                CssClass="second-instructions-label"
                style="color:#e86500; font-size:25px; margin-left:1em;"
                runat="server"> </asp:Label>
            </div>
            

            <div class="answers-container">
            <asp:RadioButtonList 
                ID="RadioButtonList1"
                class="radio-list"
                runat="server"></asp:RadioButtonList>
        </div>

            <div class="btnDiv">
                 <asp:Button
                    ID="helpBtn"
                    runat="server"
                    Text ="Help"
                    CssClass="help-btn" Style="float: left"/>
                    <asp:Button
                        ID="nextBtn"
                        class="btn"
                        runat="server"
                        Text="Next"
                        Style="float: right" OnClick="nextBtn_Click" />
                </div>

            <br />
            <asp:Label
                ID="secondclassLabel"
                CssClass="instructions-label"
        Style="display: none" 
                runat="server"> </asp:Label>
            
            <br />
            <asp:Label
                ID="firstClassLabel"
                CssClass="instructions-label"
        Style="display: none" 
                runat="server"> </asp:Label>

            
        </div>

        

        <div class="stopwatch-container">
            <div class="game-header-container">
                <asp:Label
                    ID="Label6"
                    CssClass="game-label"
                    runat="server"
                    Text="Play a Game!"> </asp:Label>
            </div>

            <div class="image-container">
                <asp:Image 
                ID="Image1" 
                runat="server" 
                ImageUrl="~/Images/game-control.png"
                Height="150px" Width="150px"/>
            </div>
            <div class="game-instructions-container">
                <div style="text-align:center;">
                    <asp:Label
                    ID="Label7"
                    runat="server"
                    Text="Do you want to compete for the highest score?"
                    Style="font-size: 20px;"> </asp:Label>
                
            <br />
            <asp:Label
                    ID="Label8"
                    CssClass="answer-label"
                    runat="server"
                    Text="Click on Play to see whether you can complete the matching task and
                          view your score on the leaderboard."
                    Style="font-size: 15px;"> </asp:Label>
            </div>
            </div>
            <div>

            </div>

            <div class="game-btnDiv">
                <asp:Button
                    ID="startGameBtn"
                    class="game-btn"
                    runat="server"
                    Text="Play" OnClick="startGameBtn_Click"  />
            </div>

            
        </div>
        
    </div>
    
</asp:Content>
