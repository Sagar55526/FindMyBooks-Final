<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="FindMyBooks.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container-fluid {
            width: 100%;
            padding: 0;
            margin: 0;
        }

        .row {
            display: flex;
            justify-content: center;
        }

        .col {
            text-align: center;
        }

        img {
            max-width: 100%;
            height: 100%;
        }

        .overlay-buttons {
            position: absolute;
            top: 65%;
            left: 10%;
            transform: translate(-10%, -30%);
            text-align: center;
        }

        .card-inside {
            color: black;
        }

            .card-inside:hover {
                color: white;
                background-color: black;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <img src="imgs/BooksTree.png" />
                    <div class="overlay-buttons">
                        <div class="row">
                            <div class="col col-md-6">
                                <asp:Button Class="btn btn-outline-success btn-block btn-lg m-3" ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" Visible="True" />
                            </div>
                            <div class="col col-md-6">
                                <asp:Button Class="btn btn-outline-success btn-block btn-lg m-3" ID="Button2" runat="server" Text="Log In" OnClick="Button2_Click" Visible="True" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="container mt-5">
            <div class="card card-outside">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col">
                                    <h1>FindMyBooks</h1>
                                    <h3>at a glance</h3>
                                </div>
                            </div>
                            <div class="row ml-5">
                                <p>
                                    Serving hundreds of students every year, we help students buy, sell & share there 
                            books. Our student-to-student book trading platform offer easier than ever ways for students to trade.
                                </p>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <div class="card mb-3 ml-5 card-inside" style="max-width: 18rem;">
                                        <div class="card-body">
                                            <h1>
                                                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label></h1>
                                            <p class="mt-3">Number of transactions of books through our 'FindMyBooks'</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:Button Class="btn btn-outline-success btn-block btn-lg mb-5" ID="Button3" runat="server" Text="Try now" OnClick="Button3_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <img src="imgs/men&women.jpg" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
