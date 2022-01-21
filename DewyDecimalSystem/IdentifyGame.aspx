<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IdentifyGame.aspx.cs" Inherits="DewyDecimalSystem.IdentifyGame" Async="true"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link type="text/css" rel="stylesheet" href="../Content/Styles/IdentifyGameStyles.css" runat="server" />


    <div class="heading-container">
        <asp:Label
            ID="Label2"
            Text="Game Time"
            CssClass="header-label"
            runat="server">
        </asp:Label>
    </div>
    <div class="instructions-container">
        <asp:Label ID="Label3"
            runat="server"
            Text="Match as many call numbers/descriptions to their corresponding call number/descriptions within 60 seconds."
            CssClass="instructions-label"
            Style="color: #122352">
        </asp:Label>
    </div>
    <div class="page-container">

        <div>
            <div class="options-container">
                <div style="float: left;">
                    <asp:Label
                        ID="Label4"
                        CssClass="answer-label"
                        runat="server"
                        Text="Possible Answers: "
                        Style="text-align: left">
                    </asp:Label>
                </div>

                <br />
                <asp:BulletedList
                    ID="BulletedList2"
                    runat="server"
                    CssClass="bullet-list">
                </asp:BulletedList>

            </div>

            <div class="answers-container">
                <asp:Label
                    ID="Label5"
                    CssClass="answer-label"
                    runat="server"
                    Text="Match your answers here: "
                    Style="text-align: left">
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
                            runat="server"
                            Style="color: #4632a8">
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
                            runat="server"
                            Style="color: #4632a8">
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
                            runat="server"
                            Style="color: #4632a8">
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
                            runat="server"
                            Style="color: #4632a8">
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
                        Text="Next"
                        Style="float: right"
                        OnClick="nextBtn_Click" />
                </div>


            </div>
    </div>


    <div class="stopwatch-container">
            <div class="time-header-container">
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label
                            ID="Label6"
                            CssClass="correct-label"
                            runat="server"
                            Text="Correct: "></asp:Label>

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
                    ImageUrl="https://c.tenor.com/DIBZH5Yaz00AAAAC/tick-tock-clock.gif"
                    Height="150px" Width="150px" />
            </div>

            <div class="time-container">
                <asp:Timer ID="timer" runat="server" OnTick="Timer_Tick" Interval="20"></asp:Timer>
                <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">

                    <ContentTemplate>
                        <div style="text-align: center;">
                            <asp:Label
                                ID="lblTime"
                                runat="server"
                                Style="font-size:35px;" />
                        </div>
                        <br />
                
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger
                            ControlID="timer"
                            EventName="tick" />
                    </Triggers>
                </asp:UpdatePanel>
                <div class="stop-btnDiv" style="text-align: center">
                    <asp:Button
                        ID="stopGameBtn"
                        class="stop-btn"
                        runat="server"
                        Text="End Game" OnClick="stopGameBtn_Click" />
                    <br />
                    <asp:Button
                        ID="viewBtn"
                        class="start-btn"
                        runat="server"
                        Text="View Results"
                        onClick="viewBtn_Click"/>
                </div>
            </div>



        </div>
    </div>
        <asp:HiddenField ID="hiddenName" runat="server" />
        <asp:HiddenField ID="hiddenSurname" runat="server" />

</asp:Content>
