<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="CareerReport.aspx.cs" Inherits="Admin_CareerReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">

        <span class="tools pull-left">
                             <%--<asp:Button ID="btnaboutNew" runat="server" Text="New" class="btn btn-success" OnClick="btnaboutNew_Click"/> --%>
            <div style="margin-left:40px; margin-top:5px">
                <asp:Button ID="btnaboutView" runat="server" Text="Show Records" class="btn  btn-warning" OnClick="btnaboutView_Click"/>
                </div>
                       
                            <%--<a href="javascript:;" class="fa fa-times"></a>--%>
                           
                        </span>
         <br />
          <h1 style="text-align:center;" >Career Record</h1>
         
        <asp:Panel ID="pnlaboutView" runat="server">
            <div class="table-responsive" style="margin-top:50px">
                <asp:GridView ID="GridView1" runat="server" class="table table-condensed" AutoGenerateColumns="False"
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>

                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnname" runat="server" Value='<%#Eval("Name") %>' />
                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         

                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnemail" runat="server" Value='<%#Eval("Email") %>' />
                                <asp:Label ID="lblcreator3" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Subject">
                          
                              <ItemTemplate>
                                <asp:HiddenField ID="hdSubject" runat="server" Value='<%#Eval("Subject") %>' />
                                <asp:Label ID="lblcreator2" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
                            </ItemTemplate>


                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Message">
                          <%--  <ItemTemplate>

                                <asp:Label ID="lblMessage" runat="server">
                                    
                                     <a href='<%# Eval("Message") %>' target="_blank"><%# Eval("Messsage") %></a>
                                </asp:Label>

                            </ItemTemplate>--%>

                               <ItemTemplate>
                                <asp:HiddenField ID="hdnMail" runat="server" Value='<%#Eval("Message") %>' />
                                <asp:Label ID="lblcreator1" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
   
                         <asp:TemplateField HeaderText="Resume">
                            <ItemTemplate>

                                <asp:Label ID="lblUpload_Resume" runat="server">

 <a download ="resume.pdf"  href='<%# "/File/"+Eval("Upload_Resume")%>' title="Resume">
    Download Resume
</a>
                                </asp:Label>

                            </ItemTemplate>
                        </asp:TemplateField>


                        <%--<asp:ButtonField runat="server" ButtonType="Button" class="btn btn-primary" />--%>

                        <%--<asp:Button runat="server" id="add" type="button" class="btn btn-primary">Add Url</asp:Button>--%>


                        <%--<asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>

                                <asp:ImageButton ID="imgbtnaboutEdit" runat="server" ImageUrl="img/download.png" Width="30" Height="30" CommandArgument='<%# Eval("Id") %>' OnClick="imgbtnaboutEdit_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>



                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>

                                <asp:ImageButton ID="imgbtnDelete" runat="server" OnClick="imgbtnDelete_Click" OnClientClick="return confirm('Are you sure you want delete');" ImageUrl="img/delete.jpg" Width="44px" Height="43px" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

                </asp:GridView>
            </div>
        </asp:Panel>
        
    </div>

   
</asp:Content>





