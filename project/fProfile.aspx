<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fProfile.aspx.cs" Inherits="project.fProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace=" project" %>
<!DOCTYPE html>
<html class="st-layout ls-top-navbar ls-bottom-footer hide-sidebar sidebar-r2" lang="en">



<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Together | <%=Session["fname"].ToString() %> Profile</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link href="css/vendor/all.css" rel="stylesheet">
  <link href="css/app/app.css" rel="stylesheet">
    <style>
        #Button1{
            margin-top:10px;
        }
    </style>
 
</head>

<body>
    <form runat="server">
  <!-- Wrapper required for sidebar transitions -->
  <div class="st-container">
      
    <!-- Fixed navbar -->
    <div class="navbar navbar-main navbar-primary navbar-fixed-top" role="navigation">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#main-nav">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          
          <a class="navbar-brand" href="index.aspx"><img src="img/logo3.png" /></a>
            
            </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="main-nav">
          
          <ul class="nav navbar-nav  navbar-right ">
              
           
              
               <li class="dropdown hidden-xs">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-envelope"></i> <b class="caret"></b></a>
                    <ul class="dropdown-menu message-dropdown">
                         <%
                                            SqlConnection cn = new SqlConnection();
                 cn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                 SqlCommand cmd = new SqlCommand("select * from message where (receiver='" + Session["uname"].ToString() + "'or sender='" + Session["uname"].ToString() + "') order by msgid desc", cn);
                 DataSet ds = new DataSet();
                 SqlDataAdapter ad = new SqlDataAdapter(cmd);
                 SqlCommandBuilder cmdb = new SqlCommandBuilder(ad);
                 ad.Fill(ds);
                 returnname r=new returnname();
                 ArrayList c =new ArrayList();
                 c.Add(Session["uname"].ToString());
                 int i = 0;
                 foreach (DataRow dr in ds.Tables[0].Rows)
                 {
                     i++;
                     if ((c.Contains(dr[1].ToString()) || c.Contains(dr[2].ToString()))&& (i<5))
                     {
                         string sender = r.name(dr[1].ToString());
                         string str1 = string.Empty;               %>
                        <li class="message-preview">
                          <a href="Message.aspx">
                                <div class="media">
                                    <span class="pull-left">
                                      
                                        <%abc A = new abc();
                    int t = A.chkpicstat(dr[1].ToString());
                    if (t == 0)
                    {
                        if (A.chkgender(dr[1].ToString()))
                        {
                            %>
                                                    <img class="media-object" src="temp/b.jpg" width="30" alt="">
                                        <%
                        }
                        else
                        {%>
                                       <img class="media-object" src="temp/g.jpg" width="30" alt=""> 
                                        <%
                        }
                    }
                    else{ %>
                                        <img class="media-object" src="Account/<%=dr[1].ToString() %>/p.jpg" width="30" alt=""><%} %>
                                    </span>
                                    <div class="media-body">
                                       
                                        <h5 class="media-heading">
                                            <strong><%=sender %></strong>

                                        </h5>
                                        <p class="small text-muted"><i class="fa fa-clock-o"></i> <%=dr[4].ToString() %></p>
                                        <%
                         string str = dr[3].ToString();
                         if(str.Length>=5)
                         {
                             str1=str.Substring(0, 5);
                         
                                             %>
                                        <p><%=str1 %>...</p>
                         <%}
                           else{
                             %>
                                    <p><%=dr[3].ToString() %></p>
                             <%
                         } %>          

                                    </div>
                                </div>
                           </a>
                        </li>
                       <%
                     }
                 }
                           cn.Close();%>   
                        <li class="message-footer">
                            <a href="Message.aspx">Read All New Messages</a>
                        </li>
                    </ul>
                </li>
               <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bell"></i> <b class="caret"></b></a>
                    <ul class="dropdown-menu alert-dropdown" id="notifi" runat="server">
                       
                    </ul>
                </li>
          
            <!-- User -->
            <li class="dropdown">
              <a href="#" class="dropdown-toggle user" data-toggle="dropdown" id="picdrop" runat="server">
                  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <span class="caret"></span>
              
              </a>
              <ul class="dropdown-menu" role="menu">
                <li><asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton3_Click">Profile</asp:LinkButton></li>
                <li><asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton6_Click">Messages</asp:LinkButton></li>
                <li><asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">Settings</asp:LinkButton></li>
                <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton></li>
              </ul>
            </li>

          </ul>
        </div>
        <!-- /.navbar-collapse -->
      </div>
    </div>
     
   
 
    <!-- content push wrapper -->
    <div class="st-pusher" id="content">

      <!-- sidebar effects INSIDE of st-pusher: -->
      <!-- st-effect-3, st-effect-6, st-effect-7, st-effect-8, st-effect-14 -->

      <!-- this is the wrapper for the content -->
      <div class="st-content">

        <!-- extra div for emulating position:fixed of the menu -->
        <div class="st-content-inner">

          <nav class="navbar navbar-subnav navbar-static-top" role="navigation">
            <div class="container">
                
              <!-- Brand and toggle get grouped for better mobile display -->
              <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#subnav">
                  <span class="sr-only">Toggle navigation</span>
                  <span class="fa fa-ellipsis-h"></span>
                </button>
              </div>

              <!-- Collect the nav links, forms, and other content for toggling -->
              <div class="collapse navbar-collapse" id="subnav">
                <ul class="nav navbar-nav">
                                         <li>
                                        <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server"><i class="fa fa-fw icon-ship-wheel"></i> My Timeline</asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server"><i class="fa fa-fw icon-user-1"></i> Edit Profile</asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton5" OnClick="LinkButton5_Click" runat="server"><i class="fa fa-fw fa-group"></i> Manage Friends</asp:LinkButton>
                                    </li>
                                    <li>
                                         <asp:LinkButton ID="LinkButton6" OnClick="LinkButton6_Click" runat="server"><i class="fa fa-fw icon-comment-fill-1"></i> Messages</asp:LinkButton>
                                    </li>
                </ul>
                <ul class="nav navbar-nav hidden-xs navbar-right">
                  <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click"> <i class="fa fa-fw icon-unlock-fill"></i> Logout</asp:LinkButton></li>
                </ul>
              </div>
              <!-- /.navbar-collapse -->

            </div>
          </nav>
            <div class="container-fluid">
                        <div class="row" id="alert" runat="server">

                        </div>
                    </div>
          <div class="container">

            <div class="cover profile">
              <div class="wrapper">
                <div class="image" id="coverimg" runat="server">
                 
                </div>
                <ul class="friends" id="friend" runat="server" style="overflow-x:hidden;overflow-y:auto">
                
                 
                </ul>
              </div>
              <div class="cover-info">
                <div class="avatar">
                    <div class="drop" id="propic" runat="server"></div>
                 
                </div>
    
                <div class="name">
                    <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>

                </div>
                <ul class="cover-nav">

                   <li class="active"><asp:LinkButton ID="LinkButton10" OnClick="LinkButton3_Click" runat="server"><i class="fa fa-fw icon-ship-wheel"></i> My Timeline</asp:LinkButton></li>
              
                  <li><asp:LinkButton ID="LinkButton11" OnClick="LinkButton5_Click" runat="server"><i class="fa fa-fw fa-users"></i> Friends</asp:LinkButton></li>
                    <li>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-block" Text="Add Friend" OnClick="Button1_Click" Visible="false"/></li>

                </ul>
              </div>
            </div>

            <div class="timeline row" data-toggle="isotope">
              <div class="col-xs-12 col-md-6 col-lg-4 item">
                <div class="timeline-block">
                  <div class="panel panel-default share clearfix-xs">
                    <div class="panel-heading panel-heading-gray title">
                      What&acute;s new
                    </div>
                    <div class="panel-body">
                      <textarea id="status" runat="server" class="form-control share-text" rows="3" placeholder="Share your status..."></textarea>
                    </div>
                    <div class="panel-footer share-buttons">
                      <a href="#"><i class="fa fa-map-marker"></i></a>
                      <a href="#"><i class="fa fa-photo"></i></a>
                      <a href="#"><i class="fa fa-video-camera"></i></a>
                        
                      
                    </div>
                  </div>
                </div>
                  <div class="row">
                      <div class="col-xs-12 col-md-12 col-sm-12 item">
                                        <div class="timeline-block">
                                            <div class="panel panel-default profile-card clearfix-xs">
                                                <div class="panel-body">
                                                    <div class="profile-card-icon">
                                                        <i class="fa fa-graduation-cap"></i>
                                                    </div>
                                                    <%string st = r.name(Session["uname"].ToString()); %>
                                                    <h4 class="text-center"><%=st%> </h4>
                                                    <ul class="icon-list icon-list-block">
                                                        <%
                                                             SqlConnection cn1 = new SqlConnection();
                 cn1.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["cn"].ToString();
                 SqlCommand cmd1 = new SqlCommand("select * from reg where Email='"+Session["fname"].ToString()+"'", cn1);
                 DataSet ds1 = new DataSet();
                 SqlDataAdapter ad1 = new SqlDataAdapter(cmd1);
                 SqlCommandBuilder cmdb1 = new SqlCommandBuilder(ad1);
                 ad1.Fill(ds1);
                 foreach (DataRow dr1 in ds1.Tables[0].Rows)
                 {
                     string[] d = dr1[2].ToString().Split(' ');
                                                             %>
                                                        <li><i class="fa fa-map-marker"></i>Born: <%=d[0]%>, <%=dr1[7].ToString() %>, <%=dr1[8].ToString() %></li>



                                                        <li>
                                                            <i class="fa fa-phone"></i>Phone number: <%=dr1[3].ToString() %><br />

                                                        </li>
                                                        <li>
                                                            <i class="fa fa-calendar"></i>
                                                            Gender : <%=dr1[6].ToString() %>

                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                      <%}
                          cn1.Close(); %>
                  </div>
              </div>
               <div class="col-xs-12 col-md-6 col-sm-12 item" id="wall" runat="server">
                  </div>
              
              
              
             
            </div>

          </div>

        </div>
        <!-- /st-content-inner -->

      </div>
      <!-- /st-content -->

    </div>
    <!-- /st-pusher -->

    <!-- Footer -->
    <footer class="footer">
      <strong>Together</strong>  &copy; Copyright 2016
    </footer>
    <!-- // Footer -->

  </div>
  <!-- /st-container -->
        </form>
  <script src="js/vendor/all.js"></script>
  <script src="js/app/app.js"></script>
</body>

</html>