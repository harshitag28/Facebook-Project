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
namespace project
{
    public partial class settings : System.Web.UI.Page
    {
        abc A = new abc();
        ArrayList a;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uname"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                    cn.Open();
                    string str = "select * from reg where Email='" + Session["uname"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(str, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Label1.Text = dr[1].ToString();
                        Label8.Text = dr[1].ToString();
                        string[] st = dr[2].ToString().Split(' ');
                        Label9.Text = st[0];
                        Label10.Text = dr[3].ToString();
                        Label11.Text = dr[4].ToString();
                        Label12.Text = dr[5].ToString();
                        Label13.Text = dr[6].ToString();
                        Label14.Text = dr[7].ToString();
                        Label15.Text = dr[8].ToString();
                        TextBox1.Text = dr[3].ToString();
                        TextBox2.Text = dr[5].ToString();
                        TextBox3.Text = dr[2].ToString();
                        TextBox4.Text = dr[7].ToString();
                        TextBox5.Text = dr[1].ToString();
                        TextBox6.Text = dr[8].ToString();
                        if (dr[9].ToString() == "0"||dr[15].ToString()=="0")
                        {
                            RadioButton1.Checked = true;
                            RadioButton3.Checked = true;
                        }
                        else
                        {
                            RadioButton2.Checked = true;
                        }
                        if (dr[16].ToString() == "0")
                        {
                            RadioButton6.Checked = true;
                        }
                        else
                            RadioButton8.Checked = true;
                        if(dr[17].ToString()=="1")
                        {
                            RadioButton9.Checked = true;
                        }
                        else if(dr[17].ToString()=="2")
                        {
                            RadioButton10.Checked = true;
                        }
                    }
                    
                    cn.Close();
                    
                }
            }
            profilepic();
            fillfriend();
            notification();   
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
            notifi.Controls.Add(new LiteralControl(" <li><a href='Notification.aspx'>View All</a></li></li>"));
            cmd.Dispose();
            cn.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set Name=@name,Dob=@dob,Pno=@pno,RecEmail=@recemail,City=@city,Country=@country where Email='" + Session["uname"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlParameter p1 = new SqlParameter("name", TextBox5.Text);
            SqlParameter p2 = new SqlParameter("dob", TextBox3.Text);
            SqlParameter p3 = new SqlParameter("pno", TextBox1.Text);
            SqlParameter p4 = new SqlParameter("recemail", TextBox2.Text);
            SqlParameter p5 = new SqlParameter("city", TextBox4.Text);
            SqlParameter p6 = new SqlParameter("country", TextBox6.Text);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.ExecuteNonQuery();
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
                if(dr[10].ToString()=="1")
                {
                    Response.Redirect("Login.aspx");
                }
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            int f = 0,t=0,d=0,s=0,m=0;
            if(RadioButton2.Checked==true)
            {
                f = 1;
            }
            A.loginverify(f,Session["uname"].ToString());
            if(RadioButton5.Checked==true)
            {
                t = 1;
            }
            A.picprivacy(t,Session["uname"].ToString());
            if(RadioButton4.Checked==true)
            {
                d = 1;
            }
            A.deactive(d, Session["uname"].ToString());
            if(RadioButton8.Checked==true)
            {
                s = 1;
            }
            A.statusprivacy(s, Session["uname"].ToString());
            if(RadioButton9.Checked==true)
            {
                m = 1;
            }
            else if(RadioButton10.Checked==true)
            {
                m = 2;
            }
            A.mailsecurity(m,Session["uname"].ToString());
        }
    }
}