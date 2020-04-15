using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Security;

namespace OnlineClothingStore
{
    

    public partial class Login : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            //establish connect to stored procedure and execute
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spValidateLogin", con);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = loginEmail.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = loginPassword.Text;
            SqlParameter retval = cmd.Parameters.Add("@success", SqlDbType.Bit);
            retval.Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            bool success = (bool)cmd.Parameters["@success"].Value;

            //if successful set session variables, if not display account already exists
            if (success)
            {
                //do query to get user information
                string query = "SELECT userId, firstName, lastName, address, admin FROM tblUsers WHERE email LIKE '" + loginEmail.Text + "';";
                SqlCommand variableQuery = new SqlCommand(query, con);
                SqlDataReader reader = variableQuery.ExecuteReader();
                while (reader.Read()) {
                    //Set session variables from query to be accessed on all pages
                    Session["userId"] = reader[0];
                    Session["email"] = loginEmail.Text;
                    Session["firstName"] = reader[1];
                    Session["lastName"] = reader[2];
                    Session["Address"] = reader[3];
                    Session["admin"] = (bool)reader[4];
                }
                FormsAuthentication.RedirectFromLoginPage(loginEmail.Text, false);
            }
            else
            {
                noMatch.Text = "No account exists with those credentials!";
            }
            con.Close();
        }
    }

}