<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updateMyBook.aspx.cs" Inherits="FindMyBooks.updateMyBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

       $(document).ready(function () {
           $('#<%=lstSubjectName.ClientID%>').SumoSelect({ okCancelInMulti: true, placeholder: 'Select From below' });
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">My Books</li>
                <li class="breadcrumb-item active" aria-current="page">Update Books</li>
            </ol>
        </nav>
    </section>

    <section>

        <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">      <%--mx-auto is used to align it in center--%>
                 
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                                    <div class="col">
                                        <div class="card mt-3">
                                            <div class="card-header" style="font-size: larger;">
                                                <center>
                                                    Update Books
                                                </center>
                                            </div>
                                        </div>


                                        <div class="container-fluid" id="inputContainer" runat="server">
                                            <div class="row">
                                                <div class="col">
                                                    <center>
                                                        <hr />
                                                    </center>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label2" runat="server" Text="Department/course name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlDeptName" runat="server" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label1" runat="server" Text="course year :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlAcademicYear" runat="server" ></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label3" runat="server" Text="Subject name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:ListBox CssClass="form-control" ID="lstSubjectName" SelectionMode="Multiple" runat="server" ></asp:ListBox>
<%--                                                    <asp:DropDownList CssClass="form-control" ID="ddlSubjectName" runat="server"></asp:DropDownList>--%>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label4" runat="server" Text="Publicaion name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlPublicationName" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label5" runat="server" Text="Book printing :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control" ID="ddlBookComment" placeHolder="Enter subject name" runat="server">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label6" runat="server" Text="Cost :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtCost" placeHolder="Enter Cost for all books together" runat="server" TextMode="Number"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:Label ID="Label7" runat="server" Text="status of request : (By default 'Available')"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:TextBox CssClass="form-control" ID="txtStatus" Text="Available" runat="server" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col">
                                                    <asp:Label ID="Label9" runat="server" Text="Comment :"></asp:Label>
                                                    <div class="form-group">
                                                    <asp:TextBox CssClass="form-control" ID="txtComment" placeholder="Make comments if you want." runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                        </div>
                                    </div>
                            </div>


                        

                        <div class="row">
                            <div class="col-10 mx-auto">
                                <center>
                                    <div class="form-group  fa-pull-right">        <%--in-built class for capturing whole width of the container--%>
                                      <asp:Button Class="btn btn-success btn-lg" ID="addBtn" runat="server" Text="Update" />
                                    </div>
                                 </center>
                            </div>
                        </div>

                    </div>
                </div>

                    <div>
                        <a href="homepage.aspx"><< Go back to home page</a>
                    </div>

            </div>
        </div>
    </div>

    </section>

</asp:Content>
