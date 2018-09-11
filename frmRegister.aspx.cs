using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmRegister : System.Web.UI.Page
{
    clsBusinessLayer myBusinessLayer;

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.UserProgrammer.Text = "Please enter information.";

        //Binds CustomerGridView()
        BindCustomerGridView();

        //Initializes the data field from the clsBusinessLayer class
        myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Data/"));

        //Binds XMLGridView()
        BindXMLGridView();
    }

    public TextBox UserName //Gets UserName
    {
        get
        {
            return txtUserName; //Returns txtUserName
        }
    }

    public TextBox Password
    {
        get
        {
            return txtPassword;
        }
    }

    public TextBox City
    {
        get
        {
            return txtCity;
        }
    }

    public TextBox State
    {
        get
        {
            return txtState;
        }
    }

    public TextBox LeastFavorite
    {
        get
        {
            return txtLeastLanguage;
        }
    }

    public TextBox FavoriteLanguage
    {
        get
        {
            return txtFavoriteLanguage;
        }
    }

    public TextBox DateCompleted
    {
        get
        {
            return txtDateCompleted;
        }
    }




    protected void btnClearFields_Click(object sender, EventArgs e)
    {
        ClearInputs(Page.Controls);
    }

    private void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else
                ClearInputs(ctrl.Controls);
        }
    }

    protected void btnFindUserName_Click(object sender, EventArgs e)
    {
        //accesses dsAccounts data set finding last name
        dsAccounts dsFindUserName;

        //accesses Accounts.mdb database for the clsDataLayer
        string tempPath = Server.MapPath("Accounts.mdb");
        clsDataLayer dataLayerObj = new clsDataLayer(tempPath);

        try
        {
            //finds lastName in dataset
            dsFindUserName = dataLayerObj.FindCustomer(txtUserName.Text);

            //if statement for user if they search by last name
            if (dsFindUserName.tblCustomers.Rows.Count > 0)
            {
                //finds last name if last name is placed in proper text field
                txtUserName.Text = dsFindUserName.tblCustomers[0].UserName;
                txtCity.Text = dsFindUserName.tblCustomers[0].City;
                txtState.Text = dsFindUserName.tblCustomers[0].State;
                txtLeastLanguage.Text = dsFindUserName.tblCustomers[0].LeastFavorite;
                txtFavoriteLanguage.Text = dsFindUserName.tblCustomers[0].FavoriteLanguage;


                Master.UserProgrammer.Text = "Record Found";

            }
            else
            {
                //Adds comment if no records were found through searching for the LastName on the database
                Master.UserProgrammer.Text = "No records were found!";
            }
        }
        catch (Exception error)
        {
            //Informs user that error occured if an exception was thrown
            string message = "Something went wrong - ";

            Master.UserProgrammer.Text = message + error.Message;
        }
    }



    protected void btnUpdateCustomer_Click(object sender, EventArgs e)
    {
        //Creates a boolean to false if the update creates an error
        bool customerUpdateError = false;

        //accesses Accounts.mdb database for the clsDataLayer
        string tempPath = Server.MapPath("Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        //Updates Customer Information for all fields
        try
        {
            myDataLayer.UpdateCustomer(txtUserName.Text, txtCity.Text, txtState.Text, txtLeastLanguage.Text, txtFavoriteLanguage.Text);
        }
        catch (Exception error)
        {
            customerUpdateError = true;
            string message = "Error updating customer, please check form data. ";
            Master.UserProgrammer.Text = message + error.Message;
        }

        if (!customerUpdateError)
        {
            ClearInputs(Page.Controls);
            Master.UserProgrammer.Text = "Customer Updated Successfully";
        }

        //Binds CustomerGridView()
        BindCustomerGridView();
    }

    //Adds click event that calls Data Layer method InsertCustomer. 
    protected void btnAddCustomer_Click(object sender, EventArgs e)
    {
        //Creates a boolean to false if the add customer creates an error
        bool customerAddError = false;

        //accesses Accounts.mdb database for the clsDataLayer
        string tempPath = Server.MapPath("Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        //Inserts Customer Information for all fields
        try
        {
            myDataLayer.InsertCustomer(txtUserName.Text, txtCity.Text, txtState.Text, txtLeastLanguage.Text, txtFavoriteLanguage.Text, txtDateCompleted.Text);
        }
        catch (Exception error)
        {
            customerAddError = true;
            string message = "Error adding customer, please check form data. ";
            Master.UserProgrammer.Text = message + error.Message;
        }

        if (!customerAddError)
        {
            ClearInputs(Page.Controls);
            Master.UserProgrammer.Text = "Customer Added Successfully";
        }

        //Binds CustomerGridView()
        BindCustomerGridView();
    }

    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        //Creates a boolean to false if the update creates an error
        bool customerDeleteError = false;

        //accesses Accounts.mdb database for the clsDataLayer
        string tempPath = Server.MapPath("Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        //Deletes User Name 
        try
        {
            myDataLayer.DeleteInfo(txtUserName.Text, txtCity.Text, txtState.Text, txtLeastLanguage.Text, txtFavoriteLanguage.Text);
        }
        catch (Exception error)
        {
            customerDeleteError = true;
            string message = "Error deleting customer, please check form data. ";
            Master.UserProgrammer.Text = message + error.Message;
        }
        if (!customerDeleteError)
        {
            ClearInputs(Page.Controls);
            Master.UserProgrammer.Text = "Customer Deleted Successfully";
        }
    }

    private dsAccounts BindCustomerGridView()
    {
        //accesses Accounts.mdb database for the clsDataLayer
        string tempPath = Server.MapPath("Accounts.mdb");
        clsDataLayer myDataLayer = new clsDataLayer(tempPath);

        //retrieve customer listings from data layer in GetAllCustomers() method
        dsAccounts customerListing = myDataLayer.GetAllCustomers();

        //adds information from customerListing in tblCustomers to the grid view
        gvCustomerList.DataSource = customerListing.tblCustomers;

        //data binds gvCustomerList and inserts into the cache
        gvCustomerList.DataBind();
        Cache.Insert("CustomerDataSet", customerListing);

        return customerListing;
    }

    public void BindXMLGridView()
    {
        //Uses business layer to process the file and handle any errors
        gvXML.DataSource = myBusinessLayer.GetCustomerXMLFile();
        gvXML.DataBind();
    }


    protected void btnUpdateXML_Click(object sender, EventArgs e)
    {

        //Updates the XML from the Cache object and binds gvXML
        gvXML.DataSource = myBusinessLayer.WriteCustomerXMLFile(Cache);
        gvXML.DataBind();
    }

    protected void btnDeleteXML_Click(object sender, EventArgs e)
    {
        //Calls a new dataset
        DataSet ds = new DataSet();

        //reads from XML file
        ds.ReadXml(Server.MapPath("~/App_Data/customers.xml"));

        //removes specified row
        ds.Tables[0].Rows.RemoveAt(0);

        //Writes to XML file
        ds.WriteXml(Server.MapPath("~/App_Data/customers.xml"));

        //Binds to CustomerGridView() method
        BindCustomerGridView();
    }
}