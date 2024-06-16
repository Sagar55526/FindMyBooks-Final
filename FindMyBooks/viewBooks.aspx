<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="FindMyBooks.viewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .GridHeader {
            text-align: center !important;
        }

        .prevent-select {
            -webkit-user-select: none;
            -ms-user-select: none; 
            user-select: none; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">View Books</li>
            </ol>
        </nav>
    </section>


    <section>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">

                    <div class="card">

                        <div class="card-body">
                            <div class="card">
                                <div class="card-header" style="font-size: larger;">
                                    <center>
                                        Books Details
                                    </center>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label2" runat="server" Text="Department/Course Name :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlDeptName" runat="server" Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label4" runat="server" Text="Publicaion Name :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlPublicationName" runat="server" Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label6" runat="server" Text="Cost :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control prevent-select" ID="txtCost" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label9" runat="server" Text="Comment :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control prevent-select" ID="txtComment" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label1" runat="server" Text="Course Year :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlAcademicYear" runat="server" Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label5" runat="server" Text="Book Printing :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlBookComment" placeHolder="Enter subject name" runat="server" Enabled="False">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label7" runat="server" Text="Status Of Request"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control prevent-select" ID="txtStatus" Text="Available" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [subjectBookList] FROM [subject_book_list_tbl]"></asp:SqlDataSource>
                                    <asp:GridView class="table table-striped table-bordered table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="subjectBookList" HeaderText="Subject Book List" SortExpression="subjectBookList" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card-body">
                        <div class="card">
                            <div class="card-header" style="font-size: larger;">
                                <center>
                                    Book Owner Details
                                </center>
                            </div>
                            <div class="card-body">

                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <span class="badge rounded-pill bg-warning mb-2" style="padding: 7px; font-size: 12px;">Personal Info</span>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label3" runat="server" Text="First Name :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control prevent-select" ID="txtFirstName" placeHolder="Enter first name" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label8" runat="server" Text="Last Name :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control prevent-select" ID="txtLastName" placeHolder="Enter last name" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label10" runat="server" Text="Phone Number :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control prevent-select" ID="txtPhone" placeHolder="Enter phone number" runat="server" TextMode="Phone" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label12" runat="server" Text="E-mail :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control prevent-select" ID="txtEmail" placeHolder="Enter E-mail" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <hr />
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <span class="badge rounded-pill bg-warning mb-2" style="padding: 7px; font-size: 12px;">Institute Info</span>
                                        </center>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-md-9">
                                        <asp:Label ID="Label13" runat="server" Text="College name :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="txtCollege" placeHolder="Enter College name" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label14" runat="server" Text="Degree :"></asp:Label>
                                        <div class="form-group">
                                            <asp:DropDownList CssClass="form-control" ID="ddlDegree" runat="server" Enabled="False">
                                                <asp:ListItem Text="B.Tech" Value="B.Tech"></asp:ListItem>
                                                <asp:ListItem Text="B.Com" Value="B.Com"></asp:ListItem>
                                                <asp:ListItem Text="B.Sc" Value="B.Sc"></asp:ListItem>
                                                <asp:ListItem Text="BA" Value="BA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label15" runat="server" Text="Course Year :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="ddlCourseYear" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label16" runat="server" Text="Department :"></asp:Label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="ddlDepartment" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3 mx-auto">
                            <center>
                                <div class=form-group">
                                    <asp:Button Class="btn btn-success btn-lg btn-block" ID="addBtn" runat="server" Text="Buy" Visible="false" OnClick="addBtn_Click" />
                                </div>
                            </center>
                        </div>
                    </div>


                </div>

                <div>
                    <a href="homepage.aspx"><< Go back to home page</a>
                </div>

            </div>
    </section>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>

<script>
    function OpenPaymentWindow(key, amountInSubunits, currency, name, descritpion, imageLogo, orderId, profileName, profileEmail, profileMobile, notes, bookId) {
        /*alert("Book ID: " + bookId)*/
        notes = $.parseJSON(notes);
        var options = {
            "key": key,
            "amount": amountInSubunits,
            "currency": currency,
            "name": name,
            "description": descritpion,
            "image": imageLogo,
            "order_id": orderId,
            "bookId": bookId, // Pass bookId as a parameter
            "handler": function (response) {
                window.location.href = "paymentSuccessfull.aspx?orderId=" + response.razorpay_order_id + "&paymentId=" + response.razorpay_payment_id + "&bookId=" + bookId;
            },
            "prefill": {
                "name": profileName,
                "email": profileEmail,
                "contact": profileMobile
            },
            "notes": notes,
            "theme": {
                "color": "#F37254"
            }
        };
        var rzp1 = new Razorpay(options);
        rzp1.open();
        rzp1.on('payment.failed', function (response) {
            console.log(response.error);
            window.location.href = "paymentFailed.aspx?orderId=" + response.razorpay_order_id + "&paymentId=" + response.razorpay_payment_id;
        });
    }
</script>


</asp:Content>



