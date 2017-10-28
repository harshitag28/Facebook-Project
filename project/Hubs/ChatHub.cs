using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace project.Hubs
{
    public class ChatHub : Hub
    {
        void dataentr(string sid, string rid, string message)
        {


            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();

            try
            {
                cn.Open();
                string str = "insert into chat (sid,cid,msg) values(@sid,@cid,@msg)";
                SqlCommand cmd = new SqlCommand(str, cn);

                cmd.Parameters.AddWithValue("sid", sid);
                cmd.Parameters.AddWithValue("cid", rid);
                cmd.Parameters.AddWithValue("msg", message);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        static Hashtable h = new Hashtable();
        public override Task OnConnected()
        {  // name=auto generated chat id
            //id=database unique id
            var split = Context.QueryString["id"].Split('}');
            string name = Context.ConnectionId;

            string id = split.First();
            Clients.All.addNewMessageToPage(name, id, 1);

            if (h.Count != 0)
            {
                foreach (string key in h.Keys)
                {

                    Clients.Client(Context.ConnectionId).addNewMessageToPage((string)h[key], key, 1);

                }
            }
            try
            {

                h.Add(id, name);
            }
            catch { }
            return base.OnConnected();
        }

        public void Send(string key1, string message, string name, string sid)
        {

            dataentr(sid, key1, message);
            Clients.Client((string)h[key1]).addNewMessageToPage(sid + "}" + name, message, 3);



        }
        public override Task OnDisconnected()
        {
            var split = Context.QueryString["id"].Split('}');

            h.Remove(split.First());
            Clients.All.addNewMessageToPage("", split.First(), 2);


            return base.OnDisconnected();
        }
    }
}