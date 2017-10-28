<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="project.Login" %>

<!DOCTYPE html>
<html class="hide-sidebar ls-bottom-footer" lang="en">


<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Together | Login</title>
   
  <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
     
  <link href="css/vendor/all.css" rel="stylesheet">
<link href="css/app/app.css" rel="stylesheet">
      <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
</head>

<body class="login">
    <form runat="server">
        
  <div id="content">
    <div class="container-fluid">
        <div class="row" id="alert" runat="server">
            <div class='alert alert-success alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label4" runat="server" ></asp:Label></strong></div>
        </div>
        <div class="row" id="alert1" runat="server">
            <div class='alert alert-danger alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label3" runat="server" ></asp:Label></strong></div>
        </div>
      <div class="lock-container">
        <h1>Account Access</h1>
        <div class="panel panel-default text-center">
          <img src="img/logo2.png"  height="80">
          <div class="panel-body">
              
             
            <input class="form-control" type="email" id="email" runat="server" placeholder="Email" required="required">
            <input class="form-control" type="password" id="pass" runat="server" placeholder="Enter Password" required="required">
           
            
                <asp:Button ID="login" OnClick="login_Click" runat="server" class="btn btn-primary" Text="Login" />
            
            <a href="#" class="forgot-password" data-toggle="modal" data-target="#myModal">Forgot password?</a>
            <a href="SignUp.aspx" class="forgot-password">Not a member yet...Register Now !!</a>
         
               </div>
        </div>
      </div>

    </div>
      
       <div class="modal fade" id="myModal"style="border-radius:3px;" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" >
    <div class="modal-content">
      <div class="modal-header  alert-success" style="border-radius:3px;">
        <h4 class="modal-title" id="H2" style="text-align:center; font-size:20px"><i class="fa fa-spinner" style="color:black"></i>&nbsp;Forgot Password</h4>
      </div>
      <div class="modal-body">
         <h5>Provide your Email here...</h5>
            <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="Enter Email"></asp:TextBox> 
		 <asp:Label ID="Label1" runat="server" ></asp:Label>
                   
      </div>
        <div class="modal-footer">
         
            <asp:Button ID="Button1" runat="server" formnovalidate="" CssClass="btn btn-primary" Text="Submit" OnClick="Button2_Click"/>
            <asp:Button ID="Button4" runat="server" CssClass="btn btn-default"  data-dismiss="modal" Text="Close"  />
        </div>
    </div>
  </div>
      </div>
      <div class="modal fade" id="modal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body alert-danger" style="text-align:center">
               <strong><em>   Fields can't be left blank.</em></strong>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </div>
                <div class="modal-footer" style="background-color:rgb(126, 182, 229); text-align:center; font-size:22px; color:white; font-family:'Comic Sans MS';">
                  <a href="#" data-dismiss="modal" style="color:white">Again Register</a>
                </div>
            </div>
        </div>
    </div>
        
  </div>
        
  <!-- Footer -->
  <footer class="footer">
   <strong>Together</strong>  &copy; Copyright 2016
  </footer>
  <!-- // Footer -->
    
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