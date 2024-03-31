using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class updateMyBook : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Execute this code only if the page is loaded for the first time
                string bookID = Request.QueryString["bookID"];
                Filldepartment();
                FillYear();
                FillPublication();
                FillBookComment();
                temp(bookID);
                GetBookDetailsById(bookID);
            }
        }

        //event handler for update btn.
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string departmentID = ddlDeptName.SelectedValue ?? "";
            string yearID = ddlAcademicYear.SelectedValue ?? "";
            string publicationID = ddlPublicationName.SelectedValue ?? "";
            string bookCommentID = ddlBookComment.SelectedValue ?? "";
            string costBooks = txtCost.Text.Trim();
            string status = txtStatus.Text.Trim();
            string comment = txtComment.Text.Trim();

            // Get the bookID from the query string
            string bookID = Request.QueryString["bookID"];

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE tbl_new_book SET departmentID = @departmentID, yearID = @yearID, publicationID = @publicationID, bookCommentID = @bookCommentID, costBooks = @costBooks, comment = @comment, date = @date WHERE bookID = @bookID", con))
                {
                    cmd.Parameters.AddWithValue("@departmentID", departmentID);
                    cmd.Parameters.AddWithValue("@yearID", yearID);
                    cmd.Parameters.AddWithValue("@publicationID", publicationID);
                    cmd.Parameters.AddWithValue("@bookCommentID", bookCommentID);
                    cmd.Parameters.AddWithValue("@costBooks", costBooks);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy"));
                    // Add the bookID parameter
                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    //GetBookDetailsById(bookID);
                }
            }
        }






        //user defined functions.
        void GetBookDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open(); // Open connection

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_new_book WHERE bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];

                            ddlDeptName.SelectedValue = row["departmentID"].ToString();
                            ddlAcademicYear.SelectedValue = row["yearID"].ToString();
                            ddlPublicationName.SelectedValue = row["publicationid"].ToString();
                            ddlBookComment.SelectedValue = row["bookcommentid"].ToString();
                            txtCost.Text = row["costBooks"].ToString();
                            txtStatus.Text = row["status"].ToString();
                            txtComment.Text = row["comment"].ToString();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No data found for the specified bookID');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void Filldepartment()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select deptID, deptName from tbl_dept_name", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlDeptName.DataSource = dt;
                    ddlDeptName.DataValueField = "deptID";
                    ddlDeptName.DataTextField = "deptName";
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

        private void FillBookComment()
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
            }
        }


        void temp(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open(); 

                    using (SqlCommand cmd = new SqlCommand("split_subject_names", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        cmd.ExecuteNonQuery();
                    }

                    SqlDataAdapter da = new SqlDataAdapter("SELECT subjectBookList FROM subject_book_list_tbl WHERE bookID = @bookID", con);
                    da.SelectCommand.Parameters.AddWithValue("@bookID", bookID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }

        
    }
}