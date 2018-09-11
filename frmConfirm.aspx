<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmConfirm.aspx.cs" MasterPageFile="~/CourseProject.master" Inherits="frmConfirm" %>
<%@ PreviousPageType VirtualPath="~/frmRegister.aspx" %>

<%@ MasterType VirtualPath="~/CourseProject.master" %>

<asp:Content ID ="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <center> <b><asp:Label ID="lblConfirmDetails" runat="server" Text="Confirm Registration Details"></asp:Label></b></center>
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
&nbsp;<asp:Label ID="lblUN" runat="server" Text=""></asp:Label>
           <br />
           <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
           &nbsp;<asp:Label ID="lblCit" runat="server"></asp:Label>
           <br />
           <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
           &nbsp;<asp:Label ID="lblStat" runat="server"></asp:Label>
           <br />
           <asp:Label ID="lblLeastLanguage" runat="server" Text="Least Favorite Language: "></asp:Label>
    <asp:Label ID="lblLeas" runat="server"></asp:Label>
           <br />
           <asp:Label ID="lblFavoriteLanguage" runat="server" Text="Favorite Language: "></asp:Label>
    <asp:Label ID="lblFav" runat="server"></asp:Label>
            <br />
    <asp:Label ID="lblDateCompleted" runat="server" Text="Date Completed: "></asp:Label>
    <asp:Label ID="lblDate" runat="server"></asp:Label>
            <br />
            <br />
            <br />
    </asp:Content>
<asp:Content ID ="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            &nbsp; &nbsp;

    <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
            <br />
    <asp:Button ID="btnLogin" runat="server" Text="Go to Login" PostBackUrl="~/frmLogin.aspx" />
          
           &nbsp;<br />
    </asp:Content>
