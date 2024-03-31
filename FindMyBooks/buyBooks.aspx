<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="buyBooks.aspx.cs" Inherits="FindMyBooks.buyBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <li class="breadcrumb-item active" aria-current="page">Buy Books</li>
            </ol>
        </nav>
    </section>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [subjectBook], [publicationID], [bookCommentID], [costBooks], [departmentID], [yearID] FROM [tbl_new_book]"></asp:SqlDataSource>
    <asp:GridView class="table table-striped table-bordered table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="subjectBook" HeaderText="subjectBook" SortExpression="subjectBook" HeaderStyle-CssClass="GridHeader" />
            <asp:BoundField DataField="costBooks" HeaderText="costBooks" SortExpression="costBooks" HeaderStyle-CssClass="GridHeader" />
            <asp:BoundField DataField="departmentID" HeaderText="departmentID" SortExpression="departmentID" HeaderStyle-CssClass="GridHeader" />
            <asp:BoundField DataField="yearID" HeaderText="yearID" SortExpression="yearID" HeaderStyle-CssClass="GridHeader" />
            <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-block btn-outline-info" />
                        </ItemTemplate>
                    </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
