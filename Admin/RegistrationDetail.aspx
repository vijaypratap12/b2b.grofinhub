<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="RegistrationDetail.aspx.cs" Inherits="Admin_RegistrationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .div1 {
            min-height: 200px;
            /*padding: 50px;*/
            padding: 30px;
            background: #e4e9ec;
        }

        .form-control {
            margin-bottom: 20px;
        }

        .layout {
            /*padding: 30px;*/
            padding: 20px;
            background: white;
        }
    </style>
    <br />
    <br />
    <h5>Basic Details</h5>
    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>FName</th>
                                        <th>MName</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>DOB</th>
                                        <th>PostApplied</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptRegistration" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Name") %> </td>
                                                <td><%# Eval("FName") %> </td>
                                                <td><%# Eval("MName") %> </td>
                                                <td><%# Eval("Email") %> </td>
                                                <td><%# Eval("Mobile") %> </td>
                                                <td><%# Eval("DOB") %> </td>
                                                <td><%# Eval("PostApplied") %> </td>
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
    <h5>Personal Details</h5>
    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <p style="color: red"></p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Nationality</th>
                                        <th>Religion</th>
                                        <th>Marital Status</th>
                                        <th>Gender</th>
                                        <th>Domicile State</th>
                                        <th>Applied Category</th>
                                        <th>Sub Category</th>
                                        <th>Reg/Govt Employee</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater8" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Nationality") %> </td>
                                                <td><%# Eval("Religion") %> </td>
                                                <td><%# Eval("Marital") %> </td>
                                                <td><%# Eval("Gender") %> </td>
                                                <td><%# Eval("DomicileState") %> </td>
                                                <td><%# Eval("Category") %> </td>
                                                <td><%# Eval("SubCategory") %> </td>
                                                <td><%# Eval("R_GEmployee") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <p style="color: red">Address</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Address1</th>
                                        <th>Address2</th>
                                        <th>Address3</th>
                                        <th>City</th>
                                        <th>District</th>
                                        <th>State</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Add1") %> </td>
                                                <td><%# Eval("Add2") %> </td>
                                                <td><%# Eval("Add3") %> </td>
                                                <td><%# Eval("City") %> </td>
                                                <td><%# Eval("District") %> </td>
                                                <td><%# Eval("State") %> </td>
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
    <h5>Study Details</h5>
    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <p style="color: red">10th Details</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th style="display: none">Diploma/Graduation</th>
                                        <th>Board</th>
                                        <th>Passing Year</th>
                                        <th>Roll No</th>
                                        <th>Marks Obtained</th>
                                        <th>Marks Total</th>
                                        <th>Marks Percentage</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="display: none"><%# Eval("checkValue") %> </td>
                                                <td><%# Eval("BoardTen") %> </td>
                                                <td><%# Eval("TenPassing") %> </td>
                                                <td><%# Eval("ResultTypeTen") %> </td>
                                                <td><%# Eval("TenMarks") %> </td>
                                                <td><%# Eval("TotalTenMarks") %> </td>
                                                <td><%# Eval("TenPercent") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <p style="color: red">12th Details</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Board</th>
                                        <th>Passing Year</th>
                                        <th>Roll No</th>
                                        <th>Marks Obtained</th>
                                        <th>Marks Total</th>
                                        <th>Marks Percentage</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("TwBoard") %> </td>
                                                <td><%# Eval("TwPassing") %> </td>
                                                <td><%# Eval("TwResultType") %> </td>
                                                <td><%# Eval("TwMarks") %> </td>
                                                <td><%# Eval("TotalTwMarks") %> </td>
                                                <td><%# Eval("TwPercent") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <p style="color: red">Graduation Details</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Board</th>
                                        <th>Passing Year</th>
                                        <th>Roll No</th>
                                        <th>Marks Obtained</th>
                                        <th>Marks Total</th>
                                        <th>Marks Percentage</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Board") %> </td>
                                                <td><%# Eval("Passing") %> </td>
                                                <td><%# Eval("RollNo") %> </td>
                                                <td><%# Eval("Marks") %> </td>
                                                <td><%# Eval("TotalMarks") %> </td>
                                                <td><%# Eval("Percentage") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <p style="color: red">Other Qualifications</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Course Name</th>
                                        <th>Specialization</th>
                                        <th>Passing Year</th>
                                        <th>Institute Name </th>
                                        <th>Result</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Course") %> </td>
                                                <td><%# Eval("Specialization") %> </td>
                                                <td><%# Eval("CoPassing") %> </td>
                                                <td><%# Eval("Institute") %> </td>
                                                <td><%# Eval("Result") %> </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <p style="color: red">Experience</p>
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Post Name</th>
                                        <th>From Date</th>
                                        <th>To Date</th>
                                        <th>Organization </th>
                                        <th>Experience</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater7" runat="server" OnItemCommand="rptRegistration_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("PostName") %> </td>
                                                <td><%# Eval("txtWExpDOJ1") %> </td>
                                                <td><%# Eval("txtWExpDOJ12") %> </td>
                                                <td><%# Eval("txtEName") %> </td>
                                                <td><%# Eval("Experience") %> </td>
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
    <h5>Download Uploaded Documents</h5>
    <div class="div1">
        <div class="row">
            <div class="layout">
                <div class="row">
                    <div class="col-sm-12">
                        <hr style="black;" />
                        <div class="table-responsive">
                            <table class="table table-striped" id="">
                                <thead>
                                    <tr>
                                        <th>Photo</th>
                                        <th>Signature</th>
                                        <th>10th Marksheet</th>
                                        <th style="display: none">10th certificate</th>
                                        <th>12th Marksheet</th>
                                        <th style="display: none">12th certificate</th>
                                        <th style="display: none">Domicile Certificate</th>
                                        <th>Highest Qualification</th>
                                        <th style="display: none">Graduation Marksheet</th>
                                        <th style="display: none">Registration Certificate</th>
                                        <th>PayemetSS</th>
                                        <th style="display: none">Other Documents</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:Repeater ID="Repeater3" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="hprPic" runat="server" Target="_blank" 
                                                        NavigateUrl='<%#  Eval("FileUpload1").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("FileUpload1")%>'
                                                        Text='<%# Eval("FileUpload1").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>

                                                    <%--<a style="color: blue; display:none" target="_blank" href='<%# "../Uploads/"+Eval("FileUpload1")%>' title="Photo">VIEW </a>--%></td>

                                                <td>
                                                    
                                                   <%-- <a style="color: blue;" target="_blank" href='<%# "../Uploads/"+Eval("FileUpload2")%>' title="Signature">VIEW </a>--%>

                                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" 
                                                        NavigateUrl='<%#  Eval("FileUpload2").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("FileUpload2")%>'
                                                        Text='<%# Eval("FileUpload2").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>


                                                </td>

                                                <td>
                                                   <%-- <a style="color: blue;" target="_blank" href='<%# "../Uploads/"+Eval("FileUpload3")%>' title="10th Marksheet">VIEW </a>--%>

                                                     <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" 
                                                        NavigateUrl='<%#  Eval("FileUpload3").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("FileUpload3")%>'
                                                        Text='<%# Eval("FileUpload3").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>

                                                </td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload4")%>' title="10th certificate"><%# Eval("FileUpload4") %> </a></td>

                                                <td>
                                                    <%--<a style="color: blue;" target="_blank" href='<%# "../Uploads/"+Eval("FileUpload5")%>' title="12th Marksheet">VIEW </a>--%>

                                                     <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" 
                                                        NavigateUrl='<%#  Eval("FileUpload5").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("FileUpload5")%>'
                                                        Text='<%# Eval("FileUpload5").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>


                                                </td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload6")%>' title="12th certificate"><%# Eval("FileUpload6") %> </a></td>

                                                <%--<td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload7")%>' title="Domicile Certificate"><%# Eval("FileUpload7") %> </a></td>--%>
                                                <td>
                                                    <asp:HyperLink ID="HyperLink5" runat="server" Target="_blank" 
                                                        NavigateUrl='<%#  Eval("FileUpload7").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("FileUpload7")%>'
                                                        Text='<%# Eval("FileUpload7").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>
                                                </td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload8")%>' title="Graduation Certificate"><%# Eval("FileUpload8") %> </a></td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload9")%>' title="Graduation Marksheet"><%# Eval("FileUpload9") %> </a></td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("FileUpload10")%>' title="Registration Certificate"><%# Eval("FileUpload10") %> </a></td>

                                                <td>
                                                    <%--<a style="color: blue;" target="_blank" href='<%# "../Uploads/"+Eval("PayemetSS")%>' title="Other Documents">VIEW </a>--%>

                                                    <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank"
                                                        NavigateUrl='<%#  Eval("PayemetSS").ToString()=="" ? "javascript:void(0);" : "../Uploads/"+Eval("PayemetSS")%>'
                                                        Text='<%# Eval("PayemetSS").ToString()=="" ? "NA": "VIEW" %>'
                                                        ></asp:HyperLink>


                                                </td>

                                                <td style="display: none"><a style="color: blue;" href='<%# "../Uploads/"+Eval("PayemetSS")%>' title="Other Documents"><%# Eval("FileUpload11") %> </a></td>
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

