<%@ Page Title="Account Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="OnlineClothingStore.AccountInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="info" style="width:50%;float:left;">
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
    </div>

    <div id ="adminStuff" style="width:50%;float:right;" runat="server">
        <h3>Promote to Admin</h3>
        <label for="email">Enter email address of to-be admin: </label>
        <br />
        <asp:TextBox id="promote" runat="server" class="form-control input-m" required="required"></asp:TextBox>
        <br />
        <div class="form-group">
            <asp:Button id="promoteSubmit" Text="Promote" runat="server" OnClick="Promote_Click" class="btn btn-primary btn-lg" style="margin-left:50px"></asp:Button>
        </div>
        <asp:Label ID="passOrFail" runat="server" class="font-weight-bold" />
    </div>

</asp:Content>

