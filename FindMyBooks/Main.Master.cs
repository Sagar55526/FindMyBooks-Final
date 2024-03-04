using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null || Session["username"] == null)
                {
                    LinkButton4.Visible = false;    //addview books btn
                    LinkButton3.Visible = false;    //Logout btn
                    LinkButton7.Visible = false;    //hello user btn
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton4.Visible = true;     //addview books btn
                    LinkButton3.Visible = true;     //Logout btn
                    LinkButton1.Visible = false;    //user log-in btn
                    LinkButton2.Visible = false;    //user sign-up btn
                    LinkButton7.Visible = true;     //hello user btn
                    LinkButton7.Text = "hello " + Session["username"].ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //redirect link for user login 
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        //redirect link for user sign-up 
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }

        //redirect link for add or view books
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("addViewBooks.aspx"); 
        }

        //redirect link for admin login
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton4.Visible = false;

            Response.Write("<script>alert('Log-out successfully.!!!')</script>");
            Response.Redirect("homePage.aspx");
        }

        //btn for user profile.
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        
    }
}