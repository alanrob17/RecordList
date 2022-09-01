﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRecord.aspx.cs" Inherits="RecordList.AddRecord" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-xs-12 col-md-6 center-block">
      <div class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title glyphicon-star">&nbsp;<strong>Add Record</strong></h3>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="artistDropDownList" class="control-label col-md-2">
                Select Artist:</label>
              <div class="col-md-8">
                <asp:DropDownList ID="artistDropDownList" runat="server" OnSelectedIndexChanged="artistDropdownList_SelectedIndexChanged"
                  CssClass="form-control"
                  title="Select Artist"></asp:DropDownList>
              </div>
            </div>            
            <div class="form-group">
              <label class="control-label col-md-12">
                <strong>Add Record</strong></label>
            </div>
            <div class="form-group">
              <label for="nameTextBox" class="control-label col-md-2">
                <strong>Title</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="nameTextBox" runat="server"
                  CssClass="form-control"
                  title="Title"
                  autofocus="autofocus"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="fieldDropDownList" class="control-label col-md-2">Field</label>
              <div class="col-md-4">
                <asp:DropDownList ID="fieldDropDownList" runat="server"				  
                  CssClass="form-control"></asp:DropDownList>
              </div>
              <label for="recordedTextBox" class="control-label col-md-2">Recorded</label>
              <div class="col-md-4">
                <asp:TextBox ID="recordedTextBox" runat="server"
                  CssClass="form-control"
                  title="Recorded"></asp:TextBox>
              </div>
            </div>
           <div class="form-group">
              <label for="labelTextBox" class="control-label col-md-2">Label</label>
              <div class="col-md-4">
                <asp:TextBox ID="labelTextBox" runat="server"
                  CssClass="form-control"
                  title="Label"></asp:TextBox>
              </div>
              <label for="pressingDropDownList" class="control-label col-md-2">Pressing</label>
              <div class="col-md-4">
               <asp:DropDownList ID="pressingDropDownList" runat="server"				  
                  CssClass="form-control"></asp:DropDownList>
              </div>
            </div>
            <div class="form-group">
              <label for="ratingDropDownList" class="control-label col-md-2">Rating</label>
              <div class="col-md-4">
               <asp:DropDownList ID="ratingDropDownList" runat="server"				  
                  CssClass="form-control"></asp:DropDownList>
              </div>
              <label for="discsDropDownList" class="control-label col-md-2">Discs</label>
              <div class="col-md-4">
               <asp:DropDownList ID="discsDropDownList" runat="server"				  
                  CssClass="form-control"></asp:DropDownList>
              </div>
            </div>
           <div class="form-group">
              <label for="mediaDropDownList" class="control-label col-md-2">Media</label>
              <div class="col-md-4">
               <asp:DropDownList ID="mediaDropDownList" runat="server"				  
                  CssClass="form-control"></asp:DropDownList>
              </div>
              <label for="boughtTextBox" class="control-label col-md-2">Bought</label>
              <div class="col-md-4">
                <asp:TextBox ID="boughtTextBox" runat="server"
                  CssClass="form-control"
                  title="Bought"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="costTextBox" class="control-label col-md-2">
                <strong>Cost</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="costTextBox" runat="server"
                  CssClass="form-control"
                  title="Cost"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="coverNameTextBox" class="control-label col-md-2">
                <strong>Cover Name</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="coverNameTextBox" runat="server"
                  CssClass="form-control"
                  title="Cover Name"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <label for="reviewTextBox" class="control-label col-md-2">
                <strong>Review</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="reviewTextBox" runat="server"
                    TextMode="MultiLine"
                  CssClass="form-control fullwidth"
                  title="Review"></asp:TextBox>
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
               <asp:button id="submitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="submitButton_Click"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>
             </div>
          </div>
        </div>
      </div>
    </div>
  </div>
    <div class="row clearfix">
      <p><asp:Label ID="returnValueLabel" runat="server" Text="Label"></asp:Label></p>
      <p><strong><asp:Literal id="reviewLiteral" runat="server"></asp:Literal></strong></p>
    </div>
  <div class="row">
      <footer>
          <hr />
        <p>Return to the <a href="/default">Main Menu</a></p>
      </footer>
  </div>        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>
