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
                    LinkButton4.Visible = false;    //add books btn
                    LinkButton3.Visible = false;    //Logout btn
                    LinkButton7.Visible = false;    //hello user btn
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton4.Visible = true;     //add books btn
                    LinkButton5.Visible = true;     //my books btn
                    LinkButton3.Visible = true;     //Logout btn
                    LinkButton1.Visible = false;    //user log-in btn
                    LinkButton2.Visible = false;    //user sign-up btn
                    LinkButton7.Visible = true;     //hello user btn
                    LinkButton6.Visible = false;    //admin login btn
                    LinkButton10.Visible = true;    //buy books btn
                    LinkButton7.Text = "hello " + Session["username"].ToString();
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton4.Visible = false;     //add books btn
                    LinkButton5.Visible = false;     //my books btn
                    LinkButton3.Visible = true;     //Logout btn
                    LinkButton1.Visible = false;    //user log-in btn
                    LinkButton2.Visible = false;    //user sign-up btn
                    LinkButton7.Visible = true;     //hello user btn
                    LinkButton8.Visible = true;     //All books btn
                    LinkButton9.Visible = true;     //User lists btn
                    LinkButton6.Visible = false;    //admin login btn
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
        //protected void LinkButton4_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("addBooks.aspx"); 
        //}

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
            LinkButton4.Visible = false;    //add books btn
            Response.Redirect("homePage.aspx");
            
        }

        //btn for user profile.
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }

        //handle event for add/view button 
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("addBooks.aspx");
        }

        //handler for my books button.
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("myBooks.aspx");
        }
        
        //handler for my books button.
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("allBooksAdmin.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("userListAdmin.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("buyBooks.aspx");
        }
    }
}