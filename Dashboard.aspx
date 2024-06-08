<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

    <style>
        .div1 {
            min-height: 500px;
            padding: 50px;
            background: #e4e9ec;
        }

        .form-control {
            margin-bottom: 20px;
        }

        .layout {
            min-height: 400px;
            padding: 30px;
            background: white;
        }
    </style>


    <div class="row">
        <h3 class="text-center"></h3>
    </div>
<form  runat="server">

    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="alert alert-success">
                        <i class="mdi mdi-check-all mr-2"></i>Welcome <strong>
                            <asp:TextBox ID="ssnValue" runat="server" BorderStyle="None" ReadOnly="true" ForeColor="Red" BackColor="Transparent"></asp:TextBox></strong>
                    </div>
                    <div class="container" id="main-container">
                        <div id="sidebar" class="navbar-collapse">
                            <ul class="nav nav-list">
                                <li class="">
                                    <a href="registration.aspx"><i class="fa fa-edit"></i><span>Restration Form</span></a>
                                </li>
                            


                            


                                <li class="">
                                    <a href="Logout.aspx"><i class="fa fa-sign-out"></i><span>Logout</span></a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </form>