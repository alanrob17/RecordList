﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordView.aspx.cs" Inherits="RecordList.RecordView" %>
<%@ Import Namespace="RecordList.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/Scripts/GetRecord.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
    <div class="col-xs-12 col-md-6 center-block">
        <h2 class="headerLabel">RecordDB Management System</h2>
          <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
          <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" BorderStyle="None" ForeColor="#000099" Font="Bold" runat="server"></asp:TextBox></h4>    
      <p> <span id="date"></span></p> 
        </div>
        </div>
   <div class="row">
    <div class="col-xs-12 col-md-6 center-block">

            <asp:FormView ID="recordFormView"  DataSourceID="recordObjectDataSource" DataKeyNames="RecordId" AllowPaging="false" runat="server">
                   <ItemTemplate>
                       <tr>
                           <td colspan="2"><h2><%# Eval("ArtistName") %></h2><br/></td>
                       </tr>
                       <tr>
                           <td colspan="2"><h3><%# Eval("Name ") %></h3><br/></td>
                       </tr>
                       <tr>
                           <td colspan="2"><input type="button" class="btn btn-primary" id="biographyButton" value="Biography:" />
                                <div id="biography"><br/><%=ShowBiography() %></div><br/>
                                <br/>
                           </td>
                       </tr>
                       <tr>
                           <td><p><strong>Field: </strong><%# Eval("Field ") %></p><br/></td>
                           <td><p><strong>Recorded: </strong><%# Eval("Recorded") %></p><br/></td>
                       </tr> 
                       <tr>
                           <td><p><strong>Label: </strong><%# Eval("Label") %></p><br/></td>
                           <td><p><strong>Pressing: </strong><span id="pressing"><%# Eval("Pressing") %></span></p><br/></td>                          
                       </tr> 
                       <tr>
                           <td><p><strong>Rating: </strong><span id="rating"><%# Eval("Rating") %></span></p><br/></td>
                           <td><p><strong>Discs: </strong><%# Eval("Discs") %></p><br/></td>
                       </tr> 
                       <tr>
                           <td><p><strong>Media: </strong><span id="media"><%# Eval("Media") %></span></p><br/></td>
                           <td><p><strong>Bought: </strong><%#RecordData.ToShortDate(Eval("Bought")) %></p><br/></td>
                       </tr> 
                       <tr>
                           <td colspan="2"><p><strong>Cost: </strong><%# Eval("Cost", "{0:c}") %></p><br/></td>
                       </tr> 
                       <tr>
                           <td colspan="3"><input type="button" class="btn btn-primary" id="showButton" value="Review:" />
                                <div id="review"><%# "<br/>" + Eval("Review") %></div><br/>
                                <br/>
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2">
                       <asp:Button ID="editButton" CssClass="btn btn-primary" OnClick="editButton_Click" runat="server" Text="Edit" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="homeButton"
                            CssClass="btn btn-primary" 
                            runat="server" 
                            Text="Home"
                            OnClick="homeButton_Click" />  
                               
                           </td>
                       </tr> 
                        
                        <br style="clear:both" />
                    </ItemTemplate>
  
        </asp:FormView>
        </div>
        </div>
  <div class="row">
      <footer>
          <hr />
        <p>Return to the <a href="/default">Main Menu</a></p>
      </footer>
  </div>                     
    <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>   
                <asp:ObjectDataSource ID="recordObjectDataSource" TypeName="RecordList.Data.RecordData" SelectMethod="Select" runat="server">
                    <SelectParameters>                                            
                         <asp:RouteParameter Name="RecordId" RouteKey="rid" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
    <script type="text/javascript">
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

        $('h2.headerLabel').css('text-align', 'center');
        $('h3.dateLabel').css('text-align', 'center');
        $('h4.clockFace').css('text-align', 'center');
        $('#<%=textClock.ClientID %>').css('text-align', 'center');
        runCode();
    </script>
    <script src="/Scripts/GetRecord.js" type="text/javascript"></script>
</asp:Content>
