using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class homePage : System.Web.UI.Page
    {
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

        //event handler for try now btn.
        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    if (Session["role"].Equals("user"))
        //    {
        //        Response.Redirect("addViewBooks.aspx");
        //    }
        //    else
        //    {
        //        Response.Redirect("userLogin.aspx");
        //    }
        //}
    }
}