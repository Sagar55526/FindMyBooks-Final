using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class registration : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
                ddlAcademicYear.Items.Insert(0, new ListItem("--Select academic year--", "0")); 
                ddlDegree.Items.Insert(0, new ListItem("--Select degree type--", "0"));
            }
        }

        protected void btnRegistratino_click(object sender, EventArgs e)
        {
            if (checkMemberExistance())
            {
                Response.Write("<script>alert('User already exists.!!!')</script>");
            }
            else
            {
                userSignUp();
            }
        }


        //user defined functions.
        bool checkMemberExistance()     /*function for checking existance of member ID*/
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user_master WHERE stdUserName='" + txtUserName.Text.Trim() + "';", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        void userSignUp()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("insert into tbl_user_master (stdFirstName, stdLastName, stdPhoneNo, stdEmail, stdAddress, stdCollege, stdDegree, stdYear, stdDept, stdUserName, password) " +
                "values(@first_name, @last_name, @phone, @email, @address, @college_name, @degree_name, @academic_year, @dept_name, @user_name, @password)", con);


            cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
            cmd.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@college_name", txtCollege.Text.Trim());
            cmd.Parameters.AddWithValue("@degree_name", ddlDegree.SelectedItem != null ? ddlDegree.SelectedItem.Text : "");
            cmd.Parameters.AddWithValue("@academic_year", ddlAcademicYear.SelectedItem != null ? ddlAcademicYear.SelectedItem.Text : "");
            cmd.Parameters.AddWithValue("@dept_name", ddlDepartment.SelectedItem != null ? ddlDepartment.SelectedItem.Text : "");
            cmd.Parameters.AddWithValue("@user_name", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Sign up successfully')</script>");
        }
    }
}