<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" EnableEventValidation="false" MaintainScrollPositionOnPostback="false" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">


    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Grofinhub  </title>
    <link rel="icon" href="webdoc/images/favicon.png">
    <link href="webdoc/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="webdoc/css/style.css">
    <link rel="stylesheet" href="webdoc/css/owl.carousel.min.css">
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">

    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
      <![endif]-->



    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


    <script language="Javascript" type="text/javascript">

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || charCode == 32)
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

    </script>

</head>

<body>


    <style>
        .login-form {
            background: #FFF;
            /* width: 300px; */
            padding: 14px 20px;
        }

        .table th, td {
            padding: 5px !important;
            text-align: left !important;
            border: none;
            width: 81% !important;
        }
    </style>




    <header id="divLFSHeader">

        <div class="container-fluid">
            <div class="navbar-header">
                <a class="" href="/">
                    <img alt=" " class="img-responsive logo" src="webdoc/images/logo.png">
                </a>
            </div>
            <ul class="nav navbar-nav navbar-right">


                <li><a href="/login.aspx" target="_blank"><i class="fa fa-home"></i><span></span></a></li>
                <li><a href="tel://+91-8210975396"><i class="fa fa-phone"></i><span>+91-8210975396     </span></a></li>
                <li><a href="mailto:apsupport@grofinhub.com"><i class="icon contact-us"></i><span>apsupport@grofinhub.com </span></a></li>
                <li class="right-right"><a href="registration.aspx"><i class="icon feedback"></i><span>Partner Join </span></a></li>
                <%--  <li class="right-line"><i class="finserv-india"></i><span>
                    <div id="google_translate_element"></div>
                </span></li>--%>
            </ul>
        </div>
    </header>


    <div class="main-wrapper" style="background: url(webdoc/bgg.png); background-size: cover; background-attachment: fixed;">

        <form runat="server">







            <div class="container">

                <div class="row">
                    <div class="col-lg-7">
                    </div>





                    <div class="col-lg-5">



                        <div class="login-form">
                            <h2 id="agntlogin">Associate Partner </h2>
                            <form id="loginForm" name="loginForm" action="#" method="post">

                                <div class="row">


                                    <div class="col-lg-6">
                                        <label for="gender">Full Name<span class="red"></span> </label>
                                    </div>


                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Enter full name" ControlToValidate="txtname" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>

                                        <div class="input-field">

                                            <%--   <input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Full Name" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                            <asp:TextBox ID="txtname" runat="server" class="GATag" placeholder="Enter Full Name" value="" MaxLength="150" onselectstart="return false" onpaste="return false;" oncopy="return false" oncut="return false" ondrag="return false" ondrop="return false" onkeypress="return onlyAlphabets(event,this);" autocomplete="off"> </asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="col-lg-6">
                                        <label for="gender">Mobile Number <span class="red"></span></label>
                                    </div>
                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Enter mobile number" ControlToValidate="txtmobile" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="mob" runat="server" ErrorMessage="Enter Valid Mobile Number." Display="Dynamic" ForeColor="Red" ControlToValidate="txtmobile" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="I"></asp:RegularExpressionValidator>
                                        <div class="input-field">
                                            <%--<input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Mobile Number" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                            <asp:TextBox ID="txtmobile" runat="server" class="GATag" placeholder="Enter Mobile Number" value="" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>






                                    <div class="col-lg-6">
                                        <label for="gender">Qualification <span class="red"></span></label>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage=" Select qualification" InitialValue="select" ControlToValidate="ddlQualification" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>
                                        <%--<input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Mobile Number" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                        <asp:DropDownList ID="ddlQualification" runat="server" class="form-control">

                                            <asp:ListItem Text=" Please select " Value="select"></asp:ListItem>
                                            <asp:ListItem Text="Intermediate" Value="Intermediate"></asp:ListItem>
                                            <asp:ListItem Text="Graduate" Value="Graduate"></asp:ListItem>
                                            <asp:ListItem Text="Post Graduate" Value="Post Graduate"></asp:ListItem>

                                            <asp:ListItem Text="PhD" Value="PhD"></asp:ListItem>
                                        </asp:DropDownList>


                                    </div>







                                    <div class="col-lg-6">
                                        <label for="gender">Date of Birth<span class="red"></span> </label>
                                    </div>

                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="Enter  date of  birth" ControlToValidate="txtdob" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>

                                        <div class="input-field">
                                            <%--    <input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Address" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                            <asp:TextBox ID="txtdob" oncopy="return false" onpaste="return false" oncut="return false" runat="server" class="GATag" placeholder="Enter Date of  Birth" TextMode="Date"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <%--  <input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter State" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>


                                    <div class="col-lg-6">
                                        <label for="gender">State <span class="red"></span></label>
                                    </div>

                                    <div class="col-lg-6">
                                        <asp:DropDownList ID="ddlproperty" runat="server" class="form-control" OnSelectedIndexChanged="ddlproperty_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="Select state " InitialValue="0" ControlToValidate="ddlproperty" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I" Font-Size="12">
                                        </asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-6">
                                        <label for="gender">District <span class="red"></span></label>
                                    </div>

                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="  Select district " InitialValue="Select District" ControlToValidate="ddldistrict" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>


                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Field Required" ControlToValidate="ddldistrict" ForeColor="Red" Style="position: absolute"
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>

                                    </div>



                                    <div class="col-lg-6">
                                        <label for="gender">Block <span class="red"></span></label>
                                    </div>


                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ErrorMessage=" Select block " InitialValue="Select Block" ControlToValidate="ddlblock" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>

                                        <asp:DropDownList ID="ddlblock" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Field Required" ControlToValidate="ddlblock" ForeColor="Red" Style="position: absolute"
                                            ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>






                                    <div class="col-lg-6">
                                        <label for="gender">Address <span class="red"></span></label>
                                    </div>

                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ErrorMessage=" Enter  address" ControlToValidate="txtAddress" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>
                                        <div class="input-field">
                                            <asp:TextBox ID="txtAddress" oncopy="return false" onpaste="return false" oncut="return false" runat="server" class="GATag" placeholder="Enter Address" value="" MaxLength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-6">
                                        <label for="gender">Pin Code<span class="red"></span></label>
                                    </div>
                                    <div class="col-lg-6">

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter Pin Code" ControlToValidate="txtPinCode" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                                        </asp:RequiredFieldValidator>
                                        
                                        <div class="input-field">
                                            <%--<input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Mobile Number" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                            <asp:TextBox ID="txtPinCode" runat="server" class="GATag" placeholder="Enter Pin Code" value="" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="6" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>




                                    <div class="col-lg-12">
                                        <br>
                                        <label>Are you associated with any company? </label>

                                        <label>
                                            <asp:RadioButtonList ID="rdbAssociatedCompany" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <span class="indicator"></span>
                                        </label>


                                        <asp:RequiredFieldValidator runat="server" ID="rfvrdbAssociatedCompany" Display="Dynamic"
                                            ControlToValidate="rdbAssociatedCompany" ErrorMessage="Please Select!"
                                            ValidationGroup="I" SetFocusOnError="true" ForeColor="Red" Font-Size="12"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-12">

                                        <label>Are you and any family member associated as Insurance Agent? </label>


                                        <label>
                                            <asp:RadioButtonList ID="rdbfamilyInsurance" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <span class="indicator"></span>
                                        </label>

                                        <asp:RequiredFieldValidator runat="server" ID="rfvrdbfamilyInsurance" Display="Dynamic"
                                            ControlToValidate="rdbfamilyInsurance" ErrorMessage="Please Select!"
                                            ValidationGroup="I" SetFocusOnError="true" ForeColor="Red" Font-Size="12"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-12">

                                        <label>Are you and any family member associated as Mutual Fund Distributor?</label>

                                        <label>
                                            <asp:RadioButtonList ID="rdbfamilyMutual" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                <asp:ListItem Value="No">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <span class="indicator"></span>
                                        </label>

                                        <asp:RequiredFieldValidator runat="server" ID="rfvrdbfamilyMutual" Display="Dynamic"
                                            ControlToValidate="rdbfamilyMutual" ErrorMessage="Please Select!"
                                            ValidationGroup="I" SetFocusOnError="true" ForeColor="Red" Font-Size="12"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-lg-12" style="display: none">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <label for="">Enter PAN Card<span class="red"></span></label>
                                                </div>
                                                <div class="col-md-3 image_div_col">
                                                    <div class="image_preview_div">

                                                        <label for="profile_img"><i class="fa fa-camera" aria-hidden="true"></i></label>

                                                        <asp:FileUpload ID="FileUpload2" runat="server" class="form-control-file border file1" />
                                                    </div>
                                                </div>
                                                <script type="text/javascript">
                                                    $(document).ready(function () {
                                                        $('#agent-home').click(function () {
                                                            window.location.href = "user.php";
                                                        });
                                                    });
                                                </script>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-lg-12" style="display: none">

                                    <%-- <input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Aadhaar Card" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <label for="">Enter Aadhaar Card<span class="red"></span>:</label>
                                            </div>
                                            <div class="col-md-3 image_div_col">
                                                <div class="image_preview_div">

                                                    <label for="profile_img"><i class="fa fa-camera" aria-hidden="true"></i></label>

                                                    <asp:FileUpload ID="FileUpload1" runat="server" class="form-control-file border file1" />
                                                </div>
                                            </div>
                                            <script type="text/javascript">
                                                $(document).ready(function () {
                                                    $('#agent-home').click(function () {
                                                        window.location.href = "user.php";
                                                    });
                                                });
                                            </script>
                                        </div>
                                    </div>



                                </div>

                                <div class="col-lg-12" style="display: none">

                                    <%-- <input name="loginId" id="loginId" type="text" class="GATag"  placeholder="Enter Aadhaar Card" value="" maxlength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off">--%>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <label for="">Qualification<span class="red"></span>:</label>
                                            </div>
                                            <div class="col-md-3 image_div_col">
                                                <div class="image_preview_div">

                                                    <label for="profile_img"><i class="fa fa-camera" aria-hidden="true"></i></label>

                                                    <asp:FileUpload ID="FileUpload3" runat="server" class="form-control-file border file1" />
                                                </div>
                                            </div>
                                            <script type="text/javascript">
                                                $(document).ready(function () {
                                                    $('#agent-home').click(function () {
                                                        window.location.href = "user.php";
                                                    });
                                                });
                                            </script>
                                        </div>
                                    </div>



                                </div>

                                <div class="col-lg-12">
                                    <div class="agreement" id="tncSet">
                                        <asp:CheckBox runat="server" ID="termsAndCondtion" Checked="true" Text="agree to usage" />

                                        <a class="GATag" data-gatag="PreL T&amp;C Redirection" href="#" title="">
                                            <span style="color: #273896;">Terms and
                                        Conditions
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <asp:CustomValidator ID="rfvtermsAndCondtion" runat="server"
                                    ErrorMessage="Please accept the terms & condtion" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="I" SetFocusOnError="true" ForeColor="Red" Font-Size="12"></asp:CustomValidator>


                                <!-- Captcha -->

                                <div class="row">
                                    <div class="col-md-9">
                                        <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                            FontColor="#D20B0C" NoiseColor="#B1B1B1" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:ImageButton ImageUrl="images/refresh.png" runat="server" CausesValidation="false" />
                                    </div>
                                </div>




                                <asp:CustomValidator ErrorMessage="Invalid. Please try again." OnServerValidate="ValidateCaptcha" ValidationGroup="I"
                                    runat="server" ID="cstmval" />
                                <div class="control-group">

                                    <label for="accountLastName" class="lab control-label">Enter Captcha Text </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtCaptcha" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvtxtCaptcha" runat="server" ValidationGroup="I" ControlToValidate="txtCaptcha"
                                        ErrorMessage="Enter Captcha" SetFocusOnError="true" ForeColor="Red" Font-Size="12"></asp:RequiredFieldValidator>
                                </div>
                                <!-- Captcha -->



                                <div class=" ">

                                    <%--		 <input type="button" id="loginBttn" value="Submit" class="login-button GATag"   >--%>


                                    <asp:Button ID="btnsave" class="login-button GATag" runat="server" Text="Submit" OnClick="btnsave_Click" ValidationGroup="I" />



                                </div>
                            </form>
                        </div>







                    </div>
                </div>




            </div>
        </form>
    </div>






    <div id="footerContent">

        <div class="footer-bottom">
            <div class="container">
                <div class="copyright-text text-center">
                    <p style="font-size: 15px">Design &amp; Developed By <a href="http://www.sigmasoftwares.org/" target="_blank" style="font-weight: 400;">SigmaIT Software Designers Pvt. Ltd.</a></p>
                </div>
            </div>
        </div>
    </div>
    <div id="snav">
        <div class="snav">
            <ul>
                <li>
                    <a href="#">
                        <img src="webdoc/images/call.png" alt="">
                        <p class="visible-xs">
                            <span>Call Us :+91-8210975396  </span>

                        </p>
                    </a>
                    <ul class="nav-expand">
                        <li>
                            <a href="#">
                                <img src="webdoc/images/call-back.png">
                                <span>
                                    <span>Call Us :+91-8210975396  </span>

                                </span>

                            </a>
                        </li>
                    </ul>
                </li>

                <li>
                    <a href="/estimate-monthly-payment/">
                        <img src="webdoc/images/WHAT.png" alt="">
                        <p class="visible-xs"><span>Call Us :+91-8210975396 </span></p>
                    </a>
                    <ul class="nav-expand">
                        <li>
                            <a href="/estimate-monthly-payment/">
                                <img src="webdoc/images/WHAT.png">
                                <span>Call Us :+91-8210975396 </span>
                            </a>
                        </li>
                    </ul>
                </li>

            </ul>
        </div>
    </div>
    <script src="webdoc/js/jquery-3.3.1.min.js"></script>
    <script src="webdoc/js/owl.carousel.js"></script>
    <script src="webdoc/js/bootstrap.min.js"></script>
    <script src="webdoc/js/chosen.jquery.js"></script>


    <script src="js/script.js"></script>


    <!-- Side Nav On Scroll for home Page-->
    <!--
    <script>
        $(window).scroll(function() {
        var scroll = $(window).scrollTop();

        if (scroll >= 300) {
            $(".move-up").show();
        } else {
            $(".move-up").hide();
        }
    });
    </script>
    -->

    <script>
        //	$('.collapse').collapse()
        $('#myCollapsible').collapse({
            toggle: false
        })
    </script>
    <script>
        //var _gpsEnabled = false;
        //var _isDynamicEnabled = true;
        //var _stateId, _cityId;
        //window.addEventListener('onDynamicReady', function (e) {
        //  if (e.detail.result == "success") {
        //    _stateId = parseInt(e.detail.stateId);
        //    _cityId = parseInt(e.detail.cityId);
        //    _gpsEnabled = true;
        //  }
        //});
        function showEnquiryForm(enquiredFor) {
            loadEnquiryComponent(enquiredFor, _stateId, _cityId);
        }
        $(document).ready(function (e) {
            $('#bannerSlider, #bannerSliderMob').on('slide.bs.carousel', function (e) {
                if ($("#bannerSlider .item").index(e.relatedTarget) == 0) {
                    $('#bannerSlider').data("bs.carousel").options.interval = 30000;
                } else {
                    $('#bannerSlider').data("bs.carousel").options.interval = 5000;
                }

                if ($("#bannerSliderMob .item").index(e.relatedTarget) == 0) {
                    $('#bannerSliderMob').data("bs.carousel").options.interval = 3000;
                } else {
                    $('#bannerSliderMob').data("bs.carousel").options.interval = 3000;
                }
            });


            $('#moreFromslider').owlCarousel({
                loop: true,
                margin: 10,
                responsiveClass: true,
                responsive: {
                    0: {
                        items: 1,
                        //                lazyLoad: true,
                        loop: true,
                        nav: true
                    },
                    600: {
                        items: 1,
                        //                lazyLoad: true,
                        nav: true,

                    },
                    1000: {
                        items: 1,
                        //                lazyLoad: true,
                        nav: true,
                        margin: 20
                    }
                }
            });

            $(".acc-head").click(function () {
                $accSelected = $(this).data("wf");
                $(".image-holder > img").hide();
                $(".image-holder").find('img[data-wf=' + $accSelected + ']').show();
            });

        });


    </script>
    <!-- FEATURES ON SCROLL -->




    <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>

    <script>
        function googleTranslateElementInit() {
            new google.translate.TranslateElement({ pageLanguage: 'en', includedLanguages: 'en,hi' }, 'google_translate_element');
        }

    </script>
    <script>
        $(window).load(function () {
            $(".goog-logo-link").empty();
            $('.goog-te-gadget').html($('.goog-te-gadget').children());
        })
    </script>


    <style>

          .skiptranslate.goog-te-gadget {
              height: 20px !important;
          }

          </
      style>


</body>

</html>
