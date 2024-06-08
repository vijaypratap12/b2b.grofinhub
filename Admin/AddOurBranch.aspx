<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddOurBranch.aspx.cs" Inherits="AddOurBranch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .mt-5 {
    margin-top: 39px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-title">
        <div>
            <h1><i class="fa fa-file-o"></i>Add  Branch</h1>
            <%--<h4>Simple form element, griding and layout</h4>--%>
        </div>
    </div>
    <!-- END Page Title -->
    <asp:Label ID="lbledit" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbldelete" runat="server" Visible="false"></asp:Label>
    <!-- BEGIN Breadcrumb -->

    <!-- END Breadcrumb -->

    <!-- BEGIN Main Content -->

       <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>


    <script type="text/javascript">

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

    <div class="">
        <div class="form-horizontal form-bordered">
           
            <div class="">
                <div class="box box-orange">
                    <div class="box-title">
                        <h3><i class="fa fa-bars"></i>Add Branch</h3>
                        <div class="box-tool">
                            <a data-action="collapse" href="#"><i class="fa fa-chevron-up"></i></a>

                        </div>
                    </div>

                    <div class="row">
                <div class="col-md-4">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">State </label>
                                 <div class="">

                                    <asp:DropDownList ID="ddlstate" runat="server" class="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="Select state " InitialValue="0" ControlToValidate="ddlproperty" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" Font-Size="12">
                                    </asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                <div class="col-md-4">
                            <div class="form-group">
                                <label  class="control-label">District </label>
                                      <div class="">

                                    <asp:DropDownList ID="ddldistrict" runat="server" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" class="form-control" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="ddldistrict" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                <div class="col-md-4">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">Block </label>
                                    <div class="">

                                    <asp:DropDownList ID="ddlblock" runat="server" class="form-control" AutoPostBack="true">
                                    </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                
            </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">Mobile </label>
                                   <div class="">

                                    <asp:TextBox ID="txtMobile" runat="server" class="form-control" MaxLength="10" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="txtMobile" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="mob" runat="server" ErrorMessage="Enter valid Mobile Number." Display="Dynamic" ForeColor="Red" ControlToValidate="txtmobile" ValidationExpression="^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>


                              <div class="col-md-4">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">Address </label>
                                   <div class="">

                                      <asp:TextBox ID="txtblock" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="txtblock" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                <div class="col-md-4">
                            <div class="mt-5">
                                
                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary"
                                        OnClick="Button1_Click" ValidationGroup="Save" />
                                
                            </div>
                        </div>

                    </div>

                    </div>
                </div>
          
                
            <div class="col-md-12">

                <div class="box box-orange">
                    <div class="box-title">
                        <h3><i class="fa fa-bars"></i> Branch Details</h3>
                        <div class="box-tool">
                            <a data-action="collapse" href="#"><i class="fa fa-chevron-up"></i></a>

                        </div>
                    </div>
                    <div class="box-content">


                        <div class="form-group">
                            <asp:Label ID="lblentryid" runat="server" Visible="false"></asp:Label>

                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                class="table table-bordered" CellPadding="4" ForeColor="Black"
                                GridLines="Vertical" OnRowCommand="GridView2_RowCommand"
                                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">

                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <%--<asp:BoundField DataField="BlockName" HeaderText="State" />
                                    <asp:BoundField DataField="BlockName" HeaderText="District" />--%>
                                    <asp:BoundField DataField="BlockName" HeaderText="Block" />
                                    <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                                    <asp:BoundField DataField="BranchMobile" HeaderText="Mobile" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnedit" runat="server" CommandName="Edit1" HeaderText="Edit" CommandArgument='<%#Eval("Id") %>' ImageUrl="img/edit-1.png" ToolTip="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete1" CommandArgument='<%#Eval("Id") %>' HeaderText="Delete" OnClientClick="return confirm('Are you sure you want to delete this ?');" ImageUrl="img/Delete-1.png" ToolTip="Delete" />
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>

                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>

                        </div>

                    </div>
                </div>
            </div>


        </div>
        </div>
        <!-- END Main Content -->



        <!-- END Main Content -->
</asp:Content>

