using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FindMyBooks
{
    public partial class registration : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private string password;
        //DataTable dt = new DataTable();
        //static int sentOtp = 0;
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
                ddlAcademicYear.Items.Insert(0, new ListItem("--Select academic year--", "0"));
                ddlDegree.Items.Insert(0, new ListItem("--Select degree type--", "0"));
                ddlDepartment.Items.Insert(0, new ListItem("--Select department--", "0"));
            }
        }

        protected void btnRegistration_click(object sender, EventArgs e)
        {
            if (checkMemberExistance())
            {
                Response.Write("<script>alert('User already exists.!!!')</script>");
            }
            else
            {
                // Generate a temporary password
                Random rand = new Random();
                string password = "FMB" + rand.Next(1000, 9999).ToString(); // Generates a random number between 1000 and 9999

                userSignUp(password);

                //below code demonstrate use of twilio sms sender.
                var accountSid = "ACa5c5ac67aa23ea6eb2abcbfe892a1642";
                var authToken = "c14749508ac28623e21a13b1c8517da0";
                TwilioClient.Init(accountSid, authToken);

                string phoneNumber = "+91-" + txtPhone.Text;

                var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber));
                messageOptions.From = new PhoneNumber("+13343674856");
                messageOptions.Body = "🔐 Welcome to our platform! Your registration is complete. \n 📝 Username: " + txtPhone.Text + "\n 🔑 Temporary Password: " + password + "\n For security reasons, please change your password upon logging in for the first time. \n If you have any questions, feel free to contact us at 9699031859. \n Happy exploring! \n Regards FindMyBooks"; 
                //messageOptions.Body = "📝 Username: " + txtPhone.Text; 
                //messageOptions.Body = "🔑 Temporary Password: " + password;
                //messageOptions.Body = "For security reasons, please change your password upon logging in for the first time.";
                //messageOptions.Body = "If you have any questions, feel free to contact us at 9699031859"; 
                //messageOptions.Body = "Happy exploring!"; 
                //messageOptions.Body = "Regards FindMyBooks";


                var message = MessageResource.Create(messageOptions);
                Response.Write("Message SID: " + message.Sid);
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user_master WHERE stdPhoneNo='" + txtPhone.Text.Trim() + "';", conn);
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

        void userSignUp(string password)
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string strpass = encryptpass(password);
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
            cmd.Parameters.AddWithValue("@user_name", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@password", strpass);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Sign up successfully')</script>");
            Response.Redirect("userLogin.aspx");
        }

        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

    }
}