<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="Admin_ViewProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        .p-1 {
    padding: 5px;
   margin-top:2px !important;
}
    </style>
    <style>
        .mt5 {
            margin-top: 15px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   

    <div class="box">
        <div class="box-title">
            <div class="row">

                <div class="col-md-10">
                    <h4 style="color: white;">Partner Details</h4>
                </div>
                <div class="col-md-2 pull-right">
                    <h4><a href="RegistrationReport.aspx" class="btn-danger btn-sm">Go Back</a></h4>
                </div>

            </div>




            <div class="box">

                <div class="box-content">





                    <div class="div1" style="margin-top: 30px;">
                        <div class="row">
                            <div class="layout">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3">
                                            <label>Name</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtname" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-sm-3">
                                            <label>Number</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtnumber" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-3">
                                            <label>Date Of Birth</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtdob" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-3">
                                            <label>Qualification</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtQualification" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="col-sm-3 mt5">
                                            <label>State</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtstate" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-sm-3 mt5">
                                            <label>District</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtdistrict" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-3 mt5">
                                            <label>Block</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtblock" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="col-sm-3 mt5">
                                            <label>Pin Code</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtPincode" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-sm-12">

                                        <div class="col-sm-12 mt5">
                                            <label>Address</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="col-sm-4 mt5">
                                            <label>Associate with any company</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtassociate" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 mt5">
                                            <label>Family Member associated as Insurance Agent?</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtfamily" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 mt5">
                                            <label>family member associated as Mutual Fund Distributor?</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="txtfund" runat="server" class="form-control" AutoComplete="off" ReadOnly="true"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                </div>

            </div>
        </div>
    </div>
</asp:Content>

