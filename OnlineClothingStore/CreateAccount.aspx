﻿<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="OnlineClothingStore.CreateAccount" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div id="creatAccount" style="width:50%;float:left;"> 
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <h3>Create Account</h3>
                    <label for="userId">First Name: </label>
                    <br />
                    <asp:TextBox id="firstName" runat="server" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="userId">Last Name: </label>
                    <br />
                    <asp:TextBox id="lastName" runat="server" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="email">Email address</label>
                    <br />
                    <asp:TextBox id="email" runat="server" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="title">Password: </label>
                    <br />
                    <asp:TextBox id="password" runat="server" TextMode="Password" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="title">Address: </label>
                    <br />
                    <asp:TextBox id="address" runat="server" class="form-control input-m"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Button id="submit" Text="Create Account" runat="server" OnClick="Submit_Click" class="btn btn-primary btn-lg"></asp:Button>
        </div>

        <asp:Label ID="existingAccount" runat="server" class="font-weight-bold" />
    </div>

    <div id="login" style="width:50%;float:right;"> 
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
            <asp:Button id="loginSubmit" Text="Login" runat="server" OnClick="Login_Click" class="btn btn-primary btn-lg"></asp:Button>
        </div>

        <asp:Label ID="noMatch" runat="server" class="font-weight-bold" />

    </div>

</asp:Content>

