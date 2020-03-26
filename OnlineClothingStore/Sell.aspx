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
                <input type="text" class="form-control" id="title" name="title">
                <label for="description">Description</label><br />
                <textarea style="vertical-align: middle;" id="description" name="description" rows="5" cols="40">"Put description here."</textarea>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Button id="submit" Text="submit" runat="server" OnClick="Submit_Click"></asp:Button>
    </div>

</asp:Content>

