﻿using System;
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
    public partial class addViewBooks : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {



                //conecting yearID data table to drop down
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select AcademicYear from YearTable", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAcademicYear.DataSource = dt;
                        ddlAcademicYear.DataValueField = "AcademicYear";
                        ddlAcademicYear.DataBind();
                    }
                }
                //conecting tbl_comment_bool data table to drop down
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
                //conecting tbl_dept_name data table to drop down
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select deptName from tbl_dept_name", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDeptName.DataSource = dt;
                        ddlDeptName.DataValueField = "deptName";
                        ddlDeptName.DataBind();
                    }
                }
                ddlAcademicYear.Items.Insert(0, new ListItem("--Select academic year--", "0"));
                ddlBookComment.Items.Insert(0, new ListItem("--Give comment on book--", "0"));
                ddlDeptName.Items.Insert(0, new ListItem("--Select department--", "0"));
            }

        }

        //for radio buttons controls.
        protected void radiobtnSingleBook_CheckedChanged(object sender, EventArgs e)
        {
            txtTotalBooks.Text = "1";
            txtTotalBooks.ReadOnly = true;
            inputContainer.Attributes["style"] = "visibility:visible;";
        }

        //protected void radbtnManyBook_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtTotalBooks.Text = "";
        //    txtTotalBooks.ReadOnly = false;
        //    int totalBooks;
        //    if (int.TryParse(txtTotalBooks.Text, out totalBooks))
        //    {
        //        // Clear existing controls
        //        inputContainer.Controls.Clear();
        //        for (int i = 0; i < totalBooks; i++)
        //        {
        //            // Create a new instance of inputContainer div
        //            var newContainer = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
        //            newContainer.Attributes["class"] = "container-fluid";
        //            newContainer.Attributes["id"] = "inputContainer" + i;
        //            newContainer.Attributes["style"] = "visibility: visible;"; // Show each new container

        //            // Add your existing ASP.NET controls within the newContainer div
        //            newContainer.Controls.Add(new Label() { Text = "Book Title:", AssociatedControlID = "txtBookTitle" + i });

        //            var txtBookTitle = new TextBox();
        //            txtBookTitle.ID = "txtBookTitle" + i;
        //            newContainer.Controls.Add(txtBookTitle);

        //            // Add your existing ASP.NET controls within the newContainer div
        //            newContainer.InnerHtml = @"
        //        <div class='row'>
        //            <div class='col'>
        //                <center>
        //                    <hr />
        //                </center>
        //            </div>
        //        </div>
        //        <div class='row'>
        //            <div class='col-md-4'>
        //                <asp:Label ID='Label1' runat='server' Text='course year:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:DropDownList CssClass='form-control' ID='ddlAcademicYear" + i + @"' placeHolder='Enter course year' runat='server'></asp:DropDownList>
        //                </div>
        //            </div>
        //            <div class='col-md-8'>
        //                <asp:Label ID='Label2' runat='server' Text='Department/course name:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:DropDownList CssClass='form-control' ID='ddlDeptName" + i + @"' placeHolder='Enter department name' runat='server'></asp:DropDownList>
        //                </div>
        //            </div>
        //        </div>
        //        <div class='row'>
        //            <div class='col-md-6'>
        //                <asp:Label ID='Label3' runat='server' Text='Subject name:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:TextBox CssClass='form-control' ID='txtSubjectName" + i + @"' placeHolder='Enter subject name' runat='server'></asp:TextBox>
        //                </div>
        //            </div>
        //            <div class='col-md-6'>
        //                <asp:Label ID='Label4' runat='server' Text='Publication name:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:TextBox CssClass='form-control' ID='txtPublication" + i + @"' placeHolder='Enter publication name' runat='server'></asp:TextBox>
        //                </div>
        //            </div>
        //        </div>
        //        <div class='row'>
        //            <div class='col-md-4'>
        //                <asp:Label ID='Label5' runat='server' Text='Book printing:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:DropDownList CssClass='form-control' ID='ddlBookComment" + i + @"' placeHolder='Enter subject name' runat='server'></asp:DropDownList>
        //                </div>
        //            </div>
        //            <div class='col-md-4'>
        //                <asp:Label ID='Label6' runat='server' Text='Cost:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:TextBox CssClass='form-control' ID='txtCost" + i + @"' placeHolder='Enter Cost' runat='server' TextMode='Number'></asp:TextBox>
        //                </div>
        //            </div>
        //            <div class='col-md-4'>
        //                <asp:Label ID='Label7' runat='server' Text='Status of request: (By default 'Available')'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:TextBox CssClass='form-control' ID='txtStatus" + i + @"' Text='Available' runat='server' ReadOnly='True'></asp:TextBox>
        //                </div>
        //            </div>
        //        </div>
        //        <div class='row'>
        //            <div class='col'>
        //                <asp:Label ID='Label8' runat='server' Text='Image of book:'></asp:Label>
        //                <div class='form-group'>
        //                    <asp:FileUpload CssClass='form-control' ID='FileUploadImg" + i + @"' runat='server' />
        //                </div>
        //            </div>
        //        </div>
        //        <div class='row'>
        //            <div class='col'>
        //                <div class='form-group fa-pull-right mt-3'>
        //                    <asp:Button CssClass='btn btn-success btn-lg' ID='btnReAddBook" + i + @"' runat='server' Text='Add book' OnClick='btnAddBook_Click' />
        //                </div>
        //            </div>
        //        </div>
        //    ";

        //            // Add the newContainer div to the inputContainer
        //            inputContainer.Controls.Add(newContainer);
        //        }
        //    }
        //    else
        //    {
        //        // Handle invalid input (e.g., show an error message)
        //    }
        //}


        protected void radbtnmanybook_checkedchanged(object sender, EventArgs e)
        {
            txtTotalBooks.Text = "";
            txtTotalBooks.ReadOnly = false;
            inputContainer.Attributes["style"] = "visibility:hidden;";
        }


        //event  handler for add book btn
        protected void btnAddBook_Click(object sender, EventArgs e)
        {

            addViewBook();
            //to get value for database
            //string groupType = string.Empty;
            //if (radiobtnSingleBook.Checked)
            //{
            //    addViewBook();
            //    Response.Write("<script>alert('book added successfully.!!!')</script>");
            //}
            //else if (radbtnManyBook.Checked)
            //{
            //    int totalBooks;
            //    if (int.TryParse(txtTotalBooks.Text, out totalBooks))
            //    {
            //        for (int i = 0; i < totalBooks; i++)
            //        {
            //            addViewBook();
            //        }
            //    }
            //}
        }



        //userLogin defined functions


        void addViewBook()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();

                int stdID = GetStdID(username);

                string selectedYear = ddlAcademicYear.SelectedItem.Text;
                int yearIdResult = getYearID(selectedYear);

                string selectedDept = ddlDeptName.SelectedItem.Text;
                int deptIdResult = getDeptNameID(selectedDept);

                string selectedComment = ddlBookComment.SelectedItem.Text;
                int commentResult = getCommentID(selectedComment);


                //to get value for database
                string groupType = string.Empty;
                if (radiobtnSingleBook.Checked)
                {
                    groupType = "1";
                }
                else if (radbtnManyBook.Checked)
                {
                    groupType = "2";

                }


                if (stdID > 0)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand insertCmd = new SqlCommand("INSERT INTO tbl_book_add(deptName, publicationName, subjectName, bookComment, bookCost, status, stdID, academicYearID, addTime, groupType)" +
                            "VALUES(@deptName, @publicationName, @subjectName, @bookComment, @bookCost, @status, @stdID, @academicYearID, @addTime, @groupType)", con);
                        {
                            //insertCmd.Parameters.AddWithValue("@deptName", ddlDeptName.SelectedItem != null ? ddlDeptName.SelectedItem.Text : "");
                            insertCmd.Parameters.AddWithValue("@publicationName", txtPublication.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@bookCost", txtCost.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@status", txtStatus.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@subjectName", txtSubjectName.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@stdID", stdID);
                            insertCmd.Parameters.AddWithValue("@academicYearID", yearIdResult);
                            insertCmd.Parameters.AddWithValue("@deptName", deptIdResult);
                            insertCmd.Parameters.AddWithValue("@bookComment", commentResult);
                            insertCmd.Parameters.AddWithValue("@addTime", DateTime.Now);
                            insertCmd.Parameters.AddWithValue("@groupType", groupType);

                            insertCmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Book added successfully.')</script>");
                        }
                    }
                }
                else
                {

                    Response.Write("<script>alert('Failed to fetch user information.!!!')</script>");
                }
            }
            else
            {

                Response.Write("<script>alert('User is not logged in.')</script>");
            }
        }

        private int GetStdID(string username)
        {
            int stdID = 0;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select stdID from tbl_user_master where stdUserName = @username", con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    stdID = Convert.ToInt32(reader["stdID"]);
                }

                reader.Close();
                con.Close();
            }

            return stdID;
        }

        private int getYearID(string selectedYear)
        {
            int yearIdResult = 0;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT yearID FROM YearTable WHERE AcademicYear = @academicYear", con);
                cmd.Parameters.AddWithValue("@academicYear", selectedYear);

                
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    yearIdResult = Convert.ToInt32(result);
                }
            }

            return yearIdResult;
        }

        private int getDeptNameID(string selectedDept)
        {
            int deptIdResult = 0;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT deptID FROM tbl_dept_name WHERE deptName = @deptName", con);
                cmd.Parameters.AddWithValue("@deptName", selectedDept);


                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    deptIdResult = Convert.ToInt32(result);
                }
            }

            return deptIdResult;
        }

        private int getCommentID(string selectedComment)
        {
            int commentResult = 0;

            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT commentID FROM tbl_comment_book WHERE comment = @comment", con);
                cmd.Parameters.AddWithValue("@comment", selectedComment);


                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    commentResult = Convert.ToInt32(result);
                }
            }

            return commentResult;
        }


    }
}