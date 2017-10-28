<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="project.EditProfile" %>
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
   <title>Together | EditProfile</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link href="css/vendor/all.css" rel="stylesheet">
  <link href="css/app/app.css" rel="stylesheet">
</head>

<body id="body" runat="server">
    <form runat="server">
  <!-- Wrapper required for sidebar transitions -->
  <div class="st-container">
        <div class="modal fade" id="myModal"style="border-radius:6px;" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header  alert-success" style="border-radius:6px;">
        <h4 class="modal-title" id="H2" style="text-align:center; font-size:30px"><i class="fa fa-headphones" style="color:black"></i>&nbsp;Edit Your Profile</h4>
      </div>
      <div class="modal-body">
          <ul class="list-unstyled profile-about margin-none" style="text-align:center">
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label18" runat="server" Text="Name"></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label2" runat="server" Text="Date of Birth"></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox3" runat="server" class="form-control" TextMode="Date"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label3" runat="server" Text="Phone Number" ></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label4" runat="server" Text="Recovery Email" ></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label5" runat="server" Text="City" ></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                         <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><asp:Label ID="Label6" runat="server" Text="Country" ></asp:Label></div>
                          <div class="col-sm-6"><asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox><br /><br /></div>
                        </div>
                      </li>
                   
                    </ul>
            
            </div>
      <div class="modal-footer">
         <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Update" OnClick="Button1_Click"/>
      </div>
    </div>
  </div>
      </div>

    
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
                <li>
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Logout</asp:LinkButton></li>
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
                                    <li  class="active">
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

          <div class="container">

            <div class="tabbable">
                <ul class="nav nav-tabs">
                <li class="active"><a href="#home" data-toggle="tab"><i class="fa fa-fw fa-picture-o"></i> Photos</a></li>
                
              </ul>
              <div class="tab-content">
                <div class="tab-pane fade active in" id="home" runat="server">
                    
                </div>
             
              </div>
            </div>
            <div class="row">
              <div class="col-md-6">
                <div class="panel panel-default">
                  <div class="panel-heading panel-heading-gray">
                    <a href="#" class="btn btn-white btn-xs pull-right" data-toggle="modal" data-target="#myModal"><i class="fa fa-pencil"></i></a>
                    <i class="fa fa-fw fa-info-circle"></i> About
                  </div>
                  <div class="panel-body">
                    <ul class="list-unstyled profile-about margin-none">
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Name</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Date of Birth</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Phone Number</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Email</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                      <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Recovery Email</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                         <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Gender</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                         <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">City</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                         <li class="padding-v-5">
                        <div class="row">
                          <div class="col-sm-4"><span class="text-muted">Country</span></div>
                          <div class="col-sm-8"><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label></div>
                        </div>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="panel panel-default">
                  <div class="panel-heading panel-heading-gray">
                    
                    <i class="icon-user-1"></i> Friends
                  </div>
                  <div class="panel-body">
                    <ul class="img-grid" id="friends" runat="server">
                     
                    </ul>
                  </div>
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
      <strong>Together</strong> &copy; Copyright 2016
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

  <!-- Vendor Scripts Bundle
    Includes all of the 3rd party JavaScript libraries above.
    The bundle was generated using modern frontend development tools that are provided with the package
    To learn more about the development process, please refer to the documentation.
    Do not use it simultaneously with the separate bundles above. -->
  <script src="js/vendor/all.js"></script>

  <!-- Vendor Scripts Standalone Libraries -->
  <!-- <script src="js/vendor/core/all.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.js"></script> -->
  <!-- <script src="js/vendor/core/bootstrap.js"></script> -->
  <!-- <script src="js/vendor/core/breakpoints.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.nicescroll.js"></script> -->
  <!-- <script src="js/vendor/core/isotope.pkgd.js"></script> -->
  <!-- <script src="js/vendor/core/packery-mode.pkgd.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.grid-a-licious.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.cookie.js"></script> -->
  <!-- <script src="js/vendor/core/jquery-ui.custom.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.hotkeys.js"></script> -->
  <!-- <script src="js/vendor/core/handlebars.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.hotkeys.js"></script> -->
  <!-- <script src="js/vendor/core/load_image.js"></script> -->
  <!-- <script src="js/vendor/core/jquery.debouncedresize.js"></script> -->
  <!-- <script src="js/vendor/core/modernizr.js"></script> -->
  <!-- <script src="js/vendor/core/velocity.js"></script> -->
  <!-- <script src="js/vendor/tables/all.js"></script> -->
  <!-- <script src="js/vendor/tables/jquery.dataTables.js"></script> -->
  <!-- <script src="js/vendor/tables/dataTables.bootstrap.js"></script> -->
  <!-- <script src="js/vendor/forms/all.js"></script> -->
  <!-- <script src="js/vendor/forms/bootstrap-slider.js"></script> -->
  <!-- <script src="js/vendor/forms/bootstrap-select.js"></script> -->
  <!-- <script src="js/vendor/forms/bootstrap-switch.js"></script> -->
  <!-- <script src="js/vendor/forms/bootstrap-datepicker.js"></script> -->
  <!-- <script src="js/vendor/forms/moment.js"></script> -->
  <!-- <script src="js/vendor/forms/daterangepicker.js"></script> -->
  <!-- <script src="js/vendor/forms/jquery.minicolors.js"></script> -->
  <!-- <script src="js/vendor/forms/jquery.bootstrap-touchspin.js"></script> -->
  <!-- <script src="js/vendor/forms/select2.js"></script> -->
  <!-- <script src="js/vendor/forms/summernote.js"></script> -->
  <!-- <script src="js/vendor/media/all.js"></script> -->
  <!-- <script src="js/vendor/player/all.js"></script> -->
  <!-- <script src="js/vendor/charts/all.js"></script> -->
  <!-- <script src="js/vendor/charts/flot/all.js"></script> -->
  <!-- <script src="js/vendor/charts/easy-pie/jquery.easypiechart.js"></script> -->
  <!-- <script src="js/vendor/charts/morris/all.js"></script> -->
  <!-- <script src="js/vendor/charts/sparkline/all.js"></script> -->
  <!-- <script src="js/vendor/maps/vector/all.js"></script> -->
  <!-- <script src="js/vendor/tree/jquery.fancytree-all.js"></script> -->
  <!-- <script src="js/vendor/nestable/jquery.nestable.js"></script> -->
  <!-- <script src="js/vendor/angular/all.js"></script> -->

  <!-- App Scripts Bundle
    Includes Custom Application JavaScript used for the current theme/module;
    Do not use it simultaneously with the standalone modules below. -->
  <script src="js/app/app.js"></script>

  <!-- App Scripts Standalone Modules
    As a convenience, we provide the entire UI framework broke down in separate modules
    Some of the standalone modules may have not been used with the current theme/module
    but ALL the modules are 100% compatible -->

  <!-- <script src="js/app/essential-all.js"></script> -->
  <!-- <script src="js/app/essential-core.js"></script> -->
  <!-- <script src="js/app/essential-cover.js"></script> -->
  <!-- <script src="js/app/essential-expandable.js"></script> -->
  <!-- <script src="js/app/essential-forms.js"></script> -->
  <!-- <script src="js/app/essential-nestable.js"></script> -->
  <!-- <script src="js/app/essential-tables.js"></script> -->
  <!-- <script src="js/app/essential-tree.js"></script> -->
  <!-- <script src="js/app/material.js"></script> -->
  <!-- <script src="js/app/layout.js"></script> -->
  <!-- <script src="js/app/sidebar.js"></script> -->
  <!-- <script src="js/app/media.js"></script> -->
  <!-- <script src="js/app/player.js"></script> -->
  <!-- <script src="js/app/timeline.js"></script> -->
  <!-- <script src="js/app/chat.js"></script> -->
  <!-- <script src="js/app/maps/vector.js"></script> -->
  <!-- <script src="js/app/maps/google.js"></script> -->
  <!-- <script src="js/app/charts/all.js"></script> -->
  <!-- <script src="js/app/charts/flot.js"></script> -->
  <!-- <script src="js/app/charts/easy-pie.js"></script> -->
  <!-- <script src="js/app/charts/morris.js"></script> -->
  <!-- <script src="js/app/charts/sparkline.js"></script> -->

  <!-- App Scripts CORE [social-3]:
        Includes the custom JavaScript for this theme/module;
        The file has to be loaded in addition to the UI modules above;
        app.js already includes main.js so this should be loaded
        ONLY when using the standalone modules; -->
  <!-- <script src="js/app/main.js"></script> -->
</body>


<!-- Mirrored from themekit.aws.ipv4.ro/dist/themes/social-3/user-private-profile.html by HTTrack Website Copier/3.x [XR&CO'2014], Sat, 20 Feb 2016 05:38:27 GMT -->
</html>