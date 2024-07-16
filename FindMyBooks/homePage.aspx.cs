using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class homePage : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"].Equals("user"))
            //{
            //    Button1.Visible = false; 
            //    Button2.Visible = false; 
            //}
            //else if (Session["username"].Equals(""))
            //{
            //    Button1.Visible = true;
            //    Button2.Visible = true;
            //}

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_new_book; ", con))
                {
                    lblCount.Text = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {

            }

        }

        //event caller for registration btn.
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }

        //event caller for user log-in btn.
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }




        //event handler for "try now" btn.
        //protected void button3_click(object sender, eventargs e)
        //{
        //if (session["role"].equals("user"))
        //{
        //    response.redirect("addviewbooks.aspx");
        //}
        //else
        //{
        //    response.redirect("userlogin.aspx");
        //}
        //}




        //event caller for user try now btn.
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["role"] != null && Session["role"].ToString() == "user")
            {
                Response.Redirect("buyBooks.aspx");
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        }
    }
}