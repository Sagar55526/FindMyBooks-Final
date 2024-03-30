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
            getBookDetailsById(bookID);
        }




        //user defined functions.
        void getBookDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_new_book WHERE bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            ddlDeptName.SelectedValue = dt.Rows[0]["departmentID"].ToString();
                            ddlAcademicYear.SelectedValue = dt.Rows[0]["yearID"].ToString();
                            ddlPublicationName.SelectedValue = dt.Rows[0]["publicationID"].ToString();
                            ddlBookComment.SelectedValue = dt.Rows[0]["bookCommentID"].ToString();
                            txtCost.Text = dt.Rows[0]["costBooks"].ToString();
                            txtStatus.Text = dt.Rows[0]["status"].ToString();
                            txtComment.Text = dt.Rows[0]["comment"].ToString();

                            foreach (DataRow row in dt.Rows)
                            {
                                string selectedSubject = row["full_name"].ToString();
                                ListItem listItem = lstSubjectName.Items.FindByValue(selectedSubject);
                                if (listItem != null) 
                                {
                                    listItem.Selected = true;
                                }
                            }

                           
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