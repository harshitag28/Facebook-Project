using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections;
using System.Web.UI.Adapters;
namespace project
{
    public partial class Profile : System.Web.UI.Page
    {
        ArrayList a,b;
        returnname r;
        FileInfo fi;
        int i = 1,j,k;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                returnname nam12 = new returnname();

                Label2.Text = nam12.id1(Session["uname"].ToString()).ToString();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                cn.Open();
                string str = "select * from reg where Email='" + Session["uname"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(str, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Label1.Text = dr[1].ToString();
                    HyperLink1.Text = dr[1].ToString();

                }
                
                dr.Close();
                cn.Close();
                
                fillfriend();
                notification();
                fillpen();
                alert1.Visible = false;
                fillpost();
                profilepic(); 
                body.Controls.Add(new LiteralControl("<script>$(document).ready(function(){$('[data-toggle='tooltip']').tooltip();});</script>"));
            }
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
                            propic.Controls.Add(new LiteralControl("<img src='temp/b.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                        }
                        else
                        {
                            picdrop.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='Profile Pics' class='img-circle' width='40' >"));
                            propic.Controls.Add(new LiteralControl("<img src='temp/g.jpg' alt='Profile Pics' class='img-circle' width='40' >"));

                        }
                    }
                    else
                    {
                        picdrop.Controls.Add(new LiteralControl("<img src='Account/" + dr[4].ToString() + "/p.jpg' alt='Profile Pics' class='img-circle' width='40' >"));
                        propic.Controls.Add(new LiteralControl("<img src='Account/" + dr[4].ToString() + "/p.jpg' alt='Profile Pics' class='img-circle' width='40'>"));

                    }
                    if (dr[14].ToString() == "0")
                    {
                        coverimg.Controls.Add(new LiteralControl("<img src='temp/q.jpg' alt=''>"));
                    }
                    else
                    {
                        coverimg.Controls.Add(new LiteralControl("<img src='Account/" + dr[4].ToString() + "/q.jpg' width='800' height='200' alt=''>"));
                    }
                }


            dr.Close();
            cn.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
         
