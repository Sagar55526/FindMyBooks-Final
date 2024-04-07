<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="FindMyBooks.userProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .tabbable-panel {
            border: 1px solid #eee;
            padding: 10px;
        }

        .tabbable-line > .nav-tabs {
            border: none;
            margin: 0px;
        }

            .tabbable-line > .nav-tabs > li {
                margin-right: 2px;
            }

                .tabbable-line > .nav-tabs > li > a {
                    border: 0;
                    margin-right: 0;
                    color: #737373;
                }

                    .tabbable-line > .nav-tabs > li > a > i {
                        color: #a6a6a6;
                    }

                .tabbable-line > .nav-tabs > li.open, .tabbable-line > .nav-tabs > li:hover {
                    border-bottom: 4px solid rgb(80,144,247);
                }

                    .tabbable-line > .nav-tabs > li.open > a, .tabbable-line > .nav-tabs > li:hover > a {
                        border: 0;
                        background: none !important;
                        color: #333333;
                    }

                        .tabbable-line > .nav-tabs > li.open > a > i, .tabbable-line > .nav-tabs > li:hover > a > i {
                            color: #a6a6a6;
                        }

                    .tabbable-line > .nav-tabs > li.open .dropdown-menu, .tabbable-line > .nav-tabs > li:hover .dropdown-menu {
                        margin-top: 0px;
                    }

                .tabbable-line > .nav-tabs > li.active {
                    border-bottom: 4px solid #32465B;
                    position: relative;
                }

                    .tabbable-line > .nav-tabs > li.active > a {
                        border: 0;
                        color: #333333;
                    }

                        .tabbable-line > .nav-tabs > li.active > a > i {
                            color: #404040;
                        }

        .tabbable-line > .tab-content {
            margin-top: -3px;
            background-color: #fff;
            border: 0;
            border-top: 1px solid #eee;
            padding: 15px 0;
        }

        .portlet .tabbable-line > .tab-content {
            padding-bottom: 0;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">User profile</li>
            </ol>
        </nav>
    </section>
        <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="card mt-3 mb-3">
                    <div class="card-header" style="font-size: larger;">
                        User profile
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
                                    <asp:TextBox class="form-control" ID="txtFirstName" placeHolder="Enter first name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Student last name :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtLastName" placeHolder="Enter last name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label10" runat="server" Text="Phone number :"></asp:Label>
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
                            <div class="col-md-12">
                                <asp:Label ID="Label11" runat="server" Text="Address :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtAddress" placeHolder="Enter address" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
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
                                    <asp:TextBox class="form-control" ID="txtCollege" placeHolder="Enter College name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label4" runat="server" Text="Degree :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList cssClass="form-control" ID="ddlDegree"  runat="server" Enabled="False">
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
                                <asp:Label ID="Label5" runat="server" Text="Course Year :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlCourseYear" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Department :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList cssClass="form-control" ID="ddlDepartment" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%--<div class="row">
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
                                    <asp:Button CssClass="btn btn-success btn-lg" ID="btnRegistration" runat="server" Text="Update" OnClick="btnRegistration_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
