<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Acceso_Login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema</title>
    <link rel="stylesheet" href="~/assets/bootstrap/css/bootstrap.min.css" runat="server" />
      <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
      <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
      <!-- Theme style -->
    <link rel="stylesheet" href="~/assets/dist/css/AdminLTE.min.css" runat="server" />
     <!-- iCheck -->
    <link rel="stylesheet" href="~/assets/plugins/iCheck/square/blue.css" runat="server" />
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <a href="~/index"><b>Admin</b>Retro</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">Ingrese sus credenciales</p>

    <form runat="server">
      <div class="form-group has-feedback">
        <input type="email" class="form-control" placeholder="Email">
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
        <input type="password" class="form-control" placeholder="Password">
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <!-- /.col -->
        <div class="col-xs-4">
          <button type="submit" class="btn btn-primary btn-block btn-flat">Sign In</button>
        </div>
        <!-- /.col -->
      </div>

        <asp:ScriptManager ID="ScriptManager1" AsyncPostBackTimeout="360000" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
                <Scripts>
                    <asp:ScriptReference Path="~/assets/plugins/jQuery/jQuery-2.2.0.min.js" />
                    <asp:ScriptReference Path="~/assets/bootstrap/js/bootstrap.min.js" />
                    
                </Scripts>
           
           </asp:ScriptManager>
    </form>
  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->


    
</body>
</html>
