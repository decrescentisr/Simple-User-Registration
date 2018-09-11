<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" MasterPageFile="~/CourseProject.master" Inherits="frmLogin" %>

<%@ MasterType VirtualPath="~/CourseProject.master" %>


<asp:Content ID ="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                         <asp:Label ID="lblUserName" runat="server" AssociatedControlID="txtUserName">User Name:</asp:Label>
                                        &nbsp;<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is Required" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <br />
            <br />
                                            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Password:</asp:Label>
                                        &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <br />
                                            <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me next time." />
                                        <br />
            <br />
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        <br />
            <br />
    

            <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" OnClick="btnLogin_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnRegister" runat="server" CommandName="Login" Text="Register" ValidationGroup="Login1" PostBackUrl="~/frmRegister.aspx" />
</asp:Content>

