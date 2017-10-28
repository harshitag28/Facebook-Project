using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace project
{
    public partial class reject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string reqid = Request.QueryString["reqid"].ToString();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("update friend set status='2' where fid='" + reqid + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            cn.Close();
            delete();

            Response.Redirect("index.aspx");

        }
        public void delete()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("delete from friend where status='2' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            cn.Close();
        }
    }
}