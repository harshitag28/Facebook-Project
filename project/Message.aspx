﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="project.Message" %>
<%@ Import Namespace=" project" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>
<html class="st-layout ls-top-navbar ls-bottom-footer hide-sidebar sidebar-r2" lang="en">



<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Together | Message</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
    <link href="css/vendor/all.css" rel="stylesheet">
    <link href="css/app/app.css" rel="stylesheet">
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
                   %>   
                        <li class="message-footer">
                            <a href="Message.aspx">Read All New Messages</a>
                        </li>
                    </ul>
                </li>
                        <li class="dropdown hidden-xs">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bell"></i><b class="caret"></b></a>
                            <ul class="dropdown-menu alert-dropdown" id="notifi" runat="server">
                               
                            </ul>
                        </li>

                        <!-- User -->
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle user" data-toggle="dropdown"  id="picdrop" runat="server">
                               
                                 <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <span class="caret"></span>
                            </a>
                            <ul class="dropdown-menu" role="menu">
                                 <li><asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton1_Click">Profile</asp:LinkButton></li>
                                 <li><asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton4_Click">Messages</asp:LinkButton></li>
                                 <li><asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">Settings</asp:LinkButton></li>
                                <li><asp:LinkButton ID="LinkButton6" OnClick="LinkButton5_Click" runat="server">Logout</asp:LinkButton></li>
                            </ul>
                        </li>

                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
        </div>



   

        <!-- sidebar effects OUTSIDE of st-pusher: -->
        <!-- st-effect-1, st-effect-2, st-effect-4, st-effect-5, st-effect-9, st-effect-10, st-effect-11, st-effect-12, st-effect-13 -->

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
                                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server"><i class="fa fa-fw icon-ship-wheel"></i> My Timeline</asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server"><i class="fa fa-fw icon-user-1"></i> Edit Profile</asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server"><i class="fa fa-fw fa-group"></i> Manage Friends</asp:LinkButton>
                                    </li>
                                    <li class="active">
                                         <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server"><i class="fa fa-fw icon-comment-fill-1"></i> Messages</asp:LinkButton>
                                    </li>
                                </ul>
                                <ul class="nav navbar-nav hidden-xs navbar-right">
                                    <li><asp:LinkButton ID="LinkButton5" OnClick="LinkButton5_Click" runat="server">Logout<i class="fa fa-fw icon-unlock-fill"></i></asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                            <!-- /.navbar-collapse -->

                        </div>
                    </nav>
                    <div class="container-fluid">
                       <div class="row" id="alert1" runat="server">
            <div class='alert alert-warning alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label2" runat="server" ></asp:Label></strong></div>
        </div>
                    </div>
                    <div class="container">

                        <div class="media messages-container media-clearfix-xs-min media-grid">
                            <div class="media-left">
                                <div class="messages-list">
                                    <div class="panel panel-default">
                                        <ul class="list-group" id="frnds" runat="server">
                                           
                                                
                                                   
                                             
                                           
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="media-body"  id="msg" runat="server">
                                <div class="panel panel-default share">
                                    <div class="input-group">
                                        <div class="input-group-btn">
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary" Text="Send" />
                                           
                                        </div>
                                        <!-- /btn-group -->
                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control share-text" placeholder="Write message..."></asp:TextBox>
                                        
                                    </div>
                                    <!-- /input-group -->
                                </div>
                                
                               
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
            <strong>Together</strong>&copy; Copyright 2016
   
        </footer>
        <!-- // Footer -->

    </div>
    <!-- /st-container -->
    </form>
    <!-- Inline Script for colors and config objects; used by various external scripts; -->
    <script>
        var colors = {
            "danger-color": "#e74c3c",
            "success-color": "#81b53e",
            "warning-color": "#f0ad4e",
            "inverse-color": "#2c3e50",
            "info-color": "#2d7cb5",
            "default-color": "#6e7882",
            "default-light-color": "#cfd9db",
            "purple-color": "#9D8AC7",
            "mustard-color": "#d4d171",
            "lightred-color": "#e15258",
            "body-bg": "#f6f6f6"
        };
        var config = {
            theme: "social-3",
            skins: {
                "default": {
                    "primary-color": "#16ae9f"
                },
                "orange": {
                    "primary-color": "#e74c3c"
                },
                "blue": {
                    "primary-color": "#4687ce"
                },
                "purple": {
                    "primary-color": "#af86b9"
                },
                "brown": {
                    "primary-color": "#c3a961"
                },
                "default-nav-inverse": {
                    "color-block": "#242424"
                }
            }
        };
  </script>
    <script src="js/vendor/all.js"></script>
    <script src="js/app/app.js"></script>
</body>
</html>
