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
    public partial class Friends : System.Web.UI.Page
    {
        ArrayList a;
        validfriend v = new validfriend();
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
                if ((a.Contains(dr[1].ToString()))&&(j<5))
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
            int c = 0;
            a = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == Session["uname"].ToString())

                    a.Add(dr[2].ToString());

                else
                    a.Add(dr[1].ToString());

            }


            foreach (object o in a)
            {
                c++;
                returnname r=new returnname();
                LinkButton l = new LinkButton();
                l.Text = o.ToString();
                l.Click += new EventHandler(l_click);
                Button b = new Button();
                Button b1 = new Button();
                b.Text = "Follow";
                b1.Text = "Unfriend";
                b.Attributes["class"]="btn btn-default btn-sm";
                b1.Attributes["class"] = "btn btn-success btn-sm";
                b.CommandName = l.Text;
                b1.CommandName = l.Text;
                b.Click += new EventHandler(b_click);
                b1.Click += new EventHandler(b1_click);
                panel.Controls.Add(new LiteralControl("<div class='col-md-6 col-lg-4 item'><div class='panel panel-default'><div class='panel-heading'><div class='media'><div class='pull-left'>"));
                abc A=new abc();
                int t=A.chkpicstat(o.ToString());
                if(t==0)
                {
                    if (A.chkgender(o.ToString()))
                    {
                        panel.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='People' class='media-object img-circle' width='40' height='40'>"));
                    }
                    else
                    {
                        panel.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='People' class='media-object img-circle' width='40' height='40'>"));
                    }
                }
                else
                panel.Controls.Add(new LiteralControl("<img src='Account/" + o.ToString() + "/p.jpg' alt='People' class='media-object img-circle' width='40' height='40'>"));
                panel.Controls.Add(new LiteralControl("</div><div class='media-body'><h4 class='media-heading margin-v-5'>"));
                panel.Controls.Add(new LiteralControl(""+r.name(o.ToString())+"<br/>"));
                panel.Controls.Add(l);
                panel.Controls.Add(new LiteralControl("</h4></div></div></div><div class='panel-footer'><div class='row'><div class='col-xs-6 col-sm-6 col-md-6'>"));
                if (!v.isinfollow(Session["uname"].ToString(), b.CommandName))
                {
                    panel.Controls.Add(b);
                }
                panel.Controls.Add(new LiteralControl("</div><div class='col-xs-6 col-sm-6 col-md-6'>"));
                panel.Controls.Add(b1);
                panel.Controls.Add(new LiteralControl("</div></div></div></div></div>"));
                
            }
            cn.Close();
            if(c==0)
            {
                panel.Controls.Add(new LiteralControl("<div class='panel panel-default'><div class='panel-body'><p style='text-align:center'>There is no Friends of your's search for Friends. </p></div></div>"));
            }
        }
        protected void l_click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            Session["fname"] = l.Text;
            Response.Redirect("fProfile.aspx");
        }
        protected void b_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string send = Session["uname"].ToString();
            string rec = b.CommandName;
            string dos = System.DateTime.Now.ToString();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from follow", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);


            DataRow dr = ds.Tables[0].NewRow();
            dr[1] = send;
            dr[2] = rec;
            dr[3] = dos;
            ds.Tables[0].Rows.Add(dr);
            ad.Update(ds);
            
            cn.Close();
            abc A = new abc();
            A.noti(Session["uname"].ToString(), 3);
        }
        protected void b1_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("delete from friend where (sender='"+Session["uname"].ToString()+"'and receiver='"+b.CommandName+"')or(sender='"+b.CommandName+"'and receiver='"+Session["uname"].ToString()+"') ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            cn.Close();
            b.CommandName = "";
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
    }
}