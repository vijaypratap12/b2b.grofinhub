<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="DashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .para {
            font-size: 16px;
            color: rgba(23, 86, 111, 0.6);
        }
    </style>
    <style type="text/css">
        .B3 {
            background-image: linear-gradient(to left, #48d6a8 0%, #029666 100%) !important;
        }

        .B1 {
            background-image: linear-gradient(to left, #0db2de 0%, #005bea 100%) !important;
        }

        .clock {
            height: 80px;
            margin: 0 auto;
            padding: 5px;
            float: right;
            margin-right: 15px;
            position: absolute;
            z-index: 9999;
            top: 6px;
            color: white;
        }

            .clock ul {
                width: 170px;
                margin: -22px;
                padding: 0;
                list-style: none;
                text-align: center;
            }


                .clock ul li {
                    display: inline;
                    font-size: 1em;
                    text-align: center;
                    font-family: "Arial", Helvetica, sans-serif;
                }

        #Date {
            font-family: 'Arial', Helvetica, sans-serif;
            font-size: 15px;
            text-align: center;
            padding-bottom: 25px;
            color: white;
        }

        #point {
            position: relative;
            -moz-animation: mymove 1s ease infinite;
            -webkit-animation: mymove 1s ease infinite;
            padding-left: 10px;
            padding-right: 10px;
        }

        /* Animasi Detik Kedap - Kedip */
        @-webkit-keyframes mymove {
            0% {
                opacity: 1.0;
                text-shadow: 0 0 20px #00c6ff;
            }

            50% {
                opacity: 0;
                text-shadow: none;
            }

            100% {
                opacity: 1.0;
                text-shadow: 0 0 20px #00c6ff;
            }
        }

        @-moz-keyframes mymove {
            0% {
                opacity: 1.0;
                text-shadow: 0 0 20px #00c6ff;
            }

            50% {
                opacity: 0;
                text-shadow: none;
            }

            100% {
                opacity: 1.0;
                text-shadow: 0 0 20px #00c6ff;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">





    <div class="page-title">
        <div>
            <h1><i class="fa fa-file-o"></i>Welcome 
                <asp:TextBox ID="ssnValue" runat="server" BorderStyle="None" ReadOnly="true" Width="15%" ForeColor="Red" BackColor="Transparent"></asp:TextBox></strong> </h1>

            <div class="clock">
                <div id="Date"></div>
                <ul>
                    <li id="hours"></li>
                    <li id="point">:</li>
                    <li id="min"></li>
                    <li id="point">:</li>
                    <li id="sec"></li>
                </ul>
            </div>

        </div>
    </div>



    <!-- BEGIN Tiles -->
    <div class="row">


        <div class="col-md-12">
            <div class="row">
                <div class="col-md-3">

                    <a href="/Admin/Dashboard">
                        <div class="tile tile-orange">
                            <div class="img">
                                <i class="fa fa-dashboard"></i>
                            </div>
                            <div class="content">

                                <p class="title">Dashboard</p>
                            </div>
                        </div>

                    </a>
                </div>

                <div class="col-md-3">
                    <a href="/Admin/RegistrationReport">
                        <div class="tile tile-dark-blue">
                            <div class="img">
                                <i class="fa fa-list"></i>
                            </div>
                            <div class="content">
                                <p class="title ffr">
                                    <asp:TextBox ID="totalRegistration" runat="server" BorderStyle="None" CssClass="form-control" ForeColor="white" ReadOnly="true" OnLoad="totalRegistration_Load"></asp:TextBox>


                                </p>
                            </div>
                        </div>
                    </a>
                </div>


                <div class="col-md-3">
                     <a href="/Admin/AddState">
                    <div class="tile tile-dark-blue">
                        <div class="img">
                            <i class="fa fa-list-alt"></i>
                        </div>
                        <div class="content">

                            <p class="title">State Master </p>
                        </div>
                    </div>
                 </a>
                </div>

                <div class="col-md-3">
                     <a href="/Admin/AddDistrict">
                    <div class="tile tile-dark-blue">
                        <div class="img">
                            <i class="fa fa-file"></i>
                        </div>
                        <div class="content">

                            <p class="title">District Master </p>
                        </div>
                    </div>
                  </a>
                </div>


                <div class="col-md-3">
                     <a href="/Admin/add_block">
                    <div class="tile tile-dark-blue">
                        <div class="img">
                            <i class="fa fa-file-text-o"></i>
                        </div>
                        <div class="content">

                            <p class="title">Block Master </p>
                        </div>
                    </div>
                </a>
                </div>


                <div class="col-md-3">
                     <a href="/Admin/RegistrationReport">
                    <div class="tile tile-dark-blue">
                        <div class="img">
                            <i class="fa fa-globe"></i>
                        </div>
                        <div class="content">

                            <p class="title">Registration Report </p>
                        </div>
                    </div>
               </a>
                </div>

            </div>


        </div>
    </div>














    <div class="row">

        <div class="col-sm-4" style="display: none">
            <br />
            <asp:TextBox ID="totalImage" runat="server" CssClass="form-control" BorderStyle="None" BackColor=" " placeholder="Total Image in Gallery" ForeColor="red" ReadOnly="true" OnLoad="totalImage_Load"></asp:TextBox>
        </div>

        <div class="col-sm-4" style="display: none">
            <br />
            <asp:TextBox ID="totalContact" runat="server" BorderStyle="None" CssClass="form-control" placeholder="Total Contact : " ForeColor="red" ReadOnly="true" OnLoad="totalContact_Load"></asp:TextBox>
        </div>

        <div class="col-sm-4" style="display: none">
            <br />
            <asp:TextBox ID="totalEnquiry" runat="server" BorderStyle="None" CssClass="form-control" placeholder="Total Enquiry : " ForeColor="red" ReadOnly="true" OnLoad="totalEnquiry_Load"></asp:TextBox>
        </div>




        <div class="row" style="display: none">
            <div class="col-md-6 col-xl-4">
                <div class="widget-rounded-circle B3 card-box B1">
                    <%--@*<a href="#">*@--%>
                    <div class="row">
                        <%--@*<div class="col-6">
                        <div class="avatar-lg rounded-circle bg-soft-info border-info border">
                            <i class="fe-bar-chart-line- font-22 avatar-title text-info"></i>
                        </div>
                    </div>
                    *@--%>
                        <div class="col-12">
                            <div class="text-right">
                                <h3 class="text-dark mt-1">&#8377;<span data-plugin="counterup"> </span></h3>
                                <p class="text-muted mb-1 text-truncate">Today's Purchase</p>
                            </div>
                        </div>
                    </div>
                    <%--  @*</a>*@--%>
                    <!-- end row-->
                </div>
                <!-- end widget-rounded-circle-->
            </div>
        </div>







        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                // Making 2 variable month and day
                var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
                var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]

                // make single object
                var newDate = new Date();
                // make current time
                newDate.setDate(newDate.getDate());
                // setting date and time
                $('#Date').html(dayNames[newDate.getDay()] + " " + newDate.getDate() + ' ' + monthNames[newDate.getMonth()] + ' ' + newDate.getFullYear());

                setInterval(function () {
                    // Create a newDate() object and extract the seconds of the current time on the visitor's
                    var seconds = new Date().getSeconds();
                    // Add a leading zero to seconds value
                    $("#sec").html((seconds < 10 ? "0" : "") + seconds);
                }, 1000);

                setInterval(function () {
                    // Create a newDate() object and extract the minutes of the current time on the visitor's
                    var minutes = new Date().getMinutes();
                    // Add a leading zero to the minutes value
                    $("#min").html((minutes < 10 ? "0" : "") + minutes);
                }, 1000);

                setInterval(function () {
                    // Create a newDate() object and extract the hours of the current time on the visitor's
                    var hours = new Date().getHours();
                    // Add a leading zero to the hours value
                    $("#hours").html((hours < 10 ? "0" : "") + hours);
                }, 1000);
            });
        </script>


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
</asp:Content>

