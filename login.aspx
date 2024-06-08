<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html lang="en">
<style type="text/css">
    a.VIpgJd-ZVi9od-l4eHX-hSRGPd {
        display: none;
    }
</style>

<script type="text/javascript">
    function preventBack() {
        window.history.forward();
    }

    setTimeout("preventBack()", 0);

    window.onunload = function () { null };

    function AllowOnlyNumber(evt) {
        var charcode = (evt.which) ? evt.which : event.keyCode
        if (charcode > 31 && (charcode < 48 || charcode > 57))
            return false;
        return true;
    }



</script>

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Grofinhub  </title>
    <link rel="icon" href="../images/favicon.png">
    <link href="webdoc/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="webdoc/css/style.css">
    <link rel="stylesheet" href="webdoc/css/owl.carousel.min.css">
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">

    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
      <![endif]-->
</head>



<body>


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
        iframe#\:1\.container {
            display: none !important;
        }
    </style>



    <header id="divLFSHeader">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="" href="/">
                    <img alt=" " class="img-responsive logo" src="/images/logo.png">
                </a>
            </div>
            <ul class="nav navbar-nav navbar-right">

                <li><a href="/login.aspx" target="_blank"><i class="fa fa-home"></i><span></span></a></li>
                <li><a href="tel://+91-8210975396"><i class="fa fa-phone"></i><span>+91-8210975396     </span></a></li>
                <li><a href="mailto:apsupport@grofinhub.com"><i class="icon contact-us"></i><span>apsupport@grofinhub.com</span></a> </li>
                <li class="right-right"><a href="registration.aspx"><i class="icon feedback"></i><span>Partner Join </span></a></li>
                <%--  <li class="right-line">  <i class="finserv-india"></i><span> <div id="google_translate_element"></div> </span>  </li>--%>

                <li class="right-line"><i class="finserv-india"></i><span>
                    <div id="google_translate_element"></div>
                </span></li>

            </ul>
        </div>
    </header>

    <div class="main-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-9">
                    <div class="full-width thump-slider featured-slider explore-tfsin">
                        <div class="owl-carousel owl-theme" id="moreFromslider">
                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/api3.jpg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <%--  <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container"> <img src="webdoc/images/1_Banner.jpeg" alt=""> </div>
                                    </div>
                                </a>
                            </div>--%>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/2_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/3_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/4_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/5_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/6_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/7_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>

                            <div class="item">
                                <a href="#">
                                    <div class="link">
                                        <div class="img-container">
                                            <img src="webdoc/images/8_Banner.jpeg" alt="">
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="login-form">
                        <h2 id="agntlogin">Login to Continue</h2>
                     <%--   <form id="loginForm" runat="server" method="post" action="https://app.grofinhub.com/">--%>

                        <form id="loginForm" runat="server" method="post" action="https://localhost:44317/">
                            <div class="error-msg" id="actionErrDiv">
                            </div>
                            <div class="error-msg" id="lidPwdDiv" style="display: none;">Please Enter Login ID and Password</div>
                            <div class="error-msg" id="pwdDiv" style="display: none;">Please Enter Password</div>
                            <div class="error-msg" id="lidDiv" style="display: none;">Please Enter Login ID</div>
                            <div class="error-msg" id="errCaptchaDiv" style="display: none;">Please Enter Captcha Text </div>
                            <div class="error-msg" id="errTermsAndCond" style="display: none;">Please accept terms and conditions</div>
                            <div>
                            </div>

                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Enter your Partner id" ControlToValidate="txtagentid" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                            </asp:RequiredFieldValidator>--%>
                            <div class="input-field">
                                <svg style="width: 22px; height: 22px" viewBox="0 0 24 24">
                                    <path fill="#323232" d="M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z"></path>
                                </svg>
                                 <%--<asp:TextBox ID="txtagentid" runat="server" class="GATag" data-gatag="Enter Agent ID" placeholder="Enter your Partner ID" value="" MaxLength="150" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off"></asp:TextBox>--%>

                                <input name="userName" id="userName" placeholder="Enter Mobile No" type="text" class="form-control" onkeypress="return AllowOnlyNumber(event);" MaxLength="10">
                            </div>

                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Enter your password" ControlToValidate="txtpassword" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="I">
                            </asp:RequiredFieldValidator>--%>

                            <div class="input-field">
                                <svg style="width: 22px; height: 22px" viewBox="0 0 24 24">
                                    <path fill="#323232" d="M12,17A2,2 0 0,0 14,15C14,13.89 13.1,13 12,13A2,2 0 0,0 10,15A2,2 0 0,0 12,17M18,8A2,2 0 0,1 20,10V20A2,2 0 0,1 18,22H6A2,2 0 0,1 4,20V10C4,8.89 4.9,8 6,8H7V6A5,5 0 0,1 12,1A5,5 0 0,1 17,6V8H18M12,3A3,3 0 0,0 9,6V8H15V6A3,3 0 0,0 12,3Z"></path>
                                </svg>
                                <input name="hd" type="hidden" value="null">
                                <%--   <input name="mtoken" type="hidden" value="null"> <input type="password" required="" name="pwd" placeholder="Enter your Password" id="pwd" maxlength="30" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off" readonly="" onfocus="this.removeAttribute('readonly');"> <input type="hidden" id="latitude" name="latitude" value=""> <input type="hidden" id="longitude" name="longitude" value="">--%>


                                 <%--<asp:TextBox ID="txtpassword" runat="server" class="GATag" data-gatag="Enter Agent ID" placeholder="Enter your Password" value="" MaxLength="30" onkeypress="mcommNS.checkEnterOnLogin(event);" autocomplete="off" TextMode="Password"></asp:TextBox>--%>

                                <input name="password" id="password" placeholder="Enter Password" type="password" class="form-control">
                            </div>
                            <div class="agreement" id="tncSet">
                                <label class="cont">
                                    <input type="checkbox" class="GATag" data-gatag="PreL T&amp;C Checkbox" id="termsAndCondtion" name="termsAndCondtion" value="true" checked="">I
                                    agree to usage <span class="checkmark"></span>
                                </label>
                                <a class="GATag" data-gatag="PreL T&amp;C Redirection" href="#" title="">
                                    <span style="color: #273896;">Terms and
                                        Conditions
                                    </span>
                                </a>
                            </div>
                            <table class="wwFormTable">
                                <input type="hidden" name="lang" id="lang" value="english">
                                <input type="hidden" name="fingerPrintBrowser" id="fingerPrintBrowser" value="387da98f9980cf23ee6271c04439f22d">
                            </table>
                            <table class="captcha-table">
                            </table>


                            <%--   <input type="button" id="loginBttn" value="Login" class="login-button GATag" data-gatag="Login SMA" onclick="mcommNS.validateLogin();">--%>


                              <%--<asp:Button ID="btnlogin" class="login-button GATag" runat="server" Text="Login" OnClick="btnlogin_Click" ValidationGroup="I" />--%>


                            <input class="login-button GATag" type="submit" value="Login to Dashboard" id="demo" />


                            <div class="forgot-password mt15">
                                <a id="ag" href="" title="" style="cursor: pointer" class="GATag" data-gatag="PreL Forgot ID" onclick="loginForgotAgentId();  return false;">Forgot Partner id?</a> | <a href="ForgotPassword.aspx" class="GATag" data-gatag="PreL Forgot Password" title="" id="fg">Forgot Password?</a><br style="height: 0;">
                                <img src="jsp/spicesafar/newLoginDesign/images/or.png" alt="">

                                <!--SelfCare-->
                                <!--  <a target="_blank" title="" class="needHelp-btn" onclick="selfRedirect();" id="fg" style="cursor:pointer">
                                    Need Help?
                                </a>  -->
                                <!--SelfCare Ends-->
                                <!--selfCarePopup -->
                                <div id="myModal" class="modal selfcare-modal">

                                    <!-- Modal content -->
                                    <div class="modal-content">
                                        <span class="w3-button w3-display-topright selfcare-close">×</span>
                                        <iframe name="hm" id="hm" class="selfcare" frameborder="0" allowfullscreen=""></iframe>

                                    </div>

                                </div>

                                <!--selfCarePopup-->
                            </div>


                            <div class="joinus-section">
                                <p>
                                    Join Grofinhub as a Partner
                                </p>
                                <a class="GATag" data-gatag="join Us bottom butn" href="registration.aspx" target="_blank">
                                    <button type="button" class="joinus-btn">Join Us</button>
                                </a>
                                <div class="border-gradient"></div>
                            </div>
                            <div class="joinus-section">
                                <p>
                                    Download <b>Grofinhub App</b>
                                </p>
                                <a class="GATag" data-gatag="download APP" href="#" target="_blank">
                                    <button type="button" class="joinus-btn">Download Now</button>
                                </a>
                                <div class="border-gradient"></div>
                            </div>





                        </form>
                    </div>







                </div>
            </div>




        </div>

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
                    <a href="tel:+918210975396">
                        <img src="webdoc/images/call.png" alt="" />
                        <p class="visible-xs">
                            <span>Call Us : +91-8210975396 </span>
                        </p>
                    </a>
                    <ul class="nav-expand">
                        <li>
                            <a href="tel:+918210975396">
                                <img src="webdoc/images/call.png" />
                                <span>
                                    <span>Call Us :+91-8210975396 </span>
                                </span>
                            </a>
                        </li>
                    </ul>
                </li>

                <li>
                    <a href="https://api.whatsapp.com/send?phone=918210975396">
                        <img src="webdoc/images/WHAT.png" alt="" />
                        <p class="visible-xs">
                            <span>Call Us :+91-8210975396</span>
                        </p>
                    </a>
                    <ul class="nav-expand">
                        <li>
                            <a href="https://api.whatsapp.com/send?phone=918210975396">
                                <img src="webdoc/images/WHAT.png" />
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
    </style>

    <script>
        $('.owl-carousel').owlCarousel({
            autoplay: true,
            autoplayTimeout: 5000,
            margin: 10,
            nav: true,
            loop: true,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        })
    </script>


</body>

</html>
