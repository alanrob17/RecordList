﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteArtist.aspx.cs" Inherits="RecordList.DeleteArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row">
    <div class="col-xs-12 col-md-6 center-block">
      <div class="panel panel-default">
        <div class="panel-heading">
          <h3 class="panel-title">&nbsp;<strong>Delete Artist</strong></h3>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="artistDropDownList" class="control-label col-md-2">
                Select Artist:</label>
              <div class="col-md-8">
                <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control"
                  title="Select Artist"></asp:DropDownList>
              </div>
            </div>
            <asp:Panel ID="editPanel" runat="server">
            <div class="form-group">
              <label class="control-label col-md-4">
                <strong>Delete Artist</strong></label>
            </div>
            <div class="form-group">
              <label for="firstNameLabel" class="control-label col-md-2">
                <strong>First Name:</strong></label>
              <div class="col-md-10">
                <asp:Label ID="firstNameLabel" runat="server"
                  CssClass="form-control"
                  title="First Name"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="lastNameLabel" class="control-label col-md-2">
                <strong>Last Name:</strong></label>
              <div class="col-md-10">
                <asp:Label ID="lastNameLabel" runat="server"
                  CssClass="form-control" 
                  title="Last Name"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="nameLabel" class="control-label col-md-2">
                <strong>Full Name:</strong></label>
              <div class="col-md-10">
                <asp:Label ID="nameLabel" runat="server"
                  CssClass="form-control"
                  title="Full Name"></asp:Label>
              </div>
            </div>
            <div class="form-group">
              <label for="biographyLabel" class="control-label col-md-2">
                <strong>Biography:</strong></label>
              <div class="col-md-12">
                <asp:Label ID="biographyLabel" runat="server"
                    TextMode="MultiLine"
                    CssClass="form-control"
                    Height="360px"
                    title="Biography"></asp:Label>
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
            </asp:Panel>
          </div>
        </div>
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="deleteButton" CssClass="btn btn-danger" runat="server" Text="Delete"
                            CommandName="Delete"
                            OnClientClick="return confirm('This will permanently delete this Artist and all their records. Are you sure you want to do this?');"                            
                            OnCommand="deleteButton_ItemDeleted"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>
             </div>
          </div>
        </div>
      </div>
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
</asp:Content>
