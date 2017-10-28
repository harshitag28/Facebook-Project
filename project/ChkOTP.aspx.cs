using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace project
{
    public partial class ChkOTP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alert1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                cn.Open();
                string str = "select * from reg where OTP='" + TextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(str, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["uname"] = dr[4].ToString();
                    Response.Redirect("index.aspx");
                }
                else
                {
                    alert1.Visible = true;
                    Label2.Text = "OOPs! Entered the wrong OTP";
                    
                    
                    TextBox1.Text = "";
                }
                cn.Close();
            }
            catch
            {
                
            }
        }
    }
}