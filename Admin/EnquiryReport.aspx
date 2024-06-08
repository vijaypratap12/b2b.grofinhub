<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="EnquiryReport.aspx.cs" Inherits="Admin_EnquiryReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style>
        .div1 {
            min-height: 200px;
            padding: 50px;
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
        <h3 class="text-center">Enquiry Record  </h3>
    </div>


    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <asp:TextBox ID="totalEnquiry" runat="server" Width="15%" BorderStyle="None" CssClass="form-control" placeholder="Total Enquiry : " ForeColor="red" ReadOnly="true" onload="totalEnquiry_Load"></asp:TextBox>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Sr</th>
                                        <th>Name</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>Message</th>
                                        <th>EntryDate</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="rptGallery" runat="server" OnItemCommand="rptGallery_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td width="5%"><%# Eval("Sr") %> </td>

                                                <td><%# Eval("name") %> </td>

                                                <td><%# Eval("email") %> </td>

                                                <td><%# Eval("mobile") %> </td>

                                                <td><%# Eval("message") %> </td>

                                                <td><%# Eval("EntryDate") %> </td>

                                                <td>
                                                    <asp:LinkButton ID="btnDlt" runat="server" Text="X" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' CssClass="form-control btn btn-danger"><i class="fa fa-trash-o" style="font-size:24px"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>

                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>



