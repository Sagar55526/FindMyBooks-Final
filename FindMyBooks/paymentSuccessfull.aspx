<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="paymentSuccessfull.aspx.cs" Inherits="FindMyBooks.paymentSuccessfull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header text-success" style="font-weight: bolder; font-size: 25px;">
                        Payment Successfull.!!!
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-7">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label runat="server" Text="Your payment against the transaction is successful. Please note the Order-Id for future reference." />
                            </div>
                        </div>
                        
                            
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-12">
                                        <label runat="server">Order Id :</label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:Label runat="server" ID="lblOrderId" Font-Bold="True" Font-Size="Larger" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-2">
                                        <label runat="server">Payment Id :</label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:Label runat="server" ID="lblPaymentId" Font-Bold="True" Font-Size="Larger" />
                                    </div>
                                </div>
                            </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-2">
                                            <label runat="server">Book Id :</label>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Label runat="server" ID="lblBookId" Font-Bold="True" Font-Size="Larger" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="row">
                                    <div class="col-md-12">
                                    <img src="imgs/payment%20success.gif" />
                                </div>
                            </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

