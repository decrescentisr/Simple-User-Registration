using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsBusinessLayer
/// </summary>
public class clsBusinessLayer
{

    //Initializes dataPath as a string
    string dataPath;

    //calls clsDataLayer and uses myDataLayer as a variable
    clsDataLayer myDataLayer;

    public clsBusinessLayer(string serverMappedPath)
    {
        //uses dataPath variable which equals to serverMappedPath, then calls the myDataLayer and sets up a new instance with the database
        dataPath = serverMappedPath;
        myDataLayer = new clsDataLayer(dataPath + "Accounts.mdb");

    }


    public DataSet GetCustomerXMLFile()
    {
        //creates new instance of DataSet
        DataSet xmlDataSet = new DataSet();

        try
        {
            //Reads XML data from customers.xml file
            xmlDataSet.ReadXml(dataPath + "customers.xml");
        }
        catch (System.IO.FileNotFoundException error)
        {
            //creates listings from the data layer in the GetAllCustomers() method
            dsAccounts customerListing = myDataLayer.GetAllCustomers();
            customerListing.tblCustomers.WriteXml(dataPath + "customers.xml");
            xmlDataSet.ReadXml(dataPath + "customers.xml");
        }

        //returns xmlDataSet
        return xmlDataSet;
    }

    public DataSet WriteCustomerXMLFile(System.Web.Caching.Cache appCache)
    {
        //reads the current list of customers from the cache object
        DataSet xmlDataSet = (DataSet)appCache["CustomerDataSet"];

        //writes the list to the xml file
        xmlDataSet.WriteXml(dataPath + "customers.xml");

        //returns xmlDataSet
        return xmlDataSet;
    }

    public bool CheckUserCredentials(System.Web.SessionState.HttpSessionState currentSession, string username)
    {
        //Locks user out of current login session if attemps fail
        currentSession["LockedSession"] = false;

        //Sets total attempts to current session
        int totalAttempts = Convert.ToInt32(currentSession["AttemptCount"]) + 1;
        currentSession["AttemptCount"] = totalAttempts;

        //Sets user attempts to current session
        int userAttempts = Convert.ToInt32(currentSession[username]) + 1;
        currentSession[username] = userAttempts;

        //Creates if statement if user attempts are greater than 3 and locks them out
        if ((userAttempts > 3) || (totalAttempts > 6))
        {
            currentSession["LockedSession"] = true;
            myDataLayer.LockUserAccount(username);
        }
        return myDataLayer.ValidateUser(username);
    }
}