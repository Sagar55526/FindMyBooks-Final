<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="adminUserProfile.aspx.cs" Inherits="FindMyBooks.adminUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid mt-3">
        <div class="row">
            <div class="col-md-5">
                <%--mx-auto is used to align it in center--%>

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Profile</h4>
                                    <span>Account Status: </span>
                                    <asp:Label ID="Label10" class="badge badge-pill badge-success" runat="server" Text="Active"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
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
                                <asp:Label ID="Label3" runat="server" Text="Phone number :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPhone" placeHolder="Enter phone number" runat="server" TextMode="Phone" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="E-mail :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtEmail" placeHolder="Enter E-mail" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="Label5" runat="server" Text="Address :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtAddress" placeHolder="Enter address" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
<%--                            <div class="col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" class="form-control" placeholder="City" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label7" runat="server" Text="Pin-Code"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" class="form-control" placeholder="Pin-Code" runat="server" TextMode="Number" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>--%>
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
                                <asp:Label ID="Label8" runat="server" Text="College name :"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtCollege" placeHolder="Enter College name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label14" runat="server" Text="Course Year :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlCourseYear" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label9" runat="server" Text="Degree :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDegree" runat="server" Enabled="False">
                                        <asp:ListItem Text="B.Tech" Value="B.Tech"></asp:ListItem>
                                        <asp:ListItem Text="B.Com" Value="B.Com"></asp:ListItem>
                                        <asp:ListItem Text="B.Sc" Value="B.Sc"></asp:ListItem>
                                        <asp:ListItem Text="BA" Value="BA"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <asp:Label ID="Label13" runat="server" Text="Department :"></asp:Label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlDepartment" Enabled="false" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%--<hr />--%>


                        <%-- <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">        
                                      <asp:Button Class="btn btn-success btn-lg btn-block" ID="Button1" runat="server" Text="Update" />
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

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                    <%--    <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" width="100" />
                                </center>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Books</h4>
                                    <asp:Label ID="Label12" class="badge badge-pill badge-info" runat="server" Text="User Books Info"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [subjectBook], [costBooks], [status], [date], [yearID], [bookCommentID] FROM [tbl_new_book]"></asp:SqlDataSource>
                            <asp:GridView class="table table-striped table-bordered gridview2 hover cell-border stripe ui celled table" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="subjectBook" HeaderText="subjectBook" SortExpression="subjectBook" />
                                    <asp:BoundField DataField="bookCommentID" HeaderText="bookCommentID" SortExpression="bookCommentID" />
                                    <asp:BoundField DataField="costBooks" HeaderText="costBooks" SortExpression="costBooks" />
                                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                                    <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
