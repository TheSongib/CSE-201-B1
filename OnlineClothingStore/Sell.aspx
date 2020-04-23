<%@ Page Title="Sell" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="OnlineClothingStore.Sell" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div class="col-lg">
            <h2>Sell</h2>
             <h3>Put an item for sale here: </h3>
        </div>
    </div>

    <div class="form-group">
        <asp:Label id="Error" Text="" style="color:Red;" runat="server"/>
    </div>

    <div class="row">
        <div class="col-lg">
            <div class="form-group">
                <label for="image"> Select Image Files (Up to 5): </label>
                    <asp:FileUpload ID= "image1" runat = "server" />
                    <asp:RegularExpressionValidator id="image1Validator" text="Not a valid image file (*.png, *.jpg, or *.jpeg)" errormessage="Not a valid image file (*.png, *.jpg, or *.jpeg)" ControlToValidate="image1" ValidationExpression="^.*\.(png|PNG|jpg|JPG|JPEG|jpeg)$" runat="server" />
                    <asp:FileUpload ID= "image2" runat = "server" />
                    <asp:RegularExpressionValidator id="image2Validator" text="Not a valid image file (*.png, *.jpg, or *.jpeg)" errormessage="Not a valid image file (*.png, *.jpg, or *.jpeg)" ControlToValidate="image2" ValidationExpression="^.*\.(png|PNG|jpg|JPG|JPEG|jpeg)$" runat="server" />
                    <asp:FileUpload ID= "image3" runat = "server" />
                    <asp:RegularExpressionValidator id="image3Validator" text="Not a valid image file (*.png, *.jpg, or *.jpeg)" errormessage="Not a valid image file (*.png, *.jpg, or *.jpeg)" ControlToValidate="image3" ValidationExpression="^.*\.(png|PNG|jpg|JPG|JPEG|jpeg)$" runat="server" />
                    <asp:FileUpload ID= "image4" runat = "server" />
                    <asp:RegularExpressionValidator id="image4Validator" text="Not a valid image file (*.png, *.jpg, or *.jpeg)" errormessage="Not a valid image file (*.png, *.jpg, or *.jpeg)" ControlToValidate="image4" ValidationExpression="^.*\.(png|PNG|jpg|JPG|JPEG|jpeg)$" runat="server" />
                    <asp:FileUpload ID= "image5" runat = "server" />
                    <asp:RegularExpressionValidator id="iamge5Validator" text="Not a valid image file (*.png, *.jpg, or *.jpeg)" errormessage="Not a valid image file (*.png, *.jpg, or *.jpeg)" ControlToValidate="image5" ValidationExpression="^.*\.(png|PNG|jpg|JPG|JPEG|jpeg)$" runat="server" />
            </div>
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
                <asp:DropDownList id="Category" runat="server" class="form-control input-m" required="required">
                    <asp:ListItem Text="Clothing" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Technology" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Furniture" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Outdoor Item" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Other" Value="5"></asp:ListItem>
                </asp:DropDownList>
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

    

    <div class="form-group">
        <asp:Button id="submit" Text="Submit" runat="server" OnClick="Submit_Click" class="btn btn-primary btn-lg" style="margin-left:85px"></asp:Button>
    </div>

</asp:Content>

