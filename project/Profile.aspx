<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="project.Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Import Namespace=" project" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>
<html class="st-layout ls-top-navbar ls-bottom-footer hide-sidebar sidebar-r2" lang="en">



<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Together |<%=Session["uname"].ToString() %> Profile</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
  <link href="css/vendor/all.css" rel="stylesheet">
  <link href="css/app/app.css" rel="stylesheet">
  <script src="js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.12.0.min.js"></script>
     <script src="js/vendor/all.js"></script>
  <script src="js/app/app.js"></script>
      <script src="../Scripts/jquery.signalR-1.0.0.js"></script>
  <script src="/signalr/hubs"></script>
    <style>

#nav_menu  #edit_image {
 position:relative;
 width:220px;
 margin:0 auto;
}
#nav_menu1  #edit_img {
 position:relative;
 
 margin:0 auto;
}
.dropdown_2columns
 {
 position:absolute;
 display:none; /* Hides the drop down */
 cursor:pointer;
}
#nav_menu  #edit_image:hover .dropdown_2columns{ 
 left:70px;
 /*float:right;*/
 display:inline;
 top:15px;
}
#nav_menu1  #edit_img:hover .dropdown_2columns{ 
 
 /*float:right;*/
 display:inline;
 top:15px;
}
.img1{
background:transparent url('img/pencil.png') no-repeat scroll right top;
height:18px;width:18px;
/*float:left;*/
}
.img{
background:transparent url('img/pencil.png') no-repeat scroll right top;
height:18px;width:18px;
/*float:left;*/
}
    </style>
     <style>
			@media only screen and (max-width : 540px) 
			{
				.chat-sidebar
				{
					display: none !important;
				}
				
				.chat-popup
				{
					display: none !important;
				}
			}
			
		
			
			.chat-sidebar
			{
				width: 200px;
				position: fixed;
				height: 100%;
				right: 0px;
				top: 0px;
				padding-top: 10px;
				padding-bottom: 10px;
				border: 1px solid rgba(29, 49, 91, .3);
                background-color:#4e5d6c;
                
			}
			
			.sidebar-name 
			{
				padding-left: 10px;
				padding-right: 10px;
				margin-bottom: 4px;
				font-size: 12px;
			}
			
			.sidebar-name span
			{
				padding-left: 5px;
			}
			
			.sidebar-name a
			{
				display: block;
				height: 100%;
				text-decoration: none;
				color: inherit;
			}
			
		
			.sidebar-name img
			{
				width: 32px;
				height: 32px;
				vertical-align:middle;
			}
			
			.popup-box
			{
				display: none;
				position: fixed;
				bottom: 25px;
				right: 220px;
				height: 285px;
				background-color: rgb(237, 239, 244);
				width: 300px;
				border: 1px solid rgba(29, 49, 91, .3);
			}
			
			.popup-box .popup-head
			{
				background-color: #6d84b4;
				padding: 5px;
				color: white;
				font-weight: bold;
				font-size: 14px;
				clear: both;
			}
			
			.popup-box .popup-head .popup-head-left
			{
				float: left;
			}
			
			.popup-box .popup-head .popup-head-right
			{
				float: right;
				opacity: 0.5;
                
			}
			
			.popup-box .popup-head .popup-head-right a
			{
				text-decoration: none;
				color: inherit;
			}
			
			.popup-box .popup-messages
			{
				height: 100%;
				overflow-y: scroll;
			}
			
			#carbonads { 
			    max-width: 300px; 
			    background: #f8f8f8;
			}

			.carbon-text { 
			    display: block; 
			    width: 130px; 
			}

			.carbon-poweredby { 
			    float: right; 
			}
			.carbon-text {
			    padding: 8px 0; 
			}

			#carbonads { 
			    padding: 15px;
			    border: 1px solid #ccc; 
			}

			.carbon-text {
			    font-size: 12px;
			    color: #333333;
			    text-decoration: none;
			}


			.carbon-poweredby {
			    font-size: 75%;
			    text-decoration: none;
			}

			#carbonads { 
			    position: fixed; 
			    top: 5px;
			    left: 5px;
			}

		</style>
  
     <style>
                #cond {
