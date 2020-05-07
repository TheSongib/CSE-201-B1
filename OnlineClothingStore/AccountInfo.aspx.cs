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

namespace OnlineClothingStore
{


    public partial class AccountInfo : Page
    {
        //sql database connection
        SqlConnection con;
        //Here we declare the parameter which we have to use in our application  
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Display user data from session variables
            adminStuff.Visible = false;
            nameInfo.InnerText = Session["firstName"] + " " + Session["lastName"];
            emailInfo.InnerText = "" + Session["email"];
            addressInfo.InnerText = "" + Session["address"];

            //If user is an admin, display promote to admin text area
            if ((bool)Session["admin"])
            {
                adminStuff.Visible = true;
            }
        }

        protected void Promote_Click(object sender, EventArgs e)
        {
            if(promote.Text == "")
            {
                passOrFail.Text = "Invalid input";
            }

            //Establish connection to stored procedure and add parameteres
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            cmd = new SqlCommand("spPromoteToAdmin", con);
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = promote.Text;
            SqlParameter retVal = cmd.Parameters.Add("@success", SqlDbType.Bit);
            retVal.Direction = ParameterDirection.Output;

            //Execute and get return value
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.ExecuteNonQuery();
            bool success = (bool)cmd.Parameters["@success"].Value;

            //Determine if successful and display message accordingly
            if (success)
            {
                passOrFail.Text = "Successfully promoted to admin!";
            }
            else
            {
                passOrFail.Text = "Failed: Either user does not exist or is already admin!";
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["email"] = null;
            Session["firstName"] = null;
            Session["lastName"] = null;
            Session["Address"] = null;
            Session["admin"] = null;
            Response.Redirect("Default.aspx");
        }
    }

}