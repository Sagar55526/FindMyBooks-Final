<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="FindMyBooks.viewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .GridHeader {
            text-align: center !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><a href="buyBooks.aspx">Buy Books</a></li>
                <li class="breadcrumb-item active" aria-current="page">View Books</li>
            </ol>
        </nav>
    </section>


    <section>

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <%--mx-auto is used to align it in center--%>

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
                                                <asp:DropDownList CssClass="form-control" ID="ddlDeptName" runat="server"  Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label4" runat="server" Text="Publicaion Name :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlPublicationName" runat="server"  Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label6" runat="server" Text="Cost :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtCost" placeHolder="Enter Cost for all books together" runat="server" TextMode="Number" ReadOnly="True" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label9" runat="server" Text="Comment :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtComment" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col">
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label1" runat="server" Text="Course Year :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlAcademicYear" runat="server"  Enabled="False"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label5" runat="server" Text="Book Printing :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlBookComment" placeHolder="Enter subject name" runat="server"  Enabled="False">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="Label7" runat="server" Text="Status Of Request"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="txtStatus" Text="Available" runat="server" ReadOnly="True"></asp:TextBox>
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
                                                <asp:TextBox class="form-control" ID="txtFirstName" placeHolder="Enter first name" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="Label8" runat="server" Text="Last Name :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox class="form-control" ID="txtLastName" placeHolder="Enter last name" runat="server" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Label ID="Label10" runat="server" Text="Phone Number :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox class="form-control" ID="txtPhone" placeHolder="Enter phone number" runat="server" TextMode="Phone" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="Label12" runat="server" Text="E-mail :"></asp:Label>
                                            <div class="form-group">
                                                <asp:TextBox class="form-control" ID="txtEmail" placeHolder="Enter E-mail" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
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
                                                <asp:DropDownList class="form-control" ID="ddlCourseYear" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="Label16" runat="server" Text="Department :"></asp:Label>
                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control" ID="ddlDepartment" Enabled="false" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">
                                            <div class="form-group fa-pull-right mt-3">
                                                <%--in-built class for capturing whole width of the container--%>
                                                <asp:Button CssClass="btn btn-success btn-lg" ID="btnRegistration" runat="server" Text="Update" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                        <%--<div class="row">
                            <div class="col-10 mx-auto">
                                <center>
                                    <div class="form-group  fa-pull-right">
                                        <asp:Button Class="btn btn-success btn-lg" ID="addBtn" runat="server" Text="Add Book" />
                                    </div>
                                </center>
                            </div>
                        </div>--%>
                    </div>
                </div>

                <div>
                    <a href="homepage.aspx"><< Go back to home page</a>
                </div>

            </div>
    </section>

</asp:Content>



