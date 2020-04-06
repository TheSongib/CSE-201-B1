<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineClothingStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="width:49%;float:left;">
        <h1>Shop Now!</h1>
        <p class="lead">See what other people are selling</p>
        <p><a href="https://localhost:44330/Buy" class="btn btn-primary btn-lg">Shop here &raquo;</a></p>
    </div>

    <div class="jumbotron" style="width:49%;float:right;">
        <h1>Sell Now!</h1>
        <p class="lead">Sell your items here!</p>
        <p><a href="https://localhost:44330/Sell" class="btn btn-primary btn-lg">Sell now &raquo;</a></p>
    </div>

</asp:Content>
