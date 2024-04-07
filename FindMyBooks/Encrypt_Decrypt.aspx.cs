using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FindMyBooks
{
    public partial class Encrypt_Decrypt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnEnc_Click(object sender, EventArgs e)
        {
            string encPass = EncDec.GetEncryptPassword(txtEncKey.Text);
            lblEnc.Text = "Your Encryption Key: " + encPass.ToString();
        }

        protected void btnDec_Click(object sender, EventArgs e)
        {
            string decPass = EncDec.GetDecryptPassword(txtDecKey.Text);
            lblDec.Text = "Your Decryption Key: " + decPass.ToString();
        }
    }
}