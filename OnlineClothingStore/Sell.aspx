<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="OnlineClothingStore.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Put an item for sale here: </h3>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="userId">Name</label>
                <input type="text" class="form-control" id="userId" name="uid">
                <label for="email">Email address</label>
                <input type="email" class="form-control" id="email" name="email">
            </div>
        </div>
    </div>


    <div class="form-group">
        <label for="title">Listing Title: </label>
        <input type="text" class="form-control" id="title" name="title">
        <label for="description">Description</label><br />
        <textarea style="vertical-align: middle;" id="description" name="description" rows="5" cols="40">"Put description here."</textarea>

    </div>

</asp:Content>

