using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace project
{
    public partial class accept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqid = Request.QueryString["reqid"].ToString();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("update friend set status='1' where fid='" + reqid + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            cn.Close();
            Response.Redirect("index.aspx");
        }
    }
}