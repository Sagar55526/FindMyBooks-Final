using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FindMyBooks
{
    public partial class addBooks : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //conecting yearID data table to drop down
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select AcademicYear from YearTable", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlAcademicYear.DataSource = dt;
                        ddlAcademicYear.DataValueField = "AcademicYear";
                        ddlAcademicYear.DataBind();
                    }
                }
                //conecting tbl_comment_bool data table to drop down
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select comment from tbl_comment_book", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlBookComment.DataSource = dt;
                        ddlBookComment.DataValueField = "comment";
                        ddlBookComment.DataBind();
                    }
                }
                //conecting tbl_dept_name data table to drop down
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select deptName from tbl_dept_name", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ddlDeptName.DataSource = dt;
                        ddlDeptName.DataValueField = "deptName";
                        ddlDeptName.DataBind();
                    }
                }

                //conecting tbl_subject_master data table to listbox items.
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    using (SqlCommand cmd = new SqlCommand("select subjectName from tbl_subject_master", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        lstSubjectName.DataSource = dt;
                        lstSubjectName.DataValueField = "subjectName";
                        lstSubjectName.DataBind();
                    }
                }
                ddlAcademicYear.Items.Insert(0, new ListItem("--Select academic year--", "0"));
                ddlBookComment.Items.Insert(0, new ListItem("--Give comment on book--", "0"));
                ddlDeptName.Items.Insert(0, new ListItem("--Select department--", "0"));
            }
        }

        //add book btn click event.
        protected void addBtn_Click(object sender, EventArgs e)
        {
            
        }

        //user defined functions.

    }
}