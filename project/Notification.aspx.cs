using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.Adapters;
namespace project
{
    public partial class Notification : System.Web.UI.Page
    {
        ArrayList a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
                Response.Redirect("Login.aspx");
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "select * from reg where Email='" + Session["uname"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = dr[1].ToString();

            }

            profilepic();
            cn.Close();
            fillfriend();
            notification();
            notmsg();
        }
        public void notification()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from notification order by nid desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            int j = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((a.Contains(dr[1].ToString())) && (j < 5))
                {
                    j++;
                    notifi.Controls.Add(new LiteralControl(" <li><a href='#'><img src='Account/" + dr[1].ToString() + "/p.jpg' class='img-circle' width='30' height='30' >" + dr[2].ToString() + "</a>"));
                }
            }
            notifi.Controls.Add(new LiteralControl("<li> <a href='Notification.aspx'>View All</a></li></li>"));
            cmd.Dispose();
            cn.Close();
        }
        protected void profilepic()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "select * from reg where Email='" + Session["uname"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[13].ToString() == "0")
                {
                    if (dr[6].ToString() == "Male")
                    {
                        picdrop.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                    }
                    else
                    {
                        picdrop.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                    }
                }
                else
                {
                    picdrop.Controls.Add(new LiteralControl("<img src='Account/" + Session["uname"].ToString() + "/p.jpg' alt='Profile Pics' class='img-circle' width='40'>"));

                }
            }
            cn.Close();
        }
        void fillfriend()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from friend where (receiver='" + Session["uname"].ToString() + "'or sender='" + Session["uname"].ToString() + "') and status='1' order by dor desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            a = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == Session["uname"].ToString())

                    a.Add(dr[2].ToString());

                else
                    a.Add(dr[1].ToString());

            }
            cn.Close();
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Session.Remove("uname");
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Friends.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx");
        }
        public void notmsg()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from notification order by nid desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            int c = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                c++;
                if (a.Contains(dr[1].ToString()))
                {
                    abc A = new abc();
                        int t1 = A.chkpicstat(dr[1].ToString());
                        if (t1 == 0)
                        {
                            if (A.chkgender(dr[1].ToString()))
                            {
                                noti.Controls.Add(new LiteralControl("<div class='media'><div class='media-left'><a href='#'><img src='temp/b.jpg' class='media-object' width='60' height='60'></a></div>"));

                            }
                            else
                            {
                                noti.Controls.Add(new LiteralControl("<div class='media'><div class='media-left'><a href='#'><img src='temp/g.jpg' class='media-object' width='60' height='60'></a></div>"));

                            }
                        }
                        else
                            noti.Controls.Add(new LiteralControl("<div class='media'><div class='media-left'><a href='#'><img src='Account/" + dr[1].ToString() + "/p.jpg'  class='media-object' width='60' height='60'></a></div>"));
                    returnname r=new returnname();
                    noti.Controls.Add(new LiteralControl("<div class='media-body message'><div class='panel panel-default'><div class='panel-heading panel-heading-white'><a href='#'>"+r.name(dr[1].ToString())+"</a></div><div class='panel-body'><p>"+dr[2].ToString()+"</p></div></div></div></div>"));
                }
            }
            
            cmd.Dispose();
            cn.Close();
            if(c==0)
            {
                noti.Controls.Add(new LiteralControl("<div class='panel panel-default'><div class='panel-body'><p style='text-align:center'>There are no notifications. </p></div></div>"));
            }
        }
    }
}