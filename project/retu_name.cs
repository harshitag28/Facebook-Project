using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
public class retu_name
{


    public string name_(string id)
    {
        string name = "";

        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();

        String s = "select Name from reg where Email = '" + id + "'  ";

        cn.Open();

        SqlCommand cmd = new SqlCommand(s, cn);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            name = dr[0].ToString();
        }
        cmd.Dispose();
        cn.Close();

        return name;


    }
    public string id2(string n)
    {
        string i = "none";
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
        cn.Open();
        string str = "Select Name from reg where id='" + n + "'";
        SqlCommand cmd = new SqlCommand(str, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            i = dr[0].ToString();

        }

        cmd.Dispose();
        cn.Close();
        return i;
    }






}