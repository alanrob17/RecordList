﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArtist.aspx.cs" Inherits="RecordList.AddArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-12 col-md-6 center-block">
            <h2 class="headerLabel">RecordDB Management System</h2>
            <h3 class="dateLabel">
                <asp:Label ID="dateLabel" runat="server"></asp:Label></h3>
            <h4 class="clockFace">
                <asp:TextBox ID="textClock" Width="120px" BorderStyle="None" ForeColor="#000099" Font="Bold" runat="server"></asp:TextBox></h4>
            <br />
            <p><span id="date"></span></p>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-6 center-block">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">&nbsp;<strong>Add Artist</strong></div>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="firstNameTextBox" class="control-label col-md-2">
                                <strong>First Name:</strong></label>
                            <div class="col-md-10">
                                <asp:TextBox ID="firstNameTextBox" runat="server"
                                    CssClass="form-control fullwidth"
                                    title="First Name"
                                    autofocus="autofocus"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="lastNameTextBox" class="control-label col-md-2">
                                <strong>Last Name:</strong></label>
                            <div class="col-md-10">
                                <asp:TextBox ID="lastNameTextBox" runat="server"
                                    CssClass="form-control fullwidth"
                                    title="Last Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="biographyTextBox" class="control-label col-md-2">
                                <strong>Biography:</strong></label>
                            <div class="col-md-12">
                                <asp:TextBox ID="biographyTextBox" runat="server"
                                    TextMode="MultiLine"
                                    CssClass="form-control fullwidth"
                                    Height="260px"
                                    title="Biography"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div id="divMessageArea"
                                    runat="server"
                                    visible="false">
                                    <div class="well">
                                        <asp:Label ID="messageLabel" runat="server"
                                            CssClass="text-warning"
                                            Text="Area to display messages." />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Button ID="submitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="submitButton_Click"></asp:Button>&nbsp;                    
               <asp:Button ID="returnButton" CssClass="btn btn-primary" runat="server" Text="Home" OnClick="returnButton_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-6 center-block">
            <asp:Label ID="yearLabel" runat="server"></asp:Label><br />
            <br />
        </div>
    </div>
    <div class="row">
        <footer>
            <hr />
            <p>Return to the <a href="/default">Main Menu</a></p>
        </footer>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
    <script type="text/javascript">

        var yr = new Date();
        var year = yr.getFullYear();

        function ShowTime() {
            var dt = new Date();
            var hours = dt.getHours();

            var part = "am";
            if (hours > 12) {
                hours -= 12;
                part = "pm";
            }
            var newtime = +hours + ":" + dt.getMinutes() + part;
            if (dt.getMinutes() < 10) {
                newtime = newtime.replace(":", ":0");
            }
            document.getElementById('<%= textClock.ClientID %>').value = newtime;
            window.setTimeout("ShowTime()", 500);
        }
        function runCode() {
            window.setTimeout("ShowTime()", 1000);
        }

        $('div.row').hide().fadeIn(1000);
        $('#<%=yearLabel.ClientID %>').html('&copy; Alan Robson ' + year);
        $('h2.headerLabel').css('text-align', 'center');
        $('h3.dateLabel').css('text-align', 'center');
        $('h4.clockFace').css('text-align', 'center');
        $('#<%=textClock.ClientID %>').css('text-align', 'center');
        runCode();

    </script>
</asp:Content>
