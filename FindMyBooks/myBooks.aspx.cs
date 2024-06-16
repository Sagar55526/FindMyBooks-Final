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

namespace FindMyBooks
{
    public partial class myBooks : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getStudentBookInfo();
            }
            catch(Exception ex)
            {

            }
        }


        //user defined functions
        void getStudentBookInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                string stdID = Session["stdID"] != null ? Session["stdID"].ToString() : "";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_new_book where stdID='" + stdID + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //important logic to pass value from one page to another as a string. 
            Button btnUpdate = (Button)sender;

            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;

            string bookID = GridView1.DataKeys[row.RowIndex].Value.ToString();

            Response.Redirect("~/updateMyBook.aspx?bookID=" + bookID);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int statusColumnIndex = 2; 
                    string status = e.Row.Cells[statusColumnIndex].Text;

                    if (status == "Sold")
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                        Button btnUpdate = e.Row.FindControl("btnUpdate") as Button;

                        if (btnUpdate != null)
                        {
                            btnUpdate.Text = "View";
                        }
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