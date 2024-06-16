<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="userListAdmin.aspx.cs" Inherits="FindMyBooks.userListAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mt-3">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:FindMyBooksConnectionString %>" SelectCommand="SELECT [stdID], [stdEmail], [stdPhoneNo], [stdFirstName], [stdLastName], [status] FROM [tbl_user_master]"></asp:SqlDataSource>
        <asp:GridView class="table table-striped table-bordered gridview2 hover cell-border stripe ui celled table" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="stdID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="stdID" HeaderText="User ID" InsertVisible="False" ReadOnly="True" SortExpression="stdID" />
                <asp:BoundField DataField="stdFirstName" HeaderText="First Name" SortExpression="stdFirstName" />
                <asp:BoundField DataField="stdLastName" HeaderText="Last Name" SortExpression="stdLastName" />
                <asp:BoundField DataField="stdEmail" HeaderText="Email" SortExpression="stdEmail" />
                <asp:BoundField DataField="stdPhoneNo" HeaderText="Phone No." SortExpression="stdPhoneNo" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:TemplateField HeaderText="View " HeaderStyle-CssClass="gridheader">
                <ItemTemplate>
                    <asp:Button ID="btnProfile" runat="server" Text="Profile" CssClass="btn btn-block btn-outline-info" PostBackUrl='<%# "~/adminUserProfile.aspx?stdID=" + Eval("stdID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


         <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js"></script>
    <script>
        $(document).ready(function () {
            $(".gridview2").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>

</asp:Content>
