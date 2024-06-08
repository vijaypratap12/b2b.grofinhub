<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Changepass.aspx.cs" Inherits="Admin_Changepass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




    
    <style>
        .div1 {
            min-height: 200px;
            padding: 25px;
            background: #e4e9ec;
        }

        .form-control {
            margin-bottom: 20px;
        }

        .layout {
            padding: 30px;
            background: white;
        }
    </style>


    <div class="row">
        <h3 class="text-center"> Change Password  </h3>
    </div>
    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="col-sm-3">
                            <label>User</label>
                            <div class="input-group">
                                
                              
                                 <asp:TextBox runat="server" ID="txtUser"  class="form-control" ReadOnly="true"> </asp:TextBox>
                              
                            </div>
                        </div>

                          <div class="col-sm-3">
                            <label> Member Id</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtUserId" runat="server" class="form-control" ></asp:TextBox>
                                
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <label>Old Password</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtOldPassword" runat="server" class="form-control" ></asp:TextBox>
                                
                            </div>
                        </div>

                        <div class="col-sm-3">
                            <label>New Password</label>
                            <div class="input-group">
                              
                                 <asp:TextBox ID="txtnewpassword" runat="server" class="form-control" ></asp:TextBox>

                            </div>
                        </div>


                          <div class="col-sm-3">
                            <label> Confirm New Password</label>
                            <div class="input-group">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please enter same password" ControlToCompare="txtnewpassword" ControlToValidate="txtcnewpassword"  ForeColor="Red" ValidationGroup="I" ></asp:CompareValidator>

                                 <asp:TextBox ID="txtcnewpassword" runat="server" class="form-control" ></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-3">
                            <br />

                         

                            <asp:Button ID="btnchangepassword" runat="server" Text="Save Changes" class="btn btn-warning active"
                                ValidationGroup="I" OnClick="btnchangepassword_Click" Style="margin-top: 6px;"  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />



































</asp:Content>

