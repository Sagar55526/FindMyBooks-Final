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
                string username = Session["username"]?.ToString();
                string bookId = Request.QueryString["bookId"];
                System.Diagnostics.Debug.WriteLine("Username from session: " + username);

                lblBookId.Text = bookId;
                //Response.Write("<script>alert('Book ID: " + bookId + "');</script>");
                UpdateBookStatus(bookId, username);

            }
        }

        //user defined functions.
        private void UpdateBookStatus(string bookID, string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    Response.Write("<script>alert('Error: User session not found or username not set.');</script>");
                    return;
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Update book status and set buyerUserName
                    string updateQuery = "UPDATE tbl_new_book SET status = 'Sold', buyerUserName = @buyerUserName WHERE bookID = @bookID";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("@bookID", bookID);
                        cmdUpdate.Parameters.AddWithValue("@buyerUserName", username);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    Response.Write("<script>alert('Book status updated successfully.');</script>");
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