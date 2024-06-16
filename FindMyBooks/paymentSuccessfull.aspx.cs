using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FindMyBooks
{
    public partial class paymentSuccessfull : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblOrderId.Text = Request.QueryString["orderId"];
                lblPaymentId.Text = Request.QueryString["paymentId"];
                string bookId = Request.QueryString["bookId"];
                lblBookId.Text = bookId;
                //Response.Write("<script>alert('Book ID: " + bookId + "');</script>");
                UpdateBookStatus(bookId);

            }
        }

        //user defined functions.
        private void UpdateBookStatus(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "UPDATE tbl_new_book SET status = 'Sold' WHERE bookID = @bookID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                Response.Write("<script>alert('Error occurred while updating book status: " + ex.Message + "');</script>");
            }
        }


    }
}