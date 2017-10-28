using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Collections;
using System.IO;
using System.Web.UI.Adapters;
    public class Email
    {
          public string send_maill(string name, string email, int status,string pass)
        {
            String stt = pass;
            string htmlBody = "";
            if (status == 1)    // register   name
            {
                htmlBody = @"
<html lang=""en"">
   
    <body>
  <div>
    
       <div style='border-top-left-radius:5px;background-color:#0D7E71;color:white; width: 511px; margin-left: 224px;'>
          <div style=' background-color:#2d95bb;'>  <p style=' float:left;padding:10px ;font-family: roboto;font-size:large'><b>Hi " + name + @" <b></p>
              <p style='float:right;font-family: roboto;padding:10px; font-size:medium''>Posted on :   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + @" </p><br />
              <br />
              <br /><br />

          </div>          <p style='border-radius:5px; margin-left: 60px;font-size:medium;'>Welcome ,<br> You are sucessfully registered . <br>Your Password : " + stt + @"

          <br/>
             <br/><br/>
       
             
      </p>
          
            
        
      </div>
      
    </div>
    </body>
</html>
";
            }
            else if (status == 2)  // forgot password  message = password
            {



                htmlBody = @"
<html lang=""en"">
   
    <body>
  <div>
    
       <div style='border-top-left-radius:5px;background-color:#0D7E71;color:white; width: 511px; margin-left: 224px;'>
          <div style=' background-color:#2d95bb;'>  <p style=' float:left;padding:10px ;font-family: roboto;font-size:large'><b>Hi  <b></p>
              <p style='float:right;font-family: roboto;padding:10px; font-size:medium''>Posted on :   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + @" </p><br />
              <br />
              <br /><br />

          </div>          <p style='border-radius:5px; margin-left: 60px;font-size:medium;'><b> Name :<b>  " + name + "<br/><br/> <b> Email Address : <b>" + email + "<br/><br/><b> Your Password is : <b>" + stt + @" 

          <br/>
             <br/><br/>
       
             
      </p>
          
            
        
      </div>
      
    </div>
    </body>
</html>
";






            }

            else if (status == 3)  // OTP
            {



                htmlBody = @"
<html lang=""en"">
    <head>    
       
        <title>
            Upcoming topics
        </title>
       
    </head>
    <body>
  <div>
    
       <div style='border-top-left-radius:5px;background-color:#0D7E71;color:white; width: 511px; margin-left: 224px;'>
          <div style=' background-color:#2d95bb;'>  <p style=' float:left;padding:10px ;font-family: roboto;font-size:large'><b>Hi Admin<b></p>
              <p style='float:right;font-family: roboto;padding:10px; font-size:medium''>Posted on :   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + @" </p><br />
              <br />
              <br /><br />

          </div>          <p style='border-radius:5px; margin-left: 60px;font-size:medium;'><b> Name :<b>  " + name + "<br/><br/> <b> Email Address : <b>" + email + "<br/><br/><b> Your OTP is : <b>" + stt + @"

          <br/>
             <br/><br/>
       
             
      </p>
          
            
        
      </div>
      
    </div>
    </body>
</html>
";

            }
            try
            {


                if (status == 4) {

                    email = "agarwalsurabhi64@gmail.com";
                    stt = "done";
                }

                using (MailMessage mm = new MailMessage("agarwalsurabhi64@gmail.com", email))
                {
                    mm.Subject = "InBox";
                    mm.Body = htmlBody;

                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("agarwalsurabhi64@gmail.com", "8171490748");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;
                    smtp.Send(mm);

                }

                return stt;



            }
            catch (Exception e1)
            {
            if (status == 4) {

                 
                    stt = "nodone";
                }
                 return stt;
            }



        

    }
    }
