<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="FindMyBooks.registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">User registration</li>
            </ol>
        </nav>
    </section>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="card mt-3 mb-3">
                    <div class="card-header" style="font-size: larger;">
                        User registration
                    </div>
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge rounded-pill bg-warning mb-2" style="padding: 7px; font-size: 12px;">Personal info</span>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Student first name :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtFirstName" placeHolder="Enter first name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Student last name :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtLastName" placeHolder="Enter last name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label10" runat="server" Text="Phone Number/Username :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPhone" placeHolder="Enter phone number as your username" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label12" runat="server" Text="E-mail :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtEmail" placeHolder="Enter E-mail" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label11" runat="server" Text="Address :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtAddress" placeHolder="Enter address" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                    <span class="badge rounded-pill bg-warning mb-2" style="padding: 7px; font-size: 12px;">Institute info</span>
                                </center>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-9">
                                <asp:Label ID="Label3" runat="server" Text="College name :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtCollege" placeHolder="Enter College name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label4" runat="server" Text="Degree :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlDegree" runat="server">
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
                                <asp:Label ID="Label5" runat="server" Text="Academic Year :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlAcademicYear" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Department :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlDepartment" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%-- <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge rounded-pill bg-warning" style="padding: 7px; font-size: 12px;">Login credentials</span>
                                </center>
                            </div>
                        </div>
                       <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="Label7" runat="server" Text="Username :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtUserName" placeHolder="Enter Username" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label8" runat="server" Text="Password :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPassword" placeHolder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label9" runat="server" Text="Confirm password :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtConPassword" placeHolder="Re-enter Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>

                        <div class="row">
                            <div class="col">
                                <div class="form-group fa-pull-right mt-3">
                                    <%--in-built class for capturing whole width of the container--%>
                                    <asp:Button CssClass="btn btn-success btn-lg" ID="btnRegistration" runat="server" Text="Submit" OnClick="btnRegistration_click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <a href="userLogin.aspx">Already have an account?</a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>