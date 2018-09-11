<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmRegister.aspx.cs" MasterPageFile="~/CourseProject.master" Inherits="frmRegister" %>

<%@ MasterType VirtualPath="~/CourseProject.master" %>


<asp:Content ID ="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <center><b> <asp:Label ID="Label1" runat="server" Text="Account Information Page"></asp:Label></b></center>
            <br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is Required" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Password is Required" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
           <br />
            <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City is Required" ForeColor="Red" ControlToValidate="txtCity"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="State is Required" ForeColor="Red" ControlToValidate="txtState"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblFavoriteLanguage" runat="server" Text="Favorite Programming Language: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFavoriteLanguage" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Favorite Language is Required" ForeColor="Red" ControlToValidate="txtFavoriteLanguage"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblLeastLanguage" runat="server" Text="Least Favorite Programming Language: "></asp:Label>
&nbsp;
            <asp:TextBox ID="txtLeastLanguage" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Least Favorite Language is Required" ForeColor="Red" ControlToValidate="txtLeastLanguage"></asp:RequiredFieldValidator>
            <br />
           <br />
            <asp:Label ID="lblDate" runat="server" Text="Date last program was completed: "></asp:Label> &nbsp;<asp:TextBox ID="txtDateCompleted" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
           <br />
            &nbsp;
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />
           <br />
           <br />
          <br />
          <asp:Label ID = "lblGVDataBase" runat="server" Text="Customers in Database: "></asp:Label>
                  <br />
                  <asp:GridView ID="gvCustomerList" runat="server" Font-Size="9"></asp:GridView><br />
                  <asp:Label ID = "lblGVXML" runat="server" Text="Customers in XML File: "></asp:Label><br />
                  <asp:GridView ID ="gvXML" runat="server" Font-Size="9"></asp:GridView>
&nbsp;<br />
           <br />
            <br />
            <br />
  

           <asp:Button ID="btnAddCustomer" runat="server" OnClick="btnAddCustomer_Click" Text="Add User" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnUpdateXML" runat="server" Text="Update XML" OnClick="btnUpdateXML_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnDeleteUser" runat="server" Text="Delete User from Database" OnClick="btnDeleteUser_Click" />
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnDeleteXML" runat="server" Text="Delete User from XML" OnClick="btnDeleteXML_Click" />
&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearFields" runat="server" OnClick="btnClearFields_Click" Text="Clear Fields" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          
           <asp:Button ID="btnFindUserName" runat="server" OnClick="btnFindUserName_Click" Text="Find User Name" />
&nbsp;&nbsp; &nbsp;<asp:Button ID="btnReturnLogin" runat="server" Text="Return to Login" PostBackUrl="~/frmLogin.aspx" />
           &nbsp;&nbsp;&nbsp;<br />
           <br />
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm Registration" PostBackUrl="~/frmConfirm.aspx" />
          
           &nbsp;<br />
           <br />
          <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

</asp:Content>