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
    public partial class adminUserProfile : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string stdID = Request.QueryString["stdID"];
            //FillYear();
            //FillDDL();
            //getMemberDetailsById(stdID);

            try
            {
                getMemberDetailsById(stdID);
                getGridData(stdID);


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


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int statusColumnIndex = 3;
                    string status = e.Row.Cells[statusColumnIndex].Text;

                    if (status == "Sold")
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //user defined functions

        void getGridData(string stdID)
        {
            SqlConnection con = new SqlConnection(strcon);
            //string stdID = Session["stdID"] != null ? Session["stdID"].ToString() : "";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from tbl_new_book where stdID= @stdID", con);
            cmd.Parameters.AddWithValue("@stdID", stdID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        void getMemberDetailsById(string stdID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from tbl_user_master where stdID = @stdID", con))
                    {
                        cmd.Parameters.AddWithValue("@stdID", stdID);
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
                        Label10.Text = dt.Rows[0]["status"].ToString();
                        //if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                        //{
                        //    Label10.Attributes.Add("class", "badge badge-pill badge-success");
                        //}
                        //else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                        //{
                        //    Label10.Attributes.Add("class", "badge badge-pill badge-warning");
                        //}
                        //else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                        //{
                        //    Label10.Attributes.Add("class", "badge badge-pill badge-danger");
                        //}
                        //else
                        //{
                        //    Label10.Attributes.Add("class", "badge badge-pill badge-info");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //private void FillDDL()
        //{
        //    using (SqlConnection con = new SqlConnection(strcon))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select DeptId,deptName from tbl_dept_name", con))
        //        {
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            ddlDepartment.DataSource = dt;
        //            ddlDepartment.DataValueField = "deptid";
        //            ddlDepartment.DataTextField = "DeptName";
        //            ddlDepartment.DataBind();
        //        }
        //    }
        //}

        //private void FillYear()
        //{
        //    using (SqlConnection con = new SqlConnection(strcon))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select YearID,AcademicYear from YearTable", con))
        //        {
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            ddlCourseYear.DataSource = dt;
        //            ddlCourseYear.DataValueField = "YearID";
        //            ddlCourseYear.DataTextField = "AcademicYear";
        //            ddlCourseYear.DataBind();
        //        }
        //    }
        //}


    }
}