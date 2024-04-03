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

    <asp:sqldatasource id="sqldatasource1" runat="server" connectionstring="<%$ connectionstrings:findmybooksconnectionstring %>" selectcommand="select [subjectbook], [publicationid], [bookcommentid], [costbooks], [departmentid], [yearid] from [tbl_new_book]"></asp:sqldatasource>
    <asp:gridview class="table table-striped table-bordered table-condensed" id="gridview1" runat="server" autogeneratecolumns="false">
        <columns>
            <asp:boundfield datafield="subjectbook" headertext="subject book" sortexpression="subjectbook" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="costbooks" headertext="cost" sortexpression="costbooks" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="departmentid" headertext="department" sortexpression="departmentid" headerstyle-cssclass="gridheader" />
            <asp:boundfield datafield="yearid" headertext="year" sortexpression="yearid" headerstyle-cssclass="gridheader" />
            <asp:templatefield headertext="view" headerstyle-cssclass="gridheader">
                        <itemtemplate>
                            <asp:button id="btnview" runat="server" text="view" cssclass="btn btn-block btn-outline-info" PostBackUrl='<%# "~/viewBooks.aspx?bookID=" + Eval("bookID") %>' />
                        </itemtemplate>
                    </asp:templatefield>
        </columns>
    </asp:gridview>

</asp:Content>
