<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="OnlineClothingStore.Sell" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-lg">
            <h2>Sell</h2>
             <h3>Put an item for sale here: </h3>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="title">Title: </label>
                <asp:TextBox id="listingTitle" runat="server" class="form-control input-m" required="required"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="Price">Listing Price: </label>
                <asp:TextBox id="Price" runat="server" class="form-control input-m" required="required"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="category">Category: </label>
                <asp:TextBox id="Category" runat="server" class="form-control input-m" required="required"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="description">Description</label><br />
                <asp:TextBox style="vertical-align: middle;" id="Description" TextMode="MultiLine" Height="400px" Width="400px" runat="server" placeholder="Describe item here"></asp:TextBox>
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
        <asp:Button id="submit" Text="Submit" runat="server" OnClick="Submit_Click" class="btn btn-primary btn-lg" style="margin-left:85px"></asp:Button>
    </div>

</asp:Content>

