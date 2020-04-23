<%@ Page Title="Submissions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Submissions.aspx.cs" Inherits="OnlineClothingStore.Submissions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="finished" style="text-align:center;" runat="server">
        <h1>No more submissions waiting for review!</h1>
    </div>

    <div id="review" runat="server">

        <div style="width:100%;float:left">
            <h2>Images: </h2>
            <asp:Literal id="img1" runat="server" />
            <asp:Literal id="img2" runat="server" />
            <asp:Literal id="img3" runat="server" />
            <asp:Literal id="img4" runat="server" />
            <asp:Literal id="img5" runat="server" />
        </div>

        <div style="width:50%;float:left">
            <h2>Title: </h2>
            <p id="title" runat="server" contenteditable="true"></p>
        </div>

        <div style="width:50%;float:right">
            <h2>Author: </h2>
            <p id="author" runat="server" contenteditable="true"></p>
        </div>

        <div style="width:50%;float:left">
            <h2>Price: </h2>
            <p id="price" runat="server" contenteditable="true"></p>
        </div>

        <div style="width:50%;float:right">
            <h2>Category: </h2>
            <p id="category" runat="server" contenteditable="true"></p>
        </div>

        <div>
            <h2>Description: </h2>
            <p id="description" runat="server" contenteditable="true"></p>
        </div>

        <div class="form-group" style="width:50%;float:left;">
                <asp:Button id="decline" Text="Decline Submittion" runat="server" OnClick="Decline_Click" class="btn btn-primary btn-lg" style="margin-top:25px;"></asp:Button>
        </div>

        <div class="form-group" style="width:50%;float:right;">
                <asp:Button id="accept" Text="Accept Submission" runat="server" OnClick="Accept_Click" class="btn btn-primary btn-lg" style="margin-top:25px;"></asp:Button>
        </div>

        
    </div>

</asp:Content>

