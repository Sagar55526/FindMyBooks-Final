<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="myBooks.aspx.cs" Inherits="FindMyBooks.myBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mt-3">
                <li class="breadcrumb-item"><a href="homePage.aspx">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">My Books</li>
            </ol>
        </nav>
    </section>

    <section>
        <div class="card mt-3 mb-3">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT * FROM [tbl_new_book]"></asp:SqlDataSource>
            <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="bookID" HeaderText="bookID" InsertVisible="False" ReadOnly="True" SortExpression="bookID" />
                    <asp:BoundField DataField="subjectBook" HeaderText="subjectBook" SortExpression="subjectBook" />
                    <asp:BoundField DataField="publicationID" HeaderText="publicationID" SortExpression="publicationID" />
                    <asp:BoundField DataField="bookCommentID" HeaderText="bookCommentID" SortExpression="bookCommentID" />
                    <asp:BoundField DataField="costBooks" HeaderText="costBooks" SortExpression="costBooks" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
                    <asp:TemplateField HeaderText="Update/View">
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update/View" CssClass="btn btn-outline-info" PostBackUrl='<%# "~/updateMyBook.aspx?bookID=" + Eval("bookID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </section>

</asp:Content>
