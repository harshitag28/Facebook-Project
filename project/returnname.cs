using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace project
{
    public class returnname
    {
        public string name(string n)
        {
            string s = string.Empty; ;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "Select * from reg where Email='" + n + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s = dr[1].ToString();

            }

            cmd.Dispose();
            cn.Close();
            return s;
        }


        public int id1(string n)
        {
            int i = 0;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
            cn.Open();
            string str = "Select * from reg where Email='" + n + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = Convert.ToInt32(dr[0].ToString());

            }

            cmd.Dispose();
            cn.Close();
            return i;

        }

    }
}