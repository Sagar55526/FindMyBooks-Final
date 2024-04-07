<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="buyBooks.aspx.cs" Inherits="FindMyBooks.buyBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .GridHeader {
            text-align: center !important;
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

    <asp:sqldatasource id="sqldatasource1" runat="server" connectionstring="<%$ connectionstrings:findmybooksconnectionstring %>" selectcommand="select [subjectbook], [publicationid], [bookcommentid], [costbooks], [departmentid], [yearid], [date] from [tbl_new_book]"></asp:sqldatasource>
    <asp:gridview class="table is-striped table-bordered table-condensed gridview2 hover cell-border stripe ui celled table" id="gridview1" runat="server" autogeneratecolumns="false" >
        <columns>
              <asp:boundfield datafield="date" headertext="Date" sortexpression="date" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="subjectbook" headertext="Subject Book" sortexpression="subjectbook" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="costbooks" headertext="Cost" sortexpression="costbooks" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="yearid" headertext="year" sortexpression="yearid" headerstyle-cssclass="gridheader" />            
          
            <asp:templatefield headertext="View " headerstyle-cssclass="gridheader">
                        <itemtemplate>
                            <asp:button id="btnview" runat="server" text="View " cssclass="btn btn-block btn-outline-info" PostBackUrl='<%# "~/viewBooks.aspx?bookID=" + Eval("bookID") %>' />
                        </itemtemplate>
                    </asp:templatefield>
        </columns>
    </asp:gridview>
 <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js"></script>
    <script>
        $(document).ready(function () {
            $(".gridview2").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        });
    </script>
</asp:Content>
