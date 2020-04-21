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


    public partial class Sell : Page
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
            //Dont let user make listing if user is not logged in
            if (Session["userId"] == null)
            {
                //put code here to display error message if user is not logged in
            }
            else
            {
                //establish connect to stored procedure and execute
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                cmd = new SqlCommand("spAddListing", con);
                cmd.Parameters.Add("@userId", SqlDbType.Int).Value = (int)Session["userId"];
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = listingTitle.Text;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = Int32.Parse(Price.Text);
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 50).Value = Category.SelectedItem.Text;
                cmd.Parameters.Add("@description", SqlDbType.VarChar, 1000).Value = Description.Text;
                SqlParameter retval = cmd.Parameters.Add("@success", SqlDbType.Int);
                retval.Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                int returnvalue = (int)cmd.Parameters["@success"].Value;

                //Create folder for this listing
                string path = Server.MapPath("/Content/Images/") + Session["userId"];
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Check if listng was created
                if (returnvalue == 0)
                {
                    //Put error code to display message for duplicate listing here
                }
                else
                {
                    path = path + "/" + returnvalue.ToString();
                    Directory.CreateDirectory(path);

                    //Make sure image file names have no spaces

                    //put code in here to to get images from file uploader and upload them to the folder
                    //located at the "path" string and then add them to Images table in database using spAddRemoveImages

                    Response.Redirect(Request.RawUrl);
                }
                con.Close();
            }
        }
    }

}