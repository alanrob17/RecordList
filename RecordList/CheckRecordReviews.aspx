﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckRecordReviews.aspx.cs" Inherits="RecordList.CheckRecordReviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/PagerStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div id="main" role="main" class="mainArea"> 
        <div class="table-responsive">
         <asp:GridView ID="recordGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="True" AllowPaging="True" PageSize="30"  DataSourceID="recordDataSource" runat="server">
         </asp:GridView>
    </div>
    <asp:SqlDataSource
        id="recordDataSource"
        ConnectionString="<%$ ConnectionStrings:RecordDB %>"
        SelectCommand="SELECT RecordId,review FROM Record WHERE Review IS NOT NULL OR len(Convert(Varchar(8000), Review)) > 5"
        runat="server"></asp:SqlDataSource>
    </div>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>
