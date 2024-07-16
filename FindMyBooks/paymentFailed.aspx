<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="paymentFailed.aspx.cs" Inherits="FindMyBooks.paymentFailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
    <div class="card bg-light mb-3">
        <div class="card-header text-danger" style="font-weight: bolder; font-size: 25px;">
            Payment Failed.!!!
        </div>
        <div class="row">
            <div class="col-md-8">
                <div class="card-body m-auto">
                    <h5 class="card-title">
                        <asp:Label CssClass="align-text-top" runat="server" Text="Your payment against the transaction is failed. Please check all credentials and try again later." /></h5>
                </div>
            </div>
            <div class="col-md-4">
            <div class="card-body m-auto" style="position: relative;">
                <img src="imgs/payment%20failed.gif" style="width: 80%;" />
            </div>

                </div>
            <a class="mb-3 ml-5" href="homePage.aspx">Home</a>
        </div>
    </div>
    </div>

</asp:Content>


