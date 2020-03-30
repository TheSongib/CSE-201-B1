<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="OnlineClothingStore.Sell" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sell</h2>
    <h3>Put an item for sale here: </h3>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="userId">Name</label>
                <asp:TextBox id="userId" runat="server"></asp:TextBox>
                <label for="email">Email address</label>
                <asp:TextBox id="email" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="title">Listing Title: </label>
                <asp:TextBox id="listingTitle" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="Price">Listing Price: </label>
                <asp:TextBox id="Price" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="category">Category: </label>
                <asp:TextBox id="Category" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="description">Description</label><br />
                <asp:TextBox style="vertical-align: middle;" id="Description" TextMode="MultiLine" Height="400px" Width="400px" runat="server">"Put description here."</asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="image"> Drag images here: </label>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Button id="submit" Text="submit" runat="server" OnClick="Submit_Click"></asp:Button>
    </div>

</asp:Content>

