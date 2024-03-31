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
            GetBookDetailsById(bookID);
            Filldepartment();
        }




        //user defined functions.
        void GetBookDetailsById(string bookID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open(); // Open connection

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_new_book WHERE bookID = @bookID", con))
                    {
                        cmd.Parameters.AddWithValue("@bookID", bookID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];

                            ddlDeptName.SelectedValue = row["departmentID"].ToString();
                            ddlAcademicYear.SelectedValue = row["yearID"].ToString();
                            ddlPublicationName.SelectedValue = row["publicationID"].ToString();
                            ddlBookComment.SelectedValue = row["bookCommentID"].ToString();
                            txtCost.Text = row["costBooks"].ToString();
                            txtStatus.Text = row["status"].ToString();
                            txtComment.Text = row["comment"].ToString();

                            foreach (DataRow subjectRow in dt.Rows)
                            {
                                string selectedSubject = subjectRow["full_name"].ToString();
                                ListItem listItem = lstSubjectName.Items.FindByValue(selectedSubject);
                                if (listItem != null)
                                {
                                    listItem.Selected = true;
                                }
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No data found for the specified bookID');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void Filldepartment()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("select deptID, deptName from tbl_dept_name", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ddlAcademicYear.DataSource = dt;
                    ddlAcademicYear.DataValueField = "deptID";
                    ddlAcademicYear.DataTextField = "deptName";
                    ddlAcademicYear.DataBind();
                }
            }
        }


    }
}