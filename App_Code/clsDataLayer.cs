using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class clsDataLayer
{
    OleDbConnection dbConnection;
    public clsDataLayer(string Path)
    {
        dbConnection = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path);

    }

    public dsAccounts FindCustomer(string UserName)
    {
        //Selects LastName from tblCustomers and connects to the database
        string sqlStmt = "select * from tblCustomers where UserName like '" + UserName + "'";
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter(sqlStmt, dbConnection);

        //Stores information to the dsAccounts data set from tblCustomers
        dsAccounts myStoreDataSet = new dsAccounts();
        sqlDataAdapter.Fill(myStoreDataSet.tblCustomers);

        //returns myStoreDataSet
        return myStoreDataSet;
    }

    public void UpdateCustomer(string userName, string city, string state, string leastFavorite, string favoriteLanguage)
    {
        //Opens database connection
        dbConnection.Open();

        //Updates username, city, state, least favorite language, favoriate language, security level to the database
        string sqlStmt = "UPDATE tblCustomers SET UserName = @user, " + "City = @city, " + "State = @state, " +
            "LeastFavorite = @least, " + "FavoriteLanguage = @favorite, " + "WHERE (tblCustomers.UserName = @user)";

        //Connects to the database
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Adds new @ parameters to the database
        OleDbParameter param = new OleDbParameter("@user", userName);
        dbCommand.Parameters.Add(param);

        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@least", leastFavorite));
        dbCommand.Parameters.Add(new OleDbParameter("@favorite", favoriteLanguage));



        //Executes a non query to the database
        dbCommand.ExecuteNonQuery();

        //Closes database connection
        dbConnection.Close();

    }

    public void InsertCustomer(string userName, string city, string state, string leastFavorite, string favoriteLanguage, string dateCompleted)
    {
        //Opens database connection
        dbConnection.Open();

        //Inserts customer information into the database
        string sqlStmt = "INSERT INTO tblCustomers(UserName, City, State, LeastFavorite, FavoriteLanguage, DateCompleted) ";
        sqlStmt += "VALUES (@user, @city, @state, @least, @favorite, @date)";

        //Connects to the database
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Adds parameters to the database connection
        OleDbParameter param = new OleDbParameter("@user", userName);
        dbCommand.Parameters.Add(param);
        dbCommand.Parameters.Add(new OleDbParameter("@city", city));
        dbCommand.Parameters.Add(new OleDbParameter("@state", state));
        dbCommand.Parameters.Add(new OleDbParameter("@least", leastFavorite));
        dbCommand.Parameters.Add(new OleDbParameter("@favorite", favoriteLanguage));
        dbCommand.Parameters.Add(new OleDbParameter("@date", dateCompleted));




        //Executes a non query to the database
        dbCommand.ExecuteNonQuery();

        //Closes database connection
        dbConnection.Close();
    }

    public void DeleteInfo(string UserName, string City, string State, string FavoriteLanguage, string LeastLanguage)
    {
        //Opens database connection
        dbConnection.Open();

        //Deletes customer information from the database
        string sqlStmt = "DELETE * FROM tblCustomers";

        //Connects to the database
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Executes a non query from the database command
        dbCommand.ExecuteNonQuery();

        //Closes the database connection
        dbConnection.Close();


    }

    public dsAccounts GetAllCustomers()
    {
        //Connects to the database adapter by selecting all from tblCustomers
        OleDbDataAdapter sqlDataAdapter = new OleDbDataAdapter("select * from tblCustomers;", dbConnection);

        //Pulls from the dataset
        dsAccounts myStoreDataSet = new dsAccounts();

        sqlDataAdapter.Fill(myStoreDataSet.tblCustomers);

        //returns myStoreDataSet
        return myStoreDataSet;

    }

    public bool ValidateUser(string username)
    {
        //Opens the database connection
        dbConnection.Open();

        //Selects username and password from tblUsers
        string sqlStmt = "SELECT * FROM tblUsers WHERE UserName = @username AND Locked = FALSE";

        //Creates new database command instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Adds username and password to the tblUsers database
        dbCommand.Parameters.Add(new OleDbParameter("@username", username));


        //Creates new instance for ExecuteReader in the database
        OleDbDataReader dr = dbCommand.ExecuteReader();

        //Uses boolean isValidAccount to read the datareader
        Boolean isValidAccount = dr.Read();

        //Closes database connection
        dbConnection.Close();

        return isValidAccount;


    }

    public void LockUserAccount(string username)
    {
        //Opens database connection
        dbConnection.Open();

        //Updates username and password from tblUsers to make sure correct user is logging in
        string sqlStmt = "SELECT * FROM tblUsers SET Locked = True WHERE UserName = @username";

        //Creates new database command instance
        OleDbCommand dbCommand = new OleDbCommand(sqlStmt, dbConnection);

        //Adds username the tblUsers database
        dbCommand.Parameters.Add(new OleDbParameter("@username", username));

        //Executes non query to database
        dbCommand.ExecuteNonQuery();

        //Closes database connection
        dbConnection.Close();

    }
}