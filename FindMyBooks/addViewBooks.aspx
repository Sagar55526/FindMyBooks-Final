<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="addViewBooks.aspx.cs" Inherits="FindMyBooks.addViewBooks" EnableViewState="true" %>

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
                <li class="breadcrumb-item active" aria-current="page">Books inventory</li>
            </ol>
        </nav>
    </section>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">

                <div class="tabbable-panel mb-3">
                    <div class="tabbable-line">
                        <ul class="nav nav-tabs">
                            <li class="active">
                                <a class="p-5" href="#tab_default_1" data-toggle="tab">View available books </a>
                            </li>
                            <li>
                                <a href="#tab_default_2" data-toggle="tab">Add books
                                </a>
                            </li>
                        </ul>
                        <div class="tab-content">

                            <%-- View books section is as follows --%>
                            <div class="tab-pane" id="tab_default_1">
                                <p>
                                    Tab 1.
                                </p>
                                <p>
                                    lorem
                                </p>
                            </div>
                            <%-- View books END --%>

                            <%-- Add books section is as follows --%>
                            <div class="tab-pane active" id="tab_default_2">


                                <div class="row">
                                    <div class="col">
                                        <div class="card mt-3">
                                            <div class="card-header" style="font-size: larger;">
                                                Add Books
                                            </div>
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <div class="form-control">
                                                            <asp:RadioButton value="1" ID="radiobtnSingleBook" runat="server" GroupName="bookType" OnCheckedChanged="radiobtnSingleBook_CheckedChanged" AutoPostBack="true" />
                                                            <asp:Label runat="server" Text="Single book"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div>
                                                            <div class="form-control">
                                                                <asp:RadioButton value="2" ID="radbtnManyBook" runat="server" GroupName="bookType" OnCheckedChanged="radbtnmanybook_checkedchanged" AutoPostBack="true" />
                                                                <asp:Label runat="server" Text="Multiple book"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <div class="form-group">
                                                            <asp:TextBox CssClass="form-control" ID="txtTotalBooks" PlaceHolder="Enter number of books want to add." runat="server" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>


                                        <div class="container-fluid" id="inputContainer" style="visibility:hidden;" runat="server">
                                            <div class="row">
                                                <div class="col">
                                                    <center>
                                                        <hr />
                                                    </center>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label1" runat="server" Text="course year :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlAcademicYear" placeHolder="Enter course year" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:Label ID="Label2" runat="server" Text="Department/course name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlDeptName" placeHolder="Enter department name" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <asp:Label ID="Label3" runat="server" Text="Subject name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtSubjectName" placeHolder="Enter subject name" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <asp:Label ID="Label4" runat="server" Text="Publicaion name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtPublication" placeHolder="Enter publicaion name" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label5" runat="server" Text="Book printing :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlBookComment" placeHolder="Enter subject name" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label6" runat="server" Text="Cost :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtCost" placeHolder="Enter Cost" runat="server" TextMode="Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label7" runat="server" Text="status of request : (By default 'Available')"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtStatus" Text="Available" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <asp:Label ID="Label8" runat="server" Text="Image of book :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:FileUpload CssClass="form-control" ID="FileUploadImg" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <div class="form-group fa-pull-right mt-3">
                                                        <asp:Button CssClass="btn btn-success btn-lg" ID="btnReAddBook" runat="server" Text="Add book" OnClick="btnAddBook_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                        </div>


                    </div>
                    <%-- Add books END --%>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

