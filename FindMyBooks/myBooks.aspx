<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="myBooks.aspx.cs" Inherits="FindMyBooks.myBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT * FROM [tbl_new_book]"></asp:SqlDataSource>
    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="bookID" HeaderText="bookID" InsertVisible="False" ReadOnly="True" SortExpression="bookID" />
            <asp:BoundField DataField="subjectBook" HeaderText="subjectBook" SortExpression="subjectBook" />
            <asp:BoundField DataField="publicationID" HeaderText="publicationID" SortExpression="publicationID" />
            <asp:BoundField DataField="bookCommentID" HeaderText="bookCommentID" SortExpression="bookCommentID" />
            <asp:BoundField DataField="costBooks" HeaderText="costBooks" SortExpression="costBooks" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="comment" HeaderText="comment" SortExpression="comment" />
            <asp:ButtonField ControlStyle-CssClass="btn btn-info" Text="Button" />
        </Columns>
    </asp:GridView>
        </div>

</asp:Content>
