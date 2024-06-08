<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="MemberAllotReport.aspx.cs" Inherits="MemberAllotReport" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="box">
        <div class="box-title">
            <h3><i class="fa fa-bars"></i>Registration Member Allotment Report </h3>

        </div>
        <div class="box-content">


            <div class="div1">
                <div class="row">
                    <div class="layout">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="col-sm-3">
                                    <label>FromDate</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtfromdate" runat="server" class="form-control" AutoComplete="off" TextMode="Date"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <label>ToDate</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txttodate" runat="server" class="form-control" AutoComplete="off" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>




                                <div class="col-sm-3">
                                    <label>State</label>
                                    <div class="input-group">
                                        <%--<asp:TextBox ID="txtstate" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="Select state " InitialValue="0" ControlToValidate="ddlstate" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="s" Font-Size="12">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-sm-3">
                                    <label>District</label>
                                    <div class="input-group">
                                        <%-- <asp:TextBox ID="txtDistrict" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>--%>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="  Select district " InitialValue="Select District" ControlToValidate="ddldistrict" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="s">
                                        </asp:RequiredFieldValidator>


                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ErrorMessage="Field Required" ControlToValidate="ddldistrict" ForeColor="Red"
                                            ValidationGroup="s"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-sm-3">
                                    <label>Block</label>
                                    <div class="input-group">
                                        <%-- <asp:TextBox ID="txtBlock" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ErrorMessage=" Select block " InitialValue="Select Block" ControlToValidate="ddlblock" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="s">
                                        </asp:RequiredFieldValidator>

                                        <asp:DropDownList ID="ddlblock" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ErrorMessage="Field Required" ControlToValidate="ddlblock" ForeColor="Red"
                                            ValidationGroup="s"></asp:RequiredFieldValidator>
                                    </div>
                                </div>                              

                                <div class="col-sm-3">
                                    <br />
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-warning active"
                                        ValidationGroup="I" OnClick="btnSearch_Click" Style="margin-top: 6px;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br />

            <div class="div1">

                <div class="layout">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:TextBox ID="totalRegistration" runat="server" Width="20%" BorderStyle="None" CssClass="form-control" placeholder="Total Registration : " ForeColor="red" ReadOnly="true" OnLoad="totalRegistration_Load"></asp:TextBox>
                            <hr style="black;" />

                            <div style="display: none">
                                <asp:Button ID="ExportToPrint" runat="server" Text="Export to Exel" class="btn btn-primary " OnClick="ExportToPrint_Click" ClientIDMode="Static" />
                            </div>

                            <div class="table-responsive">
                                <table class="table table-striped" id="">
                                    <thead>
                                        <tr style="background-color: #0e6390; color: white;">
                                            <th>Sr. No.</th>
                                            <th>Partner Id</th>
                                            <th>Name</th>
                                            <th>Mobile</th>
                                            <th>Status</th>
                                            <th>Registration Date</th>
                                            <th>View</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptRegistration" runat="server" ClientIDMode="Static">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Idd") %> </td>
                                                    <td><%# Eval("AgentId") %> </td>
                                                    <td><%# Eval("Name") %> </td>
                                                    <td><%# Eval("Mobile") %> </td>
                                                    <td><%# Eval("Status") %> </td>
                                                    <td><%# Eval("EntryDate") %> </td>
                                                    <td>
                                                        <a href="ViewProfile.aspx?AgentId=<%# Eval("AgentId") %>" class="btn btn-primary">View Details</a>
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
    </div>
</asp:Content>
