using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class allBooksAdmin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bookID = Request.QueryString["bookID"];
            }
        }

        //user defined functions.

        void getBookDetails()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using(SqlCommand cmd = new SqlCommand("select * from tbl_new_book", con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int bookID = Convert.ToInt32(row.Cells[0].Text); 

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                string sql = "DELETE FROM tbl_new_book WHERE bookID = @BookID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('book deleted successfully.!!!');</script>");
                }
            }
            GridView1.DataBind();
        }


        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e, string bookID)
        //{
        //    SqlConnection con = new SqlConnection(strcon);
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    using (SqlCommand cmd = new SqlCommand("delete from tbl_new_book where bookID = @bookID", con))
        //    {
        //        cmd.Parameters.AddWithValue("@bookID", bookID);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        Response.Write("<script>alert('book deleted successfully.!!!');</script>");
        //    }
        //}
    }
}