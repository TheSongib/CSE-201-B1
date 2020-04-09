<%@ Page Title="Account Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="OnlineClothingStore.AccountInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-lg">
            <h2>Account Information</h2>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <h2>Name:</h2>
            <p id ="nameInfo" contenteditable="true" runat="server"></p>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <h2>Email:</h2>
            <p id ="emailInfo" contenteditable="true" runat="server"></p>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <h2>Address:</h2>
            <p id ="addressInfo" contenteditable="true" runat="server"></p>
        </div>
    </div>

</asp:Content>