width: 960px; 
position: relative;
margin:0 auto;
line-height: 1.4em;
}

                @media only screen and (max-width: 479px) {
                    #cond {
                        width: 90%;
                    }
                }
            </style>
    	<script async type="text/javascript" src="..Scripts/carbond123.js?zoneid=1673&amp;serve=C6AILKT&amp;placement=qnimate" id="_carbonads_js"></script>
</head>

<body id="body" runat="server">
    <form runat="server">
                 <script>
                     //this function can remove a array element.
                     Array.remove = function (array, from, to) {
                         var rest = array.slice((to || from) + 1 || array.length);
                         array.length = from < 0 ? array.length + from : from;
                         return array.push.apply(array, rest);
                     };

                     //this variable represents the total number of popups can be displayed according to the viewport width
                     var total_popups = 0;

                     //arrays of popups ids
                     var popups = [];

                     //this is used to close a popup
                     function close_popup(id) {
                         for (var iii = 0; iii < popups.length; iii++) {
                             if (id == popups[iii]) {
                                 Array.remove(popups, iii);

                                 document.getElementById(id).style.display = "none";

                                 calculate_popups();

                                 return;
                             }
                         }
                     }

                     //displays the popups. Displays based on the maximum number of popups that can be displayed on the current viewport width
                     function display_popups() {
                         var right = 220;

                         var iii = 0;
                         for (iii; iii < total_popups; iii++) {
                             if (popups[iii] != undefined) {
                                 var element = document.getElementById(popups[iii]);
                                 element.style.right = right + "px";
                                 right = right + 320;
                                 element.style.display = "block";
                             }
                         }

                         for (var jjj = iii; jjj < popups.length; jjj++) {
                             var element = document.getElementById(popups[jjj]);
                             element.style.display = "none";
                         }
                     }

                     //creates markup for a new popup. Adds the id to popups array.
                     function register_popup(id, name) {

                         for (var iii = 0; iii < popups.length; iii++) {
                             //already registered. Bring it to front.
                             if (id == popups[iii]) {
                                 Array.remove(popups, iii);

                                 popups.unshift(id);

                                 calculate_popups();


                                 return;
                             }
                         }

                         //  var element = '<div class="popup-box chat-popup" id="' + id + '">';
                         // element = element + '<div class="popup-head">';
                         // element = element + '<div class="popup-head-left">' + name + '</div>';
                         // element = element + '<div class="popup-head-right"><a href="javascript:close_popup(\'' + id + '\');">&#10005;</a></div>';
                         // element = element + '<div style="clear: both"></div></div><div class="popup-messages ">asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br>asdsad<br></div>';
                         //  element = element + '<div class="popup-footer">1weqweqw2asda</div></div>';



                         var element = '<div class="panel panel-default popup-box chat-popup" id="' + id + '">';
                         element = element + ' <div class="panel-heading" style="background-color:rgb(38,166,154)"><span  id="' + id + '-h" style="color:white">' + name + '</span><span style="float:right;"> <a style="color:white" href="javascript:close_popup(\'' + id + '\');">&#10005;</a> </span> </div>';
                         element = element + '  <div style="height:68%;color:red;overflow-y: scroll; " data-spy="scroll" class="panel-body" id="' + id + '-p" >';


                         element = element + '   </div> <div class="panel-footer"><table><tr><td><input  class="form-control btn-sm"  id="' + id + '-t" type="text" style="width:230px"/></td><td></td><td> <input  class="sendmessage btn btn-success  btn-sm"  value="Send"   id="' + id + '-b" type="button"/></td></tr></table> </div> </div>';

                         document.getElementsByTagName("body")[0].innerHTML = document.getElementsByTagName("body")[0].innerHTML + element;

                         popups.unshift(id);

                         calculate_popups();




                         var xmlHttp2;




                         var siiid = document.getElementById('Label2').innerHTML;
                         var newiiid = document.getElementById('Label1').innerHTML;

                         xmlHttp2 = new XMLHttpRequest();
                         var url2 = "ajax.aspx?sid=" + siiid + "&rid=" + id + "&newid=" + newiiid + "&status=1";
                         xmlHttp2.open("GET", url2, true);
                         xmlHttp2.onreadystatechange = OnResponse2;
                         xmlHttp2.send(null);



                         function OnResponse2() {

                             if (xmlHttp2.readyState == 4) {
                                 var res2 = xmlHttp2.responseText;

                                 $('#' + id + '-p').empty();
                                 $('#' + id + '-p').append(res2);


                             }
                         }


                     }

                     //calculate the total number of popups suitable and then populate the toatal_popups variable.
                     function calculate_popups() {
                         var width = window.innerWidth;
                         if (width < 540) {
                             total_popups = 0;
                         }
                         else {
                             width = width - 200;
                             //320 is width of a single popup box
                             total_popups = parseInt(width / 320);
                         }

                         display_popups();

                     }

                     //recalculate when window is loaded and also when window is resized.
                     window.addEventListener("resize", calculate_popups);
                     window.addEventListener("load", calculate_popups);

		</script>

  <!-- Wrapper required for sidebar transitions -->
  <div class="st-container">
      <div class="modal fade" id="Picturemodal"style="border-radius:6px;" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header  alert-success" style="border-radius:6px;">
        <h4 class="modal-title" id="H2" style="text-align:center; font-size:20px"><i class="fa fa-headphones" style="color:black"></i>&nbsp;Change Profile Picture</h4>
      </div>
      <div class="modal-body">
         <h5>(only jpg format supported)</h5>
             <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server"/>
         
		 
           <asp:Button ID="Button2" runat="server" Text="Upload" CssClass="btn btn-success" OnClick="Button2_Click" style="width:100px; margin-top:4px;"/>        
      </div>
     
    </div>
  </div>
      </div>
        <!-------------------------------------------------------------------------------------------------------->
      <div class="modal fade" id="Covermodal"style="border-radius:6px;" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header  alert-success" style="border-radius:6px;">
        <h4 class="modal-title" id="H3" style="text-align:center; font-size:30px"><i class="fa fa-headphones" style="color:black"></i>&nbsp;Change Cover Picture</h4>
      </div>
      <div class="modal-body">
         <h5>(only jpg format supported)</h5>
             <asp:FileUpload ID="FileUpload2" CssClass="form-control" runat="server" />
         
		    <asp:Button ID="Button4" runat="server" Text="Upload" CssClass="btn btn-success" OnClick="Button4_Click" style="width:100px; margin-top:4px;"/>           
      </div>
    
    </div>
  </div>
      </div>
      <!-------------------------------------------------------------------------------------------------------->
      
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
          
          <ul class="nav navbar-nav  navbar-right">
              <li class="dropdown hidden-xs">
                 <table>
                     <tr>
                         <td>
                              <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:TextBox ID="TextBox1" class="form-control" runat="server"  Height="50" Width="250"></asp:TextBox>
         <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetName" ServicePath="" TargetControlID="TextBox1"></cc1:AutoCompleteExtender>
                         </td>
                         <td>
                               <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button2_Click1" Text="Search" Height="50"/>
  
                         </td>
                     </tr>
                 </table>
           
              </li>
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
                           ds.Dispose();
                           cn.Close(); %>   
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
                  <asp:Label ID="Label2" runat="server" Text="" Font-Size="0.5"></asp:Label>
              </li>
                                    <li  class="active">
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
                       <div class="row" id="alert1" runat="server">
            <div class='alert alert-danger alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label3" runat="server" ></asp:Label></strong></div>
        </div>
                    </div>
          <div class="container">

            <div class="cover profile">
              <div class="wrapper">
                <div class="image">
                    <div id="nav_menu1">
                                   
    <div id="edit_img">
    <div class="drop" id="coverimg" runat="server"></div>
    
        <div class="dropdown_2columns">
    
            <div class="col_2">
                <a href="#Covermodal" data-toggle="modal"><div class="img1"></div></a>             
            </div>
    
        </div>
 </div>
