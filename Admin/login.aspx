<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Grofinhub</title>
    <link rel="shortcut icon"  href="webdoc/images/logo.png"> 
    <link type="text/css" rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" />

    <!--page specific css styles-->

    <!--flaty css styles-->
    <link rel="stylesheet" href="css/flaty.css" />
    <link rel="stylesheet" href="css/flaty-responsive.css" />
    <style type="text/css">
        .login-page {
            padding: 0;
        }

        .join {
            float: right;
            position: relative;
            top: -26px;
        }

        .login-page .login-wrapper {
            top: 120px;
        }
    </style>
</head>
<body class="login-page">

    <div class="login-wrapper">
        <form id="form1" runat="server">

            <center>
                <asp:Image ID="Image1" runat="server" class="img-responsive" src="/images/logo.png" />
            </center>


            <h3>
                <asp:Label ID="lblcomname" runat="server"></asp:Label></h3>
            <hr />
            <div class="form-group">
                <div class="controls">
                    <asp:TextBox ID="txtuserid" runat="server" placeholder="Username" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" ControlToValidate="txtuserid" runat="server" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="submit">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="controls">
                    <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtpassword" runat="server" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="submit">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="controls">
                    <label class="checkbox">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me" />
                        <div class="pull-right">
                            <a href="forgotpaasword.aspx" class="btn">Forgot Password ??</a>
                        </div>
                    </label>
                </div>
            </div>
            <div class="form-group">
                <div class="controls">
                    <asp:Button ID="Button1" runat="server" Text="Sign In" class="btn btn-primary form-control" OnClick="Button1_Click" ValidationGroup="submit" />
                    <br />
                </div>
            </div>
            <hr />
        </form>

    </div>

    <!--basic scripts-->
    <script type="text/javascript" src="../../ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript">    window.jQuery || document.write('<script src="assets/jquery/jquery-2.1.1.min.js"><\/script>')</script>
    <script type="text/javascript" src="assets/bootstrap/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        function goToForm(form) {
            $('.login-wrapper > form:visible').fadeOut(500, function () {
                $('#form-' + form).fadeIn(500);
            });
        }
        $(function () {
            $('.goto-login').click(function () {
                goToForm('login');
            });
            $('.goto-forgot').click(function () {
                goToForm('forgot');
            });
            $('.goto-register').click(function () {
                goToForm('register');
            });
        });
    </script>
</body>
</html>
