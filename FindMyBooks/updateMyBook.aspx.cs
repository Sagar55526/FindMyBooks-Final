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
    public partial class updateMyBook : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string bookID = Request.QueryString["bookID"];
            getMemberDetailsById(bookID);
        }




        //user defined functions.
        void getMemberDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_new_book WHERE bookID = @BookID", con))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {

                            foreach (ListItem item in lstSubjectName.Items)
                            {
                                if (item.Value == dt.Rows[0]["full_name"].ToString())
                                {
                                    item.Selected = true;
                                    break; 
                                }
                            }

                            if (ddlDeptName.SelectedItem != null || ddlDeptName.SelectedItem != null || ddlDeptName.SelectedItem != null || ddlDeptName.SelectedItem != null)
                            {
                                ddlDeptName.SelectedItem.Text = dt.Rows[0]["full_name"].ToString();
                            
                            ddlAcademicYear.SelectedItem.Text = dt.Rows[0]["yearID"].ToString();
                            ddlPublicationName.SelectedItem.Text = dt.Rows[0]["publicationID"].ToString();
                            ddlBookComment.SelectedItem.Text = dt.Rows[0]["bookCommentID"].ToString();
                            }
                            txtCost.Text = dt.Rows[0]["costBooks"].ToString();
                            txtStatus.Text = dt.Rows[0]["status"].ToString();
                            txtComment.Text = dt.Rows[0]["comment"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('No data found for the specified bookID');</script>");
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