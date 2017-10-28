using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


    public class validfriend
    {
        public bool setvalue = false;
        public bool setvalue1 = false;
        
        public bool isinreg(string id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from reg where Email='" + id + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[4].ToString() == id)

                    setvalue = true;
            }
            return setvalue;
        }
        public bool ispnoexist(string pno)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from reg where Pno='" + pno + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[3].ToString() == pno)

                    setvalue1 = true;
            }
            return setvalue1;
        }
        public bool isinfollow(string send, string rec)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from follow where followsend='" + send + "'and followrec='" + rec + "' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[1].ToString() == send && dr[2].ToString() == rec)

                    return true;
            }
            return false;
        }
        public bool stat(string email)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            SqlCommand cmd = new SqlCommand("select * from reg where Email='"+email+"' ", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[16].ToString() == "0")

                    return true;
            }
            return false;
        }
    }
   
