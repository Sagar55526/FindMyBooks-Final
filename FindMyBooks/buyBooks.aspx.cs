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
    public partial class buyBooks : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                getBookstoBuy();
                
            }
        }




        //user defined functions
        void getBookstoBuy()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                string stdID = Session["stdID"] != null ? Session["stdID"].ToString() : "";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_new_book where stdID!='" + stdID + "' and status = 'Available'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gridview1.DataSource = dt;
                gridview1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
            //Required for jQuery DataTables to work.
            gridview1.UseAccessibleHeader = true;
            gridview1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}