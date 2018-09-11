using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserProgrammer.Text = "Please confirm your information.";

        try
        {
            if (PreviousPage.IsCrossPagePostBack)
            {
                lblUN.Text = PreviousPage.UserName.Text;
                //Code to set other form labels goes here
                lblCit.Text = PreviousPage.City.Text;
                //Code to set other form labels goes here
                lblStat.Text = PreviousPage.State.Text;
                //Code to set other form labels goes here
                lblLeas.Text = PreviousPage.LeastFavorite.Text;
                //Code to set other form labels goes here
                lblFav.Text = PreviousPage.FavoriteLanguage.Text;
                //Code to set other form labels goes here
                lblDate.Text = PreviousPage.DateCompleted.Text;
            }
        }
        catch (Exception error) //Throws an exception errors displayed in lblStatus
        {
            lblStatus.Text = "Sorry, there was an error processing your request";
        }
    }
}