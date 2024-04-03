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
    public partial class viewBooks : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Execute this code only if the page is loaded for the first time
                string bookID = Request.QueryString["bookID"]; 
                //string stdID = Request.QueryString["stdID"];
                getSubjectList(bookID);
                getBookDetailsById(bookID);
                getMemberDetailsById(bookID);
                FillBookComment();
                Filldepartment();
                FillYear();
                FillPublication();
            }
        }

        //user defined functions.
        void getSubjectList(string bookID)
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

        void getBookDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_new_book where bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ddlDeptName.Text = dt.Rows[0]["departmentID"].ToString();
                        ddlPublicationName.Text = dt.Rows[0]["publicationID"].ToString();
                        txtCost.Text = dt.Rows[0]["costBooks"].ToString();
                        ddlAcademicYear.Text = dt.Rows[0]["yearID"].ToString();
                        ddlBookComment.Text = dt.Rows[0]["bookCommentID"].ToString();
                        txtStatus.Text = dt.Rows[0]["status"].ToString();
                        txtComment.Text = dt.Rows[0]["comment"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getMemberDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    Int32 stdID = 0;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using(SqlCommand cmd = new SqlCommand("select stdID from tbl_new_book where bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        try
                        {
                            con.Open();
                            stdID = (Int32)cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    //using (SqlCommand cmd = new SqlCommand("select * from tbl_user_master where stdID = @stdID", con))
                    //{
                    //    cmd.Parameters.AddWithValue("@stdID", stdID);
                    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //    DataTable dt = new DataTable();
                    //    da.Fill(dt);

                    //    txtFirstName.Text = dt.Rows[0]["stdFirstName"].ToString();
                    //    txtLastName.Text = dt.Rows[0]["stdLastName"].ToString();
                    //    txtPhone.Text = dt.Rows[0]["stdPhoneNo"].ToString();
                    //    txtEmail.Text = dt.Rows[0]["stdEmail"].ToString();
                    //    txtCollege.Text = dt.Rows[0]["stdCollege"].ToString();
                    //    ddlDegree.Text = dt.Rows[0]["stdDegree"].ToString();
                    //    ddlCourseYear.Text = dt.Rows[0]["stdYear"].ToString();
                    //    ddlDepartment.Text = dt.Rows[0]["stdDept"].ToString();
                    //}
                    if (stdID != 0)
                    {
                        // Execute the query to fetch data from tbl_user_master only if stdID is not 0
                        using (SqlCommand cmd = new SqlCommand("select * from tbl_user_master where stdID = @stdID", con))
                        {
                            cmd.Parameters.AddWithValue("@stdID", stdID);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                txtFirstName.Text = dt.Rows[0]["stdFirstName"].ToString();
                                txtLastName.Text = dt.Rows[0]["stdLastName"].ToString();
                                txtPhone.Text = dt.Rows[0]["stdPhoneNo"].ToString();
                                txtEmail.Text = dt.Rows[0]["stdEmail"].ToString();
                                txtCollege.Text = dt.Rows[0]["stdCollege"].ToString();
                                ddlDegree.Text = dt.Rows[0]["stdDegree"].ToString();
                                ddlCourseYear.Text = dt.Rows[0]["stdYear"].ToString();
                                ddlDepartment.Text = dt.Rows[0]["stdDept"].ToString();
                            }
                            else
                            {
                                // Handle case when no rows are returned
                                Response.Write("<script>alert('No data found for stdID: " + stdID + "');</script>");
                            }
                        }
                    }
                    else
                    {
                        // Handle case when stdID is 0
                        Response.Write("<script>alert('Invalid stdID');</script>");
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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

    }
}