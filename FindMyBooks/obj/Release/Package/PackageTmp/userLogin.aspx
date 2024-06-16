﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="FindMyBooks.userLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">User Login</li>
            </ol>
        </nav>
    </section>
    <div class="container">
        <div class="row">
            <div class="col-md-6 mb-3 mx-auto">
                <div class="card">
                    <div class="card-header" style="font-size: larger;">
                        User Log-in
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <i class="fa-solid fa-user fa-5x mt-2"></i>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtUserNAme" placeHolder="Username" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPassword" placeHolder="Enter password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Button CssClass="btn btn-success btn-lg fa-pull-right" ID="Button1" runat="server" Text="Log-in" OnClick="Button1_Click" />
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <a href="registration.aspx">New to our platform?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
