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
using Newtonsoft.Json;
using Razorpay.Api;

namespace FindMyBooks
{
    public partial class viewBooks : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private const string _key = "rzp_test_fXXypA013Rnzbs";
        private const string _secret = "MyGqg0QmNhGe8aHHRFMH2zqH";
        private const decimal registrationAmount = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].ToString() == "admin")
            {
                addBtn.Visible = false;
            }
            else if (Session["role"] != null && Session["role"].ToString() == "user")
            {
                addBtn.Visible = true;
            }

            if (!IsPostBack)
            {
                txtCost.Text = registrationAmount.ToString();

                // Execute this code only if the page is loaded for the first time
                string bookID = Request.QueryString["bookID"];
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
                    using (SqlCommand cmd = new SqlCommand("select stdID from tbl_new_book where bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        try
                        {
                            stdID = (Int32)cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
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
                        txtCollege.Text = dt.Rows[0]["stdCollege"].ToString();
                        ddlDegree.Text = dt.Rows[0]["stdDegree"].ToString();
                        ddlCourseYear.Text = dt.Rows[0]["stdYear"].ToString();
                        ddlDepartment.Text = dt.Rows[0]["stdDept"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        //event handler for buy books btn.
            protected void addBtn_Click(object sender, EventArgs e)
        {
            decimal amountinSubunits = decimal.Parse(txtCost.Text) * 100;
            string currency = "INR";
            string name = "FindMyBooks";
            string description = "Razorpay Payment Gateway Demo";
            string imageLogo = "";
            string firstName = txtFirstName.Text;
            string profileEmail = txtEmail.Text;
            string bookID = Request.QueryString["bookID"];
            Dictionary<string, string> notes = new Dictionary<string, string>()
        {
            { "note 1", "this is a payment note" }, { "note 2", "here another note, you can add max 15 notes" }
        };

            string orderId = CreateOrder(amountinSubunits, currency, notes);

            string jsFunction = "OpenPaymentWindow('" + _key + "', '" + amountinSubunits + "', '" + currency + "', '" + name + "', '" + description + "', '" + imageLogo + "', '" + orderId + "', '" + firstName + "', '" + profileEmail + "', '" + profileEmail + "', '" + JsonConvert.SerializeObject(notes) + "', '" + bookID + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "OpenPaymentWindow", jsFunction, true);
        }



        private string CreateOrder(decimal amountinSubunits, string currency, Dictionary<string, string> notes)
        {
            try
            {
                int paymentCapture = 1;

                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", amountinSubunits);
                options.Add("currency", currency);
                options.Add("payment_capture", paymentCapture);
                options.Add("notes", notes);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                System.Net.ServicePointManager.Expect100Continue = false;

                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;
            }
            catch (Exception ex)
            {
                throw;
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

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            string recipientEmail = "sdahire010821@kkwagh.edu.in";
            string otp = EmailHelper.GenerateOtp();
            var emailHelper = new EmailHelper("smtp.gmail.com", 587, "ahiresagar06130@gmail.com", "utme zvqt xgdd vgzo");
            emailHelper.SendOtpEmail(recipientEmail, otp);
            Response.Write("<script>alert('OTP has been sent.');</script>");
        }

        protected void BuyBtn_Click(object sender, EventArgs e)
        {
            string recipientEmail = "sdahire010821@kkwagh.edu.in";
            string otp = EmailHelper.GenerateOtp();
            var emailHelper = new EmailHelper("smtp.gmail.com", 587, "ahiresagar06130@gmail.com", "utme zvqt xgdd vgzo");
            emailHelper.SendOtpEmail(recipientEmail, otp);
            Response.Write("<script>alert('OTP has been sent.');</script>");
        }

        //protected void btnBuy_Click(object sender, EventArgs e)
        //{
        //    string recipientEmail = "sdahire010821@kkwagh.edu.in";
        //    string otp = EmailHelper.GenerateOtp();
        //    var emailHelper = new EmailHelper("smtp.gmail.com", 587, "ahiresagar06130@gmail.com", "utme zvqt xgdd vgzo");
        //    emailHelper.SendOtpEmail(recipientEmail, otp);
        //    Response.Write("<script>alert('OTP has been sent.');</script>");
        //}



    }
}