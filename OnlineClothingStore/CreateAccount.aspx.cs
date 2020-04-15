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
    

    public partial class CreateAccount : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (firstName.Text.Equals("") || lastName.Text.Equals("") || email.Text.Equals("") || password.Text.Equals("") || address.Text.Equals(""))
            {
                existingAccount.Text = "You must fill out all fields";
            }
            else
            {
                //establish connect to stored procedure and execute
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                cmd = new SqlCommand("spCreateAccount", con);
                cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstName.Text;
                cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password.Text;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address.Text;
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
                    string query = "SELECT userId, firstName, lastName, address, admin FROM tblUsers WHERE email LIKE '" + email.Text + "';";
                    System.Diagnostics.Debug.WriteLine(query);
                    SqlCommand variableQuery = new SqlCommand(query, con);
                    SqlDataReader reader = variableQuery.ExecuteReader();
                    
                    //Set session variables from query to be accessed on all pages
                    while (reader.Read())
                    {
                        Session["userId"] = reader[0];
                        Session["email"] = email.Text;
                        Session["firstName"] = reader[1];
                        Session["lastName"] = reader[2];
                        Session["Address"] = reader[3];
                        Session["admin"] = reader[4];
                    }
                    FormsAuthentication.RedirectFromLoginPage(email.Text, false);
                }
                else
                {
                    existingAccount.Text = "Account already exists!";
                }
                con.Close();
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }

}