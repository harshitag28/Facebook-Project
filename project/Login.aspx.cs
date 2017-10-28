using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
namespace project
{
    public partial class Login : System.Web.UI.Page
    {
        Email em = new Email();
        string otp = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Visible = false;
            alert1.Visible = false;
        }
        protected void login_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "select * from reg where Email='" + email.Value + "' and Pass='" + pass.Value + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[10].ToString() == "0")
                {
                    if (dr[9].ToString() == "0")
                    {
                        Session["uname"] = email.Value;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {

                        otp = rand();
                        abc A = new abc();
                        A.otpsave(otp, email.Value);
                        returnname r = new returnname();
                        em.send_maill(r.name(email.Value),email.Value,3,otp);
                        Response.Redirect("ChkOTP.aspx");
                    }
                }
                else
                {
                    alert.Visible = true;
                    Label4.Text = "Your Account has been deactivated";
                    
                }
            }
            else
            {
                alert1.Visible = true;
                Label3.Text = "OOPs! Check your E-mail & Password";
                
            }
           
            cn.Close();
        }
        protected string rand()
        {
            string character = "";
            character = "1,2,3,4,5,6,7,8,9,0";
            char[] s = { ',' };
            string[] a = character.Split(s);
            string p = "";
            string t = "";
            Random r = new Random();
            for (int j = 0; j < 6; j++)
            {
                t = a[r.Next(0, a.Length)];
                p += t;
            }
            return (p);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string pass = string.Empty;
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                cn.Open();
                string str = "select * from reg where Email='" + TextBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(str, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    returnname r=new returnname();
                    pass = dr[12].ToString();
                    em.send_maill(r.name(TextBox3.Text), TextBox3.Text,2,pass);
                }
                else if(TextBox3.Text=="")
                {
                    alert1.Visible = true;
                    Label3.Text = "OOPs! Fields cannot be left blank";
                    
                   
                }
                else
                {
                    alert1.Visible = true;
                    Label3.Text = "OOPs! Please check your E-mail";
                    
                   
                }
                cn.Close();
            }
            catch (Exception ew)
            {

                Label1.Text = ew.Message;
            }
            
        }
        
    }
}