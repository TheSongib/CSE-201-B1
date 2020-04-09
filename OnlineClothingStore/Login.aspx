<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineClothingStore.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="login" style="width:50%;float:left;"> 
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <h3>Login</h3>
                    <label for="email">Email address</label>
                    <br />
                    <asp:TextBox id="loginEmail" runat="server" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="title">Password: </label>
                    <br />
                    <asp:TextBox id="loginPassword" runat="server" TextMode="Password" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Button id="loginSubmit" Text="Login" runat="server" OnClick="Login_Click" class="btn btn-primary btn-lg" style="margin-left:50px"></asp:Button>
        </div>

        <asp:Label ID="noMatch" runat="server" class="font-weight-bold" />

    </div>

</asp:Content>

