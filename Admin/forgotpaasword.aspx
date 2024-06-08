<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpaasword.aspx.cs" Inherits="Admin_forgotpaasword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="img/logo3.png" />
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" />

    <!--page specific css styles-->

    <!--flaty css styles-->
    <link rel="stylesheet" href="css/flaty.css" />
    <link rel="stylesheet" href="css/flaty-responsive.css" />
</head>
<body class="login-page">

    <!--basic scripts-->
    <script src="../../ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script>    window.jQuery || document.write('<script src="assets/jquery/jquery-2.1.1.min.js"><\/script>')</script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>


    <form id="form1" runat="server">
        <div>
            <div class="login-wrapper">

                <center>
                    <asp:Image ID="Image1" runat="server" Style="height: 90px; width: 120px;" src="../img/logo3.png" />
                </center>

                <div class="col-sm-12 col-md-4 col-lg-offset-4">
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
                            <asp:TextBox ID="txtoldpassword" runat="server" placeholder="Old Password" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvOldPassword" ControlToValidate="txtoldpassword" runat="server" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="submit">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="controls">
                            <asp:TextBox ID="txtNewPswrd" runat="server" placeholder="New Password" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewPswrd" ControlToValidate="txtNewPswrd" runat="server" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="submit">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="controls">
                            <asp:TextBox ID="txtCnfrmPswrd" runat="server" placeholder="Confirm Password" class="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCnfrmPswrd" ControlToValidate="txtCnfrmPswrd" runat="server" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="submit">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="controls">
                            <asp:Button ID="btnRstPswrd" runat="server" Text="Reset Now" class="btn btn-success form-control" OnClick="btnRstPswrd_Click" ValidationGroup="submit" />
                            <br />
                        </div>
                        <div class="controls">
                            <a href="login.aspx">Sign In</a>
                            <br />
                        </div>
                    </div>
                    <hr />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