            try
            {
                if ((Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1) == "jpg") || (Path.GetExtension(FileUpload1.PostedFile.FileName).Substring(1) == "JPG"))
                {
                    abc A = new abc();
                    
                    int t = A.chkpicstat(Session["uname"].ToString());
                    if (t == 0)
                    {
                        if (A.chkgender(Session["uname"].ToString()))
                        {
                            fi = new FileInfo(Server.MapPath("temp") + "\\b.jpg");
                            fi.CopyTo(Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString()) + "\\p" + i + ".jpg");

                        }
                        else
                        {
                            fi = new FileInfo(Server.MapPath("temp") + "\\g.jpg");
                            fi.CopyTo(Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString()) + "\\p" + i + ".jpg");

                        }
                    }
                    else
                    {
                        fi = new FileInfo(Server.MapPath("Account" + "\\" + Session["uname"].ToString()) + "\\p.jpg");
                        string nn = Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString());
                        DirectoryInfo d = new DirectoryInfo(nn);
                        FileInfo[] f = d.GetFiles();
                        j = f.Count();
                        k = i + j;
                        fi.CopyTo(Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString()) + "\\p" + k + ".jpg");


                    }
                    FileUpload1.SaveAs(Server.MapPath("Account" + "\\" + Session["uname"].ToString() + "\\p.jpg"));
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                    cn.Open();
                    string str = "update reg set PStatus=1 where Email='" + Session["uname"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(str, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    alert1.Visible = true;
                    Label3.Text = "OOPs! Only jpg Format images can be uploaded";
                    

                }
            }
            catch
            {
                alert1.Visible = true;
                Label3.Text = "OOPs! Choose the image you want to upload";
               
            }
            
        }
        
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (status.Value == "")
            {

            }
            else
            {

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                SqlCommand cmd = new SqlCommand("select * from wallpost", cn);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                ad.Fill(ds);

                DataRow dr = ds.Tables[0].NewRow();
                dr[1] = Session["uname"].ToString();
                dr[2] = status.Value;
                dr[3] = System.DateTime.Now.ToString();
                ds.Tables[0].Rows.Add(dr);
                ad.Update(ds);
                cn.Close();
            }
            status.Value = "";
            wall.Controls.Clear();
            abc A = new abc();
            A.noti(Session["uname"].ToString(),0);
            fillpost();
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
            b = new ArrayList();
           
            b.Add(Session["uname"].ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (b.Contains(dr[1].ToString()))
                {
                    LinkButton l1=new LinkButton();
                    l1.Text="Like";
                    TextBox text = new TextBox();
                    text.Attributes["class"] = "form-control";
                    l1.CommandName = dr[0].ToString();
                    l1.Click += new EventHandler(like_post);

                    text.ID = dr[0].ToString();
                   
                    string s = r.name(dr[1].ToString());
                    text.AutoPostBack = true;
                    text.TextChanged += new EventHandler(send_comment);
                    abc A = new abc();
                    int t = A.chkpicstat(dr[1].ToString());
                    if (t == 0)
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
                    string[] b1 = dr[4].ToString().Split('/'); 
                    if (!A.islike(Session["uname"].ToString(),l1.CommandName))
                    wall.Controls.Add(l1);
                    if (dr[5].ToString() == "0")
                    {
                        wall.Controls.Add(new LiteralControl("</a><span></span></div><ul class='comments'>"));
                    }
                    else
                    {
                        wall.Controls.Add(new LiteralControl("</a><span> "));
                        for (int i = 0; i < b1.Length; i++)
                        {

                            wall.Controls.Add(new LiteralControl(" " + b1[i] + ""));
                        }
                        wall.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;" + dr[5].ToString() + "Likes</a></span></div><ul class='comments'>"));
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
                            
                            int t1 = A.chkpicstat(dr1[2].ToString());
                            if (t1 == 0)
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
        protected void send_comment(object sender, EventArgs e)
        {
            try
            {
                TextBox t = (TextBox)sender;
                string wid = t.ID;
                string text = t.Text;
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                SqlCommand cmd = new SqlCommand("select * from comment order by doc desc", cn);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                ad.Fill(ds);
                DataRow dr = ds.Tables[0].NewRow();
                dr[1] = wid;
                dr[2] = Session["uname"].ToString();
                dr[3] = text;
                dr[4] = System.DateTime.Now.ToString();
                ds.Tables[0].Rows.Add(dr);
                ad.Update(ds);
                cn.Close();
                t.Text = "";
                abc A = new abc();
                A.noti(Session["uname"].ToString(), 2);
                
            }
            catch
            {

            }
        }
        protected void like_post(object sender, EventArgs e)
        {
            LinkButton l = (LinkButton)sender;
            string wid = l.CommandName;
            
            string pliked = string.Empty;
            int clike=0;
            int i = 1;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "select * from wallpost where wid='" + wid + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if(dr[4].ToString()=="")
                {
                    pliked = Session["uname"].ToString();
                }
                else
                pliked = dr[4].ToString() + '/' + Session["uname"].ToString();
                clike = Convert.ToInt32(dr[5].ToString()) + i;
            }
            dr.Close();
            cmd.ExecuteNonQuery();
            cn.Close();
            SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn1.Open();
            string str1 ="update wallpost set peopleliked=@Peopleliked,likecount=@Likecount where wid='"+wid+"'";
            SqlCommand cmd1 = new SqlCommand(str1, cn1);
            
            SqlParameter p1 = new SqlParameter("Peopleliked", pliked);
            SqlParameter p2 = new SqlParameter("Likecount", clike);
            cmd1.Parameters.Add(p1);
            cmd1.Parameters.Add(p2);
            cmd1.ExecuteNonQuery();
            cn1.Close();
            abc A = new abc();
            A.noti(Session["uname"].ToString(), 1);
        }
        [System.Web.Services.WebMethod]
        public static string[] GetName(string prefixText)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select Name,Email,City from reg where Name like'" + prefixText + "%' and Email!='" + HttpContext.Current.Session["uname"].ToString() + "'", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items[i] = dr[1].ToString() + "," + dr[2].ToString();
                i++;
            }
            cn.Close();
            return items;
            
        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Redirect("Profile.aspx");
            }
            else
            {
                string[] str = TextBox1.Text.Split(',');
                string rec = str[0];
                string send = Session["uname"].ToString();
                Session["fname"] = rec;
                Response.Redirect("fProfile.aspx");
            }
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
            r = new returnname();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == Session["uname"].ToString())

                    a.Add(dr[2].ToString());

                else
                    a.Add(dr[1].ToString());

            }


            foreach (object o in a)
            {
               
                LinkButton l = new LinkButton();
                l.Text = o.ToString();
                
                abc A=new abc();
                int t=A.chkpicstat(o.ToString());
                if(t==0)
                {
                    if(A.chkgender(o.ToString()))
                    {
                        friend.Controls.Add(new LiteralControl("<li><a href='#' data-toggle='tooltip' data-placement='bottom' title='"+r.name(o.ToString())+"'><img src='temp/b.jpg' alt='Profile Pics' width='55' height='60'></a>"));
                    }
                    else
                    {
                        friend.Controls.Add(new LiteralControl("<li><a href='#' data-toggle='tooltip' data-placement='bottom' title='" + r.name(o.ToString()) + "'><img src='temp/g.jpg' alt='Profile Pics' width='55' height='60'></a>"));
                    }
                }
                else
                    friend.Controls.Add(new LiteralControl("<li><a href='#' data-toggle='tooltip' data-placement='bottom' title='" + r.name(o.ToString()) + "'><img src='Account/" + o.ToString() + "/p.jpg' alt='Profile Pics' width='55' height='60'></a>"));
                
                friend.Controls.Add(new LiteralControl("</li>"));
               
        
            }
            cn.Close();
        }

        void fillpen()
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


                LinkButton b12 = new LinkButton();
                b12.Text = r.name(o.ToString());

                b12.Style.Add("font-size", "15px");
                b12.Attributes.Add("href", "javascript:register_popup('" + r.id1(o.ToString()) + "' , '" + r.name(o.ToString()) + "');");

                flist.Controls.Add(new LiteralControl("<table><tr><td><img src='img/d.png'  id='" + r.id1(o.ToString()) + "-i'   /></td>"));
                flist.Controls.Add(new LiteralControl("<td style='width:8px'></td>"));
                abc A = new abc();
                int t = A.chkpicstat(o.ToString());
                if (t == 0)
                {
                    if (A.chkgender(o.ToString()))
                    {
                        flist.Controls.Add(new LiteralControl("<td><img src='temp/b.jpg' alt='image' class='img-circle' width='60' height='60'></td>"));

                    }
                    else
                    {
                        flist.Controls.Add(new LiteralControl("<td><img src='temp/g.jpg' alt='image' class='img-circle' width='60' height='60'></td>"));

                    }
                }
                else
                    flist.Controls.Add(new LiteralControl("<td><img src='Account/" + o.ToString() + "/p.jpg' alt='image' class='img-circle' width='60' height='60'></td>"));
                flist.Controls.Add(new LiteralControl("<td style='width:15px'></td>"));
                flist.Controls.Add(new LiteralControl("<td>"));
                flist.Controls.Add(b12);
                flist.Controls.Add(new LiteralControl("</td></tr></table>"));
                //flist.Controls.Add(new LiteralControl("</li>"));
                
            }
            cn.Close();
            if(c==0)
            {
                flist.Controls.Add(new LiteralControl("<p>No Friends yet...!</p>"));
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
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

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Friends.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("settings.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Path.GetExtension(FileUpload2.PostedFile.FileName).Substring(1) == "jpg") || (Path.GetExtension(FileUpload2.PostedFile.FileName).Substring(1) == "JPG"))
                {
                    abc A = new abc();
                    int t = A.chkcoverstat(Session["uname"].ToString());
                    if (t == 0)
                    {
                        fi = new FileInfo(Server.MapPath("temp") + "\\q.jpg");
                        fi.CopyTo(Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString()) + "\\q" + i + ".jpg");
                    }

                    else
                    {
                        fi = new FileInfo(Server.MapPath("Account" + "\\" + Session["uname"].ToString()) + "\\q.jpg");
                        string cnn = Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString());
                        DirectoryInfo d = new DirectoryInfo(cnn);
                        FileInfo[] f = d.GetFiles();
                        j = f.Count();
                        k = i + j;
                        fi.CopyTo(Server.MapPath("Profileimg" + "\\" + Session["uname"].ToString()) + "\\q" + k + ".jpg");


                    }
                    FileUpload2.SaveAs(Server.MapPath("Account" + "\\" + Session["uname"].ToString() + "\\q.jpg"));
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                    cn.Open();
                    string str = "update reg set CoverStatus=1 where Email='" + Session["uname"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(str, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                   
                }
                else
                {
                    alert1.Visible = true;
                    Label3.Text = "OOPs! Only jpg Format images can be uploaded";
                   

                }
            }
            catch(Exception ex)
            {
                alert1.Visible = true;
                Label3.Text = "OOPs! Choose the image you want to upload";
                   
                
            }
        }
    }
}