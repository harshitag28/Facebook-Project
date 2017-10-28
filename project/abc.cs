using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.Adapters;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

    public class abc
    {
        public  bool isvalid(string sender, string rec)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from friend where (sender='" + sender + "' and receiver='" + rec + "') or (sender='" + rec + "' and receiver='" + sender + "')", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
        }
        public void loginverify(int f,string s)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set Status='" + f + "' where Email='" + s + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void picprivacy(int t, string s)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set Picprivacy='" + t + "' where Email='" + s + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void statusprivacy(int t, string s)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set Statusprivacy='" + t + "' where Email='" + s + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void deactive(int t, string s)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set DStatus='" + t + "' where Email='" + s + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void otpsave(string otp,string email)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set OTP='" + otp + "' where Email='" + email + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void mailsecurity(int otp, string email)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "update reg set OTP='" + otp + "' where Email='" + email + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
     public int chkpicstat(string mail)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from reg where Email='"+mail+"'", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[13].ToString() == "0")
                    return 0;
            }
              
            
                return 1;
        }
     public int chkcoverstat(string mail)
     {
         SqlConnection cn = new SqlConnection();
         cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
         SqlCommand cmd = new SqlCommand("select * from reg where Email='" + mail + "'", cn);
         DataSet ds = new DataSet();
         SqlDataAdapter ad = new SqlDataAdapter(cmd);
         SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
         ad.Fill(ds);

         foreach (DataRow dr in ds.Tables[0].Rows)
         {
             if (dr[14].ToString() == "0")
                 return 0;
         }


         return 1;
     }

        public bool chkgender(string email)
     {
         SqlConnection cn = new SqlConnection();
         cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
         SqlCommand cmd = new SqlCommand("select * from reg where Email='" + email + "'", cn);
         DataSet ds = new DataSet();
         SqlDataAdapter ad = new SqlDataAdapter(cmd);
         SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
         ad.Fill(ds);

         foreach (DataRow dr in ds.Tables[0].Rows)
         {
             if (dr[6].ToString() == "Male")
                 return true;
         }


         return false;
     }
        public void noti(string email,int s)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from notification", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            DataRow dr = ds.Tables[0].NewRow();
                dr[1] = email;
                if (s == 0)
                {
                    dr[2] = "Your friend has updated new status";
                }
                else if (s == 1)
                {
                    dr[2] = "Your friend has liked your status";
                }
                else if(s==2)
                {
                    dr[2] = "Your friend commented on your post";
                }else
                    dr[2] = "You have been followed by your friend";
            
            ds.Tables[0].Rows.Add(dr);
            ad.Update(ds);
            cn.Close();
        }
        public bool islike(string email,string wid)
        {
            int i = 0,flag=0;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from wallpost where wid='" + wid + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                string[] a = dr[4].ToString().Split('/');
                for(i=0;i<a.Length;i++)
                {
                   
                    if (a[i]==email)
                    {
                        flag = 1;
                        break;
                    }
                }
            }
            if (flag == 1)
            {
                return true;
            }
            else
                return false;
        }
    }
