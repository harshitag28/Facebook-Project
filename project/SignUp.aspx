<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="project.SignUp" %>

<!DOCTYPE html>
<html class="hide-sidebar ls-bottom-footer" lang="en">


<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Together | Sign Up</title>
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
<link rel="icon" href="img/favicon.ico" type="image/x-icon">
<script src="js/jquery.min.js"></script>
 <script src="js/bootstrap.min.js"></script>
  <link href="css/vendor/all.css" rel="stylesheet">
<link href="css/app/app.css" rel="stylesheet">
     <script type='text/javascript'>
         $(document).ready(function () {
             $('#signup').attr("disabled", "false");
             $('#tnc').click(function () {
                 var checked_status = this.checked;
                 if (checked_status == true) {
                     $("#signup").removeAttr("disabled");
                 } else {
                     $("#signup").attr("disabled", "disabled");
                 }

             });
         });
</script>
    <style>
        .Space label{
            margin-left:5px;
        }
    </style>
</head>

<body class="login" >
    <form runat="server">

      

  <div id="content">
    <div class="container-fluid">
        <div class="row" id="alert1" runat="server">
            <div class='alert alert-danger alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label2" runat="server" ></asp:Label></strong></div>
        </div>
      <div class="lock-container">
        <h1>Register Now</h1>
        <div class="panel panel-default text-center">
          <img src="img/logo2.png" height="80">
          <div class="panel-body">
            <input class="form-control" type="text" id="name" runat="server" pattern="(?=.*[a-z])(?=.*[A-Z]).{2,}" placeholder="Full Name" required="required"/>
               <asp:TextBox ID="dob" class="form-control" TextMode="Date" required="" runat="server"></asp:TextBox>
           <input class="form-control" type="text" pattern="[789][0-9]{9}" runat="server" id="phone" required placeholder="Phone Number">
            <input class="form-control" type="email" id="email" runat="server" placeholder="Email" required="required"/>
              <input class="form-control" type="email" id="remail" runat="server" placeholder="Recovery Email" required="required"/>
            <div class="row">
                <div class="col-md-6 col-xs-5 col-sm-3">
              <asp:RadioButton ID="RadioButton1" runat="server" CssClass="Space" Text="Male" GroupName="gender"/></div>
                <div class="col-md-6 col-xs-5 col-sm-3">
              <asp:RadioButton ID="RadioButton2" runat="server" CssClass="Space" Text="Female" GroupName="gender" /><br /></div>

                </div>
          <input type="checkbox" id="tnc" runat="server"/> I agree to the <a href="#">Terms of Service</a> and <a href="#">Privacy Policy</a><br />
            <asp:Button ID="signup" OnClick="signup_Click" runat="server" class="btn btn-primary" Text="Sign Up" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
              <a href="Login.aspx" class="forgot-password">Already a member... Login</a>
         
               </div>
        </div>
      

    </div>
  </div>
      </div>
        <%--<div class="modal fade" id="modal2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body alert-success" id="Div3" style="text-align:center">
                  <p>Please fill all the entries properly. You are not registered.</p>
                    
                </div>
                <div class="modal-footer" style="text-align:center; font-size:22px;">
                  <a href="SignUp.aspx" style="font-family:Arial">Again Register</a>
                </div>
            </div>
        </div>
    </div>--%>
    

        
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