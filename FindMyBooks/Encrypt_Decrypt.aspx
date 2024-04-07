    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encrypt_Decrypt.aspx.cs" Inherits="FindMyBooks.Encrypt_Decrypt" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <style>
            body{
        background: -webkit-linear-gradient(left, #3ab565, #cfdeb8);
    }
    .contact-form{
        background: #fff;
        margin-top: 10%;
        margin-bottom: 5%;
        width: 70%;
    }
    .contact-form .form-control{
        border-radius:1rem;
    }
    .contact-image{
        text-align: center;
    }
    .contact-image img{
        border-radius: 6rem;
        width: 11%;
        margin-top: -3%;
        transform: rotate(29deg);
    }
    .contact-form form{
        padding: 14%;
    }
    .contact-form form .row{
        margin-bottom: -7%;
    }
    .contact-form h3{
        margin-bottom: 8%;
        margin-top: -10%;
        text-align: center;
        color: #0062cc;
    }
    .contact-form .btnContact {
        width: 50%;
        border: none;
        border-radius: 1rem;
        padding: 1.5%;
        background: #dc3545;
        font-weight: 600;
        color: #fff;
        cursor: pointer;
    }
    .btnContactSubmit
    {
        width: 50%;
        border-radius: 1rem;
        padding: 1.5%;
        color: #fff;
        background-color: #0062cc;
        border: none;
        cursor: pointer;
    }
        </style>
        <title></title>
        <link rel="shortcut icon" href="images/Shree%20Logo%20final.ico"/>
        <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body>
        <div class="container contact-form">
            <form runat="server" id="Form1">
                <h3>Encrypt Decrypt Password</h3>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="txtEncKey" CssClass="form-control" placeholder="Enter Encryption Key" AutoComplete="Off"/>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Your Encryption Key:" ID="lblEnc" CssClass="col-form-label-lg" runat="server" />
                        </div>
                        <div class="form-group">
                            <asp:Button Text="Encrypt Key" runat="server" ID="btnEnc" CssClass="btn btn-info rounded-0" Style="float:left"/>
                        </div>
                    </div>
                    <div class="col-md-6" style="border-left: 2px solid #0074ff;">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="txtDecKey" CssClass="form-control" placeholder="Enter Decryption Key" AutoComplete="Off"/>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Your Decryption Key:" ID="lblDec" CssClass="col-form-label-lg" runat="server" />
                        </div>
                        <div class="form-group">
                            <asp:Button Text="Decrypt Key" runat="server" ID="btnDec" CssClass="btn btn-info rounded-0" Style="float:right"/>
                        </div>
                    </div>

                </div>
            </form>
        </div>
         <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
        <%--<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>

    </body>
    </html>