</div>
                  
                </div>
                <ul class="friends" id="friend" runat="server" style="overflow-x:hidden;overflow-y:auto">
                 
                </ul>
              </div>
              <div class="cover-info">
                <div class="avatar">
                 <div id="nav_menu">

    <div id="edit_image">
    <div class="drop" id="propic" runat="server"></div>
    
        <div class="dropdown_2columns">
    
            <div class="col_2">
                <a href="#Picturemodal" data-toggle="modal"><div class="img"></div></a>             
            </div>
    
        </div>
 </div>
</div>
                </div>
    
                <div class="name hidden-xs">
                    <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink></div>
                <ul class="cover-nav">

                  <li class="active"><asp:LinkButton ID="LinkButton10" OnClick="LinkButton3_Click" runat="server"><i class="fa fa-fw icon-ship-wheel"></i> My Timeline</asp:LinkButton></li>
                
                  <li><asp:LinkButton ID="LinkButton11" OnClick="LinkButton5_Click" runat="server"><i class="fa fa-fw fa-users"></i> Friends</asp:LinkButton></li>

                </ul>
              </div>
            </div>

            <div class="timeline row" data-toggle="isotope">
              <div class="col-xs-12 col-md-4 col-lg-4 item">
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
                        <asp:Button ID="Button3" runat="server" class="btn btn-primary pull-right" Height="30" Text="Post" onclick="Button3_Click"/>
                     
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
                 SqlCommand cmd1 = new SqlCommand("select * from reg where Email='"+Session["uname"].ToString()+"'", cn1);
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
              <div class="col-xs-12 col-md-5 col-sm-12 item" id="wall" runat="server">
           
                  </div>
              <div class="col-xs-12 col-md-3 col-sm-12 item">
                <div class="timeline-block" id="request" runat="server">
                    <div class="panel panel-default share clearfix-xs">
                        <div class="panel-heading panel-heading-gray title">
                            <h1>Friends</h1>
                        </div>
                        <div class="panel-body" id="flist" runat="server">
                           
                        </div>
                      
                    </div>  

        <!-- /st-content-inner -->
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
      <strong>Together</strong>  &copy; Copyright 2016
    </footer>
    <!-- // Footer -->

  </div>
  <!-- /st-container -->
       
        </form>
         <script>
             $(function () {


                 // Reference the auto-generated proxy for the hub.
                 var chat = $.connection.chatHub;



                 // Create a function that the hub can call back to display messages.
                 chat.client.addNewMessageToPage = function (name1, message, status) {
                     // Add the message to the page.
                     // message=id
                     
                     if (status == 1) {

                         if ($("#" + message + "-i").length != 0) {
                             $("#" + message + "-i").attr("src", "img/g.png");

                         }



                     }
                     else
                         if (status == 2) {


                             if ($("#" + message + "-i").length != 0) {
                                 $("#" + message + "-i").attr("src", "img/d.png");

                             }
                         }

                         else if (status == 3) {
                             var arr = name1.split('}');


                             $('#' + arr[0] + '-p').append('<div style="border-radius:5px" class="cond alert alert-dismissible alert-success">' + message + '</div>');



                             register_popup(arr[0], arr[1]);
                         }

                 };



                 $.connection.hub.qs = { "id": $('#Label2').text() + "}" + $('#Label1').text() };


                 // Start the connection.


                 $.connection.hub.start().done(function () {



                     $(document).on("click", ".sendmessage", function () {
                         // $('.sendmessage').click(function () {

                         var id = this.id;
                         
                         var arr = id.split('-');
                         var value1 = $('#' + arr[0] + '-t').val();

                         $('#' + arr[0] + '-p').append('<div style="border-radius:5px" class="cond alert alert-dismissible alert-warning">' + value1 + '</div>');

                         // send to server
                         chat.server.send(arr[0], value1, document.getElementById('Label1').innerHTML, document.getElementById('Label2').innerHTML);

                         $('#' + arr[0] + '-t').val('');

                     }

                     );



                 });
             });




    </script>

 
</body>

</html>