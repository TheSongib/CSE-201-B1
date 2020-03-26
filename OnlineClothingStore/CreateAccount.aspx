<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="OnlineClothingStore.CreateAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sell</h2>
    <h3>Create Account: </h3>
    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="userId">First Name: </label>
                <asp:TextBox id="firstName" runat="server"></asp:TextBox>
                <label for="userId">Last Name: </label>
                <asp:TextBox id="lastName" runat="server"></asp:TextBox>
                <label for="email">Email address</label>
                <asp:TextBox id="email" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="title">Address: </label>
                <asp:TextBox id="address" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <asp:Button id="submit" Text="submit" runat="server" OnClick="Submit_Click"></asp:Button>
    </div>

</asp:Content>

