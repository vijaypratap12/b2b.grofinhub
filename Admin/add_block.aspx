<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_block.aspx.cs" Inherits="add_block" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-title">
        <div>
            <h1><i class="fa fa-file-o"></i>Add Block</h1>
            <%--<h4>Simple form element, griding and layout</h4>--%>
        </div>
    </div>
    <!-- END Page Title -->
    <asp:Label ID="lbledit" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbldelete" runat="server" Visible="false"></asp:Label>
    <!-- BEGIN Breadcrumb -->

    <!-- END Breadcrumb -->

    <!-- BEGIN Main Content -->


    <div class="row hidden-xs">
        <div class="form-horizontal form-bordered">

            <div class="col-md-6">
                <div class="box box-oradnge">
                    <div class="box-title">
                        <h3><i class="fa fa-bars"></i>Add Block Details</h3>
                        <div class="box-tool">
                            <a data-action="collapse" href="#"><i class="fa fa-chevron-up"></i></a>

                        </div>
                    </div>
                    <div class="box-content">


                        <div class="col-sm-6 col-lg-6">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">State </label>
                                <div class="">

                                    <asp:DropDownList ID="ddlstate" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="ddlproperty" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>




                        <div class="col-sm-6 col-lg-6">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">District </label>
                                <div class="">

                                    <%--<asp:TextBox ID="txtpropertyname" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlproperty" runat="server" class="form-control" OnSelectedIndexChanged="ddlproperty_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="ddlproperty" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-6">
                            <div class="form-group">
                                <label for="textfield4" class="control-label">Block</label>
                                <div class="">

                                    <asp:TextBox ID="txtblock" runat="server" class="form-control" AutoComplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ErrorMessage="Field Required" ControlToValidate="txtblock" ForeColor="Red"
                                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>



                        <div class="form-group last">
                            <div class=" col-lg-6">

                                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary"
                                    OnClick="Button1_Click" ValidationGroup="Save" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>







            <div class="col-md-6">

                <div class="box box-ordange">
                    <div class="box-title">
                        <h3><i class="fa fa-bars"></i>Block Details</h3>
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

                                    <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                    <asp:BoundField DataField="BlockName" HeaderText="Block" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnedit" runat="server" CommandName="Edit1" HeaderText="Edit" CommandArgument='<%#Eval("Id") %>' ImageUrl="img/download.png" ToolTip="Edit"  Height="30px" Width="30px"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete1" CommandArgument='<%#Eval("Id") %>' HeaderText="Delete" OnClientClick="return confirm('Are you sure you want to delete this ?');" ImageUrl="img/delete.jpg" ToolTip="Delete" Height="30px" Width="30px" />
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

