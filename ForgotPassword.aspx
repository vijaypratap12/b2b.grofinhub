<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget Password</title>
    <link href="font-awesome/new/css/font-awesome.min.css" rel="stylesheet" />
    <%-- <link rel="stylesheet" href="font-awesome/4.5.0/css/fonts/font-awesome.min.css"/>--%>
    <%--<link href="font-awesome/4.5.0/css/font-awesome.min.css" rel="stylesheet" />--%>
</head>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"/>--%>

     <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


<body style="background: #32323A">
    <div class="form-gap"></div>
    <div class="container">
        <div class="row">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <h3><i class="fa fa-lock fa-4x"></i></h3>
                            <h2 class="text-center">Forgot Password?</h2>
                            <p>You can reset your password here.</p>
                            <div class="panel-body">


                                <form id="form1" runat="server" class="form">

                                    <asp:Panel ID="pnlForget" runat="server">

                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-user color-blue"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter full name" ControlToValidate="txtname" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                                </asp:RequiredFieldValidator>

                                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-time color-blue"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage=" Enter  date of  birth" ControlToValidate="txtdob" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtdob" runat="server" CssClass="form-control" placeholder="Enter Date of  Birth" TextMode="Date"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone color-blue"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter mobile number" ControlToValidate="txtmobile" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="mob" runat="server" ErrorMessage="Please Enter a valid Mobile Number." Display="Dynamic" ForeColor="Red" ControlToValidate="txtmobile" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="I"></asp:RegularExpressionValidator>
                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" placeholder="MobileNo." MaxLength="10" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil color-blue"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ErrorMessage="Enter Partner Id  " ControlToValidate="txtAgentNo" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                                </asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtAgentNo" runat="server" CssClass="form-control" placeholder="Partner Id "></asp:TextBox>
                                            </div>
                                        </div>


                                        <!-- Captcha -->

                                        <div class="row">
                                            <div class="col-md-9">
                                                 <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="40" CaptchaWidth="100" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                            FontColor="#D20B0C" NoiseColor="#B1B1B1" />
                                            </div>
                                            <div class="col-md-3">
                                                 <asp:ImageButton ImageUrl="images/refresh.png" runat="server" CausesValidation="false" />
                                            </div>
                                        </div>
                                       

                                       
                                        <asp:CustomValidator ErrorMessage="Invalid. Please try again." OnServerValidate="ValidateCaptcha" ValidationGroup="I" runat="server" ID="cstmval" />
                                        <div class="control-group">
                                            <label for="accountLastName" class="lab control-label">Enter Captcha Text </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <asp:RequiredFieldValidator ID="rfvtxtCaptcha" ErrorMessage="Enter Captcha" ControlToValidate="txtCaptcha" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I" SetFocusOnError="true">
                                        </asp:RequiredFieldValidator>
                                        <!-- Captcha -->

                                        <br />






                                        <div class="form-group">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Send OTP" CssClass="btn btn-lg btn-primary btn-block" ValidationGroup="I" OnClick="btnSubmit_Click" />
                                        </div>
                                        <div class="form-group">
                                            <a href="login.aspx">Back to login</a>
                                        </div>
                                        <input type="hidden" class="hide" name="token" id="token" value="" />
                                    </asp:Panel>

                                    <asp:Panel ID="pnlOTP" runat="server" Visible="false">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-tasks color-blue"></i></span>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ErrorMessage="Enter OTP" ControlToValidate="txtOtp" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="II">
                                                </asp:RequiredFieldValidator>

                                                <asp:TextBox ID="txtOtp" runat="server" CssClass="form-control" placeholder="Enter OTP."></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <asp:Button ID="btnOtpVerify" runat="server" Text="Enter OTP" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnOtpVerify_Click" ValidationGroup="II"/>
                                        </div>

                                        <asp:Label ID="lblOTP" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                    </asp:Panel>
                                    <input type="hidden" id="txtotph" />
                                </form>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
