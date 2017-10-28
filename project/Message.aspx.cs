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
    public partial class Message : System.Web.UI.Page
    {
        ArrayList a,b;
        returnname r;
        abc A;
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
            alert1.Visible = false;
            fillmessage();
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
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx");
        }
         protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

         protected void LinkButton2_Click(object sender, EventArgs e)
         {
             Response.Redirect("EditProfile.aspx");
         }

         protected void LinkButton3_Click(object sender, EventArgs e)
         {
             Response.Redirect("Friends.aspx");
         }

         protected void LinkButton4_Click(object sender, EventArgs e)
         {
             Response.Redirect("Message.aspx");
         }

         protected void LinkButton5_Click(object sender, EventArgs e)
         {
             Session.Remove("uname");
             Session.RemoveAll();
             Response.Redirect("Login.aspx");
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
                 c++;
                 if (dr[1].ToString() == Session["uname"].ToString())

                     a.Add(dr[2].ToString());

                 else
                     a.Add(dr[1].ToString());

             }


             foreach (object o in a)
             {
                 returnname r = new returnname();
                 LinkButton l = new LinkButton();
                 l.Text = o.ToString();
                 l.ForeColor = System.Drawing.Color.White;
                 l.Font.Name = "Comic Sans MS";
                 l.CommandName = r.name(o.ToString());
                 l.Click += new EventHandler(l_click);
                 A = new abc();
                 int t = A.chkpicstat(o.ToString());
                 if (t == 0)
                 {
                     if (A.chkgender(o.ToString()))
                     {
                         frnds.Controls.Add(new LiteralControl("<li class='list-group-item active'><div class='media'><div class='media-left'><img src='temp/b.jpg' alt='' class='media-object' width='65' height='60'></div> <div class='media-body'><span class='user'>" + l.CommandName + ""));

                     }
                     else
                     {
                         frnds.Controls.Add(new LiteralControl("<li class='list-group-item active'><div class='media'><div class='media-left'><img src='temp/g.jpg' alt='' class='media-object' width='65' height='60'></div> <div class='media-body'><span class='user'>" + l.CommandName + ""));

                     }
                 }
                 else
                 frnds.Controls.Add(new LiteralControl(" <li class='list-group-item active'><div class='media'><div class='media-left'><img src='Account/" + o.ToString() + "/p.jpg' alt='' class='media-object' width='65' height='60'></div> <div class='media-body'><span class='user'>" + l.CommandName + ""));
                 frnds.Controls.Add(l);
                 frnds.Controls.Add(new LiteralControl("</span></div></div></li><hr/>"));
             }
             cn.Close();
             if(c==0)
             {
                 frnds.Controls.Add(new LiteralControl("<p>Sorry there are no friends whom you can chat.</p>"));
             }
             }
             protected void l_click(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
           Session["to"] = l.Text;
        }

             protected void Button1_Click(object sender, EventArgs e)
             {
                 if (Session["to"] == null)
                 {
                     alert1.Visible = true;
                     Label2.Text = "OOPs! Select friend whom you want to message";
                    
                     
                 }
                 else
                 {

                     string rec = Session["to"].ToString();
                     string send = Session["uname"].ToString();
                     string message = TextBox1.Text;
                     string dos = System.DateTime.Now.ToString();
                     SqlConnection cn = new SqlConnection();
                     cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                     SqlCommand cmd = new SqlCommand("select * from message", cn);
                     DataSet ds = new DataSet();
                     SqlDataAdapter ad = new SqlDataAdapter(cmd);
                     SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                     ad.Fill(ds);


                     DataRow dr = ds.Tables[0].NewRow();

                     dr[1] = send;
                     dr[2] = rec;
                     dr[3] = message;
                     dr[4] = dos;
                     ds.Tables[0].Rows.Add(dr);
                     ad.Update(ds);
                     
                     
                     cn.Close();
                 }
                 TextBox1.Text = "";
                 Session["to"] = null;
             }
            void fillmessage()
             {
                 r = new returnname();
                 SqlConnection cn = new SqlConnection();
                 cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                 SqlCommand cmd = new SqlCommand("select * from message where (receiver='" + Session["uname"].ToString() + "'or sender='" + Session["uname"].ToString() + "') order by msgid desc", cn);
                 DataSet ds = new DataSet();
                 SqlDataAdapter ad = new SqlDataAdapter(cmd);
                 SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                 ad.Fill(ds);
                 b =new ArrayList();
                 b.Add(Session["uname"].ToString());
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     if (b.Contains(dr[1].ToString()))
                     {
                         string sender = r.name(dr[1].ToString());
                         msg.Controls.Add(new LiteralControl("<div class='media'><div class='media-body message'><div class='panel panel-default'><div class='panel-heading panel-heading-white'><div class='pull-right'><small class='text-muted'>" + dr[4].ToString() + "</small></div><a href='#'>" + sender + "</a></div><div class='panel-body'>" + dr[3].ToString() + "</div></div></div><div class='media-right'>"));
                         abc A = new abc();
                         int t = A.chkpicstat(dr[1].ToString());
                         if (t == 0)
                         {
                             if (A.chkgender(dr[1].ToString()))
                             {
                                 msg.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='' class='media-object' width='60'></div></div><br/>"));

                             }
                             else
                             {
                                 msg.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='' class='media-object' width='60'></div></div><br/>"));

                             }
                         }
                         else
                         msg.Controls.Add(new LiteralControl("<img src='Account/" + dr[1].ToString() + "/p.jpg' alt='' class='media-object' width='60'></div></div><br/>"));
                         
                     }
                     if (b.Contains(dr[2].ToString()))
                     {
                         string receiver = r.name(dr[1].ToString());
                         int t = A.chkpicstat(dr[1].ToString());
                         if (t == 0)
                         {
                             if (A.chkgender(dr[1].ToString()))
                             {
                                 msg.Controls.Add(new LiteralControl("<div class='media'><div class='media-left'><img src='temp/b.jpg' alt='' class='media-object' width='60'></div>  <div class='media-body message'><div class='panel panel-default'><div class='panel-heading panel-heading-white'><div class='pull-right'><small class='text-muted'>" + dr[4].ToString() + "</small></div><a href='#'>" + receiver + "</a></div><div class='panel-body'>" + dr[3].ToString() + "</div></div></div></div><br/>"));

                             }
                             else
                             {
                                 msg.Controls.Add(new LiteralControl("<div class='media'><div class='media-left'><img src='temp/g.jpg' alt='' class='media-object' width='60'></div>  <div class='media-body message'><div class='panel panel-default'><div class='panel-heading panel-heading-white'><div class='pull-right'><small class='text-muted'>" + dr[4].ToString() + "</small></div><a href='#'>" + receiver + "</a></div><div class='panel-body'>" + dr[3].ToString() + "</div></div></div></div><br/>"));

                             }
                         }
                         else
                         msg.Controls.Add(new LiteralControl(" <div class='media'><div class='media-left'><img src='Account/" + dr[1].ToString() + "/p.jpg' alt='' class='media-object' width='60'></div>  <div class='media-body message'><div class='panel panel-default'><div class='panel-heading panel-heading-white'><div class='pull-right'><small class='text-muted'>" + dr[4].ToString() + "</small></div><a href='#'>" + receiver + "</a></div><div class='panel-body'>" + dr[3].ToString() + "</div></div></div></div><br/>"));
                     }
                 }
                 cn.Close();
             }
         }
   
}