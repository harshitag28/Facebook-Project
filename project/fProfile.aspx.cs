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
    public partial class fProfile : System.Web.UI.Page
    {
        ArrayList a,b;
        abc A = new abc();
        returnname r=new returnname();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = r.name(Session["fname"].ToString());
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "select * from reg where Email='" + Session["uname"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            s = r.name(Session["fname"].ToString());
            if (dr.Read())
            {
                Label1.Text = dr[1].ToString();
                HyperLink1.Text =s;

            }
            profilepic();
            cn.Close();
     
            fillfriend();
            fillpost();
            notifrnds();
            notification();
            if (A.isvalid(Session["uname"].ToString(), Session["fname"].ToString()))
            {
                Button1.Visible = true;
            }
            
        }
        void notifrnds()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from friend where (receiver='" + Session["uname"].ToString() + "'or sender='" + Session["uname"].ToString() + "') and status='1' order by dor desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            b = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == Session["uname"].ToString())

                    b.Add(dr[2].ToString());

                else
                    b.Add(dr[1].ToString());

            }
            cn.Close();
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
                if ((b.Contains(dr[1].ToString()))&&(j<5))
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
            string str = "select * from reg where Email='" + Session["fname"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[15].ToString() == "0")
                {
                    if (dr[13].ToString() == "0")
                    {
                        if (dr[6].ToString() == "Male")
                        {

                            propic.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                        }
                        else
                        {

                            propic.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                        }
                    }
                    else
                    {

                        propic.Controls.Add(new LiteralControl("<img src='Account/" + Session["fname"].ToString() + "/p.jpg' alt='Profile Pics' class='img-circle' width='40'>"));
                    }
                    if (dr[14].ToString() == "0")
                    {
                        coverimg.Controls.Add(new LiteralControl("<img src='temp/q.jpg' alt=''>"));
                    }
                    else
                    {
                        coverimg.Controls.Add(new LiteralControl("<img src='Account/" + Session["fname"].ToString() + "/q.jpg' width='800' height='200' alt=''>"));
                    }
                }
                else
                {
                    if (dr[6].ToString() == "Male")
                    {

                        propic.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                    }
                    else
                    {

                        propic.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                    }
                    coverimg.Controls.Add(new LiteralControl("<img src='temp/q.jpg' alt=''>"));
                }

            }
            cn.Close();
        }



        void fillpost()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from wallpost order by wid desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            r = new returnname();
            validfriend v1 = new validfriend();
            a.Add(Session["uname"].ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (a.Contains(dr[1].ToString()))
                {
                    if (v1.stat(dr[1].ToString()))
                    {
                        LinkButton l1 = new LinkButton();
                        l1.Text = "Like";
                        TextBox text = new TextBox();
                        text.Attributes["class"] = "form-control";
                        l1.CommandName = dr[0].ToString();
                       

                        text.ID = dr[0].ToString();

                        string s = r.name(dr[1].ToString());
                       
                        A = new abc();
                        int t1 = A.chkpicstat(dr[1].ToString());
                        if (t1 == 0)
                        {
                            if (A.chkgender(dr[1].ToString()))
                            {
                                wall.Controls.Add(new LiteralControl("<div class='timeline-block'><div class='panel panel-default'><div class='panel-heading'><div class='media'><div class='media-left'> <a><img src='temp/b.jpg' class='media-object' width='60' height='60'></a></div><div class='media-body'><a class='pull-right text-muted'><i class='icon-reply-all-fill fa fa-2x '></i></a><a href='#'>" + s + "</a><span>on&nbsp;" + dr[3].ToString() + "</span></div></div></div><div class='panel-body'><p>" + dr[2].ToString().Replace(System.Environment.NewLine, "<br>") + "</p></div><div class='view-all-comments'><a href='#'><i class='fa fa-thumbs-o-up'></i>"));

                            }
                            else
                            {
                                wall.Controls.Add(new LiteralControl("<div class='timeline-block'><div class='panel panel-default'><div class='panel-heading'><div class='media'><div class='media-left'> <a><img src='temp/g.jpg' class='media-object' width='60' height='60'></a></div><div class='media-body'><a class='pull-right text-muted'><i class='icon-reply-all-fill fa fa-2x '></i></a><a href='#'>" + s + "</a><span>on&nbsp;" + dr[3].ToString() + "</span></div></div></div><div class='panel-body'><p>" + dr[2].ToString().Replace(System.Environment.NewLine, "<br>") + "</p></div><div class='view-all-comments'><a href='#'><i class='fa fa-thumbs-o-up'></i>"));

                            }
                        }
                        else
                            wall.Controls.Add(new LiteralControl(" <div class='timeline-block'><div class='panel panel-default'><div class='panel-heading'><div class='media'><div class='media-left'> <a><img src='Account/" + dr[1].ToString() + "/p.jpg' class='media-object' width='60' height='60'></a></div><div class='media-body'><a class='pull-right text-muted'><i class='icon-reply-all-fill fa fa-2x '></i></a><a href='#'>" + s + "</a><span>on&nbsp;" + dr[3].ToString() + "</span></div></div></div><div class='panel-body'><p>" + dr[2].ToString().Replace(System.Environment.NewLine, "<br>") + "</p></div><div class='view-all-comments'><a href='#'><i class='fa fa-thumbs-o-up'></i>"));
                        string[] b = dr[4].ToString().Split('/');
                        if (!A.islike(Session["uname"].ToString(), l1.CommandName))
                            wall.Controls.Add(l1);
                        if (dr[5].ToString() == "0")
                        {
                            wall.Controls.Add(new LiteralControl("</a><span></span></div><ul class='comments'>"));
                        }
                        else
                        {
                            wall.Controls.Add(new LiteralControl("</a><span> "));
                            for (int i = 0; i < b.Length; i++)
                            {

                                wall.Controls.Add(new LiteralControl("<a href='#' data-toggle='tooltip' data-placement='bottom' title='" + b[i] + "'>"));
                            }
                            wall.Controls.Add(new LiteralControl("" + dr[5].ToString() + "Likes</a></span></div><ul class='comments'>"));
                        }
                        cmd.Dispose();
                        cn.Close();
                        SqlConnection cn1 = new SqlConnection();
                        cn1.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                        SqlCommand cmd1 = new SqlCommand("select * from comment order by cid asc", cn1);
                        DataSet ds1 = new DataSet();
                        SqlDataAdapter ad1 = new SqlDataAdapter(cmd1);
                        SqlCommandBuilder cmdb1 = new SqlCommandBuilder(ad1);
                        ad1.Fill(ds1);
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            string[] st = dr1[4].ToString().Split(' ');
                            if (dr1[1].ToString().Contains(text.ID))
                            {
                                wall.Controls.Add(new LiteralControl("<li class='media'><div class='media-left'><a href='#'>"));

                                int t = A.chkpicstat(dr1[2].ToString());
                                if (t == 0)
                                {
                                    if (A.chkgender(dr1[2].ToString()))
                                    {
                                        wall.Controls.Add(new LiteralControl("<img src='temp/b.jpg' class='media-object' width='60' height='60'>"));

                                    }
                                    else
                                    {
                                        wall.Controls.Add(new LiteralControl("<img src='temp/g.jpg' class='media-object' width='60' height='60'>"));

                                    }
                                }
                                else
                                    wall.Controls.Add(new LiteralControl("<img src='Account/" + dr1[2].ToString() + "/p.jpg' class='media-object' width='60' height='60'>"));
                                wall.Controls.Add(new LiteralControl("</a></div><div class='media-body'><a href='#' class='comment-author pull-left'>" + r.name(dr1[2].ToString()) + "</a><span>" + dr1[3].ToString() + "</span><div class='comment-date'>" + st[0] + "</div></div></li>"));
                            }

                        }
                        wall.Controls.Add(new LiteralControl(" <li class='comment-form'><div class='input-group'><span class='input-group-btn'><a href='#' class='btn btn-default'><i class='fa fa-comments'></i></a></span>"));

                        wall.Controls.Add(text);
                        wall.Controls.Add(new LiteralControl("</div></li></ul></div></div>"));

                        cmd1.Dispose();
                        cn1.Close();
                    }
                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string rec = Session["fname"].ToString();
            string send = Session["uname"].ToString();
            string stat = "0";
            string dor = System.DateTime.Now.ToString();
            validfriend x = new validfriend();
            

            if (x.isinreg(rec))
            {
                if (A.isvalid(send, rec))
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                    SqlCommand cmd = new SqlCommand("select * from friend", cn);
                    DataSet ds = new DataSet();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                    ad.Fill(ds);


                    DataRow dr = ds.Tables[0].NewRow();

                    dr[1] = send;
                    dr[2] = rec;
                    dr[3] = stat;
                    dr[4] = dor;
                    ds.Tables[0].Rows.Add(dr);
                    ad.Update(ds);
                    
                    
                    cn.Close();
                    Response.Redirect("Profile.aspx");
                    
                }
               
            }

           
        }
       
        void fillfriend()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from friend where (receiver='" + Session["fname"].ToString() + "'or sender='" + Session["fname"].ToString() + "') and status='1' order by dor desc", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            a = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == Session["fname"].ToString())

                    a.Add(dr[2].ToString());

                else
                    a.Add(dr[1].ToString());

            }


            foreach (object o in a)
            {
                LinkButton l = new LinkButton();
                l.Text = o.ToString();
               
                
                int t = A.chkpicstat(o.ToString());
                if (t == 0)
                {
                    if (A.chkgender(o.ToString()))
                    {
                        friend.Controls.Add(new LiteralControl("<li><img src='temp/b.jpg' alt='Profile Pics' width='55' height='60'>"));
                    }
                    else
                    {
                        friend.Controls.Add(new LiteralControl("<li><img src='temp/g.jpg' alt='Profile Pics' width='55' height='60'>"));
                    }
                }
                else
                friend.Controls.Add(new LiteralControl("<li><img src='Account/" + o.ToString() + "/p.jpg' alt='Profile Pics' width='55' height='60'>"));
                
                friend.Controls.Add(new LiteralControl("</li>"));
                
      
            }
            cn.Close();
        }
       
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProfile.aspx");
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Friends.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("uname");
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx");
        }

        
    }
}