<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChkOTP.aspx.cs" Inherits="project.ChkOTP" %>

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
        <div class="row" id="alert1" runat="server">
            <div class='alert alert-danger alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <span aria-hidden='true'>&times;</span>

                </button>
                <strong>
                    <asp:Label ID="Label2" runat="server" ></asp:Label></strong></div>
        </div>
      <div class="lock-container">
        <h1>Account Access</h1>
        <div class="panel panel-default text-center">
          <img src="img/logo2.png" class="img-circle" height="80">
          <div class="panel-body">
              
             <h4>OTP is send on your mail. Check your mail</h4>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" maxlength="6" placeholder="Enter OTP" required=""></asp:TextBox>
            
              <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Done" class="btn btn-primary"/>
         
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
    

 
  <script src="js/vendor/all.js"></script>
  <script src="js/app/app.js"></script>
        
</body>


</html>