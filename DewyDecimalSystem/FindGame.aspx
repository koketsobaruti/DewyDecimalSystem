<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindGame.aspx.cs" Inherits="DewyDecimalSystem.FindGame" Async="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/FindGameStyles.css" runat="server" />
    <asp:HiddenField ID="keyVal" runat="server" />
    <asp:HiddenField ID="hiddenName" runat="server" />
    <asp:HiddenField ID="hiddenSurname" runat="server" />
    <asp:Button
        ID="Button1"
        runat="server"
        Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        ID="mp1"
        runat="server"
        BackgroundCssClass="Background"
        CancelControlID="startBtn"
        PopupControlID="Panel1"
        TargetControlID="Button1">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel1" runat="server" align="center" CssClass="Popup">

        <div class="inner-panel">
            <div class="text-div">
                <div class="inner-text-div">
                    <asp:Label
                        ID="Label5"
                        runat="server"
                        CssClass="main-instructions-label"
                        Text="Match the description to the correct classifications.">
                    </asp:Label>

                    <br />
                    <asp:Label
                        ID="Label7"
                        runat="server"
                        CssClass="main-instructions-label"
                        Text="After completing the game, you can view your score on the leaderboard">
                    </asp:Label>
                </div>
                <div class="second-inner-div">
                    <asp:Label
                        ID="Label6"
                        runat="server"
                        CssClass="main-instructions-label"
                        Text="Note: You only have three chances to fail."
                        Style="color: #ff4b45; font-size: 25px; font-weight: 400; text-align: center;">
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
            <br />

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
        cancelcontrolid="viewBtn"
        popupcontrolid="Panel2"
        targetcontrolid="Button2">
    </ajaxtoolkit:modalpopupextender>

    <asp:Panel ID="Panel2" runat="server" align="center" CssClass="error-popup">

        <div class="inner-error-panel">
            <div class="error-image-container">
                <asp:Image
                    ID="Image4"
                    runat="server"
                    ImageUrl="https://c.tenor.com/AWKzZ19awFYAAAAi/checkmark-transparent.gif"
                    CssClass="check-image"/>
                </div>
            
            <br />
            <div class="error-content-container">
                <div class="text-div">
                <asp:Label
                    ID="Label10"
                    runat="server"
                    CssClass="error-instructions-label"
                    Text="You have reached the end of your game.">
                </asp:Label>
                    <br />
                    <asp:Label
                    ID="Label11"
                    runat="server"
                    CssClass="error-instructions-label"
                    Text="Click the button to view the leaderboard.">
                </asp:Label>
            </div>

            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="viewBtn"
                    runat="server"
                    CausesValidation="False"
                    CssClass="view-btn"
                    Text="View Results"
                    UseSubmitBehavior="false" OnClick="viewBtn_Click"/>
            </div>
            </div>
            
        </div>
    </asp:Panel>

        <asp:Button
        ID="Button3"
        runat="server"
        Style="display: none" />

            <asp:Button
        ID="Button4"
        runat="server"
        Style="display: none" />

    <ajaxToolkit:ModalPopupExtender
        runat="server"
        ID="mp3"
        TargetControlID="Button3"
        PopupControlID="Panel3"
        CancelControlID="Button4"
        BackgroundCssClass="Background">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel3" runat="server" CssClass="name-popup" align="center">

        <div class="name-panel">
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
                    UseSubmitBehavior="true" OnClick="proceedBtn_Click"  />
            </div>
        </div>
    </asp:Panel>


    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Find a Call Number"
            CssClass="header-label"
            Style="color: #38010a;"
            runat="server">
        </asp:Label>
    </div>

    <div class="page-container">

        <div class="instructions-container">
            <asp:Label ID="Label3"
                runat="server"
                Text="Select the correct classification until you reach the furthest correct answer."
                CssClass="instructions-label"
                style="color:#38010a;">
            </asp:Label>
            <br />
            <asp:Label ID="Label4"
                runat="server"
                Text="You only have three lives to score as high as you can."
                CssClass="instructions-label"
                style="color:#38010a;">
            </asp:Label>
        </div>

        <div class="content-container">
            <div class="text-container">
                <asp:Label
                    ID="Label1"
                    Text="Correctly identify the class of: "
                    CssClass="second-instructions-label"
                    Style="color: #38010a;"
                    runat="server">
                </asp:Label>
                <br />
                <asp:Label
                    ID="classLabel"
                    CssClass="second-instructions-label"
                    Style="color: #e86500; font-size: 25px; margin-left: 1em;"
                    runat="server">
                </asp:Label>
            </div>


            <div class="answers-container">
                <asp:RadioButtonList
                    ID="RadioButtonList1"
                    class="radio-list"
                    runat="server">
                </asp:RadioButtonList>
            </div>

            <div class="btnDiv">
                <asp:Button
                    ID="nextBtn"
                    class="btn"
                    runat="server"
                    Text="Next"
                    Style="float: right" OnClick="nextBtn_Click"/>
            </div>

        </div>
        <div class="stopwatch-container">
            <div class="correct-header-container">
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label
                            ID="Label8"
                            CssClass="header-label"
                            runat="server"
                            style="font-size:45px;"
                            Text="Correct"></asp:Label>
                        <br />
                        <asp:Label
                            ID="lblcorrect"
                            CssClass="correct-label"
                            runat="server"
                            Text="0"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="nextBtn" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>

            <div class="image-container">
                <asp:Image 
                ID="Image1" 
                runat="server" 
                ImageUrl="https://cdn-icons-png.flaticon.com/512/1828/1828665.png"
                CssClass="image" />

                <asp:Image 
                ID="Image2" 
                runat="server" 
                ImageUrl="https://cdn-icons-png.flaticon.com/512/1828/1828665.png"
                CssClass="image" />

                <asp:Image 
                ID="Image3" 
                runat="server" 
                ImageUrl="https://cdn-icons-png.flaticon.com/512/1828/1828665.png"
                CssClass="image" />

            </div>
            
                       <div class="stop-btnDiv" style="text-align: center">
                    <asp:Button
                        ID="stopGameBtn"
                        class="stop-btn"
                        runat="server"
                        Text="End Game" OnClick="stopGameBtn_Click"/>
                    <br />
                </div>
            </div>
            <div>

            </div>



            
        </div>

</asp:Content>
