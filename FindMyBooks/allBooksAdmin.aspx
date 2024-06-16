<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="allBooksAdmin.aspx.cs" Inherits="FindMyBooks.allBooksAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [subjectBook], [status], [date], [bookID] FROM [tbl_new_book]"></asp:SqlDataSource>
    <asp:GridView class="table table-striped table-bordered gridview2 hover cell-border stripe ui celled table" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="bookID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="bookID" HeaderText="bookID" InsertVisible="False" ReadOnly="True" SortExpression="bookID" />
            <asp:BoundField DataField="subjectBook" HeaderText="subjectBook" SortExpression="subjectBook" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
            <asp:TemplateField HeaderText="View " HeaderStyle-CssClass="gridheader">
                <ItemTemplate>
                    <asp:Button ID="btnview" runat="server" Text="View " CssClass="btn btn-block btn-outline-info" PostBackUrl='<%# "~/viewBooks.aspx?bookID=" + Eval("bookID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete " HeaderStyle-CssClass="gridheader">
                <ItemTemplate>
                    <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btn btn-block btn-outline-danger" OnClick="btndelete_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
