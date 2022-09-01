﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordList.aspx.cs" Inherits="RecordList.RecordList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/PagerStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-xs-10 col-md-6 center-block">
        <h2 class="headerLabel">RecordDB Management System</h2>
          <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
          <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" BorderStyle="None" ForeColor="#000099" Font="Bold" runat="server"></asp:TextBox></h4>
      <br/>
      <p> <span id="date"></span></p> 
    </div>
  </div>
  <div class="row">
    <div class="col-xs-6 col-md-4 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <h3 class="panel-title">Record List</h3>
        </div>
        <div class="panel-body">
          <div class="form-group">
              <asp:Literal ID="recordLiteral" runat="server"></asp:Literal>            
          </div>
          </div>
          <div class="row">
            <div class="col-xs-6">
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
        <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>
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
