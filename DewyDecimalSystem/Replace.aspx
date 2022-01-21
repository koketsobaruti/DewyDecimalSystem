<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Replace.aspx.cs" Inherits="DewyDecimalSystem.Pages.Replace" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/ReplaceStyles.css" runat="server" />

    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Replace a Book"
            CssClass="header-label"
            runat="server" ></asp:Label>
    </div>

    <asp:Button
        ID="Button1"
        runat="server"
        Style="display: none" />

    <asp:Button
        ID="Button4"
        runat="server"
        Style="display: none" />
    
    <asp:Button
        ID="Button2"
        runat="server"
        Style="display: none" />

   

    <cc1:ModalPopupExtender 
        runat="server"
        ID="mp1"
        TargetControlID="Button1"
        PopupControlID="Panel1"
        CancelControlID="startBtn" 
        BackgroundCssClass="Background">

    </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center">

            <div class="inner-panel">
                <div class="text-div">
                <asp:Label
                    ID="Label1"
                    Text="Order the following numbers numerically and then alphabetically."
                    CssClass="main-instructions-label"
                    runat="server">
                </asp:Label>
            </div>

            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="startBtn"
                    runat="server"
                    Text ="Start"
                    CssClass="start-btn" 
                    UseSubmitBehavior="false" OnClick="startBtn_Click" CausesValidation="False" />
            </div>
            </div>
            

        </asp:Panel>


     <cc1:ModalPopupExtender 
        runat="server"
        ID="mpSuccess"
        TargetControlID="Button4"
        PopupControlID="Panel3"
        CancelControlID="winBtn" 
        BackgroundCssClass="Background">

    </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel3" runat="server" CssClass="Popup" align="center">

            <div class="inner-panel">
                <div class="text-div">
                <asp:Label
                    ID="winLbl"
                    Text = "Congratulations you have ordered them correctly! 
                    You have won the sorting award. Click on 'Collect' to claim your prize"
                    CssClass="main-instructions-label"
                    runat="server">
                </asp:Label>
            </div>

            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="winBtn"
                    runat="server"
                    Text ="Collect"
                    CssClass="start-btn" 
                    UseSubmitBehavior="false"
                    CausesValidation="False" OnClick="winBtn_Click" />
            </div>
            </div>
            

        </asp:Panel>

    <cc1:ModalPopupExtender 
        runat="server"
        ID="mpCollectPrize"
        TargetControlID="Button4"
        PopupControlID="Panel2"
        CancelControlID="winBtn" 
        BackgroundCssClass="Background">

    </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel2" runat="server" CssClass="Popup-2" align="center">

            <div class="inner-panel">

                <div class="text-2-div">
                <asp:Label
                    ID="Label7"
                    Text = "You have won yourself the Sorting Award!"
                    CssClass="main-instructions-label"
                    runat="server">
                </asp:Label>
            </div>
                <div class="image-container">
                <asp:Image
                    ID="Image3"
                    runat="server"
                    ImageUrl="~/Images/sortingachievement.png"
                    CssClass="image" />
                </div>
                
            <br />
            <div class="btnDiv">
                <asp:Button
                    ID="claimBtn"
                    runat="server"
                    Text ="Claim"
                    CssClass="start-btn" 
                    UseSubmitBehavior="false"
                    CausesValidation="False" OnClick="claimBtn_Click"/>
            </div>
            </div>
            

        </asp:Panel>
    
    <cc1:ModalPopupExtender 
        runat="server"
        ID="mpHelp"
        TargetControlID="helpBtn"
        PopupControlID="Panel4"
        CancelControlID="returnBtn" 
        BackgroundCssClass="Background">

    </cc1:ModalPopupExtender>

        <asp:Panel ID="Panel4" runat="server" CssClass="Popup-3" align="center">

            <div class="inner-panel-2">

                <div class="heading-container">
                <asp:Label
                    ID="Label6"
                    Text = "Help"
                    CssClass="header-label"
                    runat="server">
                </asp:Label>
                  </div>
                <asp:Label
                    ID="Label8"
                    Text = "1. Compare the value each of the numbers in the sequence to find out which one is the greatest."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                <br />
           <b><u>Example:</u> 120.31 ABC would be GREATER THAN 092.1 FYZ</b>
                <br />
                        <br />
                <asp:Label
                    ID="Label10"
                    Text = "2. If the numbers are equal, sort the alphabets according to ascending order."
                    CssClass="help-instructions-label-2"
                    runat="server">
                </asp:Label>
                        <br />
           <b><u>Example:</u> 021.33 WER would come AFTER 021.33 ACD</b>
               
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

    <div>
        
    </div>

    <div class="left-container">
        <div class="instructions-container">
            <asp:Label
                ID="Label3"
                Text="Examine the call numbers below and in "
                CssClass="instructions-label"
                runat="server">
            </asp:Label>
            <b class="instructions-label">ascending order, </b>
            <asp:Label
                ID="Label4"
                Text="select the appropriate call number from the list."
                CssClass="instructions-label"
                runat="server">
            </asp:Label>
        </div>
        
        <div class="list-container">
            <asp:BulletedList 
                ID="BulletedList1" 
                runat="server"
                style="font-size:20px; color:#ff6200; padding:10px; list-style-type:none; margin-right:2em; line-height:3em;">
            </asp:BulletedList>

            <div class="btnDiv">
                <asp:Button
                    ID="helpBtn"
                    runat="server"
                    Text ="Help"
                    CssClass="help-btn" />
            </div>
           
        </div>
    </div>

    <div class="right-container">
        <div class="inner-right-container">
            <div class="instructions-container">
                <asp:Label
                ID="Label5"
                Text="Ordered Calling Numbers"
                CssClass="instructions-label"
                style="font-size:35px;"
                runat="server">
            </asp:Label>
            
            </div>
            
            <asp:Label
                ID="incorrectLbl"
                Text="Incorrect Order"
                CssClass="instructions-label"
                Style="color: red"
                runat="server">
            </asp:Label>
        </div>

        <div class="inner-right-container">

            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd1"
                    runat="server"
                    CssClass="mydropdownlist" OnSelectedIndexChanged="dd1_SelectedIndexChanged" AutoPostBack = "true">
                </asp:DropDownList>

            </div>
            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd2"
                    runat="server"
                    CssClass="mydropdownlist"
                    OnSelectedIndexChanged="dd2_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>

            </div>

            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd3"
                    runat="server"
                    CssClass="mydropdownlist"
                    OnSelectedIndexChanged="dd3_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd4"
                    runat="server"
                    CssClass="mydropdownlist"
                    OnSelectedIndexChanged="dd4_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd5"
                    runat="server"
                    CssClass="mydropdownlist" 
                    OnSelectedIndexChanged="dd5_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd6"
                    runat="server"
                    CssClass="mydropdownlist" 
                    OnSelectedIndexChanged="dd6_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd7"
                    runat="server"
                    CssClass="mydropdownlist" 
                    OnSelectedIndexChanged="dd7_SelectedIndexChanged"
                    AutoPostBack = "true">

                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd8"
                    runat="server"
                    CssClass="mydropdownlist"
                    OnSelectedIndexChanged="dd8_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>

            </div>

            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd9"
                    runat="server"
                    CssClass="mydropdownlist"
                    OnSelectedIndexChanged="dd9_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


            <br />
            <div class="dropdownContainer">
                <asp:DropDownList
                    ID="dd10"
                    runat="server"
                    CssClass="mydropdownlist" 
                    OnSelectedIndexChanged="dd10_SelectedIndexChanged"
                    AutoPostBack = "true">
                </asp:DropDownList>
            </div>


        </div>

        <div class="btnDiv">
            <asp:Button
                ID="refreshBtn"
                class="stop-btn"
                runat="server"
                Text="Restart" OnClick="refreshBtn_Click"/>

            <asp:Button
                ID="submitBtn"
                class="btn"
                runat="server"
                Text="Submit" 
                OnClick="submitBtn_Click" />
        </div>

    </div>
</asp:Content>
