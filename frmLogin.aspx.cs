using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserProgrammer.Text = "Please enter username and password.";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Accesses App_Data directory in the clsBusinessLayer.cs business layer
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        //Accesses isValidUser method in business layer for user credentials
        bool isValidUser = myBusinessLayer.CheckUserCredentials(Session, txtUserName.Text);

        //if user is valid then it redirects to the frmRegister.aspx page
        if (isValidUser)
        {
            //Redirects to the frmRegister.aspx page
            Response.Redirect("~/frmRegister.aspx");
        }
        else if (Convert.ToBoolean(Session["LockedSession"]))
        {
            Master.UserProgrammer.Text = "Account is disabled. Contact System Administrator";

            //Hides login button visibility
            btnLogin.Visible = false;
        }
        else
        {
            //Creates incorrect login message
            Master.UserProgrammer.Text = "The User ID and/or Password supplied is incorrect. Please try again!";
        }
    }
}