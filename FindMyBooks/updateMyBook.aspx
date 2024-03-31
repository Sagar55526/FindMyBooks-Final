<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="updateMyBook.aspx.cs" Inherits="FindMyBooks.updateMyBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--    <script type="text/javascript">

       $(document).ready(function () {
           $('#<%=lstSubjectName.ClientID%>').SumoSelect({ okCancelInMulti: true, placeholder: 'Select From below' });
        });


    </script>--%>

     <style>
        .GridHeader
{
    text-align:center !important;    
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page"><a href="myBooks.aspx">My Books</a></li>
                <li class="breadcrumb-item active" aria-current="page">Update Books</li>
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
                                            <div class="col-md-6">
                                                <asp:Label ID="Label2" runat="server" Text="Department/Course Name :"></asp:Label>
                                                <div class="form-group">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlDeptName" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Label ID="Label1" runat="server" Text="Course Year :"></asp:Label>
                                                <div class="form-group">
                                                    <asp:DropDownList CssClass="form-control" ID="ddlAcademicYear" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <%--  <div class="col-md-4">
                                                    <asp:Label ID="Label3" runat="server" Text="Subject Name :"></asp:Label>
                                                    <div class="form-group">
                                                        <asp:ListBox CssClass="form-control" ID="lstSubjectName" SelectionMode="Multiple" runat="server" ></asp:ListBox>
                                                    </div>
                                                </div>--%>
                                        </div>


                                     <%--   <div class="row">
                                            <div class="col-md-6 m-auto">
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT * FROM [subject_book_list_tbl] WHERE bookID = @bookID">
                                                    <SelectParameters>
                                                        <asp:QueryStringParameter Name="bookID" QueryStringField="bookID" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                                <asp:GridView class="table table-striped table-bordered table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="bookID" >
                                                    <Columns>
                                                        <asp:BoundField DataField="subjectBookList" HeaderText="Subject Book List" SortExpression="subjectBookList" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>--%>

                                        <div class="row">
                                            <div class="col-md-8 m-auto">
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [subjectBookList] FROM [subject_book_list_tbl]"></asp:SqlDataSource>
                                                <asp:GridView class="table table-striped table-bordered table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False" >
                                                    <Columns>
                                                        <asp:BoundField DataField="subjectBookList" HeaderText="subjectBookList" SortExpression="subjectBookList" HeaderStyle-CssClass="GridHeader" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>



                                        <div class="row">
                                            <div class="col-md-3">
                                                <asp:Label ID="Label4" runat="server" Text="Publicaion Name :"></asp:Label>
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
                                    <div class="form-group  fa-pull-right">
                                        <%--in-built class for capturing whole width of the container--%>
                                        <asp:Button Class="btn btn-success btn-lg" ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
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
