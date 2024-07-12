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
    public partial class userLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //button click event for login btn.
        protected void Button1_Click(object sender, EventArgs e)
        {
            userLoginEvent();
        }


        //user defined functions.

        void userLoginEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user_master WHERE stdUserName=@UserName", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string encryptedPassword = dr["password"].ToString(); // Assuming password column name is 'password'
                        string decryptedPassword = DecryptPassword(encryptedPassword);

                        if (decryptedPassword == txtPassword.Text.Trim())
                        {
                            Response.Write("<script>alert('login successful..!!')</script>");
                            Session["username"] = dr["stdUserName"].ToString();
                            Session["role"] = "user";
                            //Session["status"] = dr["status"].ToString(); 
                            Session["studentID"] = dr["stdID"].ToString();
                            Response.Redirect("buyBooks.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid credentials');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('User not found');</script>");
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private string DecryptPassword(string encryptedPassword)
        {
            byte[] bytes = Convert.FromBase64String(encryptedPassword);
            string decryptedPassword = Encoding.UTF8.GetString(bytes);
            return decryptedPassword;
        }

    }
}