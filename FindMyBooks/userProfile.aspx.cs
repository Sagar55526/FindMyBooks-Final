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
    public partial class userProfile : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired Login Again 1');</script>");
                }
                else
                {
                    getMemberDetailsById();
                }

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
                            ddlCourseYear.DataSource = dt;
                            ddlCourseYear.DataValueField = "AcademicYear";
                            ddlCourseYear.DataBind();
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
                            ddlDepartment.DataSource = dt;
                            ddlDepartment.DataValueField = "deptName";
                            ddlDepartment.DataBind();
                        }
                    }
                    ddlDepartment.Items.Insert(0, new ListItem("--Select course year--", "0"));
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again 2');</script>");
            }

        }

        //event handler for registration btn.
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            updateDetails();
        }


        //user defined functions.


        void updateDetails()
        {
            //string password = "";
            //if (TextBox11.Text.Trim() == "")
            //{
            //    password = TextBox10.Text.Trim();
            //}
            //else
            //{
            //    password = TextBox11.Text.Trim();
            //}
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update tbl_user_master set stdFirstName=@stdFirstName, stdLastName=@stdLastName, stdPhoneNo=@stdPhoneNo, stdEmail=@stdEmail, stdAddress=@stdAddress, stdCollege=@stdCollege, stdDegree=@stdDegree, " +
                    "stdYear=@stdYear, stdDept=@stdDept, stdUserName=@stdUserName, password=@password where stdUserName = '" + Session["username"]
                    .ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@stdFirstName", txtFirstName.Text.Trim()); 
                cmd.Parameters.AddWithValue("@stdLastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@stdPhoneNo", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@stdEmail", txtEmail.Text.Trim()); 
                cmd.Parameters.AddWithValue("@stdAddress", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@stdCollege", txtCollege.Text.Trim());
                cmd.Parameters.AddWithValue("@stdDegree", ddlCourseYear.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@stdYear", ddlCourseYear.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@stdDept", ddlDepartment.SelectedItem.Text);
                //cmd.Parameters.AddWithValue("@stdUserName", txtUserName.Text.Trim()); 
                //cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                getMemberDetailsById();
                //getMemberBookInfo();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void getMemberDetailsById()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_user_master where stdUserName = '" + Session["username"].ToString() + "'", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        txtFirstName.Text = dt.Rows[0]["stdFirstName"].ToString();
                        txtLastName.Text = dt.Rows[0]["stdLastName"].ToString();
                        txtPhone.Text = dt.Rows[0]["stdPhoneNo"].ToString();
                        txtEmail.Text = dt.Rows[0]["stdEmail"].ToString();
                        txtAddress.Text = dt.Rows[0]["stdAddress"].ToString();
                        txtCollege.Text = dt.Rows[0]["stdCollege"].ToString();
                        ddlDegree.Text = dt.Rows[0]["stdDegree"].ToString();
                        ddlCourseYear.Text = dt.Rows[0]["stdYear"].ToString();
                        ddlDepartment.Text = dt.Rows[0]["stdDept"].ToString();
                        //txtUserName.Text = dt.Rows[0]["stdUserName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        
    }
}