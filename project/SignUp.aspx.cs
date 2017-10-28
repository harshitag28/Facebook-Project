using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Collections;
using System.Web.UI.Adapters;
namespace project
{
    public partial class SignUp : System.Web.UI.Page
    {
        validfriend v = new validfriend();
        protected void Page_Load(object sender, EventArgs e)
        {
            alert1.Visible = false;
            tnc.Checked = false;
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            Email em = new Email();
            string gender = string.Empty;
            string pass = string.Empty;
          
            int val = 0;
            
            DirectoryInfo d,d1;
             d = new DirectoryInfo(Server.MapPath("Account") + "//" + email.Value);
            d.Create();
             d1= new DirectoryInfo(Server.MapPath("Profileimg") + "//" + email.Value);
            d1.Create();
            if (RadioButton1.Checked)
            {
                gender = "Male";
        
            }
            else if (RadioButton2.Checked)
            {
                gender = "Female";
        
            }

            pass=rand1();
          
            if (RadioButton1.Checked == true || RadioButton2.Checked == true)
            {
                try
                {
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                    cn.Open();
                    string str = "insert into reg(Name,Dob,Pno,Email,RecEmail,Gender,Status,Pass,PStatus,CoverStatus,Picprivacy,DStatus,MailSecurity) values(@name,@dob,@pno,@email,@recemail,@radio,@val,@pass,@pstatus,@coverstatus,@picprivacy,@dstatus,@mail)";
                    SqlCommand cmd = new SqlCommand(str, cn);
                    SqlParameter p1 = new SqlParameter("name", name.Value);
                    SqlParameter p2 = new SqlParameter("dob", dob.Text);
                    if(v.ispnoexist(phone.Value))
                    {
                        alert1.Visible = true;
                        Label2.Text = "OOPs! Phone number already exist";
                        
                        
                    }
                    else
                    {
                        SqlParameter p3 = new SqlParameter("pno", phone.Value);
                        cmd.Parameters.Add(p3);
                    }
                    
                    
                    if (!v.isinreg(email.Value))
                    {
                        SqlParameter p4 = new SqlParameter("email", email.Value);
                        cmd.Parameters.Add(p4);
                    }
                    else
                    {
                        alert1.Visible = true;
                        Label2.Text = "OOPs! E-mail address already exist";
                       
                       
                    }
                    if(email.Value==remail.Value)
                    {
                        alert1.Visible = true;
                        Label2.Text = "OOPs! Recovery E-mail cannot be same as your E-mail address";
                        
                       
                    }
                    else
                    {
                        SqlParameter p5 = new SqlParameter("recemail", remail.Value);
                        cmd.Parameters.Add(p5);
                    }
                    
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    
                   
                    
                    cmd.Parameters.AddWithValue("radio", gender);
                    cmd.Parameters.AddWithValue("val", val);
                    cmd.Parameters.AddWithValue("pass", pass);
                    cmd.Parameters.AddWithValue("pstatus", 0);
                    cmd.Parameters.AddWithValue("coverstatus", 0);
                    cmd.Parameters.AddWithValue("picprivacy",val);
                    cmd.Parameters.AddWithValue("dstatus", 0);
                    cmd.Parameters.AddWithValue("mail", 0);
                    cmd.ExecuteNonQuery();
                    
                    
                    em.send_maill(name.Value,email.Value,1,pass);
                    
                    cn.Close();
                    Response.Redirect("login.aspx");
                    
                    
                }
                catch(Exception ex)
                {
                    
                }
                
            }
            else
            {
                alert1.Visible = true;
                Label2.Text = "OOPs! Check your details something is missing";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "$('#modal2').modal({ backdrop: 'static' })", true);

            }

        }
    
    
        protected string rand1()
        {
            string character = "";
            character = "q,w,e,r,t,y,u,i,o,p,a,s,d,f,g,h,j,k,l,z,x,c,v,b,n,m,Z,X,C,V,B,N,M,A,S,D,F,G,H,J,K,L,Q,W,E,R,T,Y,U,I,O,P,1,2,3,4,5,6,7,8,9,0";
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
    }
    }
