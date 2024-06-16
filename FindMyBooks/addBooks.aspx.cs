using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class addBooks : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //conecting yearID data table to drop down
                FillDDL();
                FillYear();
                FillPublication();
                //conecting tbl_subject_master data table to listbox items.

                ddlAcademicYear.Items.Insert(0, new ListItem("--Select academic year--", "0"));
                ddlBookComment.Items.Insert(0, new ListItem("--Give comment on book--", "0"));
                ddlDeptName.Items.Insert(0, new ListItem("--Select department--", "0"));
                ddlPublicationName.Items.Insert(0, new ListItem("--Select publication--", "0"));
            }
        }

        //add book btn click event.
        //protected void addBtn_Click(object sender, EventArgs e)
        //{

        //    SqlConnection con = new SqlConnection(strcon);
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    for (int i = 0; i < lstSubjectName.Items.Count; i++)

        //    {

        //        if (lstSubjectName.Items[i].Selected == true)

        //        {

        //            SqlCommand cmd = new SqlCommand("insert into tbl_new_book(departmentID, yearID, subjectBook, publicationID, bookCommentID, costBooks, status, comment) " +
        //                "values(@departmentID, @yearID, @subjectBook, @publicationID, @bookCommentID, @costBooks, @status, @comment)", con);

        //            cmd.Parameters.AddWithValue("@departmentID", ddlDeptName.SelectedValue != null ? ddlDeptName.SelectedValue : "");
        //            cmd.Parameters.AddWithValue("@yearID", ddlAcademicYear.SelectedValue != null ? ddlAcademicYear.SelectedValue : ""); 
        //            cmd.Parameters.AddWithValue("@subjectBook", lstSubjectName.Items[i].ToString());
        //            cmd.Parameters.AddWithValue("@publicationID", ddlPublicationName.SelectedValue != null ? ddlPublicationName.SelectedValue : ""); 
        //            cmd.Parameters.AddWithValue("@bookCommentID", ddlBookComment.SelectedValue != null ? ddlBookComment.SelectedValue : "");
        //            cmd.Parameters.AddWithValue("@costBooks", txtCost.Text.Trim());
        //            cmd.Parameters.AddWithValue("@status", txtStatus.Text.Trim()); 
        //            cmd.Parameters.AddWithValue("@comment", txtComment.Text.Trim());

        //            cmd.ExecuteNonQuery();


        //        }

        //    }
        //    con.Close();
        //    Response.Write("<script>alert('Book's added successfully')</script>");

        //}


        protected void addBtn_Click(object sender, EventArgs e)
        {
            insertBook();
        }


        protected void insertBook()
        {
            // Retrieve the userID of the current logged-in user from session variable
            string stdID = Session["stdID"] != null ? Session["stdID"].ToString() : "";

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string departmentID = ddlDeptName.SelectedValue ?? "";
            string yearID = ddlAcademicYear.SelectedValue ?? "";
            string publicationID = ddlPublicationName.SelectedValue ?? "";
            string bookCommentID = ddlBookComment.SelectedValue ?? "";
            string costBooks = txtCost.Text.Trim();
            string status = txtStatus.Text.Trim();
            string comment = txtComment.Text.Trim(); 
            List<string> selectedBooks = new List<string>();

            for (int i = 0; i < lstSubjectName.Items.Count; i++)
            {
                if (lstSubjectName.Items[i].Selected)
                {
                    selectedBooks.Add(lstSubjectName.Items[i].Text);
                }
            }

            if (selectedBooks.Count > 0)
            {
                string subjectBooks = string.Join(",", selectedBooks);

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_new_book(departmentID, yearID, subjectBook, publicationID, bookCommentID, costBooks, status, comment, stdID, date) " +
                    "VALUES(@departmentID, @yearID, @subjectBook, @publicationID, @bookCommentID, @costBooks, @status, @comment, @stdID, @date)", con);

                cmd.Parameters.AddWithValue("@departmentID", departmentID);
                cmd.Parameters.AddWithValue("@yearID", yearID);
                cmd.Parameters.AddWithValue("@subjectBook", subjectBooks);
                cmd.Parameters.AddWithValue("@publicationID", publicationID);
                cmd.Parameters.AddWithValue("@bookCommentID", bookCommentID);
                cmd.Parameters.AddWithValue("@costBooks", costBooks);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@stdID", stdID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy"));


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Books added successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Please select at least one book')</script>");
            }
        }



        protected void ddlDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                ddlAcademicYear.ClearSelection();
                ddlAcademicYear.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillSubject();
            }
            catch(Exception ex) { }
        }


        //user defined functions
        private void FillDDL()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
               
                using (SqlCommand cmd = new SqlCommand("select comment from tbl_comment_book", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlBookComment.DataSource = dt;
                    ddlBookComment.DataValueField = "comment";
                    ddlBookComment.DataBind();
                }
            
                using (SqlCommand cmd = new SqlCommand("select DeptId,deptName from tbl_dept_name", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlDeptName.DataSource = dt;
                    ddlDeptName.DataValueField = "deptid";
                    ddlDeptName.DataTextField = "DeptName";
                    ddlDeptName.DataBind();
                }
            }
        }

        private void FillYear()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select YearID,AcademicYear from YearTable", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlAcademicYear.DataSource = dt;
                    ddlAcademicYear.DataValueField = "YearID";
                    ddlAcademicYear.DataTextField = "AcademicYear";
                    ddlAcademicYear.DataBind();
                }
            }
        }

        private void FillPublication()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select publishID,publicationName from tbl_publication_master", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlPublicationName.DataSource = dt;
                    ddlPublicationName.DataValueField = "publishID";
                    ddlPublicationName.DataTextField = "publicationName";
                    ddlPublicationName.DataBind();
                }
            }
        }

        private void FillSubject()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select subjectID,subjectName from tbl_subject_master where deptID="+ddlDeptName.SelectedValue+ " and yearID="+ddlAcademicYear.SelectedValue, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtsub = new DataTable();
                    da.Fill(dtsub);
                    if (dtsub.Rows.Count > 0)
                    {
                        lstSubjectName.DataSource = dtsub;
                        lstSubjectName.DataValueField = "subjectID";
                        lstSubjectName.DataTextField = "subjectName";
                        lstSubjectName.DataBind();
                    }
                    else
                    {
                        foreach (ListItem listItem in lstSubjectName.Items)
                        {
                            listItem.Selected = false;
                        }
                        lstSubjectName.DataBind();
                    }
                }
            }
        }

    }
}